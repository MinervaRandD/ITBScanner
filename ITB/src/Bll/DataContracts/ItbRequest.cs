using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Asi.Itb.Bll.DataContracts
{
    /// <summary>
    /// Represent container data encapsulating web service request.
    /// </summary>
    public class ItbRequest
    {
        public string SN
        {
            get;
            set;
        }

        public string Gps
        {
            get;
            set;
        }

        [XmlIgnore]
        public DateTime? LastUpdateServerTime
        {
            get;
            set;
        }

        [XmlElement("LastUpdateServerTime")]
        public string LastUpdateServerTimeXml
        {
            get
            {
                if (this.LastUpdateServerTime == null)
                {
                    return null;
                }
                else
                {
                    return this.LastUpdateServerTime.Value.ToUniversalTime().ToString("u");
                }
            }
            set
            {
                this.LastUpdateServerTime = DateTime.Parse(value);
            }
        }

        public List<Scan> Scans
        {
            get;
            set;
        }

        /// <summary>
        /// List of login/logout activities
        /// </summary>
        public List<UserActivity> UserActivities
        {
            get;
            set;
        }

        public List<HandoverLocation> HandoverLocations
        {
            get;
            set;
        }

        public int BatteryPercent
        {
            get;
            set;
        }
    }
}
