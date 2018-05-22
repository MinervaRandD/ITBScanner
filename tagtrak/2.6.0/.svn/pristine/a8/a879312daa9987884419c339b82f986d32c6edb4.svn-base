using System;
using System.IO ;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Security;
using System.Security.Permissions;
using System.Xml;


namespace sb
{
	/// <summary>
	/// Summary description for SystemProfileClass.
	/// </summary>
	public class SystemProfileClass
	{
		private SystemBuilder systemBuilderForm ;

		public bool profileHasChanged = false ;
		public string profileFilePath = "" ;

		public bool forceRebuildOfBaseProject
		{
			get 
			{ 
				return systemBuilderForm.baseProjectForceRebuildCheckBox.Checked; 
			}

			set
			{
				systemBuilderForm.baseProjectForceRebuildCheckBox.Checked = value ;
			}
		}

		public bool librariesForceRebuild
		{
			get 
			{ 
				return systemBuilderForm.librariesForceRebuildCheckBox.Checked; 
			}

			set
			{
				systemBuilderForm.librariesForceRebuildCheckBox.Checked = value ;
			}
		}

		public string baseProjectDefinitionFile
		{
			get 
			{ 
				return systemBuilderForm.baseProjectDefinitionFileTextBox.Text ; 
			}

			set
			{
				systemBuilderForm.baseProjectDefinitionFileTextBox.Text = value ;
			}
		}

		public string baseProjectExeFile
		{
			get 
			{ 
				return systemBuilderForm.baseProjectExeFileTextBox.Text ; 
			}

			set
			{
				systemBuilderForm.baseProjectExeFileTextBox.Text = value ;
			}
		}

		public string airlineSoftwareDllFile
		{
			get 
			{ 
				return systemBuilderForm.airlineSoftwareLibTextBox.Text ; 
			}

			set
			{
				systemBuilderForm.airlineSoftwareLibTextBox.Text = value ;
			}
		}

		public string applicationName
		{
			get 
			{ 
				return systemBuilderForm.applicationNameTextBox.Text ; 
			}

			set
			{
				systemBuilderForm.applicationNameTextBox.Text = value ;
			}
		}

		public string deviceType
		{
			get 
			{ 
				if ( systemBuilderForm.intermecRadioButton.Checked  ) return "Intermec" ;
				if ( systemBuilderForm.symbolRadioButton.Checked    ) return "Symbol" ;
				if ( systemBuilderForm.viewsonicRadioButton.Checked ) return "Viewsonic" ;
				if ( systemBuilderForm.pcRadioButton.Checked        ) return "PC" ;
				if ( systemBuilderForm.otherRadioButton.Checked     ) return systemBuilderForm.otherDeviceTextBox.Text ;

				return "Unknown" ;
			}

			set
			{
				if ( value == "Intermec"  ) { systemBuilderForm.intermecRadioButton.Checked  = true ; return ; }
				if ( value == "Symbol"    ) { systemBuilderForm.symbolRadioButton.Checked    = true ; return ; }
				if ( value == "Viewsonic" ) { systemBuilderForm.viewsonicRadioButton.Checked = true ; return ; }
				if ( value == "PC"        ) { systemBuilderForm.pcRadioButton.Checked        = true ; return ; }
				
				systemBuilderForm.otherRadioButton.Checked = true ; systemBuilderForm.otherDeviceTextBox.Text = value ;
			}
		}

		public string processorType
		{
			get 
			{ 
				if ( systemBuilderForm.armV4RadioButton.Checked          ) return "ARMV4" ;
				if ( systemBuilderForm.otherProcessorRadioButton.Checked ) return systemBuilderForm.otherProcessorTextBox.Text ;

				return "Unknown" ;
			}

			set
			{
				if ( value == "ARMV4"  ) { systemBuilderForm.armV4RadioButton.Checked  = true ; return ; }
		
				systemBuilderForm.otherProcessorRadioButton.Checked = true ; systemBuilderForm.otherProcessorTextBox.Text = value ;
			}
		}

		public string user
		{
			get 
			{ 
				if ( systemBuilderForm.ataRadioButton.Checked         ) return "ATA"         ;
				if ( systemBuilderForm.usAirwaysRadioButton.Checked   ) return "USAirways"   ;
				if ( systemBuilderForm.jetBlueRadioButton.Checked     ) return "JetBlue"     ;
				if ( systemBuilderForm.roblexRadioButton.Checked      ) return "Roblex"      ;
				if ( systemBuilderForm.airFlamencoRadioButton.Checked ) return "AirFlamenco" ;
				if ( systemBuilderForm.MNRadioButton.Checked          ) return "MNAviation"  ;

				return "Unknown" ;
			}

			set
			{
				if ( value == "ATA"         ) systemBuilderForm.ataRadioButton.Checked         = true ; else
				if ( value == "USAirways"   ) systemBuilderForm.usAirwaysRadioButton.Checked   = true ; else
				if ( value == "JetBlue"     ) systemBuilderForm.jetBlueRadioButton.Checked     = true ; else
				if ( value == "Roblex"      ) systemBuilderForm.roblexRadioButton.Checked      = true ; else
				if ( value == "AirFlamenco" ) systemBuilderForm.airFlamencoRadioButton.Checked = true ; else
				if ( value == "MNAviation"  ) systemBuilderForm.MNRadioButton.Checked          = true ; else

				throw new Exception("Invalid user value") ;
			}
		}

