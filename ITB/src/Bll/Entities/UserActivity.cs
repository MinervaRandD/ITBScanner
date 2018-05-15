using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Business entity for UserActivity records
    /// </summary>
    public class UserActivity
    {
        /// <summary>
        /// Database ID of the user activity record.
        /// </summary>
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        /// UserName of the user performing the action
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// UTC Time when the activity occurred.
        /// </summary>
        public DateTime ActivityTime
        {
            get;
            set;
        }

        /// <summary>
        /// Type of the activity.
        /// </summary>
        public UserActivityType ActivityType
        {
            get;
            set;
        }
    }
}
