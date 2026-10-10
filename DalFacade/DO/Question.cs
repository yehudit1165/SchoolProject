using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Question    ////// ישות המייצגת שאלה
    (
        int Id,  ///מספר מזהה ייחודי
        Subject QuestionText,   ///נושא השאלה
        string CorrectAnswer,    ///תוכן השאלה
        int ExamId    ///מזהה תשובה נכונה
    )
    {
        public Question() : this(0, default, string.Empty, 0) { } /// בנאי ריק
    }
}
