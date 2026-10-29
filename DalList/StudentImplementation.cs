using DalApi;
using DO;
namespace Dal;

internal class StudentImplementation : IStudent
{
    public int Create(Student item)
    {
        foreach (Student? student in DataSource.Students)
        {
            if (student != null && student.Id == item.Id)
            {
                throw new MyException("Student already exists");
            }
        }
        DataSource.Students.Add(item);
        return item.Id;
    }
    public Student? Read(int id)
    {
        foreach (Student? student in DataSource.Students)
        {
            if (student != null && student.Id == id)
            {
                return student;
            }
        }
        return null;
    }
    public List<Student> ReadAll()
    {
        List<Student> students = new List<Student>();
        foreach (Student? student in DataSource.Students)
        {
            if (student != null)
            {
                students.Add(student);
            }
        }
        return students;
    }

    public void Update(Student item)
    {
        int index = DataSource.Students.FindIndex(
            student => student != null && student.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("Student with this ID does not exist");
        }
        DataSource.Students.RemoveAt(index);
        DataSource.Students.Add(item);
    }
    public void Delete(int id)
    {
        int index = DataSource.Students.FindIndex(
            student => student != null && student.Id == id);

        if (index == -1)
            throw new MyException("Student with this ID does not exist");

        DataSource.Students.RemoveAt(index);
    }

}
