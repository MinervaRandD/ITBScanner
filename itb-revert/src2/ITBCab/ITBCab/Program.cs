using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

//////////////////////////////////////////////////////
// TODO: Make unified CABBuilder for all applications
//////////////////////////////////////////////////////

namespace ITBCab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ITBCab {0} started.", Common.GetVersion().ToString());            
            Properties.Settings.Default.Upgrade();
                        
            if (!InitDirs())
            {
                return;
            }

            RunAutoUpdate();
            CabBuilder cb = new CabBuilder();
            cb.BuildMainCABs();
            cb.BuildNetTestCABs();
            cb.BuildAsiUpdaterCABs();
            cb.BuildDistributionCABs();

            Console.WriteLine("CAB Build Complete");
        }
        
        private static bool InitDirs()
        {
            try
            {
                Common.InputPath = new DirectoryInfo(Properties.Settings.Default.InputPath);                
                Common.CABPath = new DirectoryInfo(Properties.Settings.Default.CABPath);
                Common.CabWizPath = new DirectoryInfo(Properties.Settings.Default.CabWizPath);
                Common.TempPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Temp";
                Common.ErrorLogPath = Common.TempPath + @"\ErrorLogs";
            }
            catch
            {
                return false;
            }

            if (!Directory.Exists(Common.InputPath.FullName) && !Directory.Exists(Common.CabWizPath.FullName))
            {
                return false;
            }
            if (!Directory.Exists(Common.CABPath.FullName))
            {
                Directory.CreateDirectory(Common.CABPath.FullName);
            }
            if (!Directory.Exists(Common.TempPath))
            {
                Directory.CreateDirectory(Common.TempPath);
            }
            if (!Directory.Exists(Common.ErrorLogPath))
            {
                Directory.CreateDirectory(Common.ErrorLogPath);
            }

            return true;
        }

        private static void RunAutoUpdate()
        {
            AutoUpdate.Reader reader = new AutoUpdate.Reader(Common.InputPath);            
            reader.ParseXML();                        
        }        
    }
}
