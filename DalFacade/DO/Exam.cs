using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Exam   /// ישות המייצגת מבחן במערכת
    (
        int Id,  ///מספר מזהה ייחודי
        Subject Subject,   ///נושא המבחן
        DateTime ExamDate,    ///תאריך הבחינה
        int QuestionsCount    ///מספר השאלות במבחן
    )
    {
        public Exam() : this(0, default, DateTime.MinValue, 0) { } /// בנאי ריק
    }
}
