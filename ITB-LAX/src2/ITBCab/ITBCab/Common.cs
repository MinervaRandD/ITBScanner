using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace ITBCab
{
    public class Common
    {
        public enum Apps
        {
            [Description("Itb.Exe")]
            Itb = 1,

            [Description("ASINetTest.Exe")]
            NetTest,

            [Description("AsiUpdater.Exe")]
            AsiUpdater
        }

        public const string Distro = "Distribution";
        public const string CabWizApp = "CabWiz.exe";
        public const string bs = @"\";
        
        public static string TempPath;
        public static string ErrorLogPath;        

        public static DirectoryInfo InputPath;        
        public static DirectoryInfo CABPath;
        public static DirectoryInfo CabWizPath;        
        
        public static Version GetVersion()
        {
            Assembly AssemblyInfo = Assembly.GetExecutingAssembly();
            Version Ver = AssemblyInfo.GetName().Version;
            return Ver;
        }

        public static void RunProcess(string filename, string argu)
        {
            DirectoryInfo di = new DirectoryInfo(filename);
            
            Process process = new Process();
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = di.FullName;
            process.StartInfo.Arguments = argu;
            process.Start();
            process.WaitForExit();
            process.Dispose();
        }

        public static string GetEnumDesc(Enum EnumValue)
        {
            FieldInfo fi = EnumValue.GetType().GetField(EnumValue.ToString());
            DescriptionAttribute[] Attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (Attributes != null && Attributes.Length > 0)
            {
                return Attributes[0].Description;
            }
            else
            {
                return EnumValue.ToString();
            }
        }

        public static void DisplayError(string message)
        {
            MessageBox.Show(message, "ERROR!!!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
