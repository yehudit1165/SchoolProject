using DalApi;
using DO;
using System.Reflection;
using Tools;
namespace Dal;

internal class AnswerImplementation : IAnswer
{
    public int Create(Answer item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Create");
        int id = DataSource.Config.NextAnswerId;
        Answer newItem = item with { Id = id };
        DataSource.Answers.Add(newItem);
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending Create");
        return id;
    }
    public Answer? Read(int id)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Read");

        foreach (Answer? answer in DataSource.Answers)
        {
            if (answer != null && answer.Id == id)
            {
                LogManager.WriteToLog(
                method.DeclaringType!.FullName!,
                method.Name,
                "Ending Read");
                return answer;
            }
        }
        LogManager.WriteToLog(
                method.DeclaringType!.FullName!,
                method.Name,
                "Ending Read");
        return null;
    }
    public List<Answer> ReadAll()
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting ReadAll");
        List<Answer> answers = new List<Answer>();
        foreach (Answer? answer in DataSource.Answers)
        {
            if (answer != null)
            {
                answers.Add(answer);
            }
        }
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending ReadAll");
        return answers;
    }
    public void Update(Answer item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Update");
        int index = DataSource.Answers.FindIndex(
            answer => answer != null && answer.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("Answer whis this ID does not exist");
        }
        DataSource.Answers.RemoveAt(index);
        DataSource.Answers.Add(item);
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
        int index = DataSource.Answers.FindIndex(
            answer => answer != null && answer.Id == id);
        if (index == -1)
        {
            throw new MyException("Answer with this ID does not exist");
        }
        DataSource.Answers.RemoveAt(index);
        LogManager.WriteToLog(
       method.DeclaringType!.FullName!,
       method.Name,
       "Ending Delete");
    }

}
