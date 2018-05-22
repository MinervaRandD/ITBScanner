using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;

namespace AsiUpdater
{
    public class Configuration
    {
        private static string configFilePath;
        private static XmlDocument doc;
        private static Configuration _instance;

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    configFilePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\UpdaterConfig.xml";
                    LoadInstanceFromFile();
                }
                return _instance;
            }
        }

        public string WebServiceUri
        {
            get;
            set;
        }

        public string InstallDir
        {
            get;
            set;
        }

        public string AutoUpdateApplications
        {
            get;
            set;
        }

        public string CheckForUpgrade
        {
            get;
            set;
        }

        public string NotifyUser
        {
            get;
            set;
        }

        public string DownloadRetries
        {
            get;
            set;
        }

        public string ChunkSize
        {
            get;
            set;
        }

        public string ChunkDownloadInterval
        {
            get;
            set;
        }

        public bool ScheduledUpgradeEnabled
        {
            get;
            set;
        }

        public string ScannerUpgradeTime
        {
            get
            {
                return GetXmlElementValue("ScannerUpgradeTime");
            }            
        }

        public string ScannerUpgradeTimeWindowMinutes
        {
            get
            {
                return GetXmlElementValue("ScannerUpgradeTimeWindowMinutes");
            }
        }

        private static string GetXmlElementValue(string TagName)
        {
            string val = string.Empty;
            doc = new XmlDocument();
            doc.Load(configFilePath);

            XmlNodeList xnode = doc.GetElementsByTagName(TagName);
            if (xnode.Count > 0)
            {
                val = xnode[0].InnerText;
            }
            return val;
        }

        private static void SaveXmlElement(string TagName, string Value)
        {
            doc = new XmlDocument();
            doc.Load(configFilePath);

            XmlNodeList xnode = doc.GetElementsByTagName(TagName);
            if (xnode.Count > 0 && Value.Trim().Length > 0)
            {
                xnode[0].InnerText = Value.Trim();
                doc.Save(configFilePath);
            }
        }

        public static void SaveXmlElement(System.Collections.Hashtable ht)
        {
            doc = new XmlDocument();
            doc.Load(configFilePath);
            XmlNodeList xnode;

            foreach (string key in ht.Keys)
            {
                xnode = doc.GetElementsByTagName(key);
                if (xnode.Count > 0)
                {
                    xnode[0].InnerText = (string)ht[key];          
                }
            }
            doc.Save(configFilePath);
        }
                       
        public static void LoadInstanceFromFile()
        {
            doc = new XmlDocument();
            doc.Load(configFilePath);

            _instance = new Configuration();         
            _instance.WebServiceUri = doc.GetElementsByTagName("WebServiceUri")[0].InnerText;
            _instance.InstallDir = doc.GetElementsByTagName("InstallDir")[0].InnerText;
            
            XmlNodeList xnode = doc.GetElementsByTagName("AutoUpdateApplications");
            if (xnode.Count > 0) {_instance.AutoUpdateApplications = xnode[0].InnerText;}

            xnode = doc.GetElementsByTagName("CheckForUpgrade");
            if (xnode.Count > 0) {_instance.CheckForUpgrade = xnode[0].InnerText;}

            xnode = doc.GetElementsByTagName("DownloadRetries");
            if (xnode.Count > 0) {_instance.DownloadRetries = xnode[0].InnerText;}

            xnode = doc.GetElementsByTagName("NotifyUser");
            if (xnode.Count > 0) {_instance.NotifyUser = xnode[0].InnerText;}

            xnode = doc.GetElementsByTagName("ChunkSize");
            if (xnode.Count > 0) {_instance.ChunkSize = xnode[0].InnerText;}

            xnode = doc.GetElementsByTagName("ChunkDownloadInterval");
            if (xnode.Count > 0) {_instance.ChunkDownloadInterval = xnode[0].InnerText;}

            xnode = doc.GetElementsByTagName("EnableScheduledUpgrade");
            if (xnode.Count > 0)
            {
                _instance.ScheduledUpgradeEnabled = xnode[0].InnerText.ToString().Trim().ToLower() == "true" ? true : false;
            }
        }       
    }
}