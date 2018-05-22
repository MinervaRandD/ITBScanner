using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace sb
{
	/// <summary>
	/// Summary description for DistributionFileBuilder.
	/// </summary>
	public class MigrateFileBuilder
	{
		private SystemBuilder systemBuilder ;
		private SystemProfile systemProfile ;

		private string baseProjectAppName ;

		private string migrateFileInfFilePath ;
		private string migrateFileCabFilePath ;
		private string migrateLogFilePath ;

		private BuildUpdateOutputForm buildOutputForm ;

		public MigrateFileBuilder(SystemBuilder inputSystemBuilder, SystemProfile inputSystemBuilderProfile)
		{
			systemBuilder = inputSystemBuilder ;
			systemProfile = inputSystemBuilderProfile ;
		}

		public bool buildMigrateFile(BuildUpdateOutputForm inputBuildOutputForm, string outputCabFilePath)
		{
			buildOutputForm = inputBuildOutputForm ;

			baseProjectAppName = systemProfile.applicationName ;

			ArrayList carriers = this.systemProfile.getCarriers;

			migrateFileInfFilePath = Globals.infFilesDirectory + @"\" + this.systemProfile.deviceType + "_Migration.inf" ;
			migrateFileCabFilePath = systemProfile.migrateCabFilePath ;
			migrateLogFilePath     = Globals.workingFilesDirectory + @"\" + Path.GetFileNameWithoutExtension(systemProfile.migrateCabFilePath) + ".log" ;
			
			ArrayList outputLineList = new ArrayList() ;

			string deviceType = systemProfile.deviceType ;

			string processorType = this.systemProfile.processorType ;
			//string user = this.systemProfile.user ;

			string autoUserDatFilePath = Globals.deviceSpecificFilesDirectory + @"\autouser.dat" ;

			//{
			string baseConfigFileFullName     = Globals.configFilesDirectory + @"\BaseConfig.bin" ;
			bool configFileExists = File.Exists(baseConfigFileFullName) ;
			string airlineSoftwareDllDirectory = Path.GetDirectoryName(systemProfile.airlineSoftwareDllFile);
			//}

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

			buildOutputForm.addLines(" ") ;
			buildOutputForm.addLines("+++ Building migrate files cab file +++") ;
			buildOutputForm.addLines("     ++ Creating .inf file for \"" + migrateFileCabFilePath + "++") ;
			
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
			outputLineList.Add("InstallDir = \"\\SDMMC Disk\\\"") ;
			outputLineList.Add("AppName = " + baseProjectAppName + " Migrater") ;
			outputLineList.Add("") ;
			outputLineList.Add("[Strings]") ;
			outputLineList.Add("") ;
			outputLineList.Add("SDMMC  = \"\\SDMMC Disk\\\"") ;
			outputLineList.Add("Flash  = \"\\Flash File Store\\\"") ;
			outputLineList.Add("CABS   = \"cabfiles\"") ;
			outputLineList.Add("OTH	   = \"2577\"") ;
			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[DefaultInstall]") ;
			outputLineList.Add( "addreg= regsettings.all" ) ;
			outputLineList.Add("") ;
			outputLineList.Add("CopyFiles	= Cabs,Start1,Start2") ;
			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[SourceDisksNames]") ;
			outputLineList.Add("") ;
			outputLineList.Add("1 =, \"BuildSource\" ,, \"" + Globals.buildFilesDirectory    + "\"") ;
			outputLineList.Add("2 =, \"Common1\",, \""      + Globals.processorSpecificFilesDirectory    + "\"") ;
			outputLineList.Add("3 =, \"Common2\",, \""      + Globals.deviceSpecificFilesDirectory + "\"") ;

			//{
//			outputLineList.Add( "4=,\"Common4\",,\"" + Globals.processorSpecificFilesDirectory   + "\"" ) ;
			outputLineList.Add( "5=,\"Common5\",,\"" + Globals.workingFilesDirectory + "\"" ) ;
			outputLineList.Add( "6=,\"Common6\",, \"" + Globals.deviceSpecificFilesDirectory + "\"") ;
			outputLineList.Add( "7=,\"Library\",, \"" + airlineSoftwareDllDirectory + "\"") ;
			if ( configFileExists ) outputLineList.Add( "8=,\"Common5\",,\"" + Globals.configFilesDirectory + "\"" ) ;
			//}

			outputLineList.Add("") ;
			outputLineList.Add("[SourceDisksFiles]") ;
			outputLineList.Add("") ;

			foreach (object item in carriers)
			{                
				outputLineList.Add("DependentFiles." + item.ToString() + ".cab = 1") ;
			}

//			outputLineList.Add("netcf.core.ppc3.arm.cab       = 2") ;
			outputLineList.Add(baseProjectAppName + ".cab = 1") ;
			outputLineList.Add("autorun.exe	       = 3") ;
			outputLineList.Add("autorun.dat	       = 3") ;
			outputLineList.Add("autouser.dat       = 3") ;
			outputLineList.Add("autocab.exe	       = 3") ;
			outputLineList.Add("bootstrap.exe	   = 3") ;
			outputLineList.Add("flash_autorun.dat  = 3") ;

			//{
			outputLineList.Add( baseProjectAppName + ".exe=5" ) ;
			if ( configFileExists ) outputLineList.Add( "BaseConfig.bin=8" ) ;
			outputLineList.Add( "OpenNETCF.dll=2" ) ;
			outputLineList.Add( "OpenNETCF.Net.dll=2" ) ;
			outputLineList.Add( "Rebex.Net.Ftp.dll=2" ) ;
			outputLineList.Add( "Rebex.Net.ProxySocket.dll=2" ) ;
			outputLineList.Add( "Rebex.Net.SecureSocket.dll=2" ) ;
			outputLineList.Add( "Rebex.Security.dll=2" ) ;
			outputLineList.Add( "Intermec.DataCollection.dll=6" ) ;
			outputLineList.Add( "itcscan.dll=6") ;
			outputLineList.Add( "psuuid0c.dll=6") ;
			outputLineList.Add( "AirlineSoftware.dll=7") ;
			//}
			
			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("; Output directories for files & shortcuts") ;
			outputLineList.Add("") ;
			outputLineList.Add("[DestinationDirs]") ;
			outputLineList.Add("") ;
			outputLineList.Add("Cabs = 0, %SDMMC%%CABS%") ;
			outputLineList.Add("Start1 = 0, %Flash%%OTH%") ;
			outputLineList.Add("Start2  = 0, %SDMMC%%OTH%") ;

			//{
			outputLineList.Add( "Shortcuts=0,%CE2%\\Start Menu" ) ;
			outputLineList.Add( "Files." + processorType + "=0,%InstallDir%" ) ;
			//}

			outputLineList.Add("") ;
			outputLineList.Add("[Cabs]") ;
			outputLineList.Add("") ;

			foreach (object item in carriers)
			{
				outputLineList.Add("DependentFiles." + item.ToString() + ".cab,,,0x40000000") ;
			}

//			outputLineList.Add("netcf.core.ppc3.arm.cab,,,0x40000000") ;
			outputLineList.Add(baseProjectAppName + ".cab,,,0x40000000") ;
//			outputLineList.Add("") ;
			outputLineList.Add("[Start1]") ;
			outputLineList.Add("") ;
			outputLineList.Add("autorun.exe,,,0x40000000") ;
			outputLineList.Add("autorun.dat,flash_autorun.dat,,0x40000000") ;
			outputLineList.Add("bootstrap.exe,,,0x40000000") ;
			outputLineList.Add("") ;
			outputLineList.Add("[Start2]") ;
			outputLineList.Add("") ;
			outputLineList.Add("autorun.exe,,,0x40000000") ;
			outputLineList.Add("autorun.dat,,,0x40000000") ;
			outputLineList.Add("autocab.exe,,,0x40000000") ;
			outputLineList.Add("autouser.dat,,,0x40000000") ;

			//{	
			outputLineList.Add( "" ) ;
			outputLineList.Add( "[Files." + processorType + "]" ) ;
			outputLineList.Add( baseProjectAppName + ".exe,,,0" ) ;
			if ( configFileExists ) outputLineList.Add( "BaseConfig.bin,,,0x40000000" ) ;
			outputLineList.Add( "OpenNETCF.dll,,,0x40000000" ) ;
			outputLineList.Add( "OpenNETCF.Net.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Net.ProxySocket.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Net.Ftp.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Net.SecureSocket.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Security.dll,,,0x40000000" ) ;
			outputLineList.Add( "Intermec.DataCollection.dll,,,0x40000000" ) ;
			outputLineList.Add( "itcscan.dll,,,0x40000000" ) ;
			outputLineList.Add( "psuuid0c.dll,,,0x40000000" ) ;
			outputLineList.Add( "AirlineSoftware.dll,,,0x40000000" ) ;
			outputLineList.Add( "" ) ;
			outputLineList.Add( "[Shortcuts]" ) ;
			outputLineList.Add( baseProjectAppName + ",0," + baseProjectAppName + ".exe,%CE11%" ) ;
			outputLineList.Add( "" ) ;
			outputLineList.Add( "[RegSettings.All]" ) ;
			outputLineList.Add("HKLM,\"Hardware\\Devicemap\\Keybd\",\"vkeyGold\",0x00000001," +
				"00,00,0B,05,02,03,00,00,04,03,BE,00,34,00,00,00," +
				"09,01,00,00,BF,00,03,02,00,00,BD,00,75,00,72,00," +
				"21,00,01,02,00,00,76,00,09,00,73,00,38,01,00,00," +
				"35,00,00,00,BB,01,09,05,22,00,32,01,36,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,07,05,01,05,03,05,02,05");
			outputLineList.Add("HKLM,\"Hardware\\Devicemap\\Keybd\\ALPHA\",\"vkeyGold\",0x00000001," +
				"00,00,0B,05,02,03,00,00,04,03,BE,00,34,00,00,00," +
				"09,01,00,00,BF,00,03,02,00,00,BD,00,75,00,72,00," +
				"21,00,01,02,00,00,76,00,09,00,73,00,38,01,00,00," +
				"35,00,00,00,BB,01,09,05,22,00,32,01,36,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,07,05,01,05,03,05,02,05");
			//}


			Utilities.DeleteLocalFile( migrateFileInfFilePath ) ;

			StreamWriter outputFileStream = new StreamWriter( migrateFileInfFilePath ) ;

			foreach ( string outputLine in outputLineList )
			{
				outputFileStream.WriteLine(outputLine) ;
			}

			outputFileStream.Close() ;

			buildOutputForm.addLines("    ++ .inf file \"" + migrateFileInfFilePath + "\" created. ++\n ") ;
			buildOutputForm.addLines(" ") ;
			buildOutputForm.addLines("    ++ Generating cab file '" + baseProjectAppName + ".cab' using CabWiz") ;
			
			string command = @"C:\Program Files\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\Windows CE\..\bin\..\bin\cabwiz.exe" ;
			string parameters = "\"" + migrateFileInfFilePath + "\"" + " /dest \"" + Globals.workingFilesDirectory + "\" /err \"" +  migrateLogFilePath + "\" /cpu " + processorType ;
			string[] commandOutput = new string[2] ;

			buildOutputForm.addLines(parameters, "        ") ;

			// Utilities.DeleteLocalFile( migrateTempCabFilePath ) ;

			Utilities.executeShell(command, parameters, commandOutput) ;

			if ( Utilities.isNonNullString(commandOutput[0]) ) this.buildOutputForm.addLines(commandOutput[0], "        ") ;
			if ( Utilities.isNonNullString(commandOutput[1]) ) this.buildOutputForm.addLines(commandOutput[1], "        ") ;

			bool cabWizError = false ;
			string cabWizErrorLine = null ;

			if ( File.Exists(migrateLogFilePath) )
			{
				StreamReader logFileInputStream = new StreamReader(migrateLogFilePath) ;

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

			string migrateFilesTempCabFilePath = Globals.workingFilesDirectory + @"\" + systemProfile.deviceType + "_Migration." + systemProfile.processorType + ".Cab" ;
 			
			if ( ! File.Exists( migrateFilesTempCabFilePath ) )
 			{
 				throw new Exception("Build of base project cab file failed: no cab file created.") ;
 			}

			string migrateFilesCabFilePath = outputCabFilePath.Trim() ;
			string migrateFilesCabFileDir = Path.GetDirectoryName(migrateFilesCabFilePath) ;
			
			if ( !Directory.Exists(migrateFilesCabFileDir) )
			{
				Directory.CreateDirectory(migrateFilesCabFileDir) ;
			}

			Utilities.MoveLocalFile(migrateFilesTempCabFilePath, migrateFilesCabFilePath) ;

			this.buildOutputForm.addLines(" ") ;
			this.buildOutputForm.addLines("+++ Migration Cab File \"" + migrateFilesCabFilePath + "\" successfully created.") ;

			return true ;
		}
	}

}
