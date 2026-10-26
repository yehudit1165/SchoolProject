using DalApi;
using DO;
namespace Dal;

internal class AnswerImplementation : IAnswer
{
    public int Create(Answer item)
    {
        int id = DataSource.Config.NextAnswerId;
        Answer newItem = item with { Id = id };
        DataSource.Answers.Add(newItem);
        return id;
    }
    public Answer? Read(int id)
    {
        foreach (Answer? answer in DataSource.Answers)
        {
            if (answer != null && answer.Id == id)
            {
                return answer;
            }
        }
        return null;
    }
    public List<Answer> ReadAll()
    {
        List<Answer> answers = new List<Answer>();
        foreach (Answer? answer in DataSource.Answers)
        {
            if (answer != null)
            {
                answers.Add(answer);
            }
        }
        return answers;
    }
}
