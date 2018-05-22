using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Represents local configuration data for current program.
    /// </summary>
    public class Configuration
    {
        private Configuration()
        {
        }

        private static Configuration _instance;
        private static string confiFilePath;
        private static XmlDocument doc;

        /// <summary>
        /// Single instance of Configuration object
        /// </summary>
        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    LoadInstanceFromFile();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Load instance from configuraion file.
        /// </summary>
        private static void LoadInstanceFromFile()
        {
            confiFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) 
                + "\\config.xml";
            using (FileStream fs = File.Open(confiFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                _instance = (Configuration)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Save configuration setting
        /// </summary>
        /// <param name="TagName"></param>
        /// <param name="Value"></param>
        private static void SaveXmlElement(string TagName, string Value)
        {
            doc = new XmlDocument();
            doc.Load(confiFilePath);

            XmlNodeList xnode = doc.GetElementsByTagName(TagName);
            if (xnode.Count > 0 && Value.Trim().Length > 0)
            {
                xnode[0].InnerText = Value.Trim();
                doc.Save(confiFilePath);
            }
            doc = null;
        }

        public static void SaveMisdropWarning(bool value)
        {
            Instance.MisdropWarning = value;
            SaveXmlElement("MisdropWarning", value == true ? "true" : "false");
        }

        /// <summary>
        /// Version of the configuration.
        /// </summary>
        public string Version
        {
            get;
            set;
        }

        /// <summary>
        /// URI for the web service
        /// </summary>
        public string WebServiceUri
        {
            get;
            set;
        }

        /// <summary>
        /// Path to store database file
        /// </summary>
        public string DbFilePath
        {
            get;
            set;
        }

        /// <summary>
        /// Option to enable/disable MisdropWarning 
        /// </summary>
        public bool MisdropWarning
        {
            get;
            set;
        }

        public bool GetLocationByGpsData
        {
            get;
            set;
        }
                        
        /// <summary>
        /// Settings to submit error to FogBugz
        /// </summary>
        public FogBugzSettings FogBugzSettings
        {
            get;
            set;
        }
    }
}
