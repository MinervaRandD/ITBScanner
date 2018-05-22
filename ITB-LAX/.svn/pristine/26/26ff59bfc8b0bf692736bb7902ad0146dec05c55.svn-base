using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace ITBCab.AutoUpdate
{
    public class Reader
    {
        private const string AutoUpdateFile = "AutoUpdate.xml";
        private DirectoryInfo UpdateDir;
        public UpdateStruct[] FilesToUpdate;

        public struct UpdateStruct
        {
            public string FileName;
            public DirectoryInfo Source;
        }
        
        public Reader(DirectoryInfo AutoUpdateDir)
        {
            UpdateDir = AutoUpdateDir;
        }

        public void ParseXML()
        {
            XmlDocument XmlDoc = new XmlDocument();
            try
            {
                XmlDoc.Load(UpdateDir + Common.bs + AutoUpdateFile);
                XmlNodeList xlist = XmlDoc.GetElementsByTagName("update");
                if (xlist.Count > 0)
                {
                    int i = 0;
                    FilesToUpdate = new UpdateStruct[xlist.Count];
                    foreach (XmlNode xnode in xlist)
                    {
                        FilesToUpdate[i].FileName = xnode.SelectNodes("filename")[0].InnerText;
                        FilesToUpdate[i].Source = new DirectoryInfo(xnode.SelectNodes("source")[0].InnerText);
                        i += 1;
                    }
                }
                UpdateFiles();
            }
            catch (Exception ex)
            {
                Common.DisplayError("Error occurred while loading\n" + UpdateDir + Common.bs + AutoUpdateFile + "\n" + ex.Message);                
            }
        }

        public void UpdateFiles()
        {
            if (FilesToUpdate != null)
            {
                string SourceFilePath;
                string DestFilePath;

                foreach (UpdateStruct update in FilesToUpdate)
                {
                    SourceFilePath = update.Source.FullName + Common.bs + update.FileName;
                    DestFilePath = UpdateDir.FullName + Common.bs + update.FileName;
                    if (File.Exists(SourceFilePath))
                    {
                        if (File.Exists(DestFilePath))
                        {
                            File.Delete(DestFilePath);
                        }
                        File.Copy(SourceFilePath, DestFilePath);
                    }
                    else
                    {
                        Common.DisplayError("Cannot find file " + SourceFilePath);                        
                    }
                }
            }
        }
    }
}
