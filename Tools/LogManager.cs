namespace Tools
{
    public static class LogManager
    {
        private const string s_logFolder = "Log";
        private static string GetCurrentFolderPath()
        {
            return Path.Combine(s_logFolder, DateTime.Now.ToString("yyyy-MM"));
        }
        private static string GetCurrentFilePath()
        {
            DateTime now = DateTime.Now;

            return Path.Combine(
                s_logFolder,
                now.ToString("yyyy-MM"),
                now.ToString("dd") + ".txt");
        }
        public static void WriteToLog(string projectName, string funcName, string message)
        {
            string folderPath = GetCurrentFolderPath();
            string filePath = GetCurrentFilePath();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            string logMessage =
                $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}\t{projectName}.{funcName}:\t{message}";

            File.AppendAllText(filePath, logMessage + Environment.NewLine);
        }
        public static void CleanLogFolder()
        {
            if (!Directory.Exists(s_logFolder))
            {
                return;
            }

            DateTime currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime keepFrom = currentMonth.AddMonths(-1);

            string[] folders = Directory.GetDirectories(s_logFolder);

            foreach (string folder in folders)
            {
                string folderName = Path.GetFileName(folder);

                if (DateTime.TryParseExact(
                    folderName,
                    "yyyy-MM",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime folderDate))
                {
                    if (folderDate < keepFrom)
                    {
                        Directory.Delete(folder, true);
                    }
                }
            }
        }
    }
}
