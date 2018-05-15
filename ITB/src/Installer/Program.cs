using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Installer
{
    class Program
    {
        private static List<string> overwriteFileList = new List<string>();
        private static List<string> conditionalFileList = new List<string>();

        static void Main(string[] args)
        {

            string baseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            System.Windows.Forms.MessageBox.Show("Starting installation.");
            
            string itbCabFilePath = Path.Combine(baseDir, @"ItbCab.cab");
            
            try
            {
                

                System.Diagnostics.Process process = new System.Diagnostics.Process();

                process.StartInfo.FileName = itbCabFilePath;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.WaitForExit();
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Attempt to launch cab installer at " + itbCabFilePath + " failed: " + ex.Message);

                return;
            }

            if (!File.Exists(@"\Program Files\InterBag\itb.sdf"))
            {
                File.Copy(Path.Combine(baseDir, @"itb.sdf"), @"\Program Files\InterBag\itb.sdf");
            }

            System.Windows.Forms.MessageBox.Show("Setup completed.");
            Console.WriteLine("Setup complete.");
            Console.ReadLine();
        }
    }
}
