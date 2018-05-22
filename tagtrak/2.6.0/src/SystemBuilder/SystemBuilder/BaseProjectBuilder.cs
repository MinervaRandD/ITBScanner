using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace sb
{
	/// <summary>
	/// Summary description for BuildBaseProject.
	/// </summary>
	public class BaseProjectBuilder
	{
		private string[] baseProjectExtensionSet = { ".cs", ".vb", ".resx", ".vbdproj", ".dll" } ;

		private SystemBuilder systemBuilder ;
		private SystemProfile systemProfile ;

		private string baseProjectInfFilePath ;
		private string baseProjectExeFilePath ;
		private string baseProjectCabFilePath ;

		private string[] airlineSoftwareDllExtensionSet = { ".h", ".cpp", ".lib", ".vcp", ".vcw" } ;
		private string airlineSoftwareDllDirectory ;
		private string airlineSoftwareProjDefnFilePath ;
		private string airlineSoftwareDllFileName ;
		private string airlineSoftwareDllFilePath ;

		private string baseProjectAppName ;

		private BuildUpdateOutputForm buildOutputForm ;

		public BaseProjectBuilder(SystemBuilder inputSystemBuilder, SystemProfile inputSystemBuilderProfile)
		{
			systemBuilder = inputSystemBuilder ;
			systemProfile = inputSystemBuilderProfile ;
		}
		
		public bool buildBaseProject(BuildUpdateOutputForm inputBuildOutputForm)
		{
			buildOutputForm = inputBuildOutputForm ;

			airlineSoftwareDllDirectory = Path.GetDirectoryName(systemProfile.airlineSoftwareDllFile);
			airlineSoftwareDllFileName = Path.GetFileNameWithoutExtension(systemProfile.airlineSoftwareDllFile) ;
			airlineSoftwareDllFilePath = airlineSoftwareDllDirectory + @"\" + airlineSoftwareDllFileName + ".dll" ;
			airlineSoftwareProjDefnFilePath = systemProfile.AirlineSoftwareProj;
			
			//We don't need to rebuilt AirlineSoftware.dll each time
//			buildOutputForm.addLines(" ") ;
//			buildOutputForm.addLines("+++ Building dependent files +++") ;

//			try
//			{
//				rebuildAirlineSoftwareDll() ;
//			}
//
//			catch (Exception ex1)
//			{
//				MessageBox.Show("Build of library files failed: " + ex1.Message) ;
//				return false ;
//			}


			if ( Utilities.isNullString( systemProfile.applicationName ) )
			{
				MessageBox.Show("An application name must be specified in order to perform build.") ;
				return false ;
			}

			baseProjectAppName = Path.GetFileNameWithoutExtension(this.systemProfile.applicationName) ;

			baseProjectExeFilePath = Globals.buildFilesDirectory + @"\" + baseProjectAppName + ".exe" ;
			baseProjectInfFilePath = Globals.infFilesDirectory   + @"\" + this.systemProfile.deviceType + "_" + baseProjectAppName + ".inf" ;
			baseProjectCabFilePath = Globals.buildFilesDirectory + @"\" + baseProjectAppName + ".cab" ;

			buildOutputForm.addLines("+++ Building base project: " + this.systemProfile.baseProjectDefinitionFile + " +++") ;

			//Modified by MX
//			try
//			{
//				updateBaseConfigParms() ;
//			}
//			
//			catch (Exception ex4)
//			{
//				MessageBox.Show("Attempt to update base configuration parameters failed:\n" + ex4.Message) ;
//				return false ;
//			}

			try
			{
				rebuildBaseProject() ;
			}
		
			catch (Exception ex1)
			{
				MessageBox.Show("Attempt to build base project failed:\n" + ex1.Message) ;
				return false ;
			}
//
//			try
//			{
//				buildBaseConfigurationFile() ;
//			}
//
//			catch (Exception ex3)
//			{
//				MessageBox.Show("Attempt to build base project failed:\n" + ex3.Message) ;
//				return false ;
//			}

			try
			{
				 buildBaseProjectCabFile() ;
			}

			catch (Exception ex2)
			{
				MessageBox.Show("Attempt to build base project cab file failed:\n" + ex2.Message) ;
				return false ;
			}

			return true ;
		}

		
		// similiar to buildBaseProject with the difference of copying all needed files into
		// a temporary folder instead of cab file
		public bool buildBaseProjectForMigrate(BuildUpdateOutputForm inputBuildOutputForm)
		{
			buildOutputForm = inputBuildOutputForm ;

			airlineSoftwareDllDirectory = Path.GetDirectoryName(systemProfile.airlineSoftwareDllFile);
			airlineSoftwareDllFileName = Path.GetFileNameWithoutExtension(systemProfile.airlineSoftwareDllFile) ;
			airlineSoftwareDllFilePath = airlineSoftwareDllDirectory + @"\" + airlineSoftwareDllFileName + ".dll" ;
			airlineSoftwareProjDefnFilePath = systemProfile.AirlineSoftwareProj;

			buildOutputForm.addLines(" ") ;
			buildOutputForm.addLines("+++ Building dependent files for migrate+++") ;

			try
			{
				rebuildAirlineSoftwareDll() ;
			}

			catch (Exception ex1)
			{
				MessageBox.Show("Build of library files failed: " + ex1.Message) ;
				return false ;
			}


			if ( Utilities.isNullString( systemProfile.applicationName ) )
			{
				MessageBox.Show("An application name must be specified in order to perform build.") ;
				return false ;
			}

			baseProjectAppName = Path.GetFileNameWithoutExtension(this.systemProfile.applicationName) ;

			baseProjectExeFilePath = Globals.buildFilesDirectory + @"\" + baseProjectAppName + ".exe" ;

			buildOutputForm.addLines("+++ Building base project for migrate: " + this.systemProfile.baseProjectDefinitionFile + " +++") ;

			//Modified by MX
//			try
//			{
//				updateBaseConfigParms() ;
//			}
//			
//			catch (Exception ex4)
//			{
//				MessageBox.Show("Attempt to update base configuration parameters failed:\n" + ex4.Message) ;
//				return false ;
//			}

			try
			{
				rebuildBaseProject() ;
			}
		
			catch (Exception ex1)
			{
				MessageBox.Show("Attempt to build base project for migrate failed:\n" + ex1.Message) ;
				return false ;
			}

			return true ;
		}
		
		private bool IsCommentLine(string line)
		{
			line = line.Trim() ;

			if ( line.StartsWith("'") || line.StartsWith("#") ) return true ;

			return false ;
		}

		private bool IsUserLine(string line)
		{
			line = line.Trim() ;

			if ( line.StartsWith("Public user As String =") ) return true ;

			return false ;
		}

		private string parseUserFromInputLine(string line)
		{
			line = line.Trim() ;

			if ( ! line.StartsWith("Public user As String =") ) return null ;

			return line.Substring(23).Trim() ;
		}

		
		private string parseVersionFromInputLine(string line)
		{
			line = line.Trim() ;

			if ( ! line.StartsWith("Public myVersion As String =") ) return null ;

			return line.Substring(28).Trim() ;
		}

		private bool IsMyVersionLine(string line)
		{
			line = line.Trim() ;

			if ( line.StartsWith("Public myVersion As String =") ) return true ;

			return false ;
		}

		//Modified by MX
		/*
		private void updateBaseConfigParms()
		{
			string baseProjectDefinitionFile = systemProfile.baseProjectSourceDirectory ;

			if ( Utilities.isNullString( systemProfile.baseProjectDefinitionFile ) )
			{
				throw new Exception("No base project file specified.") ;
			}

			string baseConfigParmsFile = baseProjectDefinitionFile + @"\TagTrakBaseConfigParms.vb" ;

			if ( ! File.Exists(baseConfigParmsFile) ) return ;

			bool baseConfigFileChanged = false ;
			bool userLineFound = false ;
			bool myVersionLineFound = false ;

			ArrayList inputFile = new ArrayList() ;

			try
			{
				Utilities.readFileIntoArrayList(baseConfigParmsFile, inputFile) ;
			}

			catch (Exception ex2)
			{
				throw new Exception("Read on base config file failed: " + ex2.Message, ex2) ;
			}

			ArrayList outputFile = new ArrayList() ;

			foreach ( string inputLine in inputFile)
			{
				if ( IsCommentLine(inputLine) ) { outputFile.Add(inputLine) ; continue ; }

				if ( IsUserLine(inputLine) )
				{
					string user = parseUserFromInputLine(inputLine) ;

					if ( user != systemProfile.user )
					{
						string userLine = "    Public user As String = \"" + systemProfile.user + "\"" ;
						outputFile.Add(userLine) ;

						userLineFound = true ;
						baseConfigFileChanged = true ;
					}

					else outputFile.Add(inputLine) ;

					continue ;
				}

				if ( IsMyVersionLine(inputLine) )
				{
					string version = parseVersionFromInputLine(inputLine) ;

					if ( version != systemProfile.release )
					{
						string versionLine = "\t" + "Public myVersion As String = \"" + systemProfile.release + "\"" ;
						outputFile.Add(versionLine) ;

						myVersionLineFound = true ;
						baseConfigFileChanged = true ;
					}

					else outputFile.Add(inputLine) ;

					continue ;
				}

				else
				{
					outputFile.Add(inputLine) ;
				}
			}

			if ( ! userLineFound )
			{
				string userLine = "    Public user As String = \"" + systemProfile.user + "\"" ;
				outputFile.Add(userLine) ;

				baseConfigFileChanged = true ;
			}

			if ( ! myVersionLineFound )
			{
				string versionLine = "        Public myVersion As String = \"" + systemProfile.release + "\"" ;
				outputFile.Add(versionLine) ;

				baseConfigFileChanged = true ;
			}
			
			if ( ! baseConfigFileChanged ) return ;

			Utilities.writeFileFromArrayList(baseConfigParmsFile, outputFile) ;
		}
*/
		private bool baseProjectIsOutOfDate()
		{
			string baseProjectDefinitionFile = systemProfile.baseProjectDefinitionFile ;

			if ( Utilities.isNullString( systemProfile.baseProjectDefinitionFile ) )
			{
				throw new Exception("No base project file specified.") ;
			}

			string baseProjectDefinitionDirectory = Path.GetDirectoryName(baseProjectDefinitionFile) ;

			if ( ! Directory.Exists(baseProjectDefinitionDirectory) )
			{
				throw new Exception("Base project directory '" + baseProjectDefinitionDirectory + "' does not exist.") ;
			}

			string baseProjectExeFile = systemProfile.baseProjectExeFile ;

			if ( Utilities.isNullString( baseProjectExeFile ) )
			{
				return true ;
			}

			string baseProjectExeDirectory = Path.GetDirectoryName(baseProjectExeFile) ;

			if ( ! Directory.Exists(baseProjectExeDirectory) )
			{
				throw new Exception("Base project exe file directory '" + baseProjectExeDirectory + "' does not exist.") ;
			}

			if ( ! File.Exists(baseProjectExeFile) ) return true ;

			DateTime exeFileDateTime = File.GetLastWriteTime(baseProjectExeFile) ;

			DirectoryInfo baseProjectDirectoryInfo = new DirectoryInfo(baseProjectDefinitionDirectory) ;

			FileInfo[] fileList = baseProjectDirectoryInfo.GetFiles() ;

			foreach ( FileInfo fileInfo in fileList )
			{
				string extension = Path.GetExtension(fileInfo.Name) ;

				if ( Array.IndexOf(baseProjectExtensionSet, extension) < 0 ) continue ;

				if ( DateTime.Compare(fileInfo.LastWriteTime, exeFileDateTime) > 0 ) return true ;
			}

			return false ;
		}

		private void buildBaseProjectCabFile()
		{

			ArrayList outputLineList = new ArrayList() ;
			//One Time: MX
			ArrayList carriers = this.systemProfile.getCarriers;
			string strCopyFiles = "CopyFiles = ";
			int i;

			string processorType = this.systemProfile.processorType ;
			string deviceType = this.systemProfile.deviceType ;
			string sourceExeFilePath = this.systemProfile.baseProjectExeFile ;
			string sourcePath = Path.GetDirectoryName(sourceExeFilePath) ;
			string exeFileName = Path.GetFileNameWithoutExtension(sourceExeFilePath) ;
			string sourcePdbFilePath = sourcePath + @"\" + exeFileName + ".pdb" ;

			string appExeFilePath = Globals.workingFilesDirectory + @"\" + baseProjectAppName + ".exe" ;
			string appPdbFilePath = Globals.workingFilesDirectory+ @"\" + baseProjectAppName + ".pdb" ;

			string baseProjectTempCabFilePath = Globals.workingFilesDirectory + @"\" + deviceType + "_" + baseProjectAppName + "." + systemProfile.processorType + ".CAB" ;
			string baseProjectLogFilePath     = Globals.workingFilesDirectory + @"\" + Path.GetFileNameWithoutExtension(baseProjectInfFilePath) + ".log" ;
			string baseConfigFileFullName     = Globals.configFilesDirectory + @"\BaseConfig.bin" ;

			bool pdbFileExists = File.Exists(sourcePdbFilePath) ;
			bool configFileExists = File.Exists(baseConfigFileFullName) ;

			if ( sourceExeFilePath != appExeFilePath )
			{
				Utilities.CopyLocalFile(sourceExeFilePath, appExeFilePath) ;
			}

			if ( pdbFileExists && sourcePdbFilePath != appPdbFilePath )
			{
				Utilities.CopyLocalFile(sourcePdbFilePath, appPdbFilePath) ;
			}

			buildOutputForm.addLines("+++ Building base project cab file +++") ;
			buildOutputForm.addLines("    ++ Creating .inf file \"" + baseProjectInfFilePath + "++") ;

			Application.DoEvents() ;

			outputLineList.Add( "[Version]" ) ;
			outputLineList.Add( "Signature=\"$Windows NT$\"" ) ;
			outputLineList.Add( "Provider=\"Aviation Software, Inc.\"" ) ;
			outputLineList.Add( "CESignature=\"$Windows CE$\"" ) ;
			outputLineList.Add( "" ) ;
			outputLineList.Add( "[CEStrings]" ) ;
			outputLineList.Add( "AppName=\"" + baseProjectAppName + "\"" ) ;
			outputLineList.Add( "InstallDir=%CE1%\\%AppName%" ) ;
			outputLineList.Add( "" ) ;
			outputLineList.Add( "[CEDevice]" ) ;
			outputLineList.Add( "UnsupportedPlatforms = \"HPC\",\"Jupiter\",\"Smartphone\""); // make a platform independent build
			outputLineList.Add( "" ) ;

			//One Time: MX
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

			outputLineList.Add("") ;


			outputLineList.Add( "[DefaultInstall]" ) ;
			outputLineList.Add( "CEShortcuts=Shortcuts" ) ;
			outputLineList.Add( "addreg= regsettings.all" ) ;
			outputLineList.Add( "" ) ;
			outputLineList.Add( "[DefaultInstall." + processorType + "]" ) ;

			//One Time: MX
			for (i = 1; i <= carriers.Count; i++)
			{
				strCopyFiles += "Config" + i + ",";
			}

			//outputLineList.Add( "CopyFiles=Files." + processorType ) ;
			outputLineList.Add( strCopyFiles + "Files." + processorType ) ;

			outputLineList.Add( "" ) ;
			outputLineList.Add( "[SourceDisksNames]" ) ;
			outputLineList.Add( "1=,\"Common1\",,\"" + Globals.processorSpecificFilesDirectory   + "\"" ) ;
			outputLineList.Add( "2=,\"Common2\",,\"" + Globals.workingFilesDirectory + "\"" ) ;
			outputLineList.Add( "3=,\"Common3\",, \"" + Globals.deviceSpecificFilesDirectory + "\"") ;
			outputLineList.Add( "4=,\"Library\",, \"" + airlineSoftwareDllDirectory + "\"") ;
			if ( configFileExists ) outputLineList.Add( "5=,\"Common2\",,\"" + Globals.configFilesDirectory + "\"" ) ;
			outputLineList.Add( "" ) ;

			//One Time: MX
			outputLineList.Add( "6=,\"ConfigFiles\",,\"" + Globals.configFilesDirectory + "\"");

			outputLineList.Add( "[SourceDisksFiles]" ) ;
			outputLineList.Add( baseProjectAppName + ".exe=2" ) ;
			if ( configFileExists ) outputLineList.Add( "BaseConfig.bin=5" ) ;
			outputLineList.Add( "OpenNETCF.dll=1" ) ;
			outputLineList.Add( "OpenNETCF.Net.dll=1" ) ;
			outputLineList.Add( "Rebex.Net.Ftp.dll=1" ) ;
			outputLineList.Add( "Rebex.Net.Time.dll=1" ) ;
			outputLineList.Add( "Rebex.Net.ProxySocket.dll=1" ) ;
			outputLineList.Add( "Rebex.Net.SecureSocket.dll=1" ) ;
			outputLineList.Add( "Rebex.Security.dll=1" ) ;
			outputLineList.Add( "SharpZipLib.dll=1" ) ;

			//Changed the AirlineSoftware.dll from device specific folder
			if (systemProfile.deviceType == "Intermec") 
			{
				outputLineList.Add( "Intermec.DataCollection.dll=3" ) ;
				outputLineList.Add( "itcscan.dll=3") ;
				outputLineList.Add( "psuuid0c.dll=3") ;
				outputLineList.Add( "AirlineSoftware.dll=3") ;
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add( "HHP.DataCollection.Common.dll=3" ) ;
				outputLineList.Add( "HHP.DataCollection.Decoding.dll=3" ) ;
				outputLineList.Add( "AirlineSoftware.dll=3" ) ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				outputLineList.Add( "Symbol.dll=3" ) ;
				outputLineList.Add( "Symbol.Barcode.dll=3" );
				outputLineList.Add( "Symbol.ResourceCoordination.dll=3" ) ;
				outputLineList.Add( "AirlineSoftware.dll=3" ) ;
			}


			foreach (object item in carriers)
			{
				outputLineList.Add(item.ToString() + "Config.bin=6");
			}

			outputLineList.Add( "" ) ;
			outputLineList.Add( "[DestinationDirs]" ) ;
			outputLineList.Add( "Shortcuts=0,%CE2%\\Start Menu" ) ;
			outputLineList.Add( "Files." + processorType + "=0,%InstallDir%" ) ;
			
			//One Time: MX
			i = 0;
			foreach (object item in carriers)
			{
				i++;
				outputLineList.Add("Config" + i + @" = 0, %Flash%carriers\" + item.ToString() + @"\TagTrakConfig");
			}

			outputLineList.Add( "" ) ;
			outputLineList.Add( "[Files." + processorType + "]" ) ;
			outputLineList.Add( baseProjectAppName + ".exe,,,0x40000000" ) ;
			if ( configFileExists ) outputLineList.Add( "BaseConfig.bin,,,0x40000000" ) ;
			outputLineList.Add( "OpenNETCF.dll,,,0x40000000" ) ;
			outputLineList.Add( "OpenNETCF.Net.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Net.ProxySocket.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Net.Ftp.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Net.Time.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Net.SecureSocket.dll,,,0x40000000" ) ;
			outputLineList.Add( "Rebex.Security.dll,,,0x40000000" ) ;
			outputLineList.Add( "SharpZipLib.dll,,,0x40000000" ) ;

			if (systemProfile.deviceType == "Intermec") 
			{
				outputLineList.Add( "Intermec.DataCollection.dll,,,0x40000000" ) ;
				outputLineList.Add( "itcscan.dll,,,0x40000000" ) ;
				outputLineList.Add( "psuuid0c.dll,,,0x40000000" ) ;
				outputLineList.Add( "AirlineSoftware.dll,,,0x40000000" ) ;
			}
			else if (systemProfile.deviceType == "Dolphin")
			{
				outputLineList.Add( "HHP.DataCollection.Common.dll,,,0x40000000" ) ;
				outputLineList.Add( "HHP.DataCollection.Decoding.dll,,,0x40000000" ) ;
				outputLineList.Add( "AirlineSoftware.dll,,,0x40000000" ) ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				outputLineList.Add( "Symbol.dll,,,0x40000000" ) ;
				outputLineList.Add( "Symbol.Barcode.dll,,,0x40000000" ) ;
				outputLineList.Add( "Symbol.ResourceCoordination.dll,,,0x40000000" ) ;
				outputLineList.Add( "AirlineSoftware.dll,,,0x40000000" ) ;
			}

			outputLineList.Add( "" ) ;

			//One Time: MX
			i = 0;
			foreach (object item in carriers)
			{
				i++;
				outputLineList.Add("[Config" + i + "]") ;
				outputLineList.Add("ScannerConfig.bin," + item.ToString() + "Config.bin" + ",,0x00000010") ;
			}
			outputLineList.Add( "" ) ;

			outputLineList.Add( "[Shortcuts]" ) ;
			outputLineList.Add( baseProjectAppName + ",0," + baseProjectAppName + ".exe,%CE11%" ) ;
			outputLineList.Add( "" ) ;
			outputLineList.Add( "[RegSettings.All]" ) ;
//			outputLineList.Add( "HKLM,\"Hardware\\Devicemap\\Keybd\",\"vkeyGold\",0x00000001,00,00,0b,05,02,03,c1,07,04,03,00,00,00,00,72,00,09,01,75,00,76,00,09,00,09,00,5b,00,bb,00,38,01,00,00,bf,00,00,00,21,00,32,01,bd,00,00,00,32,00,09,05,22,00,bc,00,bb,01,34,00,35,00,33,00,02,02,08,00,be,00,37,00,38,00,36,00,03,02,01,02,20,00,30,00,0d,00,39,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,07,05,01,05,03,05,02,05" ) ;
//			outputLineList.Add( "HKLM,\"Hardware\\Devicemap\\Keybd\\ALPHA\",\"vkeyGold\",0x00000001,00,00,0b,05,02,03,c1,07,04,03,00,00,00,00,72,00,09,01,75,00,76,00,09,00,09,00,5b,00,bb,00,38,01,00,00,bf,00,00,00,21,00,32,01,bd,00,00,00,32,00,09,05,22,00,bc,00,bb,01,34,00,35,00,33,00,02,02,08,00,be,00,37,00,38,00,36,00,03,02,01,02,20,00,30,00,0d,00,39,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,07,05,01,05,03,05,02,05" ) ;
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
//				"00,00,0B,05,02,03,00,00,04,03,BE,00,34,00,00,00," +
//				"09,01,00,00,BF,00,03,02,00,00,BD,00,75,00,72,00," +
//				"21,00,01,02,00,00,76,00,09,00,73,00,38,01,00,00," +
//				"35,00,00,00,BB,01,09,05,22,00,32,01,36,00,00,00," +
//				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
//				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
//				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
//				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
//				"00,00,07,05,01,05,03,05,02,05");
				"00,00,0B,05,02,03,03,03,04,03,00,00,00,00,72,00," +
				"09,01,76,00,75,00,09,00,73,00,00,00,BB,00,38,01," +
				"00,00,BF,00,00,00,21,00,32,01,BD,00,31,00,32,00," +
				"09,05,22,00,BC,00,BB,01,34,00,35,00,33,00,02,02," +
				"08,00,BE,00,37,00,38,00,36,00,03,02,01,02,20,00," +
				"30,00,0D,00,39,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," +
				"00,00,07,05,01,05,03,05,02,05");



			Utilities.DeleteLocalFile( baseProjectInfFilePath ) ;

			StreamWriter outputFileStream = new StreamWriter( baseProjectInfFilePath ) ;

			foreach ( string outputLine in outputLineList )
			{
				outputFileStream.WriteLine(outputLine) ;
			}

			outputFileStream.Close() ;

			buildOutputForm.addLines("    ++ .inf file created. ++\n ") ;
			buildOutputForm.addLines("    ++ Generating cab file '" + baseProjectAppName + ".cab' using CabWiz") ;

			string command = @"C:\Program Files\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\Windows CE\..\bin\..\bin\cabwiz.exe" ;
			string parameters = "\"" + baseProjectInfFilePath + "\"" + " /dest \"" + Globals.workingFilesDirectory + "\" /err \"" +  baseProjectLogFilePath + "\" /cpu " + processorType ;
			string[] commandOutput = new string[2] ;

			buildOutputForm.addLines(parameters, "        ") ;

			Utilities.DeleteLocalFile( baseProjectTempCabFilePath ) ;

			Utilities.executeShell(command, parameters, commandOutput) ;

			if ( Utilities.isNonNullString(commandOutput[0]) ) buildOutputForm.addLines(commandOutput[0], "        ") ;
			if ( Utilities.isNonNullString(commandOutput[1]) ) buildOutputForm.addLines(commandOutput[1], "        ") ;

			bool cabWizError = false ;
			string cabWizErrorLine = null ;

			if ( File.Exists(baseProjectLogFilePath) )
			{
				StreamReader logFileInputStream = new StreamReader(baseProjectLogFilePath) ;

				string inputLine = logFileInputStream.ReadLine() ;

				while ( inputLine != null )
				{
					if ( inputLine.IndexOf("Error:") >= 0 )
					{
						cabWizError = true ;
						cabWizErrorLine = inputLine ;
					}

					buildOutputForm.addLines(inputLine, "    CabWiz: ") ;
					inputLine = logFileInputStream.ReadLine() ;
				}

				logFileInputStream.Close() ;
			}

			// It is really important to be sure the build was successful. Therefore several tests are performed on the
			// CabWiz results. It is likely that some of these are superfulous, but rather safe than sorry.

			if ( cabWizError )
			{
				throw new Exception( "Build of base project cab file failed: " + cabWizErrorLine ) ;
			}

			if ( ! File.Exists( baseProjectTempCabFilePath ) )
			{
				throw new Exception("Build of base project cab file failed: no cab file created.") ;
			}

			Utilities.MoveLocalFile(baseProjectTempCabFilePath, baseProjectCabFilePath) ;
			Utilities.SetFileToReadOnly(baseProjectCabFilePath) ;

		}

		
		private void rebuildBaseProject()
		{
			if ( ! systemProfile.forceRebuildOfBaseProject )
			{
				if ( ! baseProjectIsOutOfDate() )
				{
					buildOutputForm.addLines("+++ Base project is up to date. No build performed. +++") ;
					return ;
				}
			}

			string command = "\"C:\\Program Files\\Microsoft Visual Studio .NET 2003\\Common7\\IDE\\devenv.exe\"" ;
//			string parameters = "\"" + systemProfile.baseProjectDefinitionFile + "\"" + "/build " + "\"" + systemProfile.deviceType + "\"";
			string parameters = "\"" + systemProfile.baseProjectDefinitionFile + "\"" + "/build " + "\"" + systemProfile.deviceType + " " + systemProfile.baseProjectConfiguration + "\"";
			string[] commandOutput = new string[2] ;

			Utilities.DeleteLocalFile( systemProfile.baseProjectExeFile ) ;

			Utilities.executeShell(command, parameters, commandOutput) ;

			if ( Utilities.isNonNullString(commandOutput[0]) ) this.buildOutputForm.addLines(commandOutput[0], "    ") ;
			if ( Utilities.isNonNullString(commandOutput[1]) ) this.buildOutputForm.addLines(commandOutput[1], "    ") ;

			if ( File.Exists( systemProfile.baseProjectExeFile ) )
			{
				this.buildOutputForm.addLines("+++ Build succeeds. +++\n ") ;
			}

			else
			{
				throw new Exception("Build of base project failed: no output file created.") ;
			}

			buildOutputForm.addLines("+++ Build of base project completed. +++") ;
			buildOutputForm.addLines(" ") ;
		}
		
//		private void buildBaseConfigurationFile()
//		{
//			if ( Utilities.isNullString(systemBuilder.releaseTextBox.Text) ) return ;
//
//			string configFileFullName = Globals.configFilesDirectory + @"\BaseConfig.bin" ;
//
//			Utilities.DeleteLocalFile(configFileFullName) ;
//
//			string release = this.systemProfile.release.Trim() ;
//
//			if ( Utilities.isNullString(release) ) return ;
//
//			int configFileSize = release.Length ;
//
//			byte[] configFileBuffer = new byte[configFileSize] ;
//
//			int i = 0 ;
//
//			foreach (char c in release)
//			{
//				configFileBuffer[i] = ((byte) c) | 0x80 ; i++ ;
//			}
//
//			FileStream configFileStream ;
//
//			try
//			{
//				configFileStream = new FileStream(configFileFullName,System.IO.FileMode.Create) ;
//			}
//
//			catch (Exception ex1)
//			{
//				throw new Exception("Creation of configuration file failed: " + ex1.Message, ex1) ;
//			}
//
//			try
//			{
//				configFileStream.Write(configFileBuffer, 0, configFileSize) ;
//			}
//
//			catch (Exception ex2)
//			{
//				throw new Exception("Write of configuration file failed: " + ex2.Message, ex2) ;
//			}
//			
//			configFileStream.Close() ;
//		}
		private void rebuildAirlineSoftwareDll()
		{
			buildOutputForm.addLines("+++ Building airline software dll +++") ;
		
			if ( systemProfile.processorType != "ARMV4" )
			{
				throw new Exception("Currently can only build Airline Software library for ARMV4 processor.") ;
			}

			if ( Utilities.isNullString(systemProfile.airlineSoftwareDllFile) )
			{
				throw new Exception("Airline Software library path not specified.") ;
			}

			if ( ! systemProfile.forceRebuildOfLibraries )
			{
				if ( ! AirlineSoftwareDllIsOutOfDate() )
				{

					buildOutputForm.addLines("+++ Airline Software Dll is up to date. No build performed. +++") ;
					return ;
				}
			}
	
			// Note: currently do not know what build profile for evc looks like for processors other than ARM

			if ( systemProfile.processorType != "ARMV4" )
			{
				MessageBox.Show("Do not know how to build for processors other than ARMV4") ;
				throw new Exception("Build of airline software failed: do not know how to build for processors other than ARMV4.") ;
			}

			string command = @"C:\Program Files\Microsoft eMbedded Tools\Common\EVC\Bin\evc.exe" ;
			string parameters = "\"" + airlineSoftwareProjDefnFilePath + "\" /Make \"AirlineSoftware - Win32 (WCE ARM) Release\" /REBUILD" ;
			string[] commandOutput = new string[2] ;
			
			Utilities.DeleteLocalFile( airlineSoftwareDllFilePath  ) ;

			Utilities.executeShell(command, parameters, commandOutput) ;

			if ( Utilities.isNonNullString(commandOutput[0]) ) this.buildOutputForm.addLines(commandOutput[0], "    ") ;
			if ( Utilities.isNonNullString(commandOutput[1]) ) this.buildOutputForm.addLines(commandOutput[1], "    ") ;

			if ( File.Exists( airlineSoftwareDllFilePath  ) )
			{
				this.buildOutputForm.addLines("+++ Build succeeds. +++\n ") ;
			}

			else
			{
				throw new Exception("Build of airline software failed: no output file created.") ;
			}
		}

		private bool AirlineSoftwareDllIsOutOfDate()
		{

			if ( Utilities.isNullString( airlineSoftwareDllFilePath ) )
			{
				throw new Exception("No base project file specified.") ;
			}

			if ( ! Directory.Exists(airlineSoftwareDllDirectory) )
			{
				throw new Exception("Airline Software directory '" + airlineSoftwareDllDirectory + "'does not exist.") ;
			}

			if ( ! File.Exists(airlineSoftwareDllFilePath) ) return true ;

			DateTime dllFileDateTime = File.GetLastWriteTime(airlineSoftwareDllFilePath) ;

			DirectoryInfo airlineSoftwareDllDirectoryInfo = new DirectoryInfo(airlineSoftwareDllDirectory) ;

			FileInfo[] fileList = airlineSoftwareDllDirectoryInfo.GetFiles() ;

			foreach ( FileInfo fileInfo in fileList )
			{
				string extension = Path.GetExtension(fileInfo.Name) ;

				if ( Array.IndexOf(this.airlineSoftwareDllExtensionSet, extension) < 0 ) continue ;

				if ( DateTime.Compare(fileInfo.LastWriteTime, dllFileDateTime) > 0 ) return true ;
			}

			return false ;
		}


	}
}
