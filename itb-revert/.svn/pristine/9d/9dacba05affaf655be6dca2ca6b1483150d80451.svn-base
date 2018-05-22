using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Represents flight entity from local database
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
        public DateTime? ArrivalTime
        {
            get;
            set;
        }

        /// <summary>
        /// Local ETD time of the flight. Present for outbound flight.
        /// </summary>
        public DateTime? DepartureTime
        {
            get;
            set;
        }
    }
}