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
    public void Update(Answer item)
    {
        int index = DataSource.Answers.FindIndex(
            answer => answer != null && answer.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("Answer whis this ID does not exist");
        }
        DataSource.Answers.RemoveAt(index);
        DataSource.Answers.Add(item);
    }
    public void Delete(int id)
    {
        int index = DataSource.Answers.FindIndex(
            answer => answer != null && answer.Id == id);
        if (index == -1)
        {
            throw new MyException("Answer with this ID does not exist");
        }
        DataSource.Answers.RemoveAt(index);
    }

}
