using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Represents currently logged in scanner user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Logged in user DB ID
        /// </summary>
        public int UserId
        {
            get;
            set;
        }
        /// <summary>
        /// Logged in username
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// RoleName of the user
        /// </summary>
        public string RoleName
        {
            get;
            set;
        }

        /// <summary>
        /// List of permissions related to the user
        /// </summary>
        public List<string> Permissions
        {
            get;
            set;
        }
    }
}
