using System;
using System.Net;

namespace TagTrak.TagTrakLib
{
	/// <summary>
	/// Summary description for Connector.
	/// </summary>
	public class Connector : IConnector	
	{
		IConnector con;

		public Connector()
		{
			//
			// TODO: Add constructor logic here
			//
			com.asiscan.baggage_ws.TagTrakSyncService ws = new TagTrak.TagTrakLib.com.asiscan.baggage_ws.TagTrakSyncService();
			ws.Url = "http://baggage-ws.asiscan.com/tagtraksync.php";
//			ws.Proxy = new WebProxy("http://sandbox.asiscan.com:3128", false);
			con = ws;
		}

		#region IConnector Members

		public string GmtTime()
		{
			// TODO:  Add Connector.GmtTime implementation
			return con.GmtTime();
		}

		public int UploadBagScans(string data, string username, string password, bool compress, string format, string serial, string version)
		{
			// TODO:  Add Connector.UploadBagScans implementation
			return con.UploadBagScans(data, username, password, compress, format, serial, version);
		}

		public string[] GetDdl(string username, string password, string serial, string version, string localSchemaVersion)
		{
			return con.GetDdl(username, password, serial, version, localSchemaVersion);
		}
		
		public string[] GetDml(string username, string password, string serial, string version)
		{
			return con.GetDml(username, password, serial, version);
		}

		public string GetAssemblyUpgrade(string username, string password, string serial, string assemblyName, string curVersion) 
		{
			return con.GetAssemblyUpgrade(username, password, serial, assemblyName, curVersion);
		}

		#endregion
	}

	public interface IConnector
	{
		string GmtTime();
		int UploadBagScans (string data, string username, string password , bool compress, string format, string serial, string version);
		string[] GetDdl(string username, string password, string serial, string version, string localSchemaVersion);
		string[] GetDml(string username, string password, string serial, string version);
		string GetAssemblyUpgrade(string username, string password, string serial, string assemblyName, string curVersion);
		}
}
