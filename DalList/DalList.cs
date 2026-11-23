using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalList : IDal
    {
        private static readonly DalList instance = new DalList();
        public static DalList Instance
        {
            get { return instance; }
        }
        private DalList() { }

        public IAnswer Answer => new AnswerImplementation();

        public DalApi.IExam Exam => new ExamImplementation();

        public IQuestion Question => new QuestionImplementation();

        public IStudent Student => new StudentImplementation();

        public IStudentQuestion StudentQuestion => new StudentQuestionImplementation();

 
    }
}
