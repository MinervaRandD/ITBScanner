using System;
using System.IO;
using System.Collections;
using System.Xml;
using System.Data;

namespace UserSpecRecord
{
	public class userSpecRecordClass
	{
		public userSpecRecordClass()
		{
			reset() ;
		}

		public int    userNumber     ;
		public string userName       ;
		public string userFullName   ;
		public string carrierCode    ;
		
		public string ftpHostName    ;
		public int    ftpPortNumber  ;
		public string ftpLoginID     ;
		public string ftpPassword    ;

		public bool transferPointOnScanForm  ;
		public bool tailNumberOnScanForm  ;
		public bool rejectReasonOnScanForm  ;
		public bool canChangeLocationOnScanForm  ;
		public bool passwordRequiredForLocationChangeOnScanForm  ;
		public bool treatTransferScansAsLoadScans  ;
		public bool loadScansRequireSelectionFromPreset  ;
		public bool presetsRequireDestinationSpecifications  ;
		public bool lockDownReleasedInAdminForm  ;
		public bool warnOnDuplicateScan  ;
		public bool displayFlightValidationMessages  ;
		public bool triStateLargeBarcodeCheckBox  ;
		public bool setTextBoxFocusWhenFormLoads  ;

		public bool mailScanEnabled        = true ;
		public bool mailSimpleScanEnabled  = true ;
		public bool messagesEnabled        = true ;
		public bool cargoScanEnabled       = true ;
		public bool baggageScanEnabled     = true ;
		public bool scanningOptionsEnabled = true ;

		public buttonSpecRecordClass summaryButtonSpec      ;
		public buttonSpecRecordClass presetsButtonSpec      ;
		public buttonSpecRecordClass binUploadButtonSpec    ;
		public buttonSpecRecordClass binChangeButtonSpec    ;
		public buttonSpecRecordClass manifestButtonSpec     ;
		public buttonSpecRecordClass mailButtonSpec         ;
		public buttonSpecRecordClass cargoButtonSpec        ;

		public Hashtable cityTable            = new Hashtable() ;
		public Hashtable ethernetCityTable    = new Hashtable() ;
		public Hashtable wirelessCityTable    = new Hashtable() ;

		public Hashtable airportLocationTable = new Hashtable() ;

		public ArrayList cityList             = new ArrayList() ;
		public ArrayList airportLocationList  = new ArrayList() ;

		public Hashtable operationsTable      = new Hashtable() ;
		public Hashtable operationsList       = new ArrayList() ;

		public string baseParmListstring      ;

		public string cityListstring          ;
		public string ethernetCityListstring  ;
		public string wirelessCityListstring  ;

		public string operationListstring     ;
		public string buttonSpecstring        ;

		public string defnstring              ;

		private XmlDocument userSpecRecordXMLDocument = new XmlDocument() ;

		public string defaultLocation ;

		public int ftpConnectionDelay  ;

		private char[] trimChars = { (char) ' ', (char) 9, (char) 10, (char) 11, (char) 12, (char) 13 } ;

		public bool beepOnScan = true ;
		public bool buzzOnScan = true ;
		public int  buzzLength = 0    ;

		public bool showKeyboardOnFocus = true ;

		private void reset()
		{
			userNumber    =   -1 ;
			userName      = null ;
			userFullName  = null ;
			carrierCode   = null ;

			ftpHostName   = null ;
			ftpPortNumber =   -1 ;
			ftpLoginID    = null ;
			ftpPassword   = null ;

			ftpConnectionDelay = 0 ;

			transferPointOnScanForm                     = false ;
			tailNumberOnScanForm                        = false ;
			rejectReasonOnScanForm                      = false ;
			canChangeLocationOnScanForm                 = false ;
			passwordRequiredForLocationChangeOnScanForm = false ;
			treatTransferScansAsLoadScans               = false ;
			loadScansRequireSelectionFromPreset         = false ;
			presetsRequireDestinationSpecifications     = false ;
			lockDownReleasedInAdminForm                 = false ;
			warnOnDuplicateScan                         = false ;
			displayFlightValidationMessages             = true  ;
			triStateLargeBarcodeCheckBox                = false ;
			setTextBoxFocusWhenFormLoads                = true  ;

			mailScanEnabled        = true ;
			mailSimpleScanEnabled  = true ;
			messagesEnabled        = true ;
			cargoScanEnabled       = true ;
			baggageScanEnabled     = true ;
			scanningOptionsEnabled = true ;

			cityTable.Clear()             ;
			airportLocationTable.Clear()  ;
			cityList.Clear()              ;
			airportLocationList.Clear()   ;
			operationsTable.Clear()       ;

			summaryButtonSpec   = new buttonSpecRecordClass("Summary"  , false, new System.Drawing.Point( 21, 254), new System.Drawing.Size(70, 19), "Summary")     ;
			presetsButtonSpec   = new buttonSpecRecordClass("Presets"  , false, new System.Drawing.Point( 91, 254), new System.Drawing.Size(67, 19), "Presets")     ;
			manifestButtonSpec  = new buttonSpecRecordClass("Manifest" , false, new System.Drawing.Point(158, 254), new System.Drawing.Size(61, 19), "Manifest")    ;
			binUploadButtonSpec = new buttonSpecRecordClass("BinUpload", false, new System.Drawing.Point(120, 272), new System.Drawing.Size(99, 19), "Cart Upload") ;
			binChangeButtonSpec = new buttonSpecRecordClass("BinChange", false, new System.Drawing.Point( 21, 272), new System.Drawing.Size(99, 19), "Change Cart") ;

			mailButtonSpec      = new buttonSpecRecordClass("MailScan" , false, new System.Drawing.Point(186,  5), new System.Drawing.Size(69, 19), "Mail Scan" ) ;
			cargoButtonSpec     = new buttonSpecRecordClass("CargoScan", false, new System.Drawing.Point(186, 25), new System.Drawing.Size(69, 19), "Cargo Scan") ;

		}

