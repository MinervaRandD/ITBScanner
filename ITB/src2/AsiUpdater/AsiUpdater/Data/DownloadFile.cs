using System;

namespace AsiUpdater.Data
{
    public class DownloadFile
    {
        public string FileName
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public int StartByte
        {
            get;
            set;
        }

        public int ChunkSize
        {
            get;
            set;
        }

        internal string ToJsonString()
        {
            string s = string.Empty;

            s = "{ \"FileName\" : \"" + FileName + "\", " +
                    "\"Type\" : \"" + Type + "\", " +
                    "\"StartByte\" : " + StartByte.ToString() + ", " +
                    "\"ChunkSize\" : " + ChunkSize + " }" ;

            return s;
        }
    }
}
