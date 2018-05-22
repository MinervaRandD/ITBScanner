using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Asi.Itb.Bll.DataContracts
{
    /// <summary>
    /// Represents flight information data contract
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Flight carrier code
        /// </summary>
        public string Carrier
        {
            get;
            set;
        }

        /// <summary>
        /// 4-digit flight number
        /// </summary>
        public short Number
        {
            get;
            set;
        }

        /// <summary>
        /// Local ETA time of the flight. Present for inbound flight.
        /// </summary>
        [XmlIgnore]
        public DateTime? ArrivalTime
        {
            get;
            set;
        }

        [XmlElement("ArrivalTime")]
        public string ArrivalTimeXml
        {
            get
            {
                if (this.ArrivalTime == null)
                {
                    return null;
                }
                else
                {
                    return this.ArrivalTime.Value.ToString("HH:mm");
                }
            }
            set
            {
                this.ArrivalTime = DateTime.ParseExact(value, "HH:mm", null);
            }
        }

        /// <summary>
        /// Local ETD time of the flight. Present for outbound flight.
        /// </summary>
        [XmlIgnore]
        public DateTime? DepartureTime
        {
            get;
            set;
        }

        [XmlElement("DepartureTime")]
        public string DepartureTimeXml
        {
            get
            {
                if (this.DepartureTime == null)
                {
                    return null;
                }
                else
                {
                    return this.DepartureTime.Value.ToString("HH:mm");
                }
            }
            set
            {
                this.DepartureTime = DateTime.ParseExact(value, "HH:mm", null);
            }
        }
    }
}