		public string isValid()
		{
			if ( ! isNonNullstring(userName)        ) return "Invalid user name"        ;
			if ( ! isNonNullstring(carrierCode)     ) return "Invalid carrier code"     ;
			if ( Length(carrierCode) != 2           ) return "Invalid carrier code"     ;
			if ( ! isNonNullstring(defaultLocation) ) return "Invalid default location" ;
			if ( Length(defaultLocation) != 3       ) return "Invalid default location" ;
			if ( isNullstring(ftpHostName)          ) return "Invalid ftp host name"    ;
			if ( ftpPortNumber <= 0                 ) return "Invalid port number"      ;
			if ( isNullstring(ftpLoginID)           ) return "Invalid ftp login id"     ;
			if ( isNullstring(ftpPassword)          ) return "Invalid ftp password"     ;
			if ( cityList.Count <= 0                ) return "Invalid city list"        ;
			if ( operationsTable == null            ) return "Invalid operations table" ;

			return true ;
		}

			private XmlNode getOrCreateButtonNode(buttonSpecRecordClass buttonSpec)
			{

				XmlNodeList  nodeList     ;
				string       xmlText      ;

				XmlNode      buttonNode   ;
				XmlNode      rootNode     ;
				XmlNode      locationNode ;
				XmlNode      sizeNode     ;
				XmlNode      textNode     ;

				string        result      ;

				if (  ! buttonSpec.visible ) { return null ; }

				nodeList = userSpecRecordXMLDocument.GetElementsByTagName(buttonSpec.buttonName) ;

				if ( nodeList.Count == 0 )
				{
					rootNode = getOrCreateRootNode() ;

					if (  rootNode == null ) { return null ; }

				try
				{
					buttonNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, buttonSpec.buttonName, "") ;
				}

				catch (Exception ex1)
				{
					return null ;
				}

				if (  buttonNode == null ) { return null ; }

				rootNode.AppendChild(buttonNode) ;

				try
				{
					locationNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, "Location", "") ;
				}

				catch (Exception ex2)
				{
					return null ;
				}
		            
				if (  locationNode == null ) { return null ; }

				try
				{
					sizeNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, "Size", "") ;
				}

				catch (Exception ex3)
				{
					return null ;
				}

				if (  sizeNode == null ) { return null ; }

