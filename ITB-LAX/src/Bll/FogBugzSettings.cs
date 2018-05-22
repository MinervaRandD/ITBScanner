using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Settings for submitting FogBugz error during crash
    /// </summary>
    public class FogBugzSettings
    {
        public string Uri
        {
            get;
            set;
        }

        public string Project
        {
            get;
            set;
        }

        public string Area
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }
    }
}
