using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Asi.Itb.Bll.DataContracts
{
    /// <summary>
    /// Represent container data encapsulating web service request.
    /// </summary>
    /// 

    public class ItbRequestRev2
    {
        public string Entity
        {
            get;
            set;
        }

        public string TransactionId
        {
            get;
            set;
        }

        public string SN
        {
            get;
            set;
        }

        public string SessionUserName
        {
            get;
            set;
        }

        public int SessionUserId
        {
            get;
            set;
        }

        [XmlIgnore]
        public DateTime RequestTime
        {
            get;
            set;
        }

        [XmlElement("RequestTime")]
        public string RequestTimeXml
        {
            get
            {
                return this.RequestTime.ToString("u");
            }
            set
            {
                this.RequestTime = DateTime.Parse(value);
            }
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
                if (LastUpdateServerTime.HasValue)
                {
                    return this.LastUpdateServerTime.Value.ToString("u");
                }

                else
                {
                    return null;
                }
            }

            set
            {
                if (value == null)
                {
                    LastUpdateServerTime = null;
                }

                else
                {
                    this.LastUpdateServerTime = DateTime.Parse(value);
                }
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
