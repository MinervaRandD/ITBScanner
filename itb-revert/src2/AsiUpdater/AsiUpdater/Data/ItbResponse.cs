using System;
using System.Collections.Generic;

namespace AsiUpdater.Data
{
    /// <summary>
    /// Program upgrade files response from the web service
    /// </summary>
    public class ItbResponse
    {
        public List<File> ProgramUpgradeFiles
        {
            get;
            set;
        }        
    }
}
