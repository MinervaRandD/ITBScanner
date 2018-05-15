using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Reflection;

namespace AsiUpdater
{
    public class Log
    {
        private const string UpgradeLog = "Upgrade.txt";
        private const string ConnectionLog = "Connection.txt";

        private static Log _instance;

        public static Log Instance
        {
            get
            {
                if (_instance == null)
                {
                    GetAppPath();
                }
                return _instance;
            }
        }
       
        public void WriteUpgradeLog(string message)
        {
            WriteLog(AppPath + @"\" + UpgradeLog, message);
        }

        public void WriteConnectionLog(string message)
        {
            WriteLog(AppPath + @"\" + ConnectionLog, message);
        }

        private void WriteLog(string filename, string message)
        {
            /////////////////////////////////////////////////////////////////
            //if (File.Exists(filename))
            //{
            //    FileInfo fi = new FileInfo(filename);
            //    if (fi.Length > 100000)
            //    {
            //        string[] fns = Directory.GetFiles(fi.DirectoryName, Path.GetFileNameWithoutExtension(fi.FullName) + "");
                    
            //        // Order by size.
            //        var sort = from fn in fns                               
            //                   orderby new FileInfo(fn).Extension descending
            //                   select fn;

            //        string n = sort.Max();
                    
            //    }
            //}
            //////////////////////////////////////////////////////////////////

            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                if (fi.Length > 1000000)
                {
                    OpenNETCF.IO.FileHelper.SetAttributes(filename, FileAttributes.Normal);
                    File.Delete(filename);
                }
            }

            StreamWriter sw = new StreamWriter(filename, true);
            sw.WriteLine("[" + DateTime.Now.ToString() + "] - " + message);
            sw.Close();
            sw.Dispose();
        }
                
        private static void GetAppPath()
        {
            _instance = new Log();
            _instance.AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        private string AppPath
        {
            get;
            set;
        }
    }
}
