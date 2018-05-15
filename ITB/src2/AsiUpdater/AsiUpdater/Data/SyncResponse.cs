using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AsiUpdater.Data
{
    [XmlRoot("ItbResponse")]
    public class SyncResponse
    {
        public string ScannerUpgradeTime
        {
            get;
            set;
        }

        public string ScannerUpgradeTimeWindowMinutes
        {
            get;
            set;
        }
    }
}