				try
				{
					textNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, "Text", "") ;
				}

				catch ( Exception ex4 )
				{
					return null ;
				}

				if (  textNode == null ) { return null ; }

				buttonNode.AppendChild(locationNode) ;
				buttonNode.AppendChild(sizeNode)     ;
				buttonNode.AppendChild(textNode)     ;
			}

			else if (  nodeList.Count == 1 )
			{
				buttonNode = nodeList(0) ;
			}

			else
			{
				buttonNode = null ;
			}

			return buttonNode ;
		}
		public string parse(string inputstring)
		{
			string result ;

			reset() ;

			try
			{
				userSpecRecordXMLDocument.LoadXml(inputstring) ;
			}

			catch ( Exception ex )
			{
				return "Parse of user spec record failed: " & ex.Message ;
			}

			result = parseboolValue("CanChangeLocationOnScanForm", canChangeLocationOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("DisplayFlightValidationMessages", displayFlightValidationMessages) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("LoadScansRequireSelectionFromPreset", loadScansRequireSelectionFromPreset) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("LockDownReleasedInAdminForm", lockDownReleasedInAdminForm) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("PasswordRequiredForLocationChangeOnScanForm", passwordRequiredForLocationChangeOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("PresetsRequireDestinationSpecifications", presetsRequireDestinationSpecifications) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("RejectReasonOnScanForm", rejectReasonOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("TailNumberOnScanForm", tailNumberOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("TransferPointOnScanForm", transferPointOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("TreatTransferScansAsLoadScans", treatTransferScansAsLoadScans) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("TriStateLargeBarcodeCheckBox", triStateLargeBarcodeCheckBox) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("WarnOnDuplicateScan", warnOnDuplicateScan) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("SetTextBoxFocusWhenFormLoads", setTextBoxFocusWhenFormLoads) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("MailScanEnabled", mailScanEnabled) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("MailSimpleScanEnabled", mailSimpleScanEnabled) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("MessagesEnabled", messagesEnabled) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("CargoScanEnabled", cargoScanEnabled) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("BaggageScanEnabled", baggageScanEnabled) ;
			if ( result != "OK" ) return result ;

			result = parseboolValue("ScanningOptionsEnabled", scanningOptionsEnabled) ;
			if ( result != "OK" ) return result ;

			result = parseintValue("FtpConnectionDelay", ftpConnectionDelay) ;
			if ( result != "OK" ) return result ;

			result = parseCarrierCode() ;
			if ( result != "OK" ) return result ;

			result = parseDefaultLocation() ;
			if ( result != "OK" ) return result ;

			result = parseFtpHostName() ;
			if ( result != "OK" ) return result ;

			result = parseFtpLoginID() ;
			if ( result != "OK" ) return result ;

			result = parseFtpPassword() ;
			if ( result != "OK" ) return result ;

			result = parseFtpPortNumber() ;
			if ( result != "OK" ) return result ;

			result = parseUserFullName() ;
			if ( result != "OK" ) return result ;

			result = parseUserName() ;
			if ( result != "OK" ) return result ;

			result = parseCityList() ;
			if ( result != "OK" ) return result ;

			result = parseEthernetCityList() ;
			if ( result != "OK" ) return result ;

			result = parseWirelessCityList() ;
			if ( result != "OK" ) return result ;

			result = parseOperationsList() ;
			if ( result != "OK" ) return result ;

			result = parseButtonsList() ;
			if ( result != "OK" ) return result ;

			return "OK" ;
		}

		public string updateXMLDocument()
		{
			string result ;

			result = updateTextValue("UserName", userName) ;
			if ( result != "OK" ) return result ;
			
			result = updateTextValue("UserFullName", userFullName) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("CarrierCode", carrierCode) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("CanChangeLocationOnScanForm", canChangeLocationOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("DisplayFlightValidationMessages", displayFlightValidationMessages) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("LoadScansRequireSelectionFromPreset", loadScansRequireSelectionFromPreset) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("LockDownReleasedInAdminForm", lockDownReleasedInAdminForm) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("PasswordRequiredForLocationChangeOnScanForm", passwordRequiredForLocationChangeOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("PresetsRequireDestinationSpecifications", presetsRequireDestinationSpecifications) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("RejectReasonOnScanForm", rejectReasonOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("TailNumberOnScanForm", tailNumberOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("TransferPointOnScanForm", transferPointOnScanForm) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("TreatTransferScansAsLoadScans", treatTransferScansAsLoadScans) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("TriStateLargeBarcodeCheckBox", triStateLargeBarcodeCheckBox) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("WarnOnDuplicateScan", warnOnDuplicateScan) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("MailScanEnabled", mailScanEnabled) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("MailSimpleScanEnabled", mailSimpleScanEnabled) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("MessagesEnabled", messagesEnabled) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("CargoScanEnabled", cargoScanEnabled) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("BaggageScanEnabled", baggageScanEnabled) ;
			if ( result != "OK" ) return result ;

			result = updateboolValue("ScanningOptionsEnabled", scanningOptionsEnabled) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("CarrierCode", carrierCode) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("DefaultLocation", defaultLocation) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("FtpHostName", ftpHostName) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("FtpLoginID", ftpLoginID) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("FtpPassword", ftpPassword) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("FtpPortNumber", CStr(ftpPortNumber)) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("FtpConnectionDelay", CStr(ftpConnectionDelay)) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("UserFullName", userFullName) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("UserName", userName) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("CityList", cityListstring) ;
			if ( result != "OK" ) return result ;

			result = updateTextValue("OperationsList", operationListstring) ;
			if ( result != "OK" ) return result ;

			result = updatebuttonSpec() ;
			if ( result != "OK" ) return result ;
		}

//		private XmlNode getOrCreateButtonNode(buttonSpecRecordClass buttonSpec)
//		{
//			XmlNodeList nodeList     ;
//			string      xmlText      ;
//
//			XmlNode     buttonNode   ;
//			XmlNode     rootNode     ;
//			XmlNode     locationNode ; 
//			XmlNode     sizeNode     ;
//			XmlNode     textNode     ;
//
//			string      result       ; 
//
//			if (  ! buttonSpec.visible ) { return null ; }
//
//			nodeList = userSpecRecordXMLDocument.GetElementsByTagName(buttonSpec.buttonName) ;
//
//			if (  nodeList.Count == 0 )
//			{
//				rootNode = getOrCreateRootNode() ;
//
//				if (  rootNode == null ) { return null ; }
//
//				try
//				{
//					buttonNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, buttonSpec.buttonName, "") ;
//				}
//				catch (Exception ex1)
//				{
//					return null ;
//				}
//
//				if (  buttonNode == null ) { return null ; }
//
//				rootNode.AppendChild(buttonNode) ;
//
//				try
//				{
//					locationNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, "Location", "") ;
//
//				}
//
//				catch (Exception ex2)
//				{
//					return null ;
//				}
//
//				if (  locationNode == null ) { return null ; }
//
//				try
//				{
//					sizeNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, "Size", "") ;
//                }
//
//				catch (Exception ex3)
//				{
//					return null ;
//				}
//
//				if (  sizeNode == null ) { return null ; }
//
//				try
//				{
//					textNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, "Text", "") ;
//
//				}
//
//				catch (Exception ex4)
//				{
//					return null ;
//				}
//
//				if (  textNode == null ) { return null ; }
//
//				buttonNode.AppendChild(locationNode) ;
//				buttonNode.AppendChild(sizeNode)     ;
//				buttonNode.AppendChild(textNode)     ;
//			}
//
//			else if (  nodeList.Count == 1 )
//			{
//				buttonNode = nodeList(0) ;
//			}
//
//			else
//			{
//				buttonNode = null ;
//			}
//
//			return buttonNode ;
//		}


		private string updateButtonSpec(buttonSpecRecordClass buttonSpec)
		{

			XmlNodeList nodelist ;
			string xmlText       ;

			XmlNode buttonNode   ;
			XmlNode parentNode   ;

			string result        ;

			nodelist = userSpecRecordXMLDocument.GetElementsByTagName(buttonSpec.buttonName) ;

			if ( nodelist.Count == 0 )
			{

				if ( ! buttonSpec.visible ) return "OK" ;

				buttonNode = getOrCreateButtonNode(buttonSpec) ;

				if ( buttonNode == null ) return "Corrupt XML User Spec Representation. Fails on tag '" + buttonSpec.buttonName + "'" ;
			}

			else if ( nodelist.Count == 1 )
			{

				buttonNode = nodelist(0) ;

				if ( ! buttonSpec.visible )
				{

					try
					{
						parentNode = buttonNode.ParentNode ;
					}

					catch ( Exception ex1 )
					{
						return "Removal of XML button node for button '" + buttonSpec.buttonName + "' failed: " + ex1.Message ;
					}

					if ( parentNode == null )
					{
						return "Removal of XML button node for button '" + buttonSpec.buttonName + "' failed: cannot get parent." ;
					}

					try
					{
						parentNode.RemoveChild(buttonNode) ;
					}

					catch ( Exception ex2 )
					{
						return "Removal of XML button node for button '" + buttonSpec.buttonName + "' failed: " + ex.Message ;
					}

					return "OK" ;
				}
			}

			else
			{
				return "Corrupt XML User Spec Representation. Fails on tag '" + buttonSpec.buttonName + "'" ;
			}

			return updateButtonSpec(buttonSpec, buttonNode) ;
		}

		private void updateButtonSpec()
		{
			updateButtonSpec(summaryButtonSpec)   ;
			updateButtonSpec(presetsButtonSpec)   ;
			updateButtonSpec(binUploadButtonSpec) ;
			updateButtonSpec(binChangeButtonSpec) ;
			updateButtonSpec(manifestButtonSpec)  ;
			updateButtonSpec(mailButtonSpec)      ;
			updateButtonSpec(cargoButtonSpec)     ;
		}

		public string saveXMLDocument(string outputFileName)
		{
			deleteLocalFile(outputFileName) ;

			try
			{
				userSpecRecordXMLDocument.Save(outputFileName) ;
			}

			catch ( Exception ex )
			{
				return "Write of updated configuration file failed: " + ex.Message ;
			}

			return "OK" ;
		}
	}
}
