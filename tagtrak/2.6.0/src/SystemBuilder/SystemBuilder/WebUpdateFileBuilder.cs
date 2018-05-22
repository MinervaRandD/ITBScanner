using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace sb
{
	/// <summary>
	/// Summary description for WebUpdateFileBuilder.
	/// A modification from DistributionFileBuilder, except for only containing TagTrak.cab for now.
	/// </summary>
	public class WebUpdateFileBuilder
	{
		private SystemBuilder systemBuilder ;
		private SystemProfile systemProfile ;

		private string baseProjectAppName ;

		private string webUpdateFileInfFilePath ;
		private string webUpdateFileCabFilePath ;
		private string webUpdateLogFilePath ;

		private BuildUpdateOutputForm buildOutputForm ;

		public WebUpdateFileBuilder(SystemBuilder inputSystemBuilder, SystemProfile inputSystemBuilderProfile)
		{
			systemBuilder = inputSystemBuilder ;
			systemProfile = inputSystemBuilderProfile ;
		}

		public bool buildWebUpdateFile(BuildUpdateOutputForm inputBuildOutputForm, string outputCabFilePath)
		{
			buildOutputForm = inputBuildOutputForm ;

			baseProjectAppName = systemProfile.applicationName ;

			ArrayList carriers = this.systemProfile.getCarriers;

			webUpdateFileInfFilePath = Globals.infFilesDirectory + @"\" + this.systemProfile.deviceType + "_WebUpdate.inf" ;
			webUpdateFileCabFilePath = systemProfile.webUpdateCabFilePath ;
			webUpdateLogFilePath     = Globals.workingFilesDirectory + @"\" + Path.GetFileNameWithoutExtension(systemProfile.webUpdateCabFilePath) + ".log" ;
			
			ArrayList outputLineList = new ArrayList() ;

			string deviceType = systemProfile.deviceType ;

			string processorType = this.systemProfile.processorType ;
			//string user = this.systemProfile.user ;

			buildOutputForm.addLines(" ") ;
			buildOutputForm.addLines("+++ Building WebUpdate files cab file +++") ;
			buildOutputForm.addLines("     ++ Creating .inf file for \"" + webUpdateFileCabFilePath + "++") ;
			
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
//			outputLineList.Add("InstallDir = %CE1%\\%AppName%") ;
			
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

			outputLineList.Add("AppName = " + baseProjectAppName + " Upgrader") ;
			outputLineList.Add("") ;
			outputLineList.Add("[Strings]") ;
			outputLineList.Add("") ;

			if (systemProfile.deviceType == "Intermec") 
			{
				outputLineList.Add("SDMMC  = \"\\SDMMC Disk\\\"") ;
				outputLineList.Add("Flash  = \"\\Flash File Store\\\"") ;
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("SDMMC  = \"\\Storage Card\\\"") ;
				outputLineList.Add("Flash  = \"\\IPSM\\\"") ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				outputLineList.Add("SDMMC  = \"\\Storage Card\\\"") ;
				outputLineList.Add("Flash  = \"\\Application\\\"") ;
			}

			outputLineList.Add("CABS   = \"cabfiles\"") ;
			outputLineList.Add("OTH	   = \"2577\"") ;
			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[DefaultInstall]") ;
			outputLineList.Add("") ;
			outputLineList.Add("CopyFiles	= Cabs") ;
			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[SourceDisksNames]") ;
			outputLineList.Add("") ;
			outputLineList.Add("1 =, \"BuildSource\" ,, \"" + Globals.buildFilesDirectory    + "\"") ;
			outputLineList.Add("") ;
			outputLineList.Add("[SourceDisksFiles]") ;
			outputLineList.Add("") ;
			outputLineList.Add(baseProjectAppName + ".cab = 1") ;

			foreach (object item in carriers)
			{                
				outputLineList.Add("DependentFiles." + item.ToString() + ".cab = 1") ;
			}

			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("; Output directories for files & shortcuts") ;
			outputLineList.Add("") ;
			outputLineList.Add("[DestinationDirs]") ;
			outputLineList.Add("") ;
			outputLineList.Add("Cabs = 0, %SDMMC%%CABS%") ;
			outputLineList.Add("") ;
			outputLineList.Add("[Cabs]") ;
			outputLineList.Add("") ;
			outputLineList.Add(baseProjectAppName + ".cab,,,0x40000000") ;

			foreach (object item in carriers)
			{
				outputLineList.Add("DependentFiles." + item.ToString() + ".cab,,,0x40000000") ;
			}

			outputLineList.Add("") ;

			Utilities.DeleteLocalFile( webUpdateFileInfFilePath ) ;

			StreamWriter outputFileStream = new StreamWriter( webUpdateFileInfFilePath ) ;

			foreach ( string outputLine in outputLineList )
			{
				outputFileStream.WriteLine(outputLine) ;
			}

			outputFileStream.Close() ;

			buildOutputForm.addLines("    ++ .inf file \"" + webUpdateFileInfFilePath + "\" created. ++\n ") ;
			buildOutputForm.addLines(" ") ;
			buildOutputForm.addLines("    ++ Generating cab file '" + baseProjectAppName + ".cab' using CabWiz") ;
			
			string command = @"C:\Program Files\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\Windows CE\..\bin\..\bin\cabwiz.exe" ;
			string parameters = "\"" + webUpdateFileInfFilePath + "\"" + " /dest \"" + Globals.workingFilesDirectory + "\" /err \"" +  webUpdateLogFilePath + "\" /cpu " + processorType ;
			string[] commandOutput = new string[2] ;

			buildOutputForm.addLines(parameters, "        ") ;

			// Utilities.DeleteLocalFile( webUpdateTempCabFilePath ) ;

			Utilities.executeShell(command, parameters, commandOutput) ;

			if ( Utilities.isNonNullString(commandOutput[0]) ) this.buildOutputForm.addLines(commandOutput[0], "        ") ;
			if ( Utilities.isNonNullString(commandOutput[1]) ) this.buildOutputForm.addLines(commandOutput[1], "        ") ;

			bool cabWizError = false ;
			string cabWizErrorLine = null ;

			if ( File.Exists(webUpdateLogFilePath) )
			{
				StreamReader logFileInputStream = new StreamReader(webUpdateLogFilePath) ;

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

			string webUpdateFilesTempCabFilePath = Globals.workingFilesDirectory + @"\" + systemProfile.deviceType + "_WebUpdate." + systemProfile.processorType + ".Cab" ;
 			
			if ( ! File.Exists( webUpdateFilesTempCabFilePath ) )
 			{
 				throw new Exception("Build of base project cab file failed: no cab file created.") ;
 			}

			string webUpdateFilesCabFilePath = outputCabFilePath.Trim() ;
			string webUpdateFilesCabFileDir = Path.GetDirectoryName(webUpdateFilesCabFilePath) ;
			
			if ( !Directory.Exists(webUpdateFilesCabFileDir) )
			{
				Directory.CreateDirectory(webUpdateFilesCabFileDir) ;
			}

			Utilities.MoveLocalFile(webUpdateFilesTempCabFilePath, webUpdateFilesCabFilePath) ;

			this.buildOutputForm.addLines(" ") ;
			this.buildOutputForm.addLines("+++ WebUpdate Cab File \"" + webUpdateFilesCabFilePath + "\" successfully created.") ;

			return true ;
		}
	}

}
