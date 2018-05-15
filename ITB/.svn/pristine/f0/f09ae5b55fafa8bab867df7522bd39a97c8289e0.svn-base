using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Reprents EventArgs for error occurred in sync process
    /// </summary>
    public class SyncErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="e"></param>
        public SyncErrorEventArgs(Exception e)
        {
            this.Exception = e;
        }

        /// <summary>
        /// Exception object related to the error.
        /// </summary>
        public Exception Exception
        {
            get;
            set;
        }
    }
}
