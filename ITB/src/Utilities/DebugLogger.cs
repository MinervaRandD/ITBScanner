using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Utilities
{
    public class DebugLogger
    {
        public string debugLogFilePath = null;

        public object lockObject = new object();

        public DebugLogger(String debugLogFilePathParm)
        {
            debugLogFilePath = debugLogFilePathParm;
        }

        public void logMessage(string msg)
        {
            if (string.IsNullOrEmpty(debugLogFilePath))
            {
                return;
            }

            lock (lockObject)
            {
                FileStream fs = new FileStream(debugLogFilePath, FileMode.Append);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(msg);

                sw.Flush();

                sw.Close();
            }
        }

        public void logMessage(string loc, string msg)
        {
            if (string.IsNullOrEmpty(debugLogFilePath))
            {
                return;
            }

            lock (lockObject)
            {
                FileStream fs = new FileStream(debugLogFilePath, FileMode.Append);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine("[" + loc + "] " + msg);

                sw.Flush();

                sw.Close();
            }
        }


    }
}
