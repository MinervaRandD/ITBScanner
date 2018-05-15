using System;
using System.Xml.Serialization;

namespace AsiUpdater.Data
{
    [XmlRoot("ProgramVersion")]
    public class FileRequest
    {
        public string Name
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }        
    }
}
