using System;
using System.IO ;
using System.Security.Principal;
using System.Diagnostics;
using System.Collections;

namespace sb
{
	/// <summary>
	/// Summary description for Utilities.
	/// </summary>
	public class Utilities
	{
		public Utilities()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static bool isNonNullString(string inputString)
		{
			if ( inputString == null ) return false ;
			if ( inputString.Length <= 0 ) return false ;

			return true ;
		}

		public static bool isNullString(string inputString)
		{
			if ( inputString == null ) return true ;
			if ( inputString.Length <= 0 ) return true ;

			return false ;
		}

		public static string getCurrentUserName()
		{
					
			// Make a call to the SetPrincipalPolicy method of the CurrentDomain object,
			// and set the WindowsPrincipal class so that it is attached to the thread.
			// Without this call, the principal that is returned is a GenericPrincipal class
			// that contains no user information. Add this code to the Main method of Module1. 
			
			AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal) ;
			
			// Alternately, if you only want to get the user's identity, use the GetCurrent static method as a shortcut to steps 5 and 6.
			// The principal's information can then be retrieved from the user's identity.
			
			WindowsIdentity ident = WindowsIdentity.GetCurrent() ;
			WindowsPrincipal user = new WindowsPrincipal(ident) ;
		
			// Use the Name property to retrieve the user's name, and use the AuthenticationType property to display that to the
			// console.
			
			return ident.Name ;
		}

		public static void DeleteLocalFile(string filePath)
		{
			if ( ! File.Exists(filePath) ) return ;

			FileInfo fileInfo = new FileInfo(filePath) ;

			fileInfo.Attributes = FileAttributes.Normal ;

			File.Delete(filePath) ;
		}

		public static void ClearDirectory(string directoryPath)
		{
			if ( isNullString(directoryPath) ) return ;

			if ( ! Directory.Exists(directoryPath) ) return ;

			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath) ;

				FileInfo[] fileSet = directoryInfo.GetFiles() ;
				DirectoryInfo[] dirSet = directoryInfo.GetDirectories() ;

				foreach (FileInfo fileInfo in fileSet) DeleteLocalFile(fileInfo.FullName) ;
				foreach (DirectoryInfo dirInfo in dirSet) ClearDirectory(dirInfo.FullName) ;

			}

			catch
			{
				return ;
			}

		}

		public static void MoveLocalFile(string fromFilePath, string destFilePath)
		{
			DeleteLocalFile(destFilePath) ;
			File.Move(fromFilePath, destFilePath) ;
		}

		public static void CopyLocalFile(string fromFilePath, string destFilePath)
		{
			DeleteLocalFile(destFilePath) ;
			File.Copy(fromFilePath, destFilePath) ;
		}

		public static void SetFileToReadOnly(string filePath)
		{
			FileInfo fileInfo = new FileInfo(filePath) ;

			fileInfo.Attributes = FileAttributes.ReadOnly ;
		}

		public static void executeShell(string command, string parameters, string[] commandOutput)
		{
			Process p = new Process(); 

			// #tells operating system not to use a shell;
			p.StartInfo.UseShellExecute = false;        
			p.StartInfo.RedirectStandardOutput = true; 
			p.StartInfo.RedirectStandardError = true ;

			//#my command arguments, i.e. what site to ping
			p.StartInfo.Arguments = parameters; 

			//#the command to invoke under MSDOS
			p.StartInfo.FileName = command ;              

			//#do not show MSDOS window
			p.StartInfo.CreateNoWindow=true;       

			//#do it!
			p.Start();                                                 

			//#capture results
			string stdout = p.StandardOutput.ReadToEnd(); 
			string stderr = p.StandardError.ReadToEnd() ;

			//#wait for all results.
			p.WaitForExit();
  
			commandOutput[0] = stdout ;
			commandOutput[1] = stderr ;

		}

		public static void readFileIntoArrayList(string fileFullName, ArrayList targetArrayList)
		{

			targetArrayList.Clear() ;

			if ( ! File.Exists(fileFullName) ) throw new Exception("File \"" + fileFullName + "\" does not exist.") ;
			
			StreamReader inputStream ;

			try
			{
				inputStream = new StreamReader(fileFullName) ;
			}

			catch (Exception ex1)
			{
				throw new Exception("Attempt to open file \"" + fileFullName + "\" failed: " + ex1.Message, ex1) ;
			}

			try
			{
				string inputLine = inputStream.ReadLine() ;

				while ( inputLine != null )
				{
					targetArrayList.Add(inputLine) ;
					inputLine = inputStream.ReadLine() ;
				}
			}

			catch (Exception ex2)
			{
				inputStream.Close() ;
				throw new Exception("Attempt to open file \"" + fileFullName + "\" failed: " + ex2.Message, ex2) ;
			}

			inputStream.Close() ;
		}

		
		public static void writeFileFromArrayList(string fileFullName, ArrayList sourceArrayList)
		{
			Utilities.DeleteLocalFile(fileFullName) ;
			
			StreamWriter outputStream ;

			try
			{
				outputStream = new StreamWriter(fileFullName) ;
			}

			catch (Exception ex1)
			{
				throw new Exception("Attempt to create file \"" + fileFullName + "\" failed: " + ex1.Message, ex1) ;
			}

			try
			{
				foreach ( string outputLine in sourceArrayList )
				{
					outputStream.WriteLine(outputLine) ;
				}
			}

			catch (Exception ex2)
			{
				outputStream.Close() ;
				throw new Exception("Attempt to open file \"" + fileFullName + "\" failed: " + ex2.Message, ex2) ;
			}

			outputStream.Close() ;
		}
	}
}
