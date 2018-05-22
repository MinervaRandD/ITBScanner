using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.DataContracts
{
    /// <summary>
    /// Represents user data from web service
    /// </summary>
    public class User
    {
        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Level
        {
            get;
            set;
        }

        public string Salt
        {
            get;
            set;
        }
    }
}
