using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Represents scan location data
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Barcode of the location. Can also be gate number for gates.
        /// </summary>
        public string Barcode
        {
            get;
            set;
        }

        /// <summary>
        /// GPS Latitude value 
        /// </summary>
        public double Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// GPS longitude value
        /// </summary>
        public double Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// P(ickup)/D(ropoff) type of the location
        /// </summary>
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// List of carriers at the location.
        /// </summary>
        public List<string> Carriers
        {
            get;
            set;
        }

        /// <summary>
        /// Source of the location. Used when in SessionData.
        /// </summary>
        public LocationSource Source
        {
            get;
            set;
        }


        /// <summary>
        /// Gets allowed scan operation based on location type and current user.
        /// </summary>
        public Scan.ScanOperation? AllowedOperation
        {
            get
            {
                List<String> permissions = SessionData.Current.User.Permissions;
                if (this.Type == "P")
                {
                    if (permissions.Contains("Handler Pick Up"))
                    {
                        return Scan.ScanOperation.HandlerPickUp;
                    }
                    else if (permissions.Contains("Carrier Drop Off"))
                    {
                        return Scan.ScanOperation.CarrierDropOff;
                    }
                }
                else if (this.Type == "D")
                {
                    if (permissions.Contains("Handler Drop Off"))
                    {
                        return Scan.ScanOperation.HandlerDropOff;
                    }
                    else if (permissions.Contains("Carrier Pick Up"))
                    {
                        return Scan.ScanOperation.CarrierPickUp;
                    }
                }
                else if (this.Type == "I")
                {
                    if (permissions.Contains("Overnight In"))
                    {
                        return Scan.ScanOperation.OvernightIn;
                    }
                }
                else if (this.Type == "O")
                {
                    if (permissions.Contains("Overnight Out"))
                    {
                        return Scan.ScanOperation.OvernightOut;
                    }
                }
                return null;
            }
        }
    }
}
