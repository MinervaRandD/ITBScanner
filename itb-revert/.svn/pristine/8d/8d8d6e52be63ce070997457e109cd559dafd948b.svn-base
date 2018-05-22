using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AsiUpdater
{
    public class DownloadManager : IDisposable
    {
        // Default values, if defined in Config.xml, these values will be overwritten
        private int ChunkSize = 51200;
        private int ChunkDownloadInterval = 1;
        private int DownloadRetries = 3;
        private int NotifyUser = 300;

        private string InstallDir;
        private string CabDir;

        private string SerialNumber;

        public event ResumeUpgradeCheckEventArgs ResumeUpgradeCheck;
        public delegate void ResumeUpgradeCheckEventArgs();

        public event ErroOccurredEventArgs ErrorOccurred;
        public delegate void ErroOccurredEventArgs();

        private Thread thread;
        private System.Windows.Forms.Timer timer;
        private string DownloadError;
        private bool ReadyToInstall;

        private UpgradeAvailableEventArgs FilesReadyToInstall;

        public DownloadManager()
        {
            DownloadRetries = Configuration.Instance.DownloadRetries != null ? Convert.ToInt32(Configuration.Instance.DownloadRetries) : DownloadRetries;
            NotifyUser = Configuration.Instance.NotifyUser != null ? Convert.ToInt32(Configuration.Instance.NotifyUser) : NotifyUser;
            ChunkSize = Configuration.Instance.ChunkSize != null ? Convert.ToInt32(Configuration.Instance.ChunkSize) : ChunkSize;
            ChunkDownloadInterval = Configuration.Instance.ChunkDownloadInterval != null ? Convert.ToInt32(Configuration.Instance.ChunkDownloadInterval) : ChunkDownloadInterval;
            InstallDir = Configuration.Instance.InstallDir;
            CabDir = InstallDir + @"\CabFiles";

            // System.Windows.Forms.Timer must be in the main DownloadManager thread
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = NotifyUser * 1000;
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (ReadyToInstall)
            {
                lock (this)
                {
                    InstallFiles();
                }
            }
        }

        public void AddEventHandler(UpgradeManager UM)
        {
            UM.UpdateAvailable += new UpgradeManager.ProgramUpgradesAvailable(UM_UpdateAvailable);
        }

        private void StartDownload(UpgradeAvailableEventArgs e)
        {
            bool allsuccess = true;
            bool success;

            foreach (Data.File file in e.UpgradeFiles)
            {
                success = false;
                for (int i = 0; i < (DownloadRetries - 1); i++)
                {
                    if (DownloadFile(file, Configuration.Instance.WebServiceUri))
                    {
                        success = true;
                        Log.Instance.WriteUpgradeLog("Upgrade file " + file.FileName + " downloaded.");
                        break;
                    }
                    else
                    {
                        Log.Instance.WriteUpgradeLog("[ERROR] Failed to download " + file.FileName + ". " + DownloadError);
                    }
                }
                if (!success)
                {
                    allsuccess = false;
                }
            }

            if (allsuccess)
            {
                FilesReadyToInstall = e;
                InstallFiles();
            }
            else
            {
                ReadyToInstall = false;
                ResumeUpgradeCheck();
            }
        }

        private bool DownloadFile(Data.File DownloadFile, string uri)
        {
            bool success = true;
            FileStream fileStream = null;
            string TempFilePath = string.Empty;
            string TempDir = string.Empty;

            try            
            {
                List<Data.DownloadFile> DF = CreateDownloadRequest(DownloadFile, ChunkSize);                
                
                if (!Directory.Exists(CabDir))
                {
                    Directory.CreateDirectory(CabDir);
                }

                TempDir = CabDir + @"\temp";
                if (!Directory.Exists(TempDir))
                {
                    Directory.CreateDirectory(TempDir);
                }

                TempFilePath = TempDir + @"\" + DownloadFile.FileName;
                fileStream = File.Open(TempFilePath, FileMode.Create, FileAccess.Write, FileShare.None);

                int maxRead;
                byte[] buffer;
                int bytesRead;
                int totalBytesRead;

                foreach (Data.DownloadFile chunk in DF)
                {
                    HttpWebResponse HttpWebResp = null;
                    HttpWebRequest HttpWebReq = null;
                    Stream ReqStream = null;
                    StreamWriter ReqStreamWriter = null;
                    Stream RespStream = null;

                    try
                    {
                        Data.DownloadRequest dlreq = new Data.DownloadRequest();
                        dlreq.SN = SerialNumber;
                        dlreq.DownloadFile = new Data.DownloadFile();
                        dlreq.DownloadFile = chunk;

                        string XmlRequest;
                        XmlSerializer RequestSerializer = new XmlSerializer(typeof(Data.DownloadRequest));

                        using (StringWriter swXml = new StringWriter())
                        {
                            RequestSerializer.Serialize(swXml, dlreq);
                            XmlRequest = swXml.ToString();
                            swXml.Close();
                        }

                        string rawRequest = "payload=" + XmlRequest;
                        HttpWebReq = (HttpWebRequest)HttpWebRequest.Create(uri);
                        HttpWebReq.Method = "POST";
                        HttpWebReq.ContentLength = rawRequest.Length;

                        // Save the raw request (Is this needed with RESTful payload???? HttpWebReq.GetResponse() will not work)
                        ReqStream = HttpWebReq.GetRequestStream();
                        ReqStreamWriter = new StreamWriter(ReqStream);
                        ReqStreamWriter.Write(rawRequest);
                        ReqStreamWriter.Close();

                        HttpWebResp = (HttpWebResponse)HttpWebReq.GetResponse();
                        RespStream = HttpWebResp.GetResponseStream();

                        maxRead = chunk.ChunkSize;
                        buffer = new byte[maxRead];
                        bytesRead = 0;
                        totalBytesRead = 0;

                        while ((bytesRead = RespStream.Read(buffer, 0, maxRead)) > 0)
                        {
                            totalBytesRead += bytesRead;
                            fileStream.Write(buffer, 0, bytesRead);
                        }                        
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        DownloadError = ex.Message;
                    }
                    finally
                    {
                        if (HttpWebReq != null)
                        {
                            HttpWebReq = null;
                        }
                        if (HttpWebResp != null)
                        {
                            HttpWebResp.Close();
                            HttpWebResp = null;
                        }
                        if (ReqStream != null)
                        {
                            ReqStream.Close();
                            ReqStream.Dispose();
                        }
                        if (RespStream != null)
                        {
                            RespStream.Close();
                            RespStream.Dispose();
                        }
                    }
                    Thread.Sleep(ChunkDownloadInterval * 1000);
                }

            }
            catch (Exception ex)
            {
                success = false;
                DownloadError = ex.Message;
            }
            finally
            {
                fileStream.Close();
                if (success)
                {
                    success = false;
                    if (File.Exists(TempFilePath))
                    {
                        string MD5 = GetMD5HashFromFile(TempFilePath);
                        if (MD5 != null)
                        {
                            if (DownloadFile.Checksum == MD5)
                            {
                                // Copy the file to Application/CabDir
                                string ExistingCab = CabDir + @"\" + DownloadFile.FileName;
                                if (File.Exists(ExistingCab))
                                {
                                    OpenNETCF.IO.FileHelper.SetAttributes(ExistingCab, FileAttributes.Normal);
                                    File.Delete(ExistingCab);
                                }

                                File.Copy(TempFilePath, ExistingCab, true);
                                if (File.Exists(ExistingCab) && File.Exists(TempFilePath))
                                {
                                    OpenNETCF.IO.FileHelper.SetAttributes(TempFilePath, FileAttributes.Normal);
                                    File.Delete(TempFilePath);
                                    success = true;
                                }
                            }
                            else
                            {
                                DownloadError = "Incorrect MD5 checksum";
                            }
                        }
                    }
                    if (!success)
                    {
                        if (File.Exists(TempFilePath))
                        {
                            File.Delete(TempFilePath);
                        }
                    }
                }
                else
                {
                    File.Delete(TempFilePath);
                }                
            }
            return success;
        }        

        private string GetMD5HashFromFile(string fileName)
        {
            string retMD5 = string.Empty;
            try
            {
                MD5 md5 = MD5.Create();
                StringBuilder sb = new StringBuilder();
                using (FileStream fs = File.Open(fileName, FileMode.Open))
                {
                    foreach (byte b in md5.ComputeHash(fs))
                        sb.Append(b.ToString("x2").ToLower());
                }
                retMD5 = sb.ToString();
            }
            catch
            {
                retMD5 = null;
            }
            return retMD5;
        }
        
        private List<Data.DownloadFile> CreateDownloadRequest(Data.File DownloadFile, int chunksize)
        {
            List<Data.DownloadFile> DownloadRequests = null;
            Data.DownloadFile DlReq;

            // Zero base operation
            if (DownloadFile.Size > 0)
            {
                DownloadRequests = new List<Data.DownloadFile>();
                if (DownloadFile.Size <= chunksize)
                {
                    DlReq = new Data.DownloadFile();
                    DlReq.StartByte = 0;
                    DlReq.FileName = DownloadFile.FileName;
                    DlReq.Type = DownloadFile.Type;
                    DlReq.ChunkSize = DownloadFile.Size;
                    DownloadRequests.Add(DlReq);
                }
                else
                {
                    int NumberofChunks = DownloadFile.Size / chunksize;
                    int ModChunks = DownloadFile.Size % chunksize;
                    int CurrentStartByte;
                    
                    CurrentStartByte = 0;
                    for (int i = 0; i < NumberofChunks; i++)
                    {
                        DlReq = new Data.DownloadFile();                        
                        DlReq.FileName = DownloadFile.FileName;
                        DlReq.Type = DownloadFile.Type;
                        DlReq.StartByte = CurrentStartByte;
                        DlReq.ChunkSize = chunksize; // zero base
                        DownloadRequests.Add(DlReq);
                        CurrentStartByte += chunksize;
                    }

                    if (ModChunks != 0)
                    {
                        DlReq = new Data.DownloadFile();                        
                        DlReq.FileName = DownloadFile.FileName;
                        DlReq.Type = DownloadFile.Type;
                        DlReq.StartByte = CurrentStartByte;
                        DlReq.ChunkSize = ModChunks;
                        DownloadRequests.Add(DlReq);
                    }
                }
            }            
            return DownloadRequests;
        }       

        private void InstallFiles()
        {
            DialogResult dr = MessageBox.Show("ASI updates are available.\nDo you want to install it now?\n(Reboot Required)", "ASI Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            switch (dr)
            {
                case DialogResult.Yes:
                    ReadyToInstall = false;
                    StreamWriter sw = null;
                    string StartUpCtlDir = InstallDir + @"\StartUpCtl\OnReset\";
                    string OnReset = StartUpCtlDir + "OnReset.txt";
                    string OnReset_1 = StartUpCtlDir + "OnReset_1.txt";

                    try
                    {
                        if (File.Exists(OnReset))
                        {
                            File.Delete(OnReset);
                        }

                        if (!Directory.Exists(Path.GetDirectoryName(OnReset)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(OnReset));
                        }

                        sw = new StreamWriter(OnReset, false);
                        foreach (Data.File file in FilesReadyToInstall.UpgradeFiles)
                        {
                            sw.WriteLine(@"\windows\wceload.exe /noui /delete 0 " + "\"" + CabDir + "\\" + file.FileName + "\"");
                            sw.WriteLine("wait");
                        }
                        sw.Close();
                        sw.Dispose();

                        if (File.Exists(OnReset_1))
                        {
                            File.Delete(OnReset_1);
                        }

                        sw = new StreamWriter(OnReset_1, false);
                        {
                            sw.WriteLine("Delete \"" + OnReset + "\"");
                            sw.WriteLine("\"Program Files\\AsiUpdater\\AsiUpdater.exe\"");
                            sw.WriteLine("\"Program Files\\InterBag\\Itb.exe\"");
                        }
                        sw.Close();
                        sw.Dispose();
                        Hardware.Device.WarmBoot();
                    }
                    catch
                    {
                        if (sw != null)
                        {
                            sw.Close();
                            sw.Dispose();
                        }
                    }
                                        
                    break;

                case DialogResult.No:
                     ReadyToInstall = true;
                     break;
            }
        }       
                
        private void UM_UpdateAvailable(object sender, UpgradeAvailableEventArgs e)
        {
            if (Program.UpgradeMgr != null)
            {
                SerialNumber = Program.UpgradeMgr.SerialNumber;
            }

            if (SerialNumber == null || SerialNumber.Length == 0)
            {
                ErrorOccurred();
            }
            else
            {
                ThreadStart Download = delegate { StartDownload(e); };
                thread = new Thread(Download);
                thread.Start();
            }
        }

        #region IDisposable Members

        private bool disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

            // Ensure the object is not garbage collected
            // until the dispose method completes
            GC.KeepAlive(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (timer != null)
                    {
                        timer.Enabled = false;
                        timer.Dispose();
                    }
                    if (thread != null)
                    {
                        // GET BACK TO THIS
                    }
                    disposed = true;
                }
            }
        }        

        ~DownloadManager()
        {
            Dispose(false);
        }

        #endregion
    }
}
