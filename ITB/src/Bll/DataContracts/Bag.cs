using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.DataContracts
{
    public class Bag
    {
        public string Barcode
        {
            get;
            set;
        }

        public string DestLocation
        {
            get;
            set;
        }

        public string InboundCarrier
        {
            get;
            set;
        }

        public short? InboundFlight
        {
            get;
            set;
        }

        public string OutboundCarrier
        {
            get;
            set;
        }

        public short? OutboundFlight
        {
            get;
            set;
        }
    }
}
