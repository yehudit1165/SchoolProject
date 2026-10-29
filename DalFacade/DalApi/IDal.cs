using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IDal
    {
        IAnswer Answer { get; }
        IExam Exam { get; }
        IQuestion Question { get; }
        IStudent Student { get; }
        IStudentQuestion StudentQuestion { get; }
        
    }
}
