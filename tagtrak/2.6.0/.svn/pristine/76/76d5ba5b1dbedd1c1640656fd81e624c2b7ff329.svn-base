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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace sb
{
	/// <summary>
	/// Summary description for SystemProfile.
	/// </summary>
	[Serializable]
	public class SystemProfile
	{
		private SystemBuilder systemBuilderForm = null;
		private ArrayList carriers;

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
				systemBuilderForm.baseProjectForceRebuildCheckBox.Checked = (bool) value ;
			}
		}

		public bool forceRebuildOfLibraries
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

		public string baseProjectSourceDirectory
		{
			get 
			{ 
				return systemBuilderForm.baseProjectSourceDirectoryTextBox.Text ; 
			}

			set
			{
				systemBuilderForm.baseProjectSourceDirectoryTextBox.Text = value ;
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

		public string baseProjectConfiguration
		{
			get 
			{ 
				return systemBuilderForm.configurationComboBox.Text ; 
			}

			set
			{
				if ( ! systemBuilderForm.configurationComboBox.Items.Contains(value) )
				{
					systemBuilderForm.configurationComboBox.Items.Add(value) ;
				}

				systemBuilderForm.configurationComboBox.SelectedItem = value ;
			}
		}

		public string deviceType
		{
			get 
			{ 
				if ( systemBuilderForm.intermecRadioButton.Checked  ) return "Intermec" ;
				if ( systemBuilderForm.symbolRadioButton.Checked    ) return "Symbol" ;
				if ( systemBuilderForm.btnDolphin.Checked			) return "Dolphin";
				if ( systemBuilderForm.viewsonicRadioButton.Checked ) return "Viewsonic" ;
				if ( systemBuilderForm.pcRadioButton.Checked        ) return "PC" ;
				if ( systemBuilderForm.otherRadioButton.Checked     ) return systemBuilderForm.otherDeviceTextBox.Text ;

				return "Unknown" ;
			}

			set
			{
				if ( value == "Intermec"  ) { systemBuilderForm.intermecRadioButton.Checked  = true ; return ; }
				if ( value == "Symbol"    ) { systemBuilderForm.symbolRadioButton.Checked    = true ; return ; }
				if ( value == "Dolphin"	  ) { systemBuilderForm.btnDolphin.Checked			 = true ; return ; }
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

//		public string user
//		{
//			get 
//			{ 
//				return systemBuilderForm.CarrierCode.SelectedItem.ToString();
//			}
//
//			set
//			{
//				systemBuilderForm.CarrierCode.SelectedItem = value;
//
//			}
//		}

		public ArrayList getCarriers
		{
			get 
			{   
				carriers.Clear();      
				
				foreach (object item in systemBuilderForm.clbCarriers.CheckedItems)
				{
					carriers.Add(item);
				} 
				
				return carriers;	
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

		public string migrateCabFilePath
		{
			get 
			{ 
				return systemBuilderForm.migrateOutputFileTextbox.Text ; 
			}

			set
			{
				systemBuilderForm.migrateOutputFileTextbox.Text = value ;
			}
		}

		public string webUpdateCabFilePath
		{
			get 
			{ 
				return systemBuilderForm.webUpdateOutputFileTextbox.Text ; 
			}

			set
			{
				systemBuilderForm.webUpdateOutputFileTextbox.Text = value ;
			}
		}

		public string release
		{
			get 
			{ 
				return systemBuilderForm.releaseTextBox.Text.Trim() ; 
			}

			set
			{
				systemBuilderForm.releaseTextBox.Text = value.Trim() ;
			}
		}

		public string operatingSystem
		{
			get
			{
				return systemBuilderForm.OperatingSystem.SelectedItem.ToString();
			}

			set
			{
				systemBuilderForm.OperatingSystem.SelectedItem = value;
			}
		}

		public SystemProfile(SystemBuilder inputSystemBuilderForm)
		{
			systemBuilderForm = inputSystemBuilderForm ;

			carriers = new ArrayList();
 
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

			addXmlElement(outputXmlDoc, rootElement, "DeviceType"                 , deviceType                ) ;
			addXmlElement(outputXmlDoc, rootElement, "ProcessorType"              , processorType             ) ;
			addXmlElement(outputXmlDoc, rootElement, "BaseProjectDefinitionFile"  , baseProjectDefinitionFile ) ;
			addXmlElement(outputXmlDoc, rootElement, "DistributionCabFilePath"    , distributionCabFilePath   ) ;
			addXmlElement(outputXmlDoc, rootElement, "UpdateCabFilePath"    , updateCabFilePath   ) ;
			addXmlElement(outputXmlDoc, rootElement, "BaseProjectSourceDirectory" , baseProjectSourceDirectory) ;
			addXmlElement(outputXmlDoc, rootElement, "BaseProjectConfiguration"   , baseProjectConfiguration  ) ;
			addXmlElement(outputXmlDoc, rootElement, "BaseProjectExeFile"         , baseProjectExeFile        ) ;
			addXmlElement(outputXmlDoc, rootElement, "ApplicationName"            , applicationName           ) ;
			addXmlElement(outputXmlDoc, rootElement, "Release"                    , release                   ) ;
			addXmlElement(outputXmlDoc, rootElement, "AirlineSoftwareDllFile"     , airlineSoftwareDllFile    ) ;
			addXmlElement(outputXmlDoc, rootElement, "AirlineSoftwareProj"     , AirlineSoftwareProj    ) ;
			addXmlElement(outputXmlDoc, rootElement, "ForceRebuildOfBaseProject"  , forceRebuildOfBaseProject.ToString()) ;
			addXmlElement(outputXmlDoc, rootElement, "ForceRebuildOfLibraries"    , forceRebuildOfLibraries.ToString()) ;
			addXmlElement(outputXmlDoc, rootElement, "MigrateCabFilePath"    , migrateCabFilePath.ToString()) ;
			addXmlElement(outputXmlDoc, rootElement, "WebUpdateCabFilePath"    , webUpdateCabFilePath.ToString()) ;
			//addXmlElement(outputXmlDoc, rootElement, "User"    , user.ToString()) ;
			addXmlElement(outputXmlDoc, rootElement, "OperatingSystem"    , operatingSystem) ;
			addXmlElement(outputXmlDoc, rootElement, "isWireless", isWireless.ToString());
			

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

			string tempBoolString ;

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
				deviceType                 = getXmlElementText(rootElement, "DeviceType"                ) ;
				processorType              = getXmlElementText(rootElement, "ProcessorType"             ) ;
				baseProjectDefinitionFile  = getXmlElementText(rootElement, "BaseProjectDefinitionFile" ) ;
				distributionCabFilePath    = getXmlElementText(rootElement, "DistributionCabFilePath"   ) ;
				updateCabFilePath		   = getXmlElementText(rootElement, "UpdateCabFilePath"   ) ;
				baseProjectExeFile         = getXmlElementText(rootElement, "BaseProjectExeFile"        ) ;
				baseProjectConfiguration   = getXmlElementText(rootElement, "BaseProjectConfiguration"  ) ;
				applicationName            = getXmlElementText(rootElement, "ApplicationName"           ) ;
				release                    = getXmlElementText(rootElement, "Release"                   ) ;
				airlineSoftwareDllFile     = getXmlElementText(rootElement, "AirlineSoftwareDllFile"    ) ;
				AirlineSoftwareProj		   = getXmlElementText(rootElement, "AirlineSoftwareProj"    ) ;
				baseProjectSourceDirectory = getXmlElementText(rootElement, "BaseProjectSourceDirectory") ;
				tempBoolString             = getXmlElementText(rootElement, "ForceRebuildOfBaseProject" ) ;
				migrateCabFilePath         = getXmlElementText(rootElement, "MigrateCabFilePath" ) ;
				webUpdateCabFilePath       = getXmlElementText(rootElement, "WebUpdateCabFilePath" ) ;
				//user					   = getXmlElementText(rootElement, "User");
				forceRebuildOfBaseProject  = bool.Parse(tempBoolString) ;
				
				tempBoolString            = getXmlElementText(rootElement, "ForceRebuildOfLibraries") ;
				forceRebuildOfLibraries   = bool.Parse(tempBoolString) ;
				operatingSystem           = getXmlElementText(rootElement, "OperatingSystem");
				isWireless = bool.Parse(getXmlElementText(rootElement, "isWireless"));
			}

			catch (Exception ex)
			{
				throw new Exception("Load of profile from input file '" + inputFilePath + "' failed: " + ex.Message, ex) ;
			}

			this.profileFilePath = inputFilePath;

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

		public string AirlineSoftwareProj
		{
			get
			{
				return systemBuilderForm.airlinesoftwareProj.Text;
			}
			set
			{
				systemBuilderForm.airlinesoftwareProj.Text = value;
			}
		}

		public string updateCabFilePath
		{
			get
			{
				return systemBuilderForm.updateOutputFileTextBox.Text ; 
			}
			set
			{
				systemBuilderForm.updateOutputFileTextBox.Text = value ;
			}
		}

		public bool isWireless
		{
			get
			{
				return systemBuilderForm.Wireless.Checked;
			}
			set
			{
				systemBuilderForm.Wireless.Checked = value;
			}
		}
	}
}
