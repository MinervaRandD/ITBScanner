using System;
using System.Windows.Forms;

namespace TagTrak.TagTrakLib
{
	public class ScanReader
	{
        //private Intermec.DataCollection.BarcodeReader reader = null;
        //private IScanForm curform;
		
        //private static Hardware.Scanner.Base singlet;
        //public static Hardware.Scanner.Base Instance 
        //{
        //    get 
        //    {
        //        if (singlet == null) 
        //        {
        //            singlet = Hardware.Scanner.Base.GetInstance();
        //            singlet.Code128 = true;
        //            if (singlet.BeepSupported) singlet.Beep = true;
        //            if (singlet.VibrateSupported) singlet.Vibrate = true;
        //            if (singlet.LEDSupported) singlet.LED = true;
        //            singlet.IgnoreDuplicates = false;
        //            if (singlet.ContinuousSupported) singlet.Continuous = false;
        //            singlet.VolumePercent = 100;
        //        }
        //        return singlet;
        //    }
        //}

        /*
		private ScanReader()
		{
#if INTERMEC
			uint buffSize = 65536;
			reader = new Intermec.DataCollection.BarcodeReader(buffSize);
			reader.BarcodeRead += new Intermec.DataCollection.BarcodeReadEventHandler(BarcodeRead);
			reader.ContinuesScan = ConfigSetting.Instance().ContinuesScan;
#endif
		}

		private void BarcodeRead(object sender, Intermec.DataCollection.BarcodeReadEventArgs e)
		{
			try 
			{
				this.Disable();
				if (ConfigSetting.Instance().BuzzOnScan && !ConfigSetting.Instance().ContinuesScan) 
				{
					ScannerLib.VibrateON();
					System.Threading.Thread.Sleep(1000 * ConfigSetting.Instance().BuzzLength);
					ScannerLib.VibrateOFF();
				}
				if (ConfigSetting.Instance().BeepOnScan) 
				{
					ScannerLib.BeepSound();
				}
				curform.ProcessScanData(e.strDataBuffer);
				this.Enable();
			} 
			catch (Exception ex) 
			{
				MessageBox.Show("A Scan Related Error Has Occured. Please Report The Following Message To Your Systems Administrator: " + ex.Message, "Scan Error");
				this.Enable();
			}
			Application.DoEvents();
		}

		public void Disable()
		{
			if (reader == null) 
			{
				return;
			}
			reader.ScannerEnable = false;
		}

		public void Enable()
		{
			if (reader == null) 
			{
				return;
			}
			reader.ScannerEnable = true;
			reader.ThreadedRead(true);
		}

		public IScanForm CurrentScanForm
		{
			set 
			{
				this.curform = value;
			}
		}

        */
	}
}
