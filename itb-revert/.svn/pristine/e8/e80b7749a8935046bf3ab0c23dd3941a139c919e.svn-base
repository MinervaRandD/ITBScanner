using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Asi.Itb.Dal;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Dal.ItbDataSetTableAdapters;

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
                try
                {
                    this.ReportSyncProgress("Started sync process. Preparing upload data...", 5, null);

                    DataContracts.ItbRequest request = new DataContracts.ItbRequest();

                    request.SN = SessionData.Current.SN;
                    if (request.SN == null)
                    {
                        request.SN = "UNKNOWN";
                    }
                    request.Gps = SessionData.Current.GpsPosition == null ? null : SessionData.Current.GpsPosition.ToString();
                    request.LastUpdateServerTime = this.GetLastUpdateServerTime();

                    request.BatteryPercent = Hardware.Power.BatteryPercent();

                    List<Scan> scans = ScanManager.GetToBeUploadedScans();
                    if (scans != null && scans.Count > 0)
                    {
                        this.ReportSyncProgress(string.Format("Found {0} scans to upload. Adding to upload data...", scans.Count), 10, scans);

                        request.Scans = new List<Asi.Itb.Bll.DataContracts.Scan>();
                        foreach (Scan scan in scans)
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

                    UserManager umgr = new UserManager();
                    List<UserActivity> acts = umgr.GetActivities();
                    if (acts != null && acts.Count > 0)
                    {
                        this.ReportSyncProgress(string.Format("Found {0} user activities to upload. Adding to upload data...", acts.Count), 20, acts);
                        request.UserActivities = new List<Asi.Itb.Bll.DataContracts.UserActivity>();
                        foreach (UserActivity act in acts)
                        {
                            DataContracts.UserActivity actData = new Asi.Itb.Bll.DataContracts.UserActivity();
                            actData.UserName = act.UserName;
                            actData.ActivityTime = act.ActivityTime;
                            actData.ActivityType = (DataContracts.UserActivityType)act.ActivityType;
                            request.UserActivities.Add(actData);
                        }
                    }

                    // Send handover locations
                    if (_handoverLocations != null && _handoverLocations.Count > 0)
                    {
                        this.ReportSyncProgress(string.Format("Found {0} new handover locations to upload. Adding to upload data...", _handoverLocations.Count), 25, _handoverLocations);
                        request.HandoverLocations = new List<Asi.Itb.Bll.DataContracts.HandoverLocation>();
                        foreach (Asi.Itb.Bll.DataContracts.HandoverLocation hl in _handoverLocations)
                        {
                            request.HandoverLocations.Add(hl);
                        }
                    }

                    XmlSerializer requestSl = new XmlSerializer(typeof(DataContracts.ItbRequest));
                    StringWriter sw = new StringWriter();
                    requestSl.Serialize(sw, request);
                    string requestXml = sw.ToString();
                    sw.Close();

                    this.ReportSyncProgress("Upload data ready. Sending to server...", 30, requestXml);

                    string uri = Configuration.Instance.WebServiceUri;
                    WebServiceClient wc = new WebServiceClient();

                    DataContracts.ItbResponse response = null;
                    using (Stream responseStream = wc.GetStreamFromPostRequest(requestXml, uri))
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

                    this.ProcessResponse(response);

                    this.ReportSyncProgress("Downloaded data processed. Updating local settings....", 90, null);

                    this.ReportSyncProgress("Synchronization completed successfully.", 100, null);

                    SyncFailureTime = null;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception: " + e.Message, "Sync");
                    if (this.SyncErrorOccurred != null)
                    {
                        this.SyncErrorOccurred(this, new SyncErrorEventArgs(e));
                    }

                    SyncFailureTime = DateTime.Now;
                }

                Debug.WriteLine("Exiting", "Sync");
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
        private void ProcessResponse(DataContracts.ItbResponse response)
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
    }
}
