using System;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Dal
{
    public static class SyncLogManager
    {
        public static bool syncErrorsHaveOccured = false;

        public static bool syncErrorLoggingEnabled = false;

        private static object syncObject = new object();

        public static void init(bool syncErrorLoggingEnabledParm)
        {
            syncErrorsHaveOccured = false;
            syncErrorLoggingEnabled = syncErrorLoggingEnabledParm;

            string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\ItbSyncLog.txt";

            if (File.Exists(logFilePath))
            {
                FileInfo fi = new FileInfo(logFilePath);

                if (fi.Length > 4 * 1024 * 1024)
                {
                    File.Delete(logFilePath);
                }
            }
        }

        public static void logSyncError(string src, string msg, Exception ex)
        {
            if (!syncErrorLoggingEnabled)
            {
                return;
            }

            lock (syncObject)
            {
                syncErrorsHaveOccured = true;

                string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\ItbSyncLog.txt";

                FileStream fs = new FileStream(logFilePath, FileMode.Append);

                StreamWriter sr = new StreamWriter(fs);

                string timeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

                sr.WriteLine("[" + src + ": " + timeStamp + "] " + msg + "\n");
                sr.WriteLine("[" + src + ": " + timeStamp + "] Exception: " + ex.Message + "\n");
                sr.WriteLine("[" + src + ": " + timeStamp + "] Stack Trace: " + ex.StackTrace + "\n\n");

                sr.Flush();
                sr.Close();
            }
        }
    }
}
