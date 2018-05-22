using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace sb
{
	/// <summary>
	/// Summary description for UpdateFileBuilder.
	/// </summary>
	public class UpdateFileBuilder
	{
		private SystemBuilder systemBuilder ;
		private SystemProfile systemProfile ;

		private string baseProjectAppName ;

		private string UpdateFileInfFilePath ;
		private string UpdateFileCabFilePath ;
		private string UpdateLogFilePath ;

		private BuildUpdateOutputForm buildOutputForm ;

		public UpdateFileBuilder(SystemBuilder inputSystemBuilder, SystemProfile inputSystemBuilderProfile)
		{
			systemBuilder = inputSystemBuilder ;
			systemProfile = inputSystemBuilderProfile ;
		}

		public bool buildUpdateFile(BuildUpdateOutputForm inputBuildOutputForm, string outputCabFilePath)
		{
			buildOutputForm = inputBuildOutputForm ;

			baseProjectAppName = systemProfile.applicationName ;

			ArrayList outputLineList = new ArrayList() ;

			string deviceType = systemProfile.deviceType ;

			string processorType = this.systemProfile.processorType ;
			//string user = this.systemProfile.user ;


			string UpdateFilesTempCabFilePath = Globals.buildFilesDirectory + @"\" + systemProfile.applicationName + ".Cab" ;
 			
			if ( ! File.Exists( UpdateFilesTempCabFilePath ) )
 			{
 				throw new Exception("Build of base project cab file failed: no cab file created.") ;
 			}

			string UpdateFilesCabFilePath = outputCabFilePath.Trim() ;
			string UpdateFilesCabFileDir = Path.GetDirectoryName(UpdateFilesCabFilePath) ;
			
			if ( !Directory.Exists(UpdateFilesCabFileDir) )
			{
				Directory.CreateDirectory(UpdateFilesCabFileDir) ;
			}

			Utilities.MoveLocalFile(UpdateFilesTempCabFilePath, outputCabFilePath) ;

			this.buildOutputForm.addLines(" ") ;
			this.buildOutputForm.addLines("+++ Update Cab File \"" + outputCabFilePath + "\" successfully created.") ;

			return true ;
		}
	}

}
