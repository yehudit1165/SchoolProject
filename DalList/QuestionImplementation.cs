using DalApi;
using DO;
using System.Reflection;
using Tools;
namespace Dal;

internal class QuestionImplementation : IQuestion
{
    public int Create(Question item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Create");
        int id = DataSource.Config.NextQuestionId;
        Question newItem = item with { Id = id };
        DataSource.Questions.Add(newItem);
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending Create");
        return id;
    }
    public Question? Read(int id)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Read");

        foreach (Question? question in DataSource.Questions)
        {
            if (question != null && question.Id == id)
            {
                LogManager.WriteToLog(
                method.DeclaringType!.FullName!,
                method.Name,
                "Ending Read");
                return question;
            }
        }
        LogManager.WriteToLog(
                method.DeclaringType!.FullName!,
                method.Name,
                "Ending Read");
        return null;
    }
    public List<Question> ReadAll()
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting ReadAll");
        List<Question> questions = new List<Question>();
        foreach (Question? question in DataSource.Questions)
        {
            if (question != null)
            {
                questions.Add(question);
            }
        }
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending ReadAll");
        return questions;
    }

    public void Update(Question item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Update");
        int index = DataSource.Questions.FindIndex(
            question => question != null && question.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("Question with this ID does not exist");
        }
        DataSource.Questions.RemoveAt(index);
        DataSource.Questions.Add(item);
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
        int index = DataSource.Questions.FindIndex(
            question => question != null && question.Id == id);
        if (index == -1)
        {
            throw new MyException("Question with this ID does not exist");
        }
        DataSource.Questions.RemoveAt(index);
        LogManager.WriteToLog(
       method.DeclaringType!.FullName!,
       method.Name,
       "Ending Delete");
    }

}
