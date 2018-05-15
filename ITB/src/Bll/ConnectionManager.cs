using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Asi.Itb.Dal;
using System.Runtime.Serialization;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Dal.ItbDataSetTableAdapters;
using System.Windows.Forms;
using Asi.Itb.Bll.DataContracts;
//using Newtonsoft.Json;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Manager class responsible for communicating with server, via web service
    /// </summary>
    public class ConnectionManager
    {
        /// <summary>
        /// Event fired when new progress is made in the sync process.
        /// </summary>
        public event EventHandler<SyncProgressEventArgs> SyncProgressMade;

        /// <summary>
        /// Event fired when any errror occurred during the sync process.
        /// </summary>
        public event EventHandler<SyncErrorEventArgs> SyncErrorOccurred;

        /// <summary>
        /// Event fired when new value is set for ScannerUpdateInterval
        /// </summary>
        public event EventHandler ScannerUpdateIntervalUpdated;

        /// <summary>
        /// Event fired when new value is set for IdleTimeOut
        /// </summary>
        public event EventHandler IdleTimeOutUpdated;

        /// <summary>
        /// Event fired when new value is set for GpsIdleTimeOut
        /// </summary>
        public event EventHandler GpsIdleTimeOutUpdated;

        public event EventHandler BatteryWarningPercentUpdated;

        /// <summary>
        /// Object to support locking on Sync() method
        /// </summary>
        private static object syncLock = new object();

        /// <summary>
        /// Gets and sets time when the sync process failed. Set when a sync failed, and cleared when
        /// a sync successes.
        /// </summary>
        public static DateTime? SyncFailureTime
        {
            get;
            set;
        }

        public ConnectionManager()
        {
        }

        private List<Asi.Itb.Bll.DataContracts.HandoverLocation> _handoverLocations;
        public ConnectionManager(List<Asi.Itb.Bll.DataContracts.HandoverLocation> HandoverLocations)
        {
            _handoverLocations = HandoverLocations;
        }

        /// <summary>
        /// Sychronize with server, sending up local data and download updates from server.
        /// </summary>
        public void Sync()
        {
            Debug.WriteLine("Entering", "Sync");

            lock (syncLock) // avoid calling sync from multiple threads at the same time.
            {
                string state = string.Empty;

                try
                {
                    state = "Entering sync";

                    this.ReportSyncProgress("Started sync process. Preparing upload data...", 5, null);

                    state = "Getting data contracts";

                    DataContracts.ItbRequest request = new DataContracts.ItbRequest();

                    state = "Getting device serial number";

                    request.SN = SessionData.Current.SN;
                    if (request.SN == null)
                    {
                        request.SN = "UNKNOWN";
                    }

                    state = "Getting device serial number";

                    request.Gps = SessionData.Current.GpsPosition == null ? null : SessionData.Current.GpsPosition.ToString();

                    state = "Getting device serial number";

                    request.LastUpdateServerTime = this.GetLastUpdateServerTime();

                    state = "Getting battery percent";

                    request.BatteryPercent = Hardware.Power.BatteryPercent();

                    state = "Getting scans";

                    List<Asi.Itb.Bll.Entities.Scan> scans = ScanManager.GetToBeUploadedScans();

                    if (scans != null)
                    {
                        state += ": " + scans.Count + " scans to upload.";

                        if (scans.Count > 0)
                        {
                            try
                            {
                                this.ReportSyncProgress(string.Format("Found {0} scans to upload. Adding to upload data...", scans.Count), 10, scans);

                                request.Scans = new List<Asi.Itb.Bll.DataContracts.Scan>();
                                foreach (Asi.Itb.Bll.Entities.Scan scan in scans)
                                {
                                    DataContracts.Scan scanData = new Asi.Itb.Bll.DataContracts.Scan();
                                    scanData.Barcode = scan.Barcode;
                                    scanData.Location = scan.LocationCode;
                                    scanData.Operation = (int)scan.Operation;
                                    scanData.ScanTime = scan.ScanTime;
                                    scanData.UserName = scan.UserName;
                                    scanData.Damaged = Convert.ToInt32(scan.Damaged);
                                    request.Scans.Add(scanData);
                                }
                            }

                            catch (Exception ex1)
                            {
                                string msg = "Sync exception during generation of scans (" + scans.Count + ")";

                                processSyncException(msg, ex1);

                                return;
                            }
                        }
                    }

                    state = "Getting user activities";

                    UserManager umgr = new UserManager();

                    List<Asi.Itb.Bll.Entities.UserActivity> acts = umgr.GetActivities();

                    if (acts != null)
                    {
                        state += ": " + acts.Count + " acts to upload.";

                        if (acts.Count > 0)
                        {
                            try
                            {
                                this.ReportSyncProgress(string.Format("Found {0} user activities to upload. Adding to upload data...", acts.Count), 20, acts);
                                
                                request.UserActivities = new List<Asi.Itb.Bll.DataContracts.UserActivity>();
                                
                                foreach (Asi.Itb.Bll.Entities.UserActivity act in acts)
                                {
                                    DataContracts.UserActivity actData = new Asi.Itb.Bll.DataContracts.UserActivity();
                                    actData.UserName = act.UserName;
                                    actData.ActivityTime = act.ActivityTime;
                                    actData.ActivityType = (DataContracts.UserActivityType)act.ActivityType;
                                    request.UserActivities.Add(actData);
                                }
                            }

                            catch (Exception ex2)
                            {
                                string msg = "Sync exception during generation of activities (" + acts.Count + ")"; 

                                processSyncException(msg, ex2);

                                return;
                            }
                        }
                    }

                    state = "Getting handover locations";

                    // Send handover locations
                    if (_handoverLocations != null)
                    {
                        state += ": " + _handoverLocations.Count + " handover locations to upload.";

                        if (_handoverLocations.Count > 0)
                        {

                            try
                            {
                                this.ReportSyncProgress(string.Format("Found {0} new handover locations to upload. Adding to upload data...", _handoverLocations.Count), 25, _handoverLocations);
                                
                                request.HandoverLocations = new List<Asi.Itb.Bll.DataContracts.HandoverLocation>();
                                
                                foreach (Asi.Itb.Bll.DataContracts.HandoverLocation hl in _handoverLocations)
                                {
                                    request.HandoverLocations.Add(hl);
                                }
                            }

                            catch (Exception ex3)
                            {
                                string msg = "Sync exception during generation of handover locations (" + _handoverLocations.Count + ")";

                                processSyncException(msg, ex3);

                                return;
                            }
                        }
                    }

                    SyncFailureTime = null;

                    this.ReportSyncProgress("Performing updated sync.", 30, null);

                    state = "Performing updated sync";

                    PerfomUpdatedSync(request, scans, acts, umgr);

                    this.ReportSyncProgress("Updated sync completed.", 40, null);

                    //PerformLegacySync(request, scans, acts, umgr);

                    state = "Sync completed";

                    this.ReportSyncProgress("Synchronization completed successfully.", 100, null);
                }

                catch (Exception e)
                {
                    string msg = "Sync exception (" + state + ")";

                    processSyncException(msg, e);

                    return;
                }
            }
            
            //Debug.WriteLine("Exiting", "Sync");
        }

        private void processSyncException(string msg, Exception ex)
        {
            Dal.SyncLogManager.logSyncError("Sync", msg, ex);
                
            //MessageBox.Show(msg + ": " + ex.Message + "\n" + ex.StackTrace);

            if (this.SyncErrorOccurred != null)
            {
                // MDD uncomment the following
                //this.SyncErrorOccurred(this, new SyncErrorEventArgs(ex));
            }

            SyncFailureTime = DateTime.Now;

            return;
        }

        public void PerformLegacySync(
            DataContracts.ItbRequest request,
            List<Asi.Itb.Bll.Entities.Scan> scans,
            List<Asi.Itb.Bll.Entities.UserActivity> acts,
            UserManager umgr)
        {
            if (!Configuration.Instance.PerformLegacySync)
            {
                return;
            }

            if (Configuration.Instance.OperatingMode.ToLower() == "test")
            {
                return;
            }

            string uri = Configuration.Instance.WebServiceUri;
            if (string.IsNullOrEmpty(uri))
            {
                return;
            }

            XmlSerializer requestSl = new XmlSerializer(typeof(DataContracts.ItbRequest));
            StringWriter sw = new StringWriter();
            requestSl.Serialize(sw, request);
            string requestXml = sw.ToString();
            sw.Close();

            this.ReportSyncProgress("Upload data ready. Sending to server...", 45, requestXml);

            WebServiceClient wc = new WebServiceClient();

            DataContracts.ItbResponse response = null;
            using (Stream responseStream = wc.GetStreamFromLegacyPostRequest(requestXml, uri))
            {
                this.ReportSyncProgress("Download data received. Validating...", 50, responseStream);

                XmlSerializer serializer = new XmlSerializer(typeof(DataContracts.ItbResponse));
                Debug.WriteLine("serializer created", "Sync");
                response = (DataContracts.ItbResponse)serializer.Deserialize(responseStream);

                Debug.WriteLine("Deserialize() done", "Sync");

            }

            if (response.Error != null)
            {
                throw new Exception(response.Error);
            }

            // at this point, at least we can be sure the upload succeeded.
            // so we can clear upload data even if there will be errors in processing.
            if (scans != null && scans.Count > 0)
            {
                ScanManager.MarkScansUploaded(scans);
            }

            if (acts != null && acts.Count > 0)
            {
                umgr.DeleteActivities(acts);
            }

            this.ReportSyncProgress("Download data validated. Processing...", 75, response);

            this.ProcessLegacyResponse(response);

            this.ReportSyncProgress("Downloaded data processed. Updating local settings....", 90, null);
        }

        public void PerfomUpdatedSync(
            Asi.Itb.Bll.DataContracts.ItbRequest request,
            List<Asi.Itb.Bll.Entities.Scan> scans,
            List<Asi.Itb.Bll.Entities.UserActivity> acts,
            UserManager umgr)
        {
            if (!Configuration.Instance.PerformUpdatedSync)
            {
                return;
            }

            Stream responseStream = null;
            StreamReader reader = null;

            try
            {
                string uri = Configuration.Instance.UpdatedWebServiceUri;

                if (string.IsNullOrEmpty(uri))
                {
                    return;
                }

                ItbResponseRev2 itbResponseRev2 = null;

                string UserName = "";
                int UserId = 0;

                if (SessionData.Current != null)
                {
                    if (SessionData.Current.User != null)
                    {
                        UserName = SessionData.Current.User.UserName;
                        UserId = SessionData.Current.User.UserId;
                    }
                }

                string entity = Configuration.Instance.Entity;

                Asi.Itb.Bll.DataContracts.ItbRequestRev2 requestRev2 = new Asi.Itb.Bll.DataContracts.ItbRequestRev2()
                {
                    Entity = entity,
                    TransactionId = "",
                    SN = request.SN,
                    SessionUserName = UserName,
                    SessionUserId = UserId,
                    RequestTime = DateTime.UtcNow,
                    Gps = request.Gps,
                    LastUpdateServerTime = request.LastUpdateServerTime,
                    Scans = request.Scans,
                    UserActivities = request.UserActivities,
                    HandoverLocations = request.HandoverLocations,
                    BatteryPercent = request.BatteryPercent
                };

                JSONSerializer jsonSerializer = new JSONSerializer();

                string requestJSON = jsonSerializer.Serialize(requestRev2);

                //DebugWriteLine("RequestJSON: " + requestJSON, "PerformUpdatedSync");

                WebServiceClient wc = new WebServiceClient();

                responseStream = wc.GetStreamFromUpdatedPostRequest(requestJSON, uri);

                if (responseStream == null)
                {
                    return;
                }

                string response = null;

                try
                {
                    reader = new StreamReader(responseStream);
                }

                catch (Exception ex)
                {
                    SyncLogManager.logSyncError("PerfomUpdatedSync", "Sync error has occured while creating reader", ex);

                    if (reader != null)
                    {
                        reader.Close();
                        reader.Dispose();

                        reader = null;
                    }

                    return;
                }

                if (reader != null)
                {
                    response = reader.ReadToEnd();

                    DebugWriteLine("\nResponse from sync: " + response + "\n", "Perform Updated Sync");
                }

                if (responseStream != null)
                {
                    responseStream.Close();
                    responseStream.Dispose();

                    responseStream = null;
                }

                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();

                    reader = null;
                }

                if (string.IsNullOrEmpty(response))
                {
                    return;
                }

                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ItbResponseRev2));

                    StringReader stringReader = new StringReader(response);

                    itbResponseRev2 = (ItbResponseRev2)xmlSerializer.Deserialize(stringReader);
                }

                catch (Exception ex)
                {
                    SyncLogManager.logSyncError("PerfomUpdatedSync", "Sync error has occured while deserializing response: " + response, ex);

                    return;
                }

                if (itbResponseRev2.ExitCode.ToUpper() != "OK")
                {
                    return;
                }

                // at this point, at least we can be sure the upload succeeded.
                // so we can clear upload data even if there will be errors in processing.
                if (scans != null)
                {
                    if (scans.Count > 0)
                    {
                        ScanManager.MarkScansUploaded(scans);
                    }
                }

                if (acts != null && acts.Count > 0)
                {
                    if (acts.Count > 0)
                    {
                        umgr.DeleteActivities(acts);
                    }
                }

                ProcessUpdatedResponse(itbResponseRev2);
            }

            catch (Exception ex)
            {
                SyncLogManager.logSyncError("PerfomUpdatedSync", "Sync error has occured", ex);

                //MessageBox.Show("PerfomUpdatedSync exception: " + ex.Message + "\n" + ex.StackTrace);
            }

            if (responseStream != null)
            {
                responseStream.Close();
                responseStream.Dispose();

                responseStream = null;
            }

            if (reader != null)
            {
                reader.Close();
                reader.Dispose();

                reader = null;
            }
        }

        private void ProcessUpdatedResponse(ItbResponseRev2 response)
        {
            if (response == null)
            {
                return;
            }

            if (response.ExitCode.ToUpper() != "OK")
            {
                return;
            }

            if (response.CurrentServerTime != null)
            {
                TimeSpan timeDelta = DateTime.UtcNow.Subtract(response.CurrentServerTime);
                if (Math.Abs(timeDelta.Duration().TotalSeconds) > 30)
                {
                    Hardware.Device.SetTime(response.CurrentServerTime);
                }
            }
        }

        /// <summary>
        /// Gets server time of last update of the scanner.
        /// </summary>
        /// <returns></returns>
        private DateTime? GetLastUpdateServerTime()
        {
            LocalVariablesTableAdapter adpt = new LocalVariablesTableAdapter();
            adpt.Connection = DatabaseManager.Connection;
            ItbDataSet.LocalVariablesDataTable dt = adpt.GetData();
            if (dt.Rows.Count > 0)
            {
                ItbDataSet.LocalVariablesRow row = dt[0];
                return row.LastUpdateServerTime;
            }
            return null;
        }

        /// <summary>
        /// Gets interval time for periodic scanner update background process.
        /// </summary>
        /// <returns></returns>
        public int? GetScannerUpdateInterval()
        {
            LocalVariablesTableAdapter adpt = new LocalVariablesTableAdapter();
            adpt.Connection = DatabaseManager.Connection;
            ItbDataSet.LocalVariablesDataTable dt = adpt.GetData();
            if (dt.Rows.Count > 0)
            {
                ItbDataSet.LocalVariablesRow row = dt[0];
                if (row.ScannerUpdateInterval == 0)
                {
                    return null;
                }
                else
                {
                    return row.ScannerUpdateInterval;
                }
            }
            return null;
        }

        /// <summary>
        /// Save data in response into local database
        /// </summary>
        /// <param name="response"></param>
        private void ProcessLegacyResponse(DataContracts.ItbResponse response)
        {
            TimeSpan timeDelta = DateTime.UtcNow.Subtract(response.CurrentServerTime);
            if (timeDelta.Duration().TotalSeconds > 60)
            {
                Hardware.Device.SetTime(response.CurrentServerTime);
            }

            using (LocalVariablesTableAdapter adpt = new LocalVariablesTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;

                if (response.BagDropOffTimeLimitMinutes != null)
                {
                    adpt.UpdateDropOffTimeLimit(response.BagDropOffTimeLimitMinutes);
                }
                if (response.GpsUploadIntervalSeconds != null)
                {
                    adpt.UpdateGpsUploadInterval(response.GpsUploadIntervalSeconds);
                }
                if (response.ExitCode != null)
                {
                    adpt.UpdateExitCode(response.ExitCode);
                }
                if (response.ScannerUpdateIntervalSeconds != null)
                {
                    adpt.UpdateScannerUpdateInterval(response.ScannerUpdateIntervalSeconds);
                    if (this.ScannerUpdateIntervalUpdated != null)
                    {
                        this.ScannerUpdateIntervalUpdated(this, null);
                    }
                }
                if (response.IdleTimeOutMinutes != null)
                {
                    adpt.UpdateIdleTimeOutLimit(response.IdleTimeOutMinutes * 60);
                    if (this.IdleTimeOutUpdated != null)
                    {
                        this.IdleTimeOutUpdated(this, null);
                    }
                }
                if (response.GpsIdleTimeOutMinutes != null)
                {
                    adpt.UpdateGpsIdleTimeOutLimit(response.GpsIdleTimeOutMinutes * 60);
                    if (this.GpsIdleTimeOutUpdated != null)
                    {
                        this.GpsIdleTimeOutUpdated(this, new EventArgs());
                    }
                }

                if (response.BatteryWarningPercent != null)
                {
                    adpt.UpdateBatteryWarningPercent((int)(response.BatteryWarningPercent * 100));
                    if (this.BatteryWarningPercentUpdated != null)
                    {
                        this.BatteryWarningPercentUpdated(this, new EventArgs());
                    }
                }

                if (response.Locations != null)
                {
                    using (LocationTableAdapter ladpt = new LocationTableAdapter())
                    {
                        ladpt.Connection = DatabaseManager.Connection;
                        ladpt.DeleteAll();
                        foreach (DataContracts.Location loc in response.Locations)
                        {
                            double latitude = 0;
                            double longitude = 0;
                            if (loc.Gps != null)
                            {
                                string[] gps = loc.Gps.Split(",".ToCharArray());
                                latitude = double.Parse(gps[0]);
                                longitude = double.Parse(gps[1]);
                            }
                            ladpt.InsertLocation(loc.Name, latitude, longitude, loc.Type, loc.Carriers);
                        }
                    }
                }

                if (response.Messages != null)
                {
                    using (MessageTableAdapter madpt = new MessageTableAdapter())
                    {
                        madpt.Connection = DatabaseManager.Connection;
                        foreach (DataContracts.Message msg in response.Messages)
                        {
                            madpt.InsertNewMessage(msg.Subject, msg.Content, false, msg.MessageTime);
                        }
                    }
                }

                if (response.Scans != null)
                {
                    using (ScanTableAdapter sadpt = new ScanTableAdapter())
                    {
                        sadpt.Connection = DatabaseManager.Connection;
                        foreach (DataContracts.Scan s in response.Scans)
                        {
                            sadpt.InsertScan(s.Barcode, (byte)s.Operation, s.ScanTime, true, null, s.Location, null);
                        }
                    }
                }

                if (response.Bsm != null)
                {
                    using (BsmTableAdapter badpt = new BsmTableAdapter())
                    {
                        badpt.Connection = DatabaseManager.Connection;

                        // only delete old ones if there are new coming
                        badpt.DeleteOldBags();

                        foreach (DataContracts.Bag bag in response.Bsm)
                        {
                            badpt.DeleteBag(bag.Barcode); // removing existing old bag first
                            badpt.InsertBag(bag.Barcode, bag.DestLocation, bag.InboundCarrier, bag.OutboundCarrier, DateTime.Now, bag.InboundFlight, bag.OutboundFlight);
                        }
                    }
                }

                if (response.Users != null)
                {
                    // set up mapping from rolename to roleid
                    using (RoleTableAdapter radpt = new RoleTableAdapter())
                    using (UserTableAdapter uadpt = new UserTableAdapter())
                    {
                        radpt.Connection = DatabaseManager.Connection;
                        ItbDataSet.RoleDataTable dt = radpt.GetData();
                        Dictionary<string, byte> roleIdMap = new Dictionary<string, byte>();
                        foreach (ItbDataSet.RoleRow row in dt.Rows)
                        {
                            roleIdMap.Add(row.Name.ToLower(), row.Id);
                        }

                        uadpt.Connection = DatabaseManager.Connection;
                        uadpt.DeleteAll();
                        foreach (DataContracts.User u in response.Users)
                        {
                            uadpt.InsertUser(u.UserName, u.Password, roleIdMap[u.Level.ToLower()], u.Salt);
                        }
                    }
                }

                if (response.Flights != null)
                {
                    FlightManager fmgr = new FlightManager();
                    fmgr.InsertFlights(response.Flights);
                    fmgr.FlushOldFlights();
                }

                adpt.UpdateLastUpdateServerTime(response.ServerTime);
            }
        }

        /// <summary>
        /// Reports current progress to UI element if setup.
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <param name="percent"></param>
        private void ReportSyncProgress(string statusMessage, int percent, object detail)
        {
            Debug.WriteLine(statusMessage, "ReportSyncProgress");

            if (this.SyncProgressMade != null)
            {
                SyncProgressEventArgs args = new SyncProgressEventArgs();
                args.StatusMessage = statusMessage;
                args.ProgressPercentage = percent;
                args.Detail = detail;
                this.SyncProgressMade(this, args);
            }
        }

        private void DebugWriteLine(string msg, string src)
        {
            //LogManager.DebugWriteLine(msg, src);
        }
    }
}
