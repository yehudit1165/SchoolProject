namespace Dal
{
    internal static class DataSource
    {
        // רשימות הנתונים של כל הישויות
        internal static System.Collections.Generic.List<DO.Answer?> Answers = new();
        internal static System.Collections.Generic.List<DO.Exam?> Exams = new();
        internal static System.Collections.Generic.List<DO.Question?> Questions = new();
        internal static System.Collections.Generic.List<DO.Student?> Students = new();
        internal static System.Collections.Generic.List<DO.StudentQuestion?> StudentQuestions = new();

        // מחלקת קונפיגורציה למספרים רצים
        internal static class Config
        {
            internal const int AnswerIdStart = 1;
            private static int currentAnswerId = AnswerIdStart;
            internal static int NextAnswerId => currentAnswerId++;

            internal const int ExamIdStart = 1;
            private static int currentExamId = ExamIdStart;
            internal static int NextExamId => currentExamId++;

            internal const int QuestionIdStart = 1;
            private static int currentQuestionId = QuestionIdStart;
            internal static int NextQuestionId => currentQuestionId++;
        }
    }
}
