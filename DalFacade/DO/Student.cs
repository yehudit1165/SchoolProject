using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Student    /// ישות המייצגת תלמיד נבחן
    (
        int Id,  ///תעודת זהות
        string Name,   ///שם התלמיד
        int ExamId,    ///מזהה בחינה
        int? Grade    ///Nullable  ציון
    )
    {
        public Student() : this(0, string.Empty, 0,null) { }  /// בנאי ריק
    }
}
