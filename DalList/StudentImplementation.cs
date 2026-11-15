using DalApi;
using DO;
using Tools;
using System.Reflection;

namespace Dal;

internal class StudentImplementation : IStudent
{
    public int Create(Student item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Create");
        foreach (Student? student in DataSource.Students)
        {
            if (student != null && student.Id == item.Id)
            {
                throw new MyException("Student already exists");
            }
        }
        DataSource.Students.Add(item);
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending Create");
        return item.Id;
    }
    public Student? Read(int id)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Read");
        foreach (Student? student in DataSource.Students)
        {
            if (student != null && student.Id == id)
            {
                LogManager.WriteToLog(
                method.DeclaringType!.FullName!,
                method.Name,
                "Ending Read");
                return student;
            }
        }
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending Read");
        return null;
    }
    public List<Student> ReadAll()
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting ReadAll");
        List<Student> students = new List<Student>();
        foreach (Student? student in DataSource.Students)
        {
            if (student != null)
            {
                students.Add(student);
            }
        }
        LogManager.WriteToLog(
       method.DeclaringType!.FullName!,
       method.Name,
       "Ending ReadAll");
        return students;
    }

    public void Update(Student item)
    {
        MethodBase method = MethodBase.GetCurrentMethod()!;
        LogManager.WriteToLog(
            method.DeclaringType!.FullName!,
            method.Name,
            "Starting Update");
        int index = DataSource.Students.FindIndex(
            student => student != null && student.Id == item.Id);
        if (index == -1)
        {
            throw new MyException("Student with this ID does not exist");
        }
        DataSource.Students.RemoveAt(index);
        DataSource.Students.Add(item);
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
        int index = DataSource.Students.FindIndex(
            student => student != null && student.Id == id);

        if (index == -1)
            throw new MyException("Student with this ID does not exist");

        DataSource.Students.RemoveAt(index);
        LogManager.WriteToLog(
        method.DeclaringType!.FullName!,
        method.Name,
        "Ending Delete");
    }

}
