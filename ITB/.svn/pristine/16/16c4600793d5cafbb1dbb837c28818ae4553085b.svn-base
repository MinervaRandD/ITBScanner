using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Asi.Itb.Bll.DataContracts
{
    /// <summary>
    /// DataContract for UserActivity records
    /// </summary>
    public class UserActivity
    {
        /// <summary>
        /// Type of the activity.
        /// </summary>
        [XmlElement("Type")]
        public UserActivityType ActivityType
        {
            get;
            set;
        }

        /// <summary>
        /// UserName of the user performing the action
        /// </summary>
        [XmlElement("User")]
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// UTC Time when the activity occurred.
        /// </summary>
        [XmlIgnore]
        public DateTime ActivityTime
        {
            get;
            set;
        }

        [XmlElement("DateTime")]
        public string ActivityTimeXml
        {
            get
            {
                return this.ActivityTime.ToString("u");
            }
            set
            {
                this.ActivityTime = DateTime.Parse(value);
            }
        }
    }
}
