using DalApi;
using DO;
using static DalApi.ICrud;
using static System.Net.Mime.MediaTypeNames;

namespace DalTest
{
    internal class Program
    {
        static IDal s_dal = new Dal.DalList();
        static void Main(string[] args)
        {
            Initialization.Initialize(s_dal);
            string selection = "start";

            while (selection != "0")
            {
                PrintMainMenu();
                selection = Console.ReadLine()!;

                switch (selection)
                {
                    case "1":
                        SubMenu<Student>("student", s_dal.Student, GetStudent);
                        break;

                    case "2":
                        SubMenu<Question>("question", s_dal.Question, GetQuestion);
                        break;

                    case "3":
                        SubMenu<Answer>("answer", s_dal.Answer, GetAnswer);
                        break;

                    case "4":
                        SubMenu<StudentQuestion>("question for student", s_dal.StudentQuestion, GetQuestionForStudent);
                        break;

                    case "5":
                        SubMenu<Exam>("test", s_dal.Exam, GetTest);
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Wrong input, please enter again");
                        break;
                }
            }
        }
        private static void PrintMainMenu()
        {
            Console.WriteLine("Choose an entity:");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Question");
            Console.WriteLine("3. Answer");
            Console.WriteLine("4. QuestionForStudent");
            Console.WriteLine("5. Test");
            Console.WriteLine("0. Exit");
        }
        private static void PrintSecondMenu(string name)
        {
            Console.WriteLine($"Choose an action for {name}:");
            Console.WriteLine("1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Read All");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("0. Back");
        }
        private static void SubMenu<T>(string name, ICrud<T> crud, Func<bool, T> getParams)
        {
            int choice;
            do
            {
                PrintSecondMenu(name);
                choice = GetIntInput("Enter your choice:");
                try
                {
                    switch (choice)
                    {
                        case 1:
                            crud.Create(getParams(false));
                            break;

                        case 2:
                            int id = GetIntInput("Enter ID:");
                            Console.WriteLine(crud.Read(id));
                            break;

                        case 3:
                            foreach (T item in crud.ReadAll())
                            {
                                Console.WriteLine(item);
                            }
                            break;

                        case 4:
                            crud.Update(getParams(true));
                            break;

                        case 5:
                            id = GetIntInput("Enter ID:");
                            crud.Delete(id);
                            break;

                        case 0:
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (choice != 0);
        }
        private static Student GetStudent(bool isUpdate)
        {
            int id = GetIntInput(isUpdate ? "Enter student ID to update:" : "Enter student ID:");

            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine()!;

            int examId = GetIntInput("Enter exam ID:");
            Console.WriteLine("Enter student grade (or press Enter for no grade):");
            string? input = Console.ReadLine();

            int? grade = string.IsNullOrWhiteSpace(input)
                ? null
                : int.Parse(input);

            return new Student(id, name, examId, grade);
        }
        private static Question GetQuestion(bool isUpdate)
        {
            int id = isUpdate ? GetIntInput("Enter question ID to update:") : 0;

            Subject questionText;

            while (true)
            {
                Console.WriteLine("Enter question subject (Math, English, CSharp, History):");

                if (Enum.TryParse(Console.ReadLine(), out questionText) &&
                    Enum.IsDefined(questionText))
                    break;

                Console.WriteLine("Invalid subject, try again.");
            }

            Console.WriteLine("Enter correct answer:");
            string correctAnswer = Console.ReadLine()!;

            int examId = GetIntInput("Enter exam ID:");

            return new Question(id, questionText, correctAnswer, examId);
        }
        private static Answer GetAnswer(bool isUpdate)
        {
            int id = isUpdate ? GetIntInput("Enter answer ID to update:") : 0;

            int questionId = GetIntInput("Enter question ID:");

            Console.WriteLine("Enter answer text:");
            string text = Console.ReadLine()!;

            return new Answer(id, questionId, text);
        }
        private static StudentQuestion GetQuestionForStudent(bool isUpdate)
        {
            int id = isUpdate ? GetIntInput("Enter ID:") : 0;

            int studentId = GetIntInput("Enter student ID:");
            int examId = GetIntInput("Enter exam ID:");
            int questionId = GetIntInput("Enter question ID:");
            Console.WriteLine("Enter selected answer ID (or press Enter for no answer):");
            string? input = Console.ReadLine();

            int? selectedAnswerId = string.IsNullOrWhiteSpace(input)
                ? null
                : int.Parse(input);

            return new StudentQuestion(id, studentId, examId, questionId, selectedAnswerId);
        }
        private static Exam GetTest(bool isUpdate)
        {
            int id = isUpdate ? GetIntInput("Enter test ID to update:") : 0;

            Subject subject;

            while (true)
            {
                Console.WriteLine("Enter test subject (Math, English, CSharp, History):");

                if (Enum.TryParse(Console.ReadLine(), out subject) &&
                    Enum.IsDefined(subject))
                    break;

                Console.WriteLine("Invalid subject, try again.");
            }

            DateTime examDate;

            while (true)
            {
                Console.WriteLine("Enter test date:");

                if (DateTime.TryParse(Console.ReadLine(), out examDate))
                    break;

                Console.WriteLine("Invalid date, try again.");
            }

            int questionsCount = GetIntInput("Enter number of questions:");

            return new Exam(id, subject, examDate, questionsCount);
        }
        private static int GetIntInput(string text)
        {
            Console.WriteLine(text);
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine()!);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }
    }
}
