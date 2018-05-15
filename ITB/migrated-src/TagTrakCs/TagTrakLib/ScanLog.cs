using System;

namespace TagTrak.TagTrakLib
{
	/// <summary>
	/// Summary description for ScanLog.
	/// </summary>
	public class ScanLog
	{
		private DateTime logTime;
		private string message;

		public ScanLog(DateTime time, string msg)
		{
			logTime = time;
			message = msg;
		}

		public ScanLog(string msg) : this(DateTime.UtcNow, msg)
		{
		}

		public string LogTime
		{
			get
			{
				DateTime localTime = logTime.ToLocalTime();
				return localTime.ToString("MM-dd HH:mm:ss");
			}
		}

		public string Message
		{
			get
			{
				return message;
			}
		}

	}
}
