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
}
