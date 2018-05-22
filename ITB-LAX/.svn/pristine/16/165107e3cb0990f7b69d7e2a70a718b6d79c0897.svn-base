using System;
using System.Data.SqlServerCe; 
using TagTrak.TagTrakLib;
using System.Data; 
using System.Threading; 
using System.Collections;
using TagTrak.TagTrakLib.com.asiscan.baggage;

namespace TagTrak.Baggage
{
	/// <summary>
	/// model class containing data for a baggage scna
	/// </summary>
	internal class BagScan
	{
        /// <summary>
        /// For every SynchronizeInterval updates do a synchronize
        /// </summary>
        private const int SynchronizeInterval = 12;

		public string opcode;
		public string tag;
		public string carrier;
		public string location;
		public string fromFlight;
		public string toFlight;
		public string cartid;
		public string holdpos;
		public string containerpos;
		public string employeeno;
		public System.DateTime scantime;
		public static string uploadStatus; 
		public bool gatechecked = false;

		private static SqlCeCommand insertCmd; 
		private static SqlCeConnection dbcon;

        private static Object _staticLock = new Object();
        private static int _uploadIndex = 0;

        private static string _activeOpCode = null;
        /// <summary>
        /// Currently selected op code
        /// </summary>
        public static string ActiveOpCode
        {
            get
            {
                lock (_staticLock)
                {
                    return _activeOpCode;
                }
            }
            set
            {
                lock (_staticLock)
                {
                    _activeOpCode = value;
                    _uploadIndex = 0;
                }
            }
        }

        private static int? _activeFlightNumber = null;
        /// <summary>
        /// Currently typed in flight number
        /// </summary>
        public static int? ActiveFlightNumber
        {
            get
            {
                lock (_staticLock)
                {
                    return _activeFlightNumber;
                }
            }
            set
            {
                lock (_staticLock)
                {
                    _activeFlightNumber = value;
                    _uploadIndex = 0;
                }
            }
        }

		public BagScan()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void SetUpDatabase() 
		{ 
			dbcon = DbAccess.OpenConnection; 

			insertCmd = dbcon.CreateCommand(); 
			string insertSql	
				= "insert into bag_scans (" 
				+ "operation_code, " 
				+ "tag, " 
				+ "carrier, " 
				+ "location, " 
				+ "from_flight, " 
				+ "to_flight, " 
				+ "cart_id, " 
				+ "hold_position, " 
				+ "container_position, " 
				+ "employee_number, " 
				+ "scan_time, " 
				+ "gate_checked"
				+ ") values (" 
				+ "?,?,?,?,?,?,?,?,?,?,?,?" 
				+ ")"; 
			insertCmd.CommandText = insertSql; 
			insertCmd.Parameters.Add(new SqlCeParameter("opcode", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("tag", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("carrier", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("location", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("fromflight", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("toflight", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("cartid", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("holdpos", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("containerpos", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("employeeno", DbType.String)); 
			insertCmd.Parameters.Add(new SqlCeParameter("scantime", DbType.Date)); 
			insertCmd.Parameters.Add(new SqlCeParameter("gatechecked", DbType.Boolean));
			insertCmd.Prepare(); 
		} 

		public void Save() 
		{ 
			insertCmd.Parameters["opcode"].Value = this.opcode; 
			insertCmd.Parameters["tag"].Value = this.tag; 
			insertCmd.Parameters["carrier"].Value = this.carrier; 
			insertCmd.Parameters["location"].Value = this.location; 
			insertCmd.Parameters["fromflight"].Value = this.fromFlight; 
			insertCmd.Parameters["toflight"].Value = this.toFlight; 
			insertCmd.Parameters["cartid"].Value = this.cartid; 
			insertCmd.Parameters["holdpos"].Value = this.holdpos; 
			insertCmd.Parameters["containerpos"].Value = this.containerpos; 
			insertCmd.Parameters["employeeno"].Value = this.employeeno;
			insertCmd.Parameters["scantime"].Value = this.scantime; 
			insertCmd.Parameters["gatechecked"].Value = this.gatechecked; 

			insertCmd.ExecuteNonQuery(); 
		}

		public static void Upload(object stateInfo) 
		{
			SqlCeDataAdapter daScans = new SqlCeDataAdapter("select * from bag_scans where uploaded = 0", dbcon);
			DataSet dsScans = new DataSet();

            SqlCeDataAdapter daLog = new SqlCeDataAdapter("select * from log where uploaded = 0", dbcon);
            DataSet dsLog = new DataSet(); 

			WebSyncService ws = new WebSyncService();

            while (true)
            {
                Thread.Sleep(5000);
                daScans.Fill(dsScans);
                daLog.Fill(dsLog);
                
                int rows = dsScans.Tables[0].Rows.Count;
                
                if (rows > 0)
                {
                    uploadStatus = rows + " new scan(s) found. Uploading ...";
                    if (!BagScanBaseForm.isClose)
                    {
                        BagScanBaseForm.Instance.Invoke(new EventHandler(BagScanBaseForm.Instance.updateStatusUpdate));
                    }
                    //					string data = ds.GetXml().Trim(); 
                    string data = DbAccess.ToTxtString(dsScans.Tables[0]);
                    try
                    {
                        string sn = Utilities.SerialNo;
                        string version = System.Reflection.Assembly.GetCallingAssembly().GetName().Version.ToString();
                        ws.UploadBagScans(data, false, "txt", sn);
                        foreach (DataRow r in dsScans.Tables[0].Rows)
                        {
                            SqlCeCommand c = new SqlCeCommand("update bag_scans set uploaded=1 where id=" + r["id"], dbcon);
                            c.ExecuteNonQuery();
                        }

                        uploadStatus = DateTime.Now.ToShortTimeString() + ": " + rows + " scan(s) uploaded.";

                        if (BagScanBaseForm.Instance.ActiveLog)
                        {
                            BagScanBaseForm.Instance.Logs.Add(new ScanLog(rows + " scan(s) uploaded"));
                        }

                        if (_uploadIndex % SynchronizeInterval == 0)
                        {
                            // Synchronize data
                            Synchronize();
                        }
                        _uploadIndex++;

                    }
                    catch (Exception ex)
                    {
                        uploadStatus = DateTime.Now.ToShortTimeString() + ": " + ex.Message;

                        if (BagScanBaseForm.Instance.ActiveLog)
                        {
                            BagScanBaseForm.Instance.Logs.Add(new ScanLog(ex.Message));
                        }
                    }
                }
                else
                {
                    uploadStatus = "No new scan to upload";
                }
                dsScans.Clear();

                if (!BagScanBaseForm.isClose)
                {
                    BagScanBaseForm.Instance.Invoke(new EventHandler(BagScanBaseForm.Instance.updateStatusUpdate));
                }
                else
                {
                    break;
                }

            }// end while

            daScans.Dispose();
			((AutoResetEvent)stateInfo).Set();

		}// end function

        public static void Synchronize()
        {
            ConfigSetting config = ConfigSetting.Instance();

            Flights.Update(config.Carrier, config.Location);

            int? FlightNumber;
            string OpCode;
            lock (_staticLock)
            {
                FlightNumber = _activeFlightNumber;
                OpCode = _activeOpCode;
            }

            if (FlightNumber.HasValue && OpCode == "U")
            {
                // We're unloading a flight now
                HotBags.Update(config.Carrier, config.Location, FlightNumber.Value);
            }
            
            // Cleanup uoutdated records
            Flights.Cleanup();
            HotBags.Cleanup();


        }// end function

	}// end class

}// end namespace
