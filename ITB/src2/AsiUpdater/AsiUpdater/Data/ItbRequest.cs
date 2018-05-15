using System;
using System.Collections.Generic;

namespace AsiUpdater.Data
{
    public class ItbRequest
    {
        public string SN
        {
            get;
            set;
        }
        
        public List<FileRequest> ProgramVersions
        {
            get;
            set;
        }               
    }
}
