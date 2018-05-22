using System;
using System.IO;
using TagTrak.TagTrakLib.com.asiscan.baggage;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;

namespace TagTrak.TagTrakLib
{
	/// <summary>
	/// ProgVersionManager handles TagTrak program upgrade process
	/// </summary>
	public class ProgVersionManager
	{
		private static bool upgradePending = false;

		private static AssemblyVersion[] curAssemblyVersions;

		public static AssemblyVersion[] CurAssemblyVersions
		{
			get
			{
				if (curAssemblyVersions == null)
				{
					string[] ans = {"TagTrak", "TagTrakLib", "Baggage", "Resources"};

					ArrayList curAssemblyVersionList = new ArrayList(ans.Length);

					foreach (string assemblyName in ans)
					{
						try
						{
							Assembly a = Assembly.Load(assemblyName);
							AssemblyVersion av = new AssemblyVersion();
							av.assemblyName = assemblyName;
							av.version = a.GetName().Version.ToString();
							curAssemblyVersionList.Add(av);
						}
						catch (IOException)
						{
						}
					}

					curAssemblyVersions = (AssemblyVersion[]) (curAssemblyVersionList.ToArray(typeof(AssemblyVersion)));
				}

				return curAssemblyVersions;
			}

		}

		public static void CheckForUpgrade(Label statusLabel)
		{
			if (!upgradePending)
			{
				WebSyncService ws = new WebSyncService();

				UpgradeFileInfo[] fis = ws.GetAssemblyUpgrade(Utilities.SerialNo, CurAssemblyVersions);

				if (fis != null && fis.Length > 0)
				{
					int fileNumber = fis.Length;

					statusLabel.Text = fileNumber + " upgrade file(s) found.";
					statusLabel.Update();

					int curNumber = 0;

					foreach (UpgradeFileInfo fi in fis) 
					{
						statusLabel.Text = "Downloading file " + ++curNumber + " of " + fileNumber + " ...";
						statusLabel.Update();

						GetAndSaveUpgradeFile(fi);
					}
					statusLabel.Text = curNumber + " upgrade file(s) downloaded.";
					statusLabel.Update();

					upgradePending = true;
				}
				else
				{
					statusLabel.Text = "No upgrade file found";
					statusLabel.Update();
				}
			}

			if (upgradePending)
			{
				DialogResult res = MessageBox.Show("System upgrade are available. " +
					"You need to reboot the device to install them. Reboot now?", 
					"Upgrade Found", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk,
					MessageBoxDefaultButton.Button2);
				if (res.Equals(DialogResult.Yes)) 
				{
                    Hardware.Device.WarmBoot();
				}
				
			}
		}

		private static void GetAndSaveUpgradeFile(UpgradeFileInfo upgradeFile)
		{
			int totalSize = upgradeFile.size;

			int maxLength = 65536;
			string cabPath = "\\SDMMC Disk\\cabfiles\\";
			if (!Directory.Exists(cabPath)) 
			{
				Directory.CreateDirectory(cabPath);
			}

			string filePath = cabPath + upgradeFile.fileName;

			if (File.Exists(filePath)) 
			{
				OpenNETCF.IO.FileEx.SetAttributes(filePath, FileAttributes.Normal);
			}
			
			FileStream fs = File.Open(filePath, FileMode.Create, 
				FileAccess.Write, FileShare.None);

			WebSyncService ws = new WebSyncService();
			for (int i = 0; i < totalSize; i += maxLength)
			{
				string s = ws.GetFile("", upgradeFile.fileName, 
					upgradeFile.version, i, maxLength);
				if (s != "" && s != null) 
				{
					byte[] buf = System.Convert.FromBase64String(s);
					fs.Write(buf, 0, buf.Length); 
				}
			}
			fs.Close();

			OpenNETCF.IO.FileEx.SetAttributes(filePath, FileAttributes.ReadOnly);

		}
	}
}
