using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Asi.Itb.Bll.DataContracts
{
    public class Message
    {
        public string Subject
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        [XmlIgnore]
        public DateTime MessageTime
        {
            get;
            set;
        }

        [XmlElement("MessageTime")]
        public string MessageTimeXml
        {
            get
            {
                return this.MessageTime.ToUniversalTime().ToString("u");
            }
            set
            {
                this.MessageTime = DateTime.Parse(value, null, System.Globalization.DateTimeStyles.AdjustToUniversal);
            }
        }
    }
}
