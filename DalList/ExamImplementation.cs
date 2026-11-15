using DalApi;
using DO;
using System.Reflection;
using Tools;
namespace Dal;

internal class ExamImplementation : DalApi.IExam
{
    public int Create(Exam item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Create");
        int id = DataSource.Config.NextExamId;
        Exam newItem = item with { Id = id };
        DataSource.Exams.Add(newItem);
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending Create");
        return id;
    }
    public Exam? Read(int id)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Read");

        foreach (Exam? exam in DataSource.Exams)
        {
            if (exam != null && exam.Id == id)
            {
                LogManager.WriteToLog(
                method.DeclaringType!.FullName!,
                method.Name,
                "Ending Read");
                return exam;
            }
        }
        LogManager.WriteToLog(
                method.DeclaringType!.FullName!,
                method.Name,
                "Ending Read");
        return null;
    }
    public List<Exam> ReadAll()
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting ReadAll");
        List<Exam> exams = new List<Exam>();
        foreach (Exam? exam in DataSource.Exams)
        {
            if (exam != null)
            {
                exams.Add(exam);
            }
        }
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending ReadAll");
        return exams;
    }
    public void Update(Exam item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Update");
        int index = DataSource.Exams.FindIndex(
            exam => exam != null && exam.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("Exam with this ID does not exist");
        }
        DataSource.Exams.RemoveAt(index);
        DataSource.Exams.Add(item);
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
        int index = DataSource.Exams.FindIndex(
            exam => exam != null && exam.Id == id);
        if (index == -1)
        {
            throw new MyException("Exam with this ID does not exist");
        }
        DataSource.Exams.RemoveAt(index);
        LogManager.WriteToLog(
       method.DeclaringType!.FullName!,
       method.Name,
       "Ending Delete");
    }

}
