using System.Diagnostics;
using System.IO;

namespace MusicRecognitionProject.Utils
{
    public static class Logger
    {
        private static readonly object _locker = new object();

        public static void LogInfo(object message)
        {
            var loggerDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logger");
            if (!Directory.Exists(loggerDirectory))
            {
                Directory.CreateDirectory(loggerDirectory);
            }

            var logFile = Path.Combine(loggerDirectory, "log.txt");
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Close();
            }

            lock (_locker)
            {
                using (StreamWriter writer = new StreamWriter(File.Open(logFile, FileMode.Append)))
                {
                    writer.WriteLine($"[{DateTime.Now}\t{Process.GetCurrentProcess().Id}]: {message}");
                }
            }
        }
    }
}
