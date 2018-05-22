using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace sb
{
	/// <summary>
	/// Summary description for DependentFileBuilder.
	/// </summary>
	public class DependentFileBuilder
	{
		private SystemBuilder systemBuilder ;
		private SystemProfile systemProfile ;


		private string dependentFilesInfFilePath ;
		private string dependentFilesCabFilePath ;


		private BuildUpdateOutputForm buildOutputForm ;



		public DependentFileBuilder(SystemBuilder inputSystemBuilder, SystemProfile inputSystemBuilderProfile)
		{
			systemBuilder = inputSystemBuilder ;
			systemProfile = inputSystemBuilderProfile ;
		}

		public bool buildDependentFiles(BuildUpdateOutputForm inputBuildOutputForm)
		{
			buildOutputForm = inputBuildOutputForm ;
			ArrayList carriers = this.systemProfile.getCarriers;

			if ( systemProfile.processorType != "ARMV4")
			{
				MessageBox.Show("Do not know how to build Airline Software Dll for processors other than ARMV4") ;
				throw new Exception("Do not know how to build Airline Software Dll for processors other than ARMV4") ;
			}

			foreach (object item in carriers)
			{
				dependentFilesInfFilePath = Globals.infFilesDirectory + @"\" + this.systemProfile.deviceType + "_DependentFiles." + item.ToString() + ".inf";
				dependentFilesCabFilePath = Globals.buildFilesDirectory + @"\DependentFiles." + item.ToString() + ".cab" ;

				try
				{
					buildDependentFilesCabFiles(item.ToString()) ;
				}
				catch (Exception ex2)
				{
					MessageBox.Show("Build of dependant cab file failed: " + ex2.Message) ;
					return false ;
				}
			}

			return true ;
		}

		private void buildDependentFilesCabFiles(String carrier)
		{
			ArrayList outputLineList = new ArrayList() ;

			string deviceType = systemProfile.deviceType ;
			string processorType = this.systemProfile.processorType ;
			//string user = this.systemProfile.user ;

			string strCopyFiles = "CopyFiles = ";
			int i;
            
			string dependentFilesTempCabFilePath = Globals.workingFilesDirectory + @"\" + deviceType + "_DependentFiles." + this.systemProfile.processorType + ".CAB" ;
			string dependentFilesLogFilePath = Globals.workingFilesDirectory + @"\" + deviceType + "_DependentFiles.log" ;

			buildOutputForm.addLines("+++ Building dependent files cab file +++") ;
			buildOutputForm.addLines("     ++ Creating .inf file \"" + dependentFilesInfFilePath + "\" ++") ;

			outputLineList.Add("[Version]") ;
			outputLineList.Add("Signature=\"$Windows NT$\"") ;
			outputLineList.Add("Provider=\"Aviation Software, Inc.\"") ;
			outputLineList.Add("CESignature=\"$Windows CE$\"") ;
			outputLineList.Add("") ;
			outputLineList.Add("[CEStrings]") ;
			outputLineList.Add("AppName=\"TagTrak Support Files\"") ;
//			outputLineList.Add("InstallDir=%CE1%\\%AppName%") ;
			
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

			outputLineList.Add("") ;
			outputLineList.Add("[CEDevice]") ;
			outputLineList.Add("VersionMin=3.00") ;
			outputLineList.Add("VersionMax=100") ;
			outputLineList.Add("") ;
			outputLineList.Add("[Strings]") ;
			outputLineList.Add("") ;

			if (systemProfile.deviceType == "Intermec") 
			{
				outputLineList.Add("Flash 	= \"\\SDMMC Disk\\\"") ;
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add("Flash 	= \"\\Storage Card\\\"") ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				outputLineList.Add("Flash 	= \"\\Storage Card\\\"") ;
			}

			outputLineList.Add("Windows = %CE2%") ;
			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[DefaultInstall]") ;
			outputLineList.Add("") ;

			strCopyFiles += "Config" + ",";

			outputLineList.Add(strCopyFiles + "Fonts") ;

			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("[SourceDisksNames]") ;
			outputLineList.Add("") ;
			outputLineList.Add("1 =, \"Config\" ,, \"" + Globals.configFilesDirectory   + "\"") ;
			outputLineList.Add("2 =, \"Common1\",, \"" + Globals.processorSpecificFilesDirectory    + "\"") ;
			outputLineList.Add("") ;
			outputLineList.Add("[SourceDisksFiles]") ;
			outputLineList.Add("") ;

            outputLineList.Add(carrier + "Config.bin=1");

			outputLineList.Add("ARIALN.TTF=2");
			outputLineList.Add("lucon.ttf=2");
			outputLineList.Add("") ;
			outputLineList.Add(";==================================================") ;
			outputLineList.Add("") ;
			outputLineList.Add("; Output directories for files & shortcuts") ;
			outputLineList.Add("") ;
			outputLineList.Add("[DestinationDirs]") ;
			outputLineList.Add("") ;

			outputLineList.Add("Config" + @" = 0, %Flash%carriers\" + carrier + @"\TagTrakConfig");

			outputLineList.Add("Fonts = 0, %CE15%") ;
			outputLineList.Add("") ;

			outputLineList.Add("[Config]") ;
			outputLineList.Add("ScannerConfig.bin," + carrier + "Config.bin" + ",,0x20000000") ;

			outputLineList.Add("") ;

			outputLineList.Add("[Fonts]") ;
			outputLineList.Add("") ;
			outputLineList.Add("ARIALN.TTF,,,0x00000010") ;
			outputLineList.Add("lucon.ttf,,,0x00000010") ;

			Utilities.DeleteLocalFile( dependentFilesInfFilePath ) ;

			StreamWriter outputFileStream = new StreamWriter( dependentFilesInfFilePath ) ;

			foreach ( string outputLine in outputLineList )
			{
				outputFileStream.WriteLine(outputLine) ;
			}

			outputFileStream.Close() ;

			buildOutputForm.addLines("    ++ .inf file \"" + dependentFilesInfFilePath + "\" created. ++\n ") ;
			buildOutputForm.addLines("    ++ Generating cab file 'DependentFiles.cab' using CabWiz") ;

			string command = @"C:\Program Files\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\Windows CE\..\bin\..\bin\cabwiz.exe" ;
			string parameters = "\"" + dependentFilesInfFilePath + "\"" + " /dest \"" + Globals.workingFilesDirectory + "\" /err \"" +  dependentFilesLogFilePath + "\" /cpu " + processorType ;
			string[] commandOutput = new string[2] ;

			buildOutputForm.addLines(parameters, "        ") ;

			Utilities.DeleteLocalFile( dependentFilesTempCabFilePath ) ;

			Utilities.executeShell(command, parameters, commandOutput) ;

			if ( Utilities.isNonNullString(commandOutput[0]) ) this.buildOutputForm.addLines(commandOutput[0], "        ") ;
			if ( Utilities.isNonNullString(commandOutput[1]) ) this.buildOutputForm.addLines(commandOutput[1], "        ") ;

			bool cabWizError = false ;
			string cabWizErrorLine = null ;

			if ( File.Exists(dependentFilesLogFilePath) )
			{
				StreamReader logFileInputStream = new StreamReader(dependentFilesLogFilePath) ;

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

			if ( ! File.Exists( dependentFilesTempCabFilePath ) )
			{
				throw new Exception("Build of base project cab file failed: no cab file created.") ;
			}

			Utilities.MoveLocalFile(dependentFilesTempCabFilePath, dependentFilesCabFilePath) ;
			Utilities.SetFileToReadOnly(dependentFilesCabFilePath) ;
		}

	}
}
