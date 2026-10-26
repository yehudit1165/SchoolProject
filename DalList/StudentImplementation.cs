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
}
