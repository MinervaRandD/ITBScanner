using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Represent entity for a particular bag, identitified by barcode
    /// </summary>
    public class Bag
    {
        /// <summary>
        /// Tag/barcode of the bag
        /// </summary>
        public string Barcode
        {
            get;
            set;
        }

        /// <summary>
        /// Carrier of inbound flight
        /// </summary>
        public string InboundCarrier
        {
            get;
            set;
        }

        /// <summary>
        /// Carrier of outbound flight
        /// </summary>
        public string OutboundCarrier
        {
            get;
            set;
        }

        /// <summary>
        /// Barcode of destination location
        /// </summary>
        public string DestinationLocationCode
        {
            get;
            set;
        }

        /// <summary>
        /// Flight number of inbound flight
        /// </summary>
        public short InboundFlight
        {
            get;
            set;
        }

        /// <summary>
        /// Flight number of outbound flight
        /// </summary>
        public short OutboundFlight
        {
            get;
            set;
        }

        /// <summary>
        /// ETA of inbound flight of the bag
        /// </summary>
        public DateTime? ArrivalTime
        {
            get;
            set;
        }

        /// <summary>
        /// ETD of outbound flight of the bag
        /// </summary>
        public DateTime? DepartureTime
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the bag is damaged
        /// </summary>
        public bool? Damaged
        {
            get;
            set;
        }

        /// <summary>
        /// Status filter to select bags
        /// </summary>
        public enum Status
        {
            OnHand,
            DroppedOff,
            All
        }
    }

}
