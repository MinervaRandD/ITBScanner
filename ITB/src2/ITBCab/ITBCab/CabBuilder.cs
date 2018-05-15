using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITBCab
{
    public class CabBuilder
    {
        public void BuildMainCABs()
        {
            Console.WriteLine("Building {0} CABs...", Common.Apps.Itb.ToString());

            // TODO: for now, input and cab dir is the same. not by device, os, processor
            string DirPath = Common.CABPath + @"\" + Common.Apps.Itb.ToString();
            DirectoryInfo CurCABDir = new DirectoryInfo(DirPath);
            DirectoryInfo CurInputDir = Common.InputPath;
            
            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            BuildAppCAB(Common.Apps.Itb, Platforms.All.Processors.ARMV4, Platforms.All.Devices.SymbolMC_InternalFlash, CurInputDir, CurCABDir);
        }

        public void BuildNetTestCABs()
        {
            Console.WriteLine("Building {0} CABs...", Common.Apps.NetTest.ToString());

            // TODO: for now, input and cab dir is the same. not by device, os, processor            
            string DirPath = Common.CABPath + @"\" + Common.Apps.NetTest.ToString();
            DirectoryInfo CurCABDir = new DirectoryInfo(DirPath);
            DirectoryInfo CurInputDir = Common.InputPath;
            
            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }
            
            BuildAppCAB(Common.Apps.NetTest, Platforms.All.Processors.ARMV4, Platforms.All.Devices.SymbolMC_InternalFlash, CurInputDir, CurCABDir);
        }

        public void BuildAsiUpdaterCABs()
        {
            Console.WriteLine("Building {0} CABs...", Common.Apps.AsiUpdater.ToString());

            // TODO: for now, input and cab dir is the same. not by device, os, processor            
            string DirPath = Common.CABPath + @"\" + Common.Apps.AsiUpdater.ToString();
            DirectoryInfo CurCABDir = new DirectoryInfo(DirPath);
            DirectoryInfo CurInputDir = Common.InputPath;

            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            BuildAppCAB(Common.Apps.AsiUpdater, Platforms.All.Processors.ARMV4, Platforms.All.Devices.SymbolMC_InternalFlash, CurInputDir, CurCABDir);
        }
               
        private void BuildAppCAB(Common.Apps App, Platforms.All.Processors TheProcessor, Platforms.All.Devices TheDevice, DirectoryInfo TheInputDir, DirectoryInfo TheCABDir)
        {
            // CabWiz will append Process to the output CAB filename
            FileStream Inf = new FileStream(Common.TempPath + Common.bs + App.ToString() + "." + TheDevice.ToString() + ".inf", FileMode.Create);
            InfWriter InfW = new InfWriter(TheInputDir);

            switch (App)
            {
                case Common.Apps.Itb:
                    InfW.WriteMain(Inf, TheDevice, TheProcessor);
                    break;
                case Common.Apps.NetTest:
                    InfW.WriteNetTester(Inf, TheDevice, TheProcessor);
                    break;
                case Common.Apps.AsiUpdater:
                    InfW.WriteAsiUpdater(Inf, TheDevice, TheProcessor);
                    break;
            }
            
            Inf.Close();

            string ErrFilePath = Path.GetFullPath(Path.GetDirectoryName(Inf.Name)) + @"\ErrorLogs" + Common.bs + Path.GetFileNameWithoutExtension(Inf.Name) + ".log";
            string argu = "\"" + Inf.Name + "\"" + " /dest \"" + TheCABDir.FullName + "\" /err \"" + ErrFilePath + "\"" + " /cpu " + TheProcessor.ToString();
            Common.RunProcess(Common.CabWizPath + @"\" + Common.CabWizApp, argu);

            string OutFileName = TheCABDir.FullName + Common.bs + App.ToString() + "." + TheDevice.ToString() + "." + TheProcessor.ToString() + ".CAB";

            if (File.Exists(OutFileName))
            {
                string AppExe = TheInputDir.FullName + Common.bs + Common.GetEnumDesc(App);
                                
                if (File.Exists(AppExe))
                {
                    ITBCab.Versioning.ITB Ver = new ITBCab.Versioning.ITB(new FileInfo(AppExe));

                    string NewName1 = TheCABDir.FullName + Common.bs + App.ToString() + "." + Ver.GetVersion(App) + ".cab";
                    string NewName2 = TheCABDir.FullName + Common.bs + App.ToString() + ".cab";

                    if (File.Exists(NewName1))
                    {
                        File.SetAttributes(NewName1, FileAttributes.Normal);
                        File.Delete(NewName1);
                    }

                    if (File.Exists(NewName2))
                    {
                        File.SetAttributes(NewName2, FileAttributes.Normal);
                        File.Delete(NewName2);
                    }

                    File.Copy(OutFileName, NewName1);
                    File.Copy(OutFileName, NewName2);
                    File.SetAttributes(OutFileName, FileAttributes.Normal);
                    File.Delete(OutFileName);

                    File.SetAttributes(NewName2, FileAttributes.ReadOnly);
                }
                else
                {
                    throw new ApplicationException("Cannot find file " + AppExe);
                }
            }            
        }

        public void BuildDistributionCABs()
        {
            Console.WriteLine("Building {0} CABs...", Common.Distro);

            // TODO: for now, input and cab dir is the same. not by device, os, processor
            string DirPath = Common.CABPath + @"\" + Common.Distro;
            DirectoryInfo CurCABDir = new DirectoryInfo(DirPath);
            DirectoryInfo CurInputDir = Common.InputPath; // This can be changed later

            // ////////////////////////////////////////////////////////////////////////////
            // LOOP SECTION LATER
            // ////////////////////////////////////////////////////////////////////////////

            if (!Directory.Exists(DirPath))
            {
                Directory.CreateDirectory(DirPath);
            }

            FileInfo ItbCAB = new FileInfo(Common.CABPath.FullName + Common.bs + Common.Apps.Itb.ToString() + Common.bs + Common.Apps.Itb.ToString() + ".cab");
            FileInfo NetTestCAB = new FileInfo(Common.CABPath.FullName + Common.bs + Common.Apps.NetTest.ToString() + Common.bs + Common.Apps.NetTest.ToString() + ".cab");
            FileInfo AsiUpdaterCAB = new FileInfo(Common.CABPath.FullName + Common.bs + Common.Apps.AsiUpdater.ToString() + Common.bs + Common.Apps.AsiUpdater.ToString() + ".cab");

            if (File.Exists(ItbCAB.FullName) && File.Exists(NetTestCAB.FullName) && File.Exists(AsiUpdaterCAB.FullName))
            {
                //////////////////////////////////
                // carrier parameter omitted
                //////////////////////////////////
                BuildDistribution(Platforms.All.Processors.ARMV4, Platforms.All.Devices.SymbolMC_InternalFlash, Platforms.All.OSes.WM6, CurInputDir, CurCABDir, ItbCAB, NetTestCAB, AsiUpdaterCAB);
            }
            else
            {
                throw new ApplicationException("Cannot find file(s): \n" + ItbCAB.Name + "/" + NetTestCAB.Name + "/" + AsiUpdaterCAB.Name);
            }
        }
        
        private void BuildDistribution(Platforms.All.Processors TheProcessor, Platforms.All.Devices TheDevice, Platforms.All.OSes TheOS, DirectoryInfo TheInputDir, DirectoryInfo TheCABDir, FileInfo ItbCAB, FileInfo NetTestCAB, FileInfo AsiUpdaterCAB)
        {
            // CabWiz will append Process to the output CAB filename
            FileStream Inf = new FileStream(Common.TempPath + Common.bs + Common.Distro + "." + TheDevice.ToString() + ".inf", FileMode.Create);
            InfWriter InfW = new InfWriter(TheInputDir);

            //////////////////////////////////
            // bool wireless option not used
            //////////////////////////////////
            InfW.WriteDistribution(Inf, TheDevice, TheProcessor, TheOS, true, ItbCAB, NetTestCAB, AsiUpdaterCAB);
            Inf.Close();
            
            string ErrFilePath = Path.GetFullPath(Path.GetDirectoryName(Inf.Name)) + @"\ErrorLogs" + Common.bs + Path.GetFileNameWithoutExtension(Inf.Name) + ".log";
            string argu = "\"" + Inf.Name + "\"" + " /dest \"" + TheCABDir.FullName + "\" /err \"" + ErrFilePath + "\"" + " /cpu " + TheProcessor.ToString();
            Common.RunProcess(Common.CabWizPath + @"\" + Common.CabWizApp, argu);

            string OutFileName = TheCABDir.FullName + Common.bs + Common.Distro + "." + TheDevice.ToString() + "." + TheProcessor.ToString() + ".CAB";

            if (File.Exists(OutFileName))
            {
                bool FullVersion = true;
                string NewName = string.Empty;

                ITBCab.Versioning.ITB Ver = new ITBCab.Versioning.ITB(new FileInfo(TheInputDir + Common.bs + Common.GetEnumDesc(Common.Apps.Itb)), FullVersion);
                NewName = TheCABDir.FullName + Common.bs + Common.Apps.Itb.ToString().ToUpper() + "-" + Ver.GetVersion(Common.Apps.Itb) + "-" + TheOS.ToString() + ".cab";

                if (File.Exists(NewName))
                {
                    File.SetAttributes(NewName, FileAttributes.Normal);
                    File.Delete(NewName);
                }
                File.Move(OutFileName, NewName);
                File.Delete(OutFileName);
            }
        }        
    }
}
