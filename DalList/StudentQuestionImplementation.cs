using DalApi;
using DO;
namespace Dal;

internal class StudentQuestionImplementation: IStudentQuestion
{
    public int Create(StudentQuestion item)
    {
        int id = DataSource.Config.NextStudentQuestionId;
        StudentQuestion newItem = item with { Id = id };
        DataSource.StudentQuestions.Add(newItem);
        return id;
    }
    public StudentQuestion? Read(int id)
    {
        foreach (StudentQuestion? studentQuestion in DataSource.StudentQuestions)
        {
            if (studentQuestion != null && studentQuestion.Id == id)
            {
                return studentQuestion;
            }
        }
        return null;
    }
    public List<StudentQuestion> ReadAll()
    {
        List<StudentQuestion> studentQuestions = new List<StudentQuestion>();
        foreach (StudentQuestion? studentQuestion in DataSource.StudentQuestions)
        {
            if (studentQuestion != null)
            {
                studentQuestions.Add(studentQuestion);
            }
        }
        return studentQuestions;
    }

    public void Update(StudentQuestion item)
    {
        int index = DataSource.StudentQuestions.FindIndex(
            studentQuestion => studentQuestion != null && studentQuestion.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("StudentQuestion with this ID does not exist");
        }
        DataSource.StudentQuestions.RemoveAt(index);
        DataSource.StudentQuestions.Add(item);
    }
    public void Delete(int id)
    {
        int index = DataSource.StudentQuestions.FindIndex(
            studentQuestion => studentQuestion != null && studentQuestion.Id == id);
        if (index == -1)
        {
            throw new MyException("StudentQuestion with this ID does not exist");
        }
        DataSource.StudentQuestions.RemoveAt(index);
    }

}
