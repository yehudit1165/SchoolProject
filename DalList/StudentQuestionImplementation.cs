using DalApi;
using DO;
using System.Reflection;
using Tools;
namespace Dal;

internal class StudentQuestionImplementation: IStudentQuestion
{
    public int Create(StudentQuestion item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Create");
        int id = DataSource.Config.NextStudentQuestionId;
        StudentQuestion newItem = item with { Id = id };
        DataSource.StudentQuestions.Add(newItem);
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending Create");
        return id;
    }
    public StudentQuestion? Read(int id)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Read");

        foreach (StudentQuestion? studentQuestion in DataSource.StudentQuestions)
        {
            if (studentQuestion != null && studentQuestion.Id == id)
            {
                LogManager.WriteToLog(
                     method.DeclaringType!.FullName!,
                     method.Name,
                "Ending Read");
                return studentQuestion;
            }
        }
        LogManager.WriteToLog(
                method.DeclaringType!.FullName!,
                method.Name,
                "Ending Read");
        return null;
    }
    public List<StudentQuestion> ReadAll()
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting ReadAll");
        List<StudentQuestion> studentQuestions = new List<StudentQuestion>();
        foreach (StudentQuestion? studentQuestion in DataSource.StudentQuestions)
        {
            if (studentQuestion != null)
            {
                studentQuestions.Add(studentQuestion);
            }
        }
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending ReadAll");
        return studentQuestions;
    }

    public void Update(StudentQuestion item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Update");
        int index = DataSource.StudentQuestions.FindIndex(
            studentQuestion => studentQuestion != null && studentQuestion.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("StudentQuestion with this ID does not exist");
        }
        DataSource.StudentQuestions.RemoveAt(index);
        DataSource.StudentQuestions.Add(item);
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending Update");
    }
    public void Delete(int id)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Delete");
        int index = DataSource.StudentQuestions.FindIndex(
            studentQuestion => studentQuestion != null && studentQuestion.Id == id);
        if (index == -1)
        {
            throw new MyException("StudentQuestion with this ID does not exist");
        }
        DataSource.StudentQuestions.RemoveAt(index);
        LogManager.WriteToLog(
       method.DeclaringType!.FullName!,
       method.Name,
       "Ending Delete");
    }

}
