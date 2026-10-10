using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Answer    /// ישות המייצגת תשובה לשאלה
    (
       int Id,   ///מספר מזהה ייחודי
       int QuestionId,   ///מזהה שאלה
       string Text    ///תוכן התשובה
    )
    {
        public Answer() : this(0, 0, string.Empty) { }   /// בנאי ריק
    }
}
