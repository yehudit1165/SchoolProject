using DalApi;
using DO;
namespace Dal;

internal class QuestionImplementation : IQuestion
{
    public int Create(Question item)
    {
        int id = DataSource.Config.NextQuestionId;
        Question newItem = item with { Id = id };
        DataSource.Questions.Add(newItem);
        return id;
    }
    public Question? Read(int id)
    {
        foreach (Question? question in DataSource.Questions)
        {
            if (question != null && question.Id == id)
            {
                return question;
            }
        }
        return null;
    }
    public List<Question> ReadAll()
    {
        List<Question> questions = new List<Question>();
        foreach (Question? question in DataSource.Questions)
        {
            if (question != null)
            {
                questions.Add(question);
            }
        }
        return questions;
    }

    public void Update(Question item)
    {
        int index = DataSource.Questions.FindIndex(
            question => question != null && question.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("Question with this ID does not exist");
        }
        DataSource.Questions.RemoveAt(index);
        DataSource.Questions.Add(item);
    }
    public void Delete(int id)
    {
        int index = DataSource.Questions.FindIndex(
            question => question != null && question.Id == id);
        if (index == -1)
        {
            throw new MyException("Question with this ID does not exist");
        }
        DataSource.Questions.RemoveAt(index);
    }

}
