using System;
using System.IO;
using System.Windows.Forms;

namespace sb
{
	/// <summary>
	/// Summary description for Globals.
	/// </summary>
	public class Globals
	{
		public static string baseDirectory ;
		public static string configFilesDirectory ;
		public static string buildFilesDirectory  ;
		public static string infFilesDirectory    ;
		public static string workingFilesDirectory ;
		public static string processorSpecificFilesDirectory ;
		public static string deviceSpecificFilesDirectory ;

		public static string ARMV4FilesDirectory ;
		public static string intermecFilesDirectory ;
		public static string dolphinFilesDirectory ;
		public static string symbolFilesDirectory ;

		public static bool SetupBaseDirectoryDefinitions()
		{
			string SystemName = "SystemBuilder" ;

			baseDirectory = Directory.GetCurrentDirectory() ;

			int index = baseDirectory.IndexOf(SystemName) ;

			if ( index < 0 )
			{
				MessageBox.Show("Unable to establish system directories. Program will terminate.") ;
				return false ;
			}

			index += SystemName.Length ;

			baseDirectory = baseDirectory.Substring(0, index) ;

			configFilesDirectory   = baseDirectory + @"\" + "Config Files"       ;
			buildFilesDirectory    = baseDirectory + @"\" + "Build Files"        ;
			infFilesDirectory      = baseDirectory + @"\" + "Inf Files"          ;
			workingFilesDirectory  = baseDirectory + @"\" + "Working Files"      ;
			ARMV4FilesDirectory    = baseDirectory + @"\" + "ARMV4 Common Files" ;
			intermecFilesDirectory = baseDirectory + @"\" + "Intermec Files"     ;
			dolphinFilesDirectory  = baseDirectory + @"\" + "Dolphin Files"		 ;
			symbolFilesDirectory   = baseDirectory + @"\" + "Symbol Files"       ;

			return true ;
		}

		public static bool SetupBuildSpecificDirectoryDefinitions(sb.SystemProfile systemProfile)
		{
			if ( systemProfile.processorType == "ARMV4" )
			{
				processorSpecificFilesDirectory = ARMV4FilesDirectory ;
			}

			else
			{
				MessageBox.Show("Unable to support build for processor type: " + systemProfile.processorType) ;
				return false ;
			}

			if ( systemProfile.deviceType == "Intermec" )
			{
				deviceSpecificFilesDirectory = intermecFilesDirectory ;
			}
			else if ( systemProfile.deviceType == "Dolphin" )
			{
				deviceSpecificFilesDirectory = dolphinFilesDirectory ;
			}
			else if (systemProfile.deviceType == "Symbol")
			{
				deviceSpecificFilesDirectory = symbolFilesDirectory ;
			}
			else
			{
				MessageBox.Show("Unable to support build for device type: " + systemProfile.deviceType) ;
				return false ;
			}

			return true ;
		}

		public Globals()
		{
			//
			// TODO: Add constructor logic here
			//
		}


	}
}
