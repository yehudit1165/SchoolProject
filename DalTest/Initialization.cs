using DalApi;
using DO;

namespace DalTest;
public static class Initialization
{
    private static IDal s_dal=null!;
    public static void Initialize(IDal dal)
    {
        s_dal = dal;

        createExams();
        createStudents();
        createQuestions();
        createAnswers();
        createStudentQuestions();
    }
    private static void createExams()
    {
        s_dal.Exam.Create(new Exam(0, Subject.Math, DateTime.Now.AddDays(5), 2));
        s_dal.Exam.Create(new Exam(0, Subject.CSharp, DateTime.Now.AddDays(10), 1));
    }
    private static void createStudents()
    {
        s_dal.Student.Create(new Student(111111111, "David", 1, null));
        s_dal.Student.Create(new Student(222222222, "Moshe", 2, 95));
    }
    private static void createQuestions()
    {
        s_dal.Question.Create(new Question(0, Subject.Math, "4", 1));
        s_dal.Question.Create(new Question(0, Subject.Math, "10", 1));
        s_dal.Question.Create(new Question(0, Subject.CSharp, "int", 2));
    }
    private static void createAnswers()
    {
        s_dal.Answer.Create(new Answer(0, 1, "4"));
        s_dal.Answer.Create(new Answer(0, 1, "5"));

        s_dal.Answer.Create(new Answer(0, 2, "10"));
        s_dal.Answer.Create(new Answer(0, 2, "12"));

        s_dal.Answer.Create(new Answer(0, 3, "int"));
        s_dal.Answer.Create(new Answer(0, 3, "string"));
    }
    private static void createStudentQuestions()
    {
        s_dal.StudentQuestion.Create(new StudentQuestion(0, 111111111, 1, 1, 1));
        s_dal.StudentQuestion.Create(new StudentQuestion(0, 111111111, 1, 2, 3));
        s_dal.StudentQuestion.Create(new StudentQuestion(0, 222222222, 2, 3, 5));
    }
}
