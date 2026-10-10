using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record StudentQuestion    /// ישות המייצגת שאלה לנבחן
    (
        int StudentId,   ///מזהה תלמיד
        int ExamId,     ///מזהה בחינה
        int QuestionId,   ///מזהה שאלה
        int? SelectedAnswerId    /// Nullable   מזהה תשובה שנבחרה
    )
    {
        public StudentQuestion() : this(0, 0, 0, null) { }  /// בנאי ריק
    }
}
