using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace TagTrak.TagTrakLib
{
	public struct FileUtilities
	{

		public static bool deleteLocalFile(string fileNameString)
		{
			if (!(File.Exists(fileNameString))) 
			{
				return false;
			}
			FileInfo localFileInfo;
			try 
			{
				localFileInfo = new FileInfo(fileNameString);
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Delete of file " + fileNameString + " failed: " + ex.Message);
				return false;
			}
			try 
			{
				localFileInfo.Attributes = FileAttributes.Normal;
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Delete of file " + fileNameString + " failed: " + ex.Message);
				return false;
			}
			try 
			{
				System.IO.File.Delete(fileNameString);
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Delete of file " + fileNameString + " failed: " + ex.Message);
				return false;
			}
			return true;
		}

		public static void recursiveRemoveDirectory(string directoryPath)
		{
			if (!(Directory.Exists(directoryPath))) 
			{
				return;
			}
			try 
			{
				System.IO.Directory.Delete(directoryPath, true);
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Remove directory " + directoryPath + " failed: " + ex.Message);
				return;
			}
		}
	}
}
