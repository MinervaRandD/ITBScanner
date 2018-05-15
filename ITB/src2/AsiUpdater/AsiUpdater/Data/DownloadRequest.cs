using System;
using System.Xml.Serialization;

namespace AsiUpdater.Data
{
    [XmlRoot(Program.RequestRoot)]
    public class DownloadRequest
    {
        public string SN
        {
            get;
            set;
        }

        public Data.DownloadFile DownloadFile
        {
            get;
            set;
        }

        internal string ToJsonString()
        {
            string s =  string.Empty;
            
            s = "{ \"SN\" : \"" + SN + "\", " +
                "\"DownloadFile\" : " + DownloadFile.ToJsonString() + " }";

            return s;
        }
    }
}
