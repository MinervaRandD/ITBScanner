using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AsiUpdater
{
    public class UpgradeAvailableEventArgs : EventArgs
    {
        public List<Data.File> UpgradeFiles
        {
            get;
            set;
        }
    }
}
