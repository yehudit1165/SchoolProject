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
}
