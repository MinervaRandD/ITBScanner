using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Represents event args for Sync progress
    /// </summary>
    public class SyncProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Current progress status description
        /// </summary>
        public string StatusMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Overall percentage of completion in whole sync process
        /// </summary>
        public int ProgressPercentage
        {
            get;
            set;
        }

        /// <summary>
        /// Further detail information
        /// </summary>
        public object Detail
        {
            get;
            set;
        }
    }
}
