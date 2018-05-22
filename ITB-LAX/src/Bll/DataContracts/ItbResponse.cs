﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Asi.Itb.Bll.DataContracts
{
    /// <summary>
    /// Represents data entitiy from web service response xml
    /// </summary>
    public class ItbResponse
    {
        /// <summary>
        /// Effective server UTC time for the response data
        /// </summary>
        /// <remarks>
        /// ServerTime may not be the actual current server time, particularily during
        /// chunk responses.
        /// </remarks>
        [XmlIgnore]
        public DateTime ServerTime
        {
            get;
            set;
        }

        [XmlElement("ServerTime")]
        public string ServerTimeXml
        {
            get
            {
                return this.ServerTime.ToUniversalTime().ToString("u");
            }
            set
            {
                this.ServerTime = DateTime.Parse(value, null, System.Globalization.DateTimeStyles.AdjustToUniversal);
            }
        }

        /// <summary>
        /// Current server UTC time used to synchronize device with.
        /// </summary>
        [XmlIgnore]
        public DateTime CurrentServerTime
        {
            get;
            set;
        }

        [XmlElement("CurrentServerTime")]
        public string CurrentServerTimeXml
        {
            get
            {
                return this.CurrentServerTime.ToUniversalTime().ToString("u");
            }
            set
            {
                this.CurrentServerTime = DateTime.Parse(value, null, System.Globalization.DateTimeStyles.AdjustToUniversal);
            }
        }

        /// <summary>
        /// Encrypted scanner exit code
        /// </summary>
        public string ExitCode
        {
            get;
            set;
        }

        /// <summary>
        /// Required interval to upload GPS data in seconds
        /// </summary>
        public int? GpsUploadIntervalSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Required uppper limit of minutes before picked-up bags being dropped-off
        /// </summary>
        public int? BagDropOffTimeLimitMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// List of users for current scanner (or airport)
        /// </summary>
        public List<User> Users
        {
            get;
            set;
        }

        /// <summary>
        /// List of locations applicable to current scanner
        /// </summary>
        public List<Location> Locations
        {
            get;
            set;
        }

        /// <summary>
        /// List of Bags from BSM
        /// </summary>
        public List<Bag> Bsm
        {
            get;
            set;
        }

        /// <summary>
        /// List of scans from other scanners
        /// </summary>
        public List<Scan> Scans
        {
            get;
            set;
        }

        /// <summary>
        /// List of Messages to download
        /// </summary>
        public List<Message> Messages
        {
            get;
            set;
        }

        /// <summary>
        /// Interval between web service calls in seconds
        /// </summary>
        public int? ScannerUpdateIntervalSeconds
        {
            get;
            set;
        }

        /// <summary>
        /// Error message from server
        /// </summary>
        public string Error
        {
            get;
            set;
        }

        /// <summary>
        /// Idle time in minutes before users are logged out
        /// </summary>
        public int? IdleTimeOutMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// No GPS movement time in minutes before users are logged out
        /// </summary>
        public int? GpsIdleTimeOutMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// Battery warning threshold in percent
        /// </summary>
        public decimal? BatteryWarningPercent
        {
            get;
            set;
        }

        /// <summary>
        /// List of flight information from server.
        /// </summary>
        public List<Flight> Flights
        {
            get;
            set;
        }
    }
}
