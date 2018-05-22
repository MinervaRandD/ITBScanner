using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace sb
{
	/// <summary>
	/// Summary description for DistributionFileBuilder.
	/// </summary>
	public class DistributionFileBuilder
	{
		private SystemBuilder systemBuilder ;
		private SystemProfile systemProfile ;

		private string baseProjectAppName ;

		private string distributionFileInfFilePath ;
		private string distributionFileCabFilePath ;
		private string distributionLogFilePath ;

		private BuildUpdateOutputForm buildOutputForm ;

		public DistributionFileBuilder(SystemBuilder inputSystemBuilder, SystemProfile inputSystemBuilderProfile)
		{
			systemBuilder = inputSystemBuilder ;
			systemProfile = inputSystemBuilderProfile ;
		}

		public bool buildDistributionFile(BuildUpdateOutputForm inputBuildOutputForm, string outputCabFilePath)
		{
			buildOutputForm = inputBuildOutputForm ;

			baseProjectAppName = systemProfile.applicationName ;

			ArrayList carriers = this.systemProfile.getCarriers;

			distributionFileInfFilePath = Globals.infFilesDirectory + @"\" + this.systemProfile.deviceType + "_Distribution.inf" ;
			distributionFileCabFilePath = systemProfile.distributionCabFilePath ;
			distributionLogFilePath     = Globals.workingFilesDirectory + @"\" + Path.GetFileNameWithoutExtension(systemProfile.distributionCabFilePath) + ".log" ;
			
			ArrayList outputLineList = new ArrayList() ;

			string deviceType = systemProfile.deviceType ;

			string processorType = this.systemProfile.processorType ;
			//string user = this.systemProfile.user ;

			if (systemProfile.deviceType == "Intermec") 
			{
				string autoUserDatFilePath = Globals.deviceSpecificFilesDirectory + @"\autouser.dat" ;

				buildOutputForm.addLines(" ") ;
				buildOutputForm.addLines("+++ Updating autostart file \"" + autoUserDatFilePath + "\" +++") ;
		
				Utilities.DeleteLocalFile(autoUserDatFilePath) ;

				StreamWriter autouserDatOutputStream ;

				try
				{
					autouserDatOutputStream = new StreamWriter(autoUserDatFilePath) ;
				}

				catch (Exception ex1)
				{
					throw new Exception("Attempt to create autouser.dat file \"" + autoUserDatFilePath + "\" failed: " + ex1.Message, ex1) ;
				}

				string outputRunLine = "RUN \"\\Program Files\\" + baseProjectAppName + @"\" + baseProjectAppName + ".exe" ;

				try
				{
					autouserDatOutputStream.WriteLine(outputRunLine) ;
				}

				catch (Exception ex2)
				{
					autouserDatOutputStream.Close() ;
					throw new Exception("Attempt to write to autouser.dat file \"" + autoUserDatFilePath + "\" failed: " + ex2.Message, ex2) ;
				}

				autouserDatOutputStream.Close() ;
			}

			buildOutputForm.addLines(" ") ;
			buildOutputForm.addLines("+++ Building distribution files cab file +++") ;
			buildOutputForm.addLines("     ++ Creating .inf file for \"" + distributionFileCabFilePath + "++") ;
			
			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[Version]") ;
			outputLineList.Add("") ;
			outputLineList.Add("Signature	= \"$Windows NT$\"") ;
			outputLineList.Add("Provider	= \"Aviation Software, Inc.\"") ;
			outputLineList.Add("CESignature	= \"$Windows CE$\"") ;
			outputLineList.Add("") ;
			outputLineList.Add("[CEDevice]") ;
			outputLineList.Add("Processortype	= 2577") ;
			outputLineList.Add("VersionMin 	= 3.0") ;
			outputLineList.Add("VersionMax	= 100") ;
			outputLineList.Add("") ;
			outputLineList.Add("[CEStrings]") ;
			outputLineList.Add("") ;

			if (systemProfile.deviceType == "Intermec") 
			{
				outputLineList.Add("InstallDir = \"\\SDMMC Disk\\\"") ;
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("InstallDir = \"\\Storage Card\\\"") ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				outputLineList.Add("InstallDir = \"\\Storage Card\\\"") ;
			}

			outputLineList.Add("AppName = " + baseProjectAppName + " Installer") ;
			outputLineList.Add("") ;
			outputLineList.Add("[Strings]") ;
			outputLineList.Add("") ;

			if (systemProfile.deviceType == "Intermec") 
			{
				outputLineList.Add("SDMMC  = \"\\SDMMC Disk\\\"") ;
				outputLineList.Add("Flash  = \"\\Flash File Store\\\"") ;
				outputLineList.Add("CABS   = \"cabfiles\\\"") ;
				outputLineList.Add("OTH	   = \"2577\\\"") ;
				outputLineList.Add("CRE	   = \"CORE\\\"") ;
				outputLineList.Add("MDL	   = \"Modules\\\"") ;
				outputLineList.Add("Instl	   = \"Installed\\\"") ;
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("SDMMC  = \"\\Storage Card\\\"") ;
				outputLineList.Add("Flash  = \"\\IPSM\\\"") ;
				outputLineList.Add("CABS   = \"cabfiles\\\"") ;
				outputLineList.Add("AutoInstall = \"AutoInstall\\\"") ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				outputLineList.Add("SDMMC  = \"\\Storage Card\\\"") ;
				outputLineList.Add("Flash  = \"\\Application\\\"") ;
				outputLineList.Add("CABS   = \"cabfiles\\\"") ;
				outputLineList.Add("Startup = \"Startup\\\"") ;
			}


			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[DefaultInstall]") ;
			outputLineList.Add("") ;

			if (systemProfile.deviceType == "Intermec") 
			{

				if (systemProfile.operatingSystem == "Pocket PC 2003" && systemProfile.isWireless) 
				{
					outputLineList.Add("CopyFiles = Cabs,Start1,Start2,CORE,CORE_Modules_Installed") ;
			
				} 
				else 
				{
					outputLineList.Add("CopyFiles	= Cabs,Start1,Start2") ;
				}
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("CopyFiles = Cabs, Dolphin1") ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				outputLineList.Add("CopyFiles = Cabs, Symbol1") ;
			}


			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[SourceDisksNames]") ;
			outputLineList.Add("") ;
			outputLineList.Add("1 =, \"BuildSource\" ,, \"" + Globals.buildFilesDirectory    + "\"") ;
			outputLineList.Add("2 =, \"Common1\",, \""      + Globals.processorSpecificFilesDirectory    + "\"") ;
			outputLineList.Add("3 =, \"Common2\",, \""      + Globals.deviceSpecificFilesDirectory + "\"") ;

			if (systemProfile.deviceType == "Intermec") 
			{
				if (systemProfile.operatingSystem == "Pocket PC 2003") 
				{
					outputLineList.Add( "4=,\"Common3\",, \"" + Globals.deviceSpecificFilesDirectory + @"\PPC2003" + "\"") ;
				}
				else
				{
					outputLineList.Add( "4=,\"Common3\",, \"" + Globals.deviceSpecificFilesDirectory + @"\PPC2002" + "\"") ;
				}
			}

			outputLineList.Add("") ;
			outputLineList.Add("[SourceDisksFiles]") ;
			outputLineList.Add("") ;

			outputLineList.Add(baseProjectAppName + ".cab = 1") ;

			foreach (object item in carriers)
			{                
				outputLineList.Add("DependentFiles." + item.ToString() + ".cab = 1") ;
			}

			if (systemProfile.deviceType == "Intermec") 
			{
				if (systemProfile.operatingSystem == "Pocket PC 2003")
				{
					if (systemProfile.isWireless) 
					{
						outputLineList.Add("autouser.wireless.dat       = 4") ;
						outputLineList.Add("CORE.exe       = 4") ;
						outputLineList.Add("WAN_Module.dll       = 4") ;
					}
					else 
					{
						outputLineList.Add("autouser.wired.dat       = 4") ;
					}
					outputLineList.Add("autorun.dat	       = 4") ;
					outputLineList.Add("RegEnableAndFlush Mobile 2003.exe       = 4") ;
					outputLineList.Add("autorun.exe	       = 4") ;
					outputLineList.Add("autocab.exe	       = 4") ;
				} 
				else 
				{
					outputLineList.Add("autouser.dat       = 3") ;
					outputLineList.Add("autorun.dat	       = 3") ;
					outputLineList.Add("netcf.core.ppc3.arm.cab       = 2") ;
					outputLineList.Add("autorun.exe	       = 3") ;
					outputLineList.Add("autocab.exe	       = 3") ;
					outputLineList.Add("regflush.cab = 4");
				}
				outputLineList.Add("bootstrap.exe	   = 3") ;
				outputLineList.Add("flash_autorun.dat  = 3") ;
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("netcf.hhp.wce4.armv4_2.05.CAB =3") ;
				outputLineList.Add("Autorun.exm =3") ;                
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				if (systemProfile.operatingSystem != "Pocket PC 2003")
				{
					outputLineList.Add("netcf.core.ppc3.arm.cab = 2") ;
				}
				//outputLineList.Add("TagTrak.cpy=3") ;
				outputLineList.Add("TagTrak.run = 3") ;
			}

			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("; Output directories for files & shortcuts") ;
			
			outputLineList.Add("") ;
			outputLineList.Add("[DestinationDirs]") ;

			if (systemProfile.deviceType == "Intermec") 
			{
				outputLineList.Add("Cabs = 0, %SDMMC%%CABS%") ;
				outputLineList.Add("Start1 = 0, %Flash%%OTH%") ;
				outputLineList.Add("Start2  = 0, %SDMMC%%OTH%") ;
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("Cabs = 0, %Flash%%AutoInstall%") ;
				outputLineList.Add("Dolphin1 = 0, %Flash%") ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				//outputLineList.Add("Cabs = 0, %SDMMC%%CABS%") ;
				outputLineList.Add("Cabs = 0, %SDMMC%%Startup%") ;
                outputLineList.Add("Symbol1 = 0, %SDMMC%%Startup%") ;
			}

			if (systemProfile.operatingSystem == "Pocket PC 2003" && systemProfile.isWireless)
			{
				outputLineList.Add("CORE  = 0, %SDMMC%%CRE%") ;
				outputLineList.Add("CORE_Modules_Installed  = 0, %SDMMC%%CRE%%MDL%%Instl%") ;
			} 

			outputLineList.Add("") ;
			outputLineList.Add("[Cabs]") ;

			outputLineList.Add(baseProjectAppName + ".cab,,,0x40000000") ;

			foreach (object item in carriers)
			{
				outputLineList.Add("DependentFiles." + item.ToString() + ".cab,,,0x40000000") ;
			}

			if (systemProfile.deviceType == "Intermec")
			{
				if (systemProfile.operatingSystem != "Pocket PC 2003") 
				{
					outputLineList.Add("FCDotNet.cab,netcf.core.ppc3.arm.cab,,0x40000000") ;
					outputLineList.Add("regflush.cab,,,0x40000000") ;
				}
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("netcf.hhp.wce4.armv4_2.05.CAB,,,0x40000000") ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				if (systemProfile.operatingSystem != "Pocket PC 2003")
				{
					outputLineList.Add("FCDotNet.cab,netcf.core.ppc3.arm.cab,,0x40000000") ;
				}
			}

			if (systemProfile.deviceType == "Intermec")
			{
				outputLineList.Add("") ;
				outputLineList.Add("[Start1]") ;
				if (systemProfile.operatingSystem == "Pocket PC 2002") 
				{
					outputLineList.Add("autorun.exe,,,0x40000000") ;
					outputLineList.Add("autorun.dat,flash_autorun.dat,,0x40000000") ;
					outputLineList.Add("bootstrap.exe,,,0x40000000") ;
				}
				outputLineList.Add("[Start2]") ;
				outputLineList.Add("") ;
				outputLineList.Add("autorun.exe,,,0x40000000") ;
				outputLineList.Add("autorun.dat,,,0x40000000") ;
				outputLineList.Add("autocab.exe,,,0x40000000") ;
				if (systemProfile.operatingSystem == "Pocket PC 2003")
				{
					if (systemProfile.isWireless) 
					{
						outputLineList.Add("autouser.dat,autouser.wireless.dat,,0x40000000") ;
						outputLineList.Add("RegEnableAndFlush Mobile 2003.exe,,,0x40000000") ;
						outputLineList.Add("") ;
						outputLineList.Add("[CORE]") ;
						outputLineList.Add("") ;
						outputLineList.Add("core.exe,,,0x40000000") ;
						outputLineList.Add("") ;
						outputLineList.Add("[CORE_Modules_Installed]") ;
						outputLineList.Add("") ;
						outputLineList.Add("WAN_Module.dll,,,0x40000000") ;
					}
					else 
					{
						outputLineList.Add("autouser.dat,autouser.wired.dat,,0x40000000") ;
						outputLineList.Add("RegEnableAndFlush Mobile 2003.exe,,,0x40000000") ;
					}
				} 
				else 
				{
					outputLineList.Add("autouser.dat,,,0x40000000") ;
				}
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("") ;
				outputLineList.Add("[Dolphin1]") ;
				outputLineList.Add("Autorun.exm,,,0x40000000") ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				outputLineList.Add("") ;
				outputLineList.Add("[Symbol1]") ;
				outputLineList.Add("TagTrak.run,,,0x40000000") ;
			}

			Utilities.DeleteLocalFile( distributionFileInfFilePath ) ;

			StreamWriter outputFileStream = new StreamWriter( distributionFileInfFilePath ) ;

			foreach ( string outputLine in outputLineList )
			{
				outputFileStream.WriteLine(outputLine) ;
			}

			outputFileStream.Close() ;

			buildOutputForm.addLines("    ++ .inf file \"" + distributionFileInfFilePath + "\" created. ++\n ") ;
			buildOutputForm.addLines(" ") ;
			buildOutputForm.addLines("    ++ Generating cab file '" + baseProjectAppName + ".cab' using CabWiz") ;
			
			string command = @"C:\Program Files\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\Windows CE\..\bin\..\bin\cabwiz.exe" ;
			string parameters = "\"" + distributionFileInfFilePath + "\"" + " /dest \"" + Globals.workingFilesDirectory + "\" /err \"" +  distributionLogFilePath + "\" /cpu " + processorType ;
			string[] commandOutput = new string[2] ;

			buildOutputForm.addLines(parameters, "        ") ;

			Utilities.executeShell(command, parameters, commandOutput) ;

			if ( Utilities.isNonNullString(commandOutput[0]) ) this.buildOutputForm.addLines(commandOutput[0], "        ") ;
			if ( Utilities.isNonNullString(commandOutput[1]) ) this.buildOutputForm.addLines(commandOutput[1], "        ") ;

			bool cabWizError = false ;
			string cabWizErrorLine = null ;

			if ( File.Exists(distributionLogFilePath) )
			{
				StreamReader logFileInputStream = new StreamReader(distributionLogFilePath) ;

				string inputLine = logFileInputStream.ReadLine() ;

				while ( inputLine != null )
				{
					if ( inputLine.IndexOf("Error:") >= 0 )
					{
						cabWizError = true ;
						cabWizErrorLine = inputLine ;
					}

					this.buildOutputForm.addLines(inputLine, "    CabWiz: ") ;
					inputLine = logFileInputStream.ReadLine() ;
				}

				logFileInputStream.Close() ;
			}

			// It is really important to be sure the build was successful. Therefore several tests are performed on the
			// CabWiz results. It is likely that some of these are superfulous, but rather safe than sorry.

			if ( cabWizError )
			{
				throw new Exception( "Build of dependent files cab file failed: " + cabWizErrorLine ) ;
			}

			string distributionFilesTempCabFilePath = Globals.workingFilesDirectory + @"\" + systemProfile.deviceType + "_Distribution." + systemProfile.processorType + ".Cab" ;
 			
			if ( ! File.Exists( distributionFilesTempCabFilePath ) )
 			{
 				throw new Exception("Build of base project cab file failed: no cab file created.") ;
 			}

			string distributionFilesCabFilePath = outputCabFilePath.Trim() ;
			string distributionFilesCabFileDir = Path.GetDirectoryName(distributionFilesCabFilePath) ;
			
			if ( !Directory.Exists(distributionFilesCabFileDir) )
			{
				Directory.CreateDirectory(distributionFilesCabFileDir) ;
			}

			Utilities.MoveLocalFile(distributionFilesTempCabFilePath, distributionFilesCabFilePath) ;

			this.buildOutputForm.addLines(" ") ;
			this.buildOutputForm.addLines("+++ Distribution Cab File \"" + distributionFilesCabFilePath + "\" successfully created.") ;

			return true ;
		}
	}

}
