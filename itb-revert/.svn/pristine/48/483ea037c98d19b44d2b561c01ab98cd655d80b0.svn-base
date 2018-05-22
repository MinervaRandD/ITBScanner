using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace ITBCab.Versioning
{
    public class ITB
    {
        private static string Revision = "";

        private FileInfo appexe;
        private bool bShortVersion;

        public ITB(FileInfo AppExe)
        {
            appexe = AppExe;
        }

        public ITB(FileInfo AppExe, bool ShortVersion)
        {
            appexe = AppExe;
            bool bShortVersion = ShortVersion;
        }

        public string GetVersion(Common.Apps App)
        {
            FileVersionInfo Ver = FileVersionInfo.GetVersionInfo(appexe.FullName);
            string ReturnVer = "";

            if (Ver.FileVersion == null)
            {
                Assembly AsmInfo = Assembly.LoadFile(appexe.FullName);

                switch (App)
                {
                    case Common.Apps.Itb:
                        //if (bShortVersion)
                        //{

                        //    ReturnVer = GetShortVersion(AsmInfo.GetName().Version.ToString());
                        //}
                        //else
                        //{
                        //    ReturnVer = ComputeVersion(AsmInfo.GetName().Version.ToString());
                        //}                        
                        //break;
                    case Common.Apps.NetTest:                        
                    case Common.Apps.AsiUpdater:
                        ReturnVer = AsmInfo.GetName().Version.ToString();
                        break;
                }                
            }
            else
            {
                switch (App)
                {
                    case Common.Apps.Itb:
                        //if (bShortVersion)
                        //{
                        //    ReturnVer = GetShortVersion(Ver.FileVersion);
                        //}
                        //else
                        //{
                        //    ReturnVer = ComputeVersion(Ver.FileVersion);
                        //}
                        //break;
                    case Common.Apps.NetTest:
                    case Common.Apps.AsiUpdater:
                        ReturnVer = Ver.FileVersion;
                        break;
                }                
            }
            return ReturnVer;
        }

        private string GetShortVersion(string Ver)
        {
            string result = "";

            try
            {
                string[] VerParts = Ver.Split('.');
                result = VerParts[0] + "." + VerParts[1] + "." + GetRevision();
            }
            catch
            {
                throw new ApplicationException("Cannot detect version!");          
            }

            return result;
        }


        private string ComputeVersion(string FileVersion)
        {
            string[] VerParts = FileVersion.Split('.');

            int DaysSince2k = int.Parse(VerParts[2]);
            int SecSinceMidnight = int.Parse(VerParts[3]) * 2;
            int MyVersionBuild = (DaysSince2k << 12) | (SecSinceMidnight / 22);

            return VerParts[0] + "." + VerParts[1] + "." + GetRevision() + "." + MyVersionBuild.ToString();
        }

        private string GetRevision()
        {
            while (Revision == "")
            {
                Console.WriteLine("Please enter ITB's revision number: ");
                try
                {
                    Revision = int.Parse(Console.ReadLine()).ToString();
                }
                catch
                {
                    Revision = "";
                }                
            }
            return Revision;
        }
    }
}