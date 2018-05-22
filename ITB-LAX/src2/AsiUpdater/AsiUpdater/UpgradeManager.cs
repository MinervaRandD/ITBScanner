using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace AsiUpdater
{
    public class UpgradeManager : IDisposable
    {
        // default applications
        public string[] Apps = {"ITB", "ASINetTest", "AsiUpdater"};
        private int iCheckForUpgrade = 600;
        private bool StartChecking;

        private static string serialno;
        public string SerialNumber
        {
            get
            {
                if (serialno == null)
                {
                    try
                    {
                        serialno = Hardware.Device.GetUniqueID();                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot detect device serial number\n\n" + ex.Message);
                        ErrorOccurred();
                    }
                }
                return serialno;
            }
        }

        // public event EventHandler ErrorOccurred;
        public event ErroOccurredEventArgs ErrorOccurred;
        public delegate void ErroOccurredEventArgs();

        // public event EventHandler<UpgradeAvailableEventArgs> ProgramUpgradesAvailable;
        public event ProgramUpgradesAvailable UpdateAvailable;
        public delegate void ProgramUpgradesAvailable(object sender, UpgradeAvailableEventArgs e);

        private Data.ItbRequest Request;
        private Data.ItbResponse Response;
        private Data.SyncRequest syncRequest;
        private Data.SyncResponse syncResponse;

        private Thread thread;
        private System.Windows.Forms.Timer timer;
        
        private System.DateTime startUpdateTime;
        private System.DateTime endUpdateTime;

        public UpgradeManager()
        {
            iCheckForUpgrade = Configuration.Instance.CheckForUpgrade != null ? Convert.ToInt32(Configuration.Instance.CheckForUpgrade) : iCheckForUpgrade;

            // Get values from UpdaterConfig.xml
            startUpdateTime = Convert.ToDateTime(Configuration.Instance.ScannerUpgradeTime);
            endUpdateTime = startUpdateTime.AddMinutes(Convert.ToDouble(Configuration.Instance.ScannerUpgradeTimeWindowMinutes));
            
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = iCheckForUpgrade * 1000;
            timer.Enabled = true;
            StartChecking = true;
        }       

        private void Sync()
        {
            syncRequest = new Data.SyncRequest();
            syncRequest.SN = SerialNumber;

            syncResponse = null;
            syncResponse = GetResponse(syncRequest);
    
            // TODO: REMOVE TESTING CODE
            // ######################################################
            // syncResponse = new Data.SyncResponse();
            // syncResponse.ScannerUpgradeTime = "13:00";
            // syncResponse.ScannerUpgradeTimeWindowMinutes = "240";
            // ######################################################

            if (syncResponse != null)
            {
                Regex regTime = new Regex(@"^(20|21|22|23|[01]\d|\d)(([:][0-5]\d){1,2})$");
                Regex regNumber = new Regex(@"\d");

                if (regTime.IsMatch(syncResponse.ScannerUpgradeTime) && regNumber.IsMatch(syncResponse.ScannerUpgradeTimeWindowMinutes))
                {
                    System.Collections.Hashtable ht = new System.Collections.Hashtable();

                    ht.Add("ScannerUpgradeTime", syncResponse.ScannerUpgradeTime);
                    ht.Add("ScannerUpgradeTimeWindowMinutes", syncResponse.ScannerUpgradeTimeWindowMinutes);

                    Configuration.SaveXmlElement(ht);

                    startUpdateTime = Convert.ToDateTime(syncResponse.ScannerUpgradeTime);
                    endUpdateTime = startUpdateTime.AddMinutes(Convert.ToDouble(syncResponse.ScannerUpgradeTimeWindowMinutes));
                }
                else
                {
                    if (!regTime.IsMatch(syncResponse.ScannerUpgradeTime))
                    {
                        Log.Instance.WriteConnectionLog("[ERROR] Invalid <ScannerUpgradeTime> : " + syncResponse.ScannerUpgradeTime == null ? "NULL" : syncResponse.ScannerUpgradeTime);
                    }
                    if (!regNumber.IsMatch(syncResponse.ScannerUpgradeTimeWindowMinutes))
                    {
                        Log.Instance.WriteConnectionLog("[ERROR] Invalid <ScannerUpgradeTimeWindowMinutes> : " + syncResponse.ScannerUpgradeTimeWindowMinutes == null ? "NULL" : syncResponse.ScannerUpgradeTimeWindowMinutes);
                    }
                }
            }
        }
        

        public void AddEventHandler(DownloadManager DM)
        {
            DM.ResumeUpgradeCheck += new DownloadManager.ResumeUpgradeCheckEventArgs(DM_ResumeUpgradeCheck);
        }

        private void DM_ResumeUpgradeCheck()
        {
            StartChecking = true;
        }

        public void Start()
        {
            try
            {
                Apps = Configuration.Instance.AutoUpdateApplications.Split(',');                
            }
            catch
            {
                // Nothing to do here. If error occurs, it will try to load default applications
            }

            if (Configuration.Instance.WebServiceUri == null)
            {
                ErrorOccurred();
            }            
        }

        ////////////////////////////////////////////////////////////////////////////////
        // <ProgramVersions>
        //   <ProgramVersion>
        //     <Name>ITB</Name>
        //     <Version>1.0.0.1</Version>
        //   </ProgramVersion>
        //   <ProgramVersion>
        //     <Name>NetTest</Name>
        //     <Version>2.3</Version>
        //   </ProgramVersion>
        //</ProgramVersions>
        ////////////////////////////////////////////////////////////////////////////////

        private void CheckForUpgrade()
        {
            Request = new Data.ItbRequest();
            Request.ProgramVersions = new List<Data.FileRequest>();
            Request.SN = SerialNumber;

            // All applications must exist (FOR NOW)
            try
            {
                for (int i = 0; i < Apps.Length; i++)
                {
                    string AppDir;
                    switch (Apps[i].ToLower())
                    {
                        case "itb":
                            AppDir = "InterBag";
                            break;
                        case "asinettest":
                            AppDir = "ASI Net Test";
                            break;
                        default:
                            AppDir = Apps[i];
                            break;
                    }

                    string AppFilePath = @"\Program Files\" + AppDir + @"\" + Apps[i] + ".exe";

                    if (File.Exists(AppFilePath))
                    {
                        Data.FileRequest FileReq = new Data.FileRequest();
                        FileReq.Name = Apps[i];                   
                        FileReq.Version = Assembly.LoadFrom(AppFilePath).GetName().Version.ToString();
                        if (FileReq.Version.Trim().Length > 0)
                        {
                            Request.ProgramVersions.Add(FileReq);
                        }
                    }
                    else
                    {
                        MessageBox.Show(Apps[i] + " is not installed on this scanner.");
                        throw new ApplicationException();
                    }
                }                
            }
            catch
            {
                ErrorOccurred();
            }
                        
            Response = null;
            Response = GetResponse(Request);

            if (Response != null)
            {
                if (Response.ProgramUpgradeFiles.Count > 0)
                {
                    UpgradeAvailableEventArgs UpgradeEventArgs = new UpgradeAvailableEventArgs();
                    UpgradeEventArgs.UpgradeFiles = Response.ProgramUpgradeFiles;
                    // ProgramUpgradesAvailable(this, UpgradeEventArgs);
                    StartChecking = false;
                    UpdateAvailable(this, UpgradeEventArgs);
                }
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (Configuration.Instance.ScheduledUpgradeEnabled)
            {
                ProcessScheduledUpgrade();
            }
            else
            {
                if (StartChecking)
                {
                    lock (this)
                    {
                        thread = new Thread(new ThreadStart(this.CheckForUpgrade));
                        thread.Start();
                        thread.Join();
                    }
                }
            }            
        }

        private void ProcessScheduledUpgrade()
        {
            Sync();
            if (startUpdateTime <= DateTime.UtcNow && endUpdateTime >= DateTime.UtcNow)
            {
                if (StartChecking)
                {
                    lock (this)
                    {
                        thread = new Thread(new ThreadStart(this.CheckForUpgrade));
                        thread.Start();
                        thread.Join();
                    }
                }
            }
        }
        
        private Data.ItbResponse GetResponse(Data.ItbRequest Req)
        {
            Data.ItbResponse ResponseResult = null;
            if (Req.ProgramVersions.Count > 0)
            {
                string XmlRequest;
                XmlSerializer RequestSerializer = new XmlSerializer(typeof(Data.ItbRequest));               

                using (StringWriter sw = new StringWriter())
                {
                    RequestSerializer.Serialize(sw, Req);
                    XmlRequest = sw.ToString();
                    sw.Close();
                }

                Stream ResponseStream = Stream.Null;
                WebServiceClient wc = new WebServiceClient();

                try
                {
                    string WebServiceUri = Configuration.Instance.WebServiceUri;
                    ResponseStream = wc.GetStreamFromPostRequest(XmlRequest, WebServiceUri);

                    XmlSerializer serializer = new XmlSerializer(typeof(Data.ItbResponse));
                    ResponseResult = (Data.ItbResponse)serializer.Deserialize(ResponseStream);

                    try
                    {
                        int i = ResponseResult.ProgramUpgradeFiles.Count;
                    }
                    catch (NullReferenceException)
                    {
                        ResponseResult = null;
                    }
                }                
                catch (Exception ex)
                {
                    Log.Instance.WriteConnectionLog("[ERROR] Failed to connect.\n" + ex.Message);
                }
                finally
                {
                    if (ResponseStream != null)
                    {
                        ResponseStream.Close();
                        ResponseStream.Dispose();
                    }
                    wc.Dispose();
                }
            }
            return ResponseResult;
        }

        private Data.SyncResponse GetResponse(Data.SyncRequest SyncReq)
        {
            Data.SyncResponse ResponseResult = null;

            string XmlRequest;
            XmlSerializer RequestSerializer = new XmlSerializer(typeof(Data.SyncRequest));

            using (StringWriter sw = new StringWriter())
            {
                RequestSerializer.Serialize(sw, SyncReq);
                XmlRequest = sw.ToString();
                sw.Close();
            }

            Stream ResponseStream = Stream.Null;
            WebServiceClient wc = new WebServiceClient();

            try
            {
                string WebServiceUri = Configuration.Instance.WebServiceUri;
                ResponseStream = wc.GetStreamFromPostRequest(XmlRequest, WebServiceUri);

                XmlSerializer serializer = new XmlSerializer(typeof(Data.SyncResponse));
                ResponseResult = (Data.SyncResponse)serializer.Deserialize(ResponseStream);                

                if (ResponseResult.ScannerUpgradeTime == null || ResponseResult.ScannerUpgradeTimeWindowMinutes == null)
                {
                    ResponseResult = null;
                }           
            }
            catch (Exception ex)
            {
                Log.Instance.WriteConnectionLog("[ERROR] Failed to connect.\n" + ex.Message);
            }
            finally
            {
                if (ResponseStream != null)
                {
                    ResponseStream.Close();
                    ResponseStream.Dispose();
                }
                wc.Dispose();
            }
            return ResponseResult;
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

        ~UpgradeManager()
        {
            Dispose(false);
        }        

        #endregion
    }
}