		public string distributionCabFilePath
		{
			get 
			{ 
				return systemBuilderForm.distributionOutputFileTextBox.Text ; 
			}

			set
			{
				systemBuilderForm.distributionOutputFileTextBox.Text = value ;
			}
		}

		public SystemProfileClass(SystemBuilder inputSystemBuilderForm)
		{
			//
			// TODO: Add constructor logic here
			//

			systemBuilderForm = inputSystemBuilderForm ;
		}

		public void saveProfile(string outputFilePath)
		{
			XmlDocument outputXmlDoc = new XmlDocument() ;
			XmlNode xmlnode ;

			xmlnode = outputXmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "SystemBuilderProfileDocument","") ;
			outputXmlDoc.AppendChild(xmlnode);

			XmlElement rootElement=outputXmlDoc.CreateElement("", "SystemBuilderProfile", "") ;

			rootElement.SetAttribute("SaveDate", "", DateTime.Now.ToString()) ;
			rootElement.SetAttribute("Creator", "", Utilities.getCurrentUserName()) ;

			outputXmlDoc.AppendChild(rootElement);

			addXmlElement(outputXmlDoc, rootElement, "DeviceType"               , deviceType               ) ;
			addXmlElement(outputXmlDoc, rootElement, "ProcessorType"            , processorType            ) ;
			addXmlElement(outputXmlDoc, rootElement, "BaseProjectDefinitionFile", baseProjectDefinitionFile) ;
			addXmlElement(outputXmlDoc, rootElement, "BaseProjectExeFile"       , baseProjectExeFile       ) ;
			addXmlElement(outputXmlDoc, rootElement, "ApplicationName"          , applicationName          ) ;
			addXmlElement(outputXmlDoc, rootElement, "AirlineSoftwareDllFile"   , airlineSoftwareDllFile   ) ;

			try
			{
				outputXmlDoc.Save(outputFilePath) ;
			}

			catch (Exception ex)
			{
				throw new Exception("Save of profile failed: " + ex.Message, ex) ;
			}

			return ;
		}

		public void loadProfile(string inputFilePath)
		{
			XmlDocument inputXmlDoc = new XmlDocument() ;

			try
			{
				inputXmlDoc.Load(inputFilePath) ;
			}
			catch (Exception ex)
			{
				throw new Exception("Load of profile failed: " + ex.Message, ex) ;
			}

			System.Xml.XmlNodeList rootElementList = inputXmlDoc.GetElementsByTagName("SystemBuilderProfile") ;

			if ( rootElementList.Count != 1 )
			{
				throw new Exception("Invalid profile: missing or invalid node count for root element") ;
			}

			XmlElement rootElement = (XmlElement) rootElementList[0] ;

			try
			{
				deviceType                = getXmlElementText(rootElement, "DeviceType"               ) ;
				processorType             = getXmlElementText(rootElement, "ProcessorType"            ) ;
				baseProjectDefinitionFile = getXmlElementText(rootElement, "BaseProjectDefinitionFile") ;
				baseProjectExeFile        = getXmlElementText(rootElement, "BaseProjectExeFile"       ) ;
				applicationName           = getXmlElementText(rootElement, "ApplicationName"          ) ;
			}

			catch (Exception ex)
			{
				throw new Exception("Load of profile from input file '" + inputFilePath + "' failed: " + ex.Message, ex) ;
			}

			// systemBuilderForm.intermecRadioButton.Checked = true ;

			return ;
		}

		private void addXmlElement(XmlDocument xmlDoc, XmlElement parent, string tag, string innerText)
		{
			XmlElement newXmlElement = xmlDoc.CreateElement(tag) ;
			newXmlElement.InnerText = innerText ;
			parent.AppendChild(newXmlElement) ;
		}

		private string getXmlElementText(XmlElement parent, string tag)
		{
			System.Xml.XmlNodeList nodeList = parent.GetElementsByTagName(tag) ;
			
			if ( nodeList.Count != 1 ) throw new Exception("Invalid profile: missing or invalid node count for tag '" + tag + "'") ;

			return nodeList[0].InnerText ;
		}
	}
}
