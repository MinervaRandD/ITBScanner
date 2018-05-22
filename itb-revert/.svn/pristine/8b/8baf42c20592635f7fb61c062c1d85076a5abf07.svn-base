using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITBCab
{
    public class InfWriter
    {
        private DirectoryInfo InputDir;
        
        public InfWriter(DirectoryInfo InputDirectory)
        {
            InputDir = InputDirectory;
        }

        public void WriteMain(Stream Output, Platforms.All.Devices TheDevice, Platforms.All.Processors TheProcessor)
        {
            StreamWriter sw = new StreamWriter(Output);

            sw.WriteLine("[Version]");
            sw.WriteLine("Signature=\"$Windows NT$\"");
            sw.WriteLine("Provider=\"Aviation Software, Inc.\"");
            sw.WriteLine("CESignature=\"$Windows CE$\"");
            sw.WriteLine();

            sw.WriteLine("[CEStrings]");
            sw.WriteLine("AppName=\"InterBag\"");
            sw.WriteLine("InstallDir=%CE1%\\%AppName%");
            sw.WriteLine();

            sw.WriteLine("[CEDevice]");
            sw.WriteLine("VersionMin=4.0");
            sw.WriteLine("VersionMax=6.99");
            sw.WriteLine("BuildMax=0xE0000000");
            sw.WriteLine();

            sw.WriteLine("[Strings]");
            sw.WriteLine("Flash=\"\\Application\\\"");
            sw.WriteLine();

            sw.WriteLine("[DefaultInstall]");
            sw.WriteLine("CEShortcuts=Shortcuts");
            sw.WriteLine("AddReg=RegKeys");
            sw.WriteLine("CopyFiles=Files.Common1,Files.Common2");
            sw.WriteLine();

            sw.WriteLine("[SourceDisksNames]");
            sw.WriteLine("1=,\"Common1\",,\"" + InputDir.FullName + "\"");
            sw.WriteLine();

            sw.WriteLine("[SourceDisksFiles]");
            sw.WriteLine("Itb.exe=1");
            sw.WriteLine("Itb.sdf=1");
            sw.WriteLine("Config.xml=1");
            sw.WriteLine("Asi.Itb.Bll.dll=1");
            sw.WriteLine("Asi.Itb.Dal.dll=1");
            sw.WriteLine("Asi.Itb.Utilities.dll=1");
            sw.WriteLine("BugzScout.dll=1");
            sw.WriteLine("Gps.Location.dll=1");
            sw.WriteLine("Hardware.dll=1");
            sw.WriteLine("OpenNETCF.dll=1");
            sw.WriteLine("OpenNETCF.Telephony.dll=1");
            sw.WriteLine("Intermec.DataCollection.dll=1");
            sw.WriteLine("Symbol.dll=1");
            sw.WriteLine("Symbol.Barcode.dll=1");
            sw.WriteLine("Symbol.ResourceCoordination.dll=1");
            sw.WriteLine("Symbol.StandardForms.dll=1");
            sw.WriteLine("Symbol.Keyboard.dll=1");
            sw.WriteLine("PsionTeklogixNet.dll=1");
            sw.WriteLine("Microsoft.WindowsMobile.dll=1");
            sw.WriteLine("Microsoft.WindowsMobile.Status.dll=1");
            sw.WriteLine("toolhelp.dll=1");
            sw.WriteLine("logo.png=1");
            sw.WriteLine("splash.png=1");
            sw.WriteLine("batteryEmpty.png=1");
            sw.WriteLine("batteryFull.png=1");
            sw.WriteLine("radioOff.png=1");
            sw.WriteLine("radioOn.png=1");
            sw.WriteLine("pingFail.png=1");
            sw.WriteLine("pingSuccess.png=1");
            sw.WriteLine("radio0bar.png=1");
            sw.WriteLine("radio1bar.png=1");
            sw.WriteLine("radio2bar.png=1");
            sw.WriteLine("radio3bar.png=1");
            sw.WriteLine("radio4bar.png=1");
            sw.WriteLine("uploadDataExists.png=1");
            sw.WriteLine("uploadDataNotExists.png=1");
            sw.WriteLine();

            sw.WriteLine("[DestinationDirs]");
            sw.WriteLine("Shortcuts=0,%CE2%\\Start Menu");
            sw.WriteLine("Files.Common1=0,%InstallDir%");
            sw.WriteLine("Files.Common2=0,%InstallDir%\\images");
            sw.WriteLine();

            sw.WriteLine("[Files.Common1]");
            sw.WriteLine("Itb.exe,,,0x40000000");
            sw.WriteLine("Itb.sdf,,,0x40000000");
            sw.WriteLine("Config.xml,,,0x40000000");
            sw.WriteLine("Asi.Itb.Bll.dll,,,0x40000000");
            sw.WriteLine("Asi.Itb.Dal.dll,,,0x40000000");
            sw.WriteLine("Asi.Itb.Utilities.dll,,,0x40000000");
            sw.WriteLine("BugzScout.dll,,,0x40000000");
            sw.WriteLine("Gps.Location.dll,,,0x40000000");
            sw.WriteLine("Hardware.dll,,,0x40000000");
            sw.WriteLine("OpenNETCF.dll,,,0x40000000");
            sw.WriteLine("OpenNETCF.Telephony.dll,,,0x40000000");
            sw.WriteLine("Intermec.DataCollection.dll,,,0x40000000");
            sw.WriteLine("Symbol.dll,,,0x40000000");
            sw.WriteLine("Symbol.Barcode.dll,,,0x40000000");
            sw.WriteLine("Symbol.ResourceCoordination.dll,,,0x40000000");
            sw.WriteLine("Symbol.StandardForms.dll,,,0x40000000");
            sw.WriteLine("Symbol.Keyboard.dll,,,0x40000000");
            sw.WriteLine("PsionTeklogixNet.dll,,,0x40000000");
            sw.WriteLine("Microsoft.WindowsMobile.dll,,,0x40000000");
            sw.WriteLine("Microsoft.WindowsMobile.Status.dll,,,0x40000000");
            sw.WriteLine("toolhelp.dll,,,0x40000000");
            sw.WriteLine();

            sw.WriteLine("[Files.Common2]");
            sw.WriteLine("logo.png,,,0x40000000");
            sw.WriteLine("splash.png,,,0x40000000");
            sw.WriteLine("batteryEmpty.png,,,0x40000000");
            sw.WriteLine("batteryFull.png,,,0x40000000");
            sw.WriteLine("radioOff.png,,,0x40000000");
            sw.WriteLine("radioOn.png,,,0x40000000");
            sw.WriteLine("pingFail.png,,,0x40000000");
            sw.WriteLine("pingSuccess.png,,,0x40000000");
            sw.WriteLine("radio0bar.png,,,0x40000000");
            sw.WriteLine("radio1bar.png,,,0x40000000");
            sw.WriteLine("radio2bar.png,,,0x40000000");
            sw.WriteLine("radio3bar.png,,,0x40000000");
            sw.WriteLine("radio4bar.png,,,0x40000000");
            sw.WriteLine("uploadDataExists.png,,,0x40000000");
            sw.WriteLine("uploadDataNotExists.png,,,0x40000000");
            sw.WriteLine();

            sw.WriteLine("[Shortcuts]");
            sw.WriteLine("InterBag,0,Itb.exe,%CE11%");
            sw.WriteLine();

            sw.Close();
        }      
        
        public void WriteNetTester(Stream Output, Platforms.All.Devices TheDevice, Platforms.All.Processors TheProcessor)
        {
            StreamWriter sw = new StreamWriter(Output);            

            if (TheProcessor != Platforms.All.Processors.ARMV4)
            {
                return;
            }
            sw.WriteLine("[Version]");
            sw.WriteLine("Signature = \"$Windows NT$\"");
            sw.WriteLine("Provider = \"ASI\"");
            sw.WriteLine("CESignature = \"$Windows CE$\"");
            sw.WriteLine();
            sw.WriteLine("[CEStrings]");
            sw.WriteLine("AppName = \"ASI Net Test\"");
            sw.WriteLine("InstallDir=%CE1%\\%AppName%");
            sw.WriteLine();
            sw.WriteLine("[CEDevice]");
            sw.WriteLine("VersionMin=4.0");
            sw.WriteLine("VersionMax=6.99");
            sw.WriteLine("BuildMax=0xE0000000");
            sw.WriteLine();
            sw.WriteLine("[DefaultInstall]");
            sw.WriteLine("CEShortcuts=Shortcuts");
            sw.WriteLine("CopyFiles=Files.Common");
            sw.WriteLine();
            sw.WriteLine("[SourceDisksNames]");
            sw.WriteLine("1=,\"Common1\",,\"" + InputDir.FullName + "\"");
            sw.WriteLine();
            sw.WriteLine("[SourceDisksFiles]");
            sw.WriteLine("ASINetTest.exe=1");
            sw.WriteLine("icmpwrap.dll=1");

            //if (TheDevice == Platforms.All.Devices.Intermec_700C || TheDevice TheDevice == Platforms.All.Devices.Intermec_CN3)
            //{
            //    sw.WriteLine("psuuid0c.dll=1");
            //}

            sw.WriteLine("Rebex.Net.Time.dll=1");
            sw.WriteLine("Rebex.Security.dll=1");
            sw.WriteLine("Rebex.Net.SecureSocket.dll=1");
            sw.WriteLine("Rebex.Net.Ftp.dll=1");
            sw.WriteLine("Rebex.Net.ProxySocket.dll=1");
            sw.WriteLine("OpenNETCF.dll=1");
            sw.WriteLine("OpenNETCF.Drawing.dll=1");
            sw.WriteLine("OpenNETCF.Net.dll=1");
            sw.WriteLine("OpenNETCF.VisualBasic.dll=1");
            sw.WriteLine("OpenNETCF.Windows.Forms.dll=1");
            sw.WriteLine();
            sw.WriteLine("[DestinationDirs]");
            sw.WriteLine("Files.Common=0,%InstallDir%");
            sw.WriteLine("Shortcuts=0,%CE2%\\Start Menu");
            sw.WriteLine();
            sw.WriteLine("[Files.Common]");
            sw.WriteLine("ASINetTest.exe, , , 0");
            sw.WriteLine("icmpwrap.dll, , , 0");

            //if (TheDevice == Platforms.All.Devices.Intermec_700C || TheDevice TheDevice == Platforms.All.Devices.Intermec_CN3)
            //{
            //    sw.WriteLine("psuuid0c.dll, , , 0");
            //}                

            sw.WriteLine("Rebex.Net.Time.dll, , , 0");
            sw.WriteLine("Rebex.Security.dll, , , 0");
            sw.WriteLine("Rebex.Net.SecureSocket.dll, , , 0");
            sw.WriteLine("Rebex.Net.Ftp.dll, , , 0");
            sw.WriteLine("Rebex.Net.ProxySocket.dll, , , 0");
            sw.WriteLine("OpenNETCF.dll, , , 0");
            sw.WriteLine("OpenNETCF.Drawing.dll, , , 0");
            sw.WriteLine("OpenNETCF.Net.dll, , , 0");
            sw.WriteLine("OpenNETCF.VisualBasic.dll, , , 0");
            sw.WriteLine("OpenNETCF.Windows.Forms.dll, , , 0");
            sw.WriteLine();
            sw.WriteLine("[Shortcuts]");
            sw.WriteLine("ASI Net Test,0,ASINetTest.exe,%CE11%");

            sw.Close();            
        }

        public void WriteAsiUpdater(Stream Output, Platforms.All.Devices TheDevice, Platforms.All.Processors TheProcessor)
        {
            StreamWriter sw = new StreamWriter(Output);

            if (TheProcessor != Platforms.All.Processors.ARMV4)
            {
                return;
            }
            sw.WriteLine("[Version]");
            sw.WriteLine("Signature = \"$Windows NT$\"");
            sw.WriteLine("Provider = \"ASI\"");
            sw.WriteLine("CESignature = \"$Windows CE$\"");
            sw.WriteLine();
            sw.WriteLine("[CEStrings]");
            sw.WriteLine("AppName = \"ASIUpdater\"");
            sw.WriteLine("InstallDir=%CE1%\\%AppName%");
            sw.WriteLine();
            sw.WriteLine("[CEDevice]");
            sw.WriteLine("VersionMin=4.0");
            sw.WriteLine("VersionMax=6.99");
            sw.WriteLine("BuildMax=0xE0000000");
            sw.WriteLine();
            sw.WriteLine("[DefaultInstall]");
            sw.WriteLine("CEShortcuts=Shortcuts");
            sw.WriteLine("CopyFiles=Files.Common");
            sw.WriteLine();
            sw.WriteLine("[SourceDisksNames]");
            sw.WriteLine("1=,\"Common1\",,\"" + InputDir.FullName + "\"");
            sw.WriteLine();
            
            sw.WriteLine("[SourceDisksFiles]");
            sw.WriteLine("AsiUpdater.exe=1");
            sw.WriteLine("Hardware_AsiUpdater.dll=1");
            sw.WriteLine("Intermec.DataCollection.dll=1");
            sw.WriteLine("OpenNETCF_AsiUpdater.dll=1");
            sw.WriteLine("OpenNETCF.Windows.Forms_AsiUpdater.dll=1");
            sw.WriteLine("Symbol.Barcode.dll=1");
            sw.WriteLine("Symbol.dll=1");
            sw.WriteLine("Symbol.ResourceCoordination.dll=1");
            sw.WriteLine("Symbol.StandardForms.dll=1");
            sw.WriteLine("UpdaterConfig.xml=1");
            sw.WriteLine();

            sw.WriteLine("[DestinationDirs]");
            sw.WriteLine("Files.Common=0,%InstallDir%");
            sw.WriteLine("Shortcuts=0,%CE2%\\Start Menu");
            sw.WriteLine();

            sw.WriteLine("[Files.Common]");
            sw.WriteLine("AsiUpdater.exe, , , 0");
            sw.WriteLine("Hardware.dll,Hardware_AsiUpdater.dll, , 0");
            sw.WriteLine("Intermec.DataCollection.dll, , , 0");
            sw.WriteLine("OpenNETCF.dll,OpenNETCF_AsiUpdater.dll, , 0");
            sw.WriteLine("OpenNETCF.Windows.Forms.dll,OpenNETCF.Windows.Forms_AsiUpdater.dll, , 0");
            sw.WriteLine("Symbol.Barcode.dll, , , 0");
            sw.WriteLine("Symbol.dll, , , 0");
            sw.WriteLine("Symbol.ResourceCoordination.dll, , , 0");
            sw.WriteLine("Symbol.StandardForms.dll, , , 0");
            sw.WriteLine("UpdaterConfig.xml, , , 0");
            
            sw.WriteLine();
            sw.WriteLine("[Shortcuts]");
            sw.WriteLine("ASIUpdater,0,AsiUpdater.exe,%CE11%");

            sw.Close();
        }
        
        // Wireless option not used here
        public void WriteDistribution(Stream Output, Platforms.All.Devices TheDevice, Platforms.All.Processors TheProcessor, Platforms.All.OSes TheOS, bool IsWireless, FileInfo ItbCAB, FileInfo NetTestCAB, FileInfo AsiUpdaterCAB)
        {
            StreamWriter sw = new StreamWriter(Output);

            sw.WriteLine("[Version]");
            sw.WriteLine("Signature=\"$Windows NT$\"");
            sw.WriteLine("Provider=\"Aviation Software, Inc.\"");
            sw.WriteLine("CESignature=\"$Windows CE$\"");
            sw.WriteLine();

            sw.WriteLine("[CEStrings]");
            sw.WriteLine("AppName=\"InterBag Installer\"");
            sw.WriteLine("InstallDir=\"\\" + GetInstallDir(TheDevice) + "\"");            
            sw.WriteLine();

            sw.WriteLine("[CEDevice]");
            sw.WriteLine("VersionMin=4.0");
            sw.WriteLine("VersionMax=6.99");
            sw.WriteLine("BuildMax=0xE0000000");
            sw.WriteLine();

            sw.WriteLine("[Strings]");
            sw.WriteLine("Flash = \"\\Application\\\"");
            sw.WriteLine("StartUp=\"StartUp\\\"");
            sw.WriteLine("StartUpCtl=\"StartUpCtl\\\"");
            sw.WriteLine("StartUpCtlBin=\"Bin\\\"");
            sw.WriteLine("Reset=\"OnReset\\\"");
            // sw.WriteLine("Restore=\"OnRestore\\\"");
            sw.WriteLine("CABS=\"CabFiles\\\"");
            sw.WriteLine();

            sw.WriteLine("[DefaultInstall]");
            sw.WriteLine("CopyFiles=CABS,STARTUP,STARTUPCTL,STARTUPCTLBIN,RESET");
            // sw.WriteLine("CopyFiles=CABS,STARTUP,STARTUPCTL,STARTUPCTLBIN,RESET,RESTORE");
            sw.WriteLine("AddReg = RegSettings.All");
            sw.WriteLine();

            sw.WriteLine("[SourceDisksNames]");
            sw.WriteLine("1=,\"PrerequisiteCAB\",,\"" + InputDir.FullName + "\"");
            sw.WriteLine("2=,\"MainCAB\",,\"" + ItbCAB.Directory.FullName + "\"");
            sw.WriteLine("3=,\"NetTestCAB\",,\"" + NetTestCAB.Directory.FullName + "\"");
            sw.WriteLine("4=,\"SupportFiles\",,\"" + InputDir.FullName + "\"");
            sw.WriteLine("5=,\"AsiUpdaterCAB\",,\"" + AsiUpdaterCAB.Directory.FullName + "\"");
            sw.WriteLine();

            sw.WriteLine("[SourceDisksFiles]");
            sw.WriteLine("NETCFv35.wm.ARMV4I.cab=1");
            sw.WriteLine("NETCFv35.Messages.EN.wm.cab=1");
            sw.WriteLine("sqlce.ppc.wce5.armv4i.CAB=1");
            sw.WriteLine("sqlce.repl.ppc.wce5.armv4i.CAB=1");
            sw.WriteLine("ITB.CAB=2");
            sw.WriteLine("NetTest.CAB=3");
            sw.WriteLine("StartUpCtl.exe=4");
            sw.WriteLine("StartUpCtlConfig.txt=4");
            sw.WriteLine("copyfiles.exe=4");
            sw.WriteLine("regmerge.exe=4");
            sw.WriteLine("OnReset.txt=4");
            sw.WriteLine("OnReset_1.txt=4");
            sw.WriteLine("AsiUpdater.CAB=5");
            sw.WriteLine();

            // *********************************************
            // ** [CESTRING] INSTALLDIR WILL NOT APPEND \
            // *********************************************

            sw.WriteLine("[DestinationDirs]");
            sw.WriteLine("CABS=0,%InstallDir%\\%CABS%");
            sw.WriteLine("STARTUP=0,%Flash%%StartUp%");
            sw.WriteLine("STARTUPCTL=0,%InstallDir%\\%StartUpCtl%");
            sw.WriteLine("STARTUPCTLBIN=0, %InstallDir%\\%StartUpCtl%%StartUpCtlBin%");
            sw.WriteLine("RESET=0,%InstallDir%\\%StartUpCtl%%Reset%");
            // sw.WriteLine("RESTORE=0,%InstallDir%%StartUpCtl%%Restore%");
            sw.WriteLine();

            sw.WriteLine("[CABS]");
            sw.WriteLine("NETCFv35.wm.ARMV4I.cab,,,0x40000000");
            sw.WriteLine("NETCFv35.Messages.EN.wm.cab,,,0x40000000");
            sw.WriteLine("sqlce.ppc.wce5.armv4i.CAB,,,0x40000000");
            sw.WriteLine("sqlce.repl.ppc.wce5.armv4i.CAB,,,0x40000000");
            sw.WriteLine("ITB.CAB,,,0x40000000");
            sw.WriteLine("NetTest.CAB,,,0x40000000");
            sw.WriteLine("AsiUpdater.CAB,,,0x40000000");

            sw.WriteLine("[STARTUP]");
            sw.WriteLine("StartUpCtl.exe,,,0x40000000");
            sw.WriteLine();

            sw.WriteLine("[STARTUPCTL]");
            sw.WriteLine("StartUpCtlConfig.txt,,,0x40000000");
            sw.WriteLine();

            sw.WriteLine("[STARTUPCTLBIN]");
            sw.WriteLine("copyfiles.exe,,,0x40000000");
            sw.WriteLine("regmerge.exe,,,0x40000000");
            sw.WriteLine();

            sw.WriteLine("[RESET]");
            sw.WriteLine("OnReset.txt,,,0x40000000");
            sw.WriteLine("OnReset_1.txt,,,0x40000000");
            sw.WriteLine();

            //sw.WriteLine("[RESTORE]");
            //sw.WriteLine("OnRestore.txt,,,0x40000000");
            //sw.WriteLine();

            // Disable phone buttons
            sw.WriteLine("[RegSettings.All]");
            sw.WriteLine("HKLM,HARDWARE\\DEVICEMAP\\KEYBD,RedKeyOverride,0x00000000,"); // default factory setting: 61
            sw.WriteLine("HKLM,HARDWARE\\DEVICEMAP\\KEYBD,GreenKeyOverride,0x00000000,"); // default factory setting: 62           
            // following three entries hide startButton in WinMo 6.5.x
            // (http://www.hjgode.de/wp/2010/10/11/windows-mobile-hide-startbutton-in-winmo-6-5-x/)
            sw.WriteLine("HKLM,Software\\Microsoft\\Shell\\BubbleTiles,TextModeEnabled,0x00010001,1");
            sw.WriteLine("HKLM,Software\\Microsoft\\Shell\\BubbleTiles,HardwareStartKeyEnabled,0x00010001,1");
            sw.WriteLine("HKLM,Software\\Microsoft\\Shell\\BubbleTiles,HardwareDoneKeyEnabled,0x00010001,1");

            sw.Close();
        }
                        
        public string GetInstallDir(Platforms.All.Devices Device)
        {
            string InstallDir = "";

            switch (Device)
            {
                case Platforms.All.Devices.SymbolMC_InternalFlash:
                    InstallDir = "Application";
                    break;
                case Platforms.All.Devices.SymbolMC_SDCard:
                    InstallDir = "Storage Card";
                    break;
                default:
                    InstallDir = "Application";
                    break;
            }

            return InstallDir;
        }
    }
}
