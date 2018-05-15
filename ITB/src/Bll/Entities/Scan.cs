using System;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Represents local and server scan data
    /// </summary>
    public class Scan
    {
        /// <summary>
        /// DB Id of the scan record
        /// </summary>
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        /// Barcode of the scan
        /// </summary>
        public string Barcode
        {
            get;
            set;
        }

        /// <summary>
        /// Operation type
        /// </summary>
        public ScanOperation Operation
        {
            get;
            set;
        }

        /// <summary>
        /// Time when the scan occurred
        /// </summary>
        public DateTime ScanTime
        {
            get;
            set;
        }

        /// <summary>
        /// Whether or not the scan has been uploaded
        /// </summary>
        public bool IsUploaded
        {
            get;
            set;
        }

        /// <summary>
        /// Username of the employee who performed the scan
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Code of the location in which the scan was performed.
        /// </summary>
        public string LocationCode
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the scanned bag is deemed damaged.
        /// </summary>
        public bool Damaged
        {
            get;
            set;
        }

        /// <summary>
        /// Whether the scan is one of the pick-up scans
        /// </summary>
        public bool IsPickUp
        {
            get
            {
                if (this.Operation == ScanOperation.HandlerPickUp || 
                    this.Operation == ScanOperation.CarrierPickUp || 
                    this.Operation == ScanOperation.GatePickUp || 
                    this.Operation == ScanOperation.OvernightOut)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Represents scan operation codes
        /// </summary>
        public enum ScanOperation
        {
            HandlerPickUp = 1,
            HandlerDropOff,
            CarrierPickUp,
            CarrierDropOff,
            GatePickUp,
            GateDropOff,
            OvernightIn,
            OvernightOut
        }
    }
}
