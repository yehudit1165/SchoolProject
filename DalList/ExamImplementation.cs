using DalApi;
using DO;
namespace Dal;

internal class ExamImplementation : DalApi.IExam
{
    public int Create(Exam item)
    {
        int id = DataSource.Config.NextExamId;
        Exam newItem = item with { Id = id };
        DataSource.Exams.Add(newItem);
        return id;
    }
    public Exam? Read(int id)
    {
        foreach (Exam? exam in DataSource.Exams)
        {
            if (exam != null && exam.Id == id)
            {
                return exam;
            }
        }
        return null;
    }
    public List<Exam> ReadAll()
    {
        List<Exam> exams = new List<Exam>();
        foreach (Exam? exam in DataSource.Exams)
        {
            if (exam != null)
            {
                exams.Add(exam);
            }
        }
        return exams;
    }
    public void Update(Exam item)
    {
        int index = DataSource.Exams.FindIndex(
            exam => exam != null && exam.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("Exam with this ID does not exist");
        }
        DataSource.Exams.RemoveAt(index);
        DataSource.Exams.Add(item);
    }
    public void Delete(int id)
    {
        int index = DataSource.Exams.FindIndex(
            exam => exam != null && exam.Id == id);
        if (index == -1)
        {
            throw new MyException("Exam with this ID does not exist");
        }
        DataSource.Exams.RemoveAt(index);
    }

}
