using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Asi.Itb.Bll.DataContracts
{
    public class Scan
    {
        public string Barcode
        {
            get;
            set;
        }

        public int Operation
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public int? Damaged
        {
            get;
            set;
        }

        [XmlIgnore]
        public DateTime ScanTime
        {
            get;
            set;
        }

        [XmlElement("ScanTime")]
        public string ScanTimeXml
        {
            get
            {
                return this.ScanTime.ToString("u");
            }
            set
            {
                this.ScanTime = DateTime.Parse(value);
            }
        }

        public string UserName
        {
            get;
            set;
        }
    }
}
