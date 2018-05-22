using System;
using System.Text;
using System.Windows.Forms;

namespace TagTrak.TagTrakLib
{
	public class SYSTEM_POWER_STATUS_EX
	{
		public byte ACLineStatus;
		public byte BatteryFlag;
		public byte BatteryLifePercent;
		public byte Reserved1;
		public uint BatteryLifeTime;
		public uint BatteryFullLifeTime;
		public byte Reserved2;
		public byte BackupBatteryFlag;
		public byte BackupBatteryLifePercent;
		public byte Reserved3;
		public uint BackupBatteryLifeTime;
		public uint BackupBatteryFullLifeTime;
	}
	public class ScannerLib
	{
		[System.Runtime.InteropServices.DllImport("coredll")]
		static extern uint GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, bool fUpdate);

		public static Int32 SystemPowerStatus()
		{
			SYSTEM_POWER_STATUS_EX status = new SYSTEM_POWER_STATUS_EX();
			GetSystemPowerStatusEx(status, true);
			return status.ACLineStatus;
		}
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern Int32 aesEncrypt(byte[] inputMode, byte[] inputBuff, Int32 inputLen, byte[] outputBuff, byte[] key, Int32 keyLen);
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern Int32 aesDecrypt(byte[] inputMode, byte[] inputBuff, Int32 inputLen, byte[] outputBuff, byte[] key, Int32 keyLen);
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void Code93Active();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void Code93NotActive();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void Code128Active();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void Code128NotActive();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void TurnOnRegistrySave();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern Int32 GetTimeZone();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void SetTimeZone(Int32 nOffset);
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void WarmBoot();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void ColdBoot();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern int GetRegistryString(StringBuilder rValue, string lpSubKey, string lpEntry);
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern Int32 GetRegistryNumber(string lpSubKey, string lpEntry);
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void BeepSound();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void VibrateON();
		[System.Runtime.InteropServices.DllImport("AirlineSoftware.dll")]
		public static extern void VibrateOFF();

		private static string serialNo = null;

		public static string SerialNumber()
		{
			if (serialNo != null)
			{
				return serialNo;
			}

			string sn;
#if INTERMEC
			sn = "";
			byte[] buff = new byte[128];
			try 
			{
				Psuuid.GetSerNum(buff, 22);
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("Get serial number failed: " + ex.Message);
			}
			for (int i = 0; i <= 10; i++) 
			{
				if (Utilities.isTextCharacter(buff[2 * i])) 
				{
					char nextChar = Convert.ToChar(buff[2 * i]);
					sn += nextChar;
				}
				else
				{
					break;
				}
			}
#else
			sn = "EMULATOR";
#endif
			serialNo = sn;

			return serialNo;
		}
	}
}
