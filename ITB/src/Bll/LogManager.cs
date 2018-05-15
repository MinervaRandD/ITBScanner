using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Asi.Itb.Bll
{
    public static class LogManager
    {

        public static void DebugWriteLine(string msg, string src)
        {
            if (Configuration.Instance.DebugLogging != true)
            {
                return;
            }

            string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\ItbDbgLog.txt";

            FileStream fs = new FileStream(logFilePath, FileMode.Append);

            StreamWriter sr = new StreamWriter(fs);

            sr.WriteLine("[" + src + ": " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + "] " + msg);

            sr.Flush();
            sr.Close();
        }
    }
}
