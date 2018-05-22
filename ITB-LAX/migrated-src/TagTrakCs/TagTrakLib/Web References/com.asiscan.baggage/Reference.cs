﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.1433.
// 
namespace TagTrak.TagTrakLib.com.asiscan.baggage {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TagTrakSyncBinding", Namespace="urn:TagTrakSyncwsdl")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(UpgradeFileInfo))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(AssemblyVersion))]
    public partial class TagTrakSyncService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public TagTrakSyncService() {
            this.Url = "http://henry.dev.asiscan.com/bagstats/docs/index.php?soap=tagtraksync";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GmtTime", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public System.DateTime GmtTime() {
            object[] results = this.Invoke("GmtTime", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGmtTime(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GmtTime", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.DateTime EndGmtTime(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#UploadBagScans", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int UploadBagScans(string data, bool compress, string format, string serial) {
            object[] results = this.Invoke("UploadBagScans", new object[] {
                        data,
                        compress,
                        format,
                        serial});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUploadBagScans(string data, bool compress, string format, string serial, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UploadBagScans", new object[] {
                        data,
                        compress,
                        format,
                        serial}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndUploadBagScans(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#UploadLogs", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int UploadLogs(string data, bool compress, string format, string serial) {
            object[] results = this.Invoke("UploadLogs", new object[] {
                        data,
                        compress,
                        format,
                        serial});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUploadLogs(string data, bool compress, string format, string serial, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UploadLogs", new object[] {
                        data,
                        compress,
                        format,
                        serial}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndUploadLogs(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetCarriers", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetCarriers(string serial, System.DateTime lastUpdate) {
            object[] results = this.Invoke("GetCarriers", new object[] {
                        serial,
                        lastUpdate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCarriers(string serial, System.DateTime lastUpdate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCarriers", new object[] {
                        serial,
                        lastUpdate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetCarriers(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetCities", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetCities(string serial, System.DateTime lastUpdate) {
            object[] results = this.Invoke("GetCities", new object[] {
                        serial,
                        lastUpdate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCities(string serial, System.DateTime lastUpdate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCities", new object[] {
                        serial,
                        lastUpdate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetCities(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetCarrierCity", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetCarrierCity(string serial, System.DateTime lastUpdate) {
            object[] results = this.Invoke("GetCarrierCity", new object[] {
                        serial,
                        lastUpdate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetCarrierCity(string serial, System.DateTime lastUpdate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetCarrierCity", new object[] {
                        serial,
                        lastUpdate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetCarrierCity(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetEmployees", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetEmployees(string serial, System.DateTime lastUpdate) {
            object[] results = this.Invoke("GetEmployees", new object[] {
                        serial,
                        lastUpdate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetEmployees(string serial, System.DateTime lastUpdate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetEmployees", new object[] {
                        serial,
                        lastUpdate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetEmployees(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetAssemblyUpgrade", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public UpgradeFileInfo[] GetAssemblyUpgrade(string serial, AssemblyVersion[] curAssemblyVersions) {
            object[] results = this.Invoke("GetAssemblyUpgrade", new object[] {
                        serial,
                        curAssemblyVersions});
            return ((UpgradeFileInfo[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetAssemblyUpgrade(string serial, AssemblyVersion[] curAssemblyVersions, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetAssemblyUpgrade", new object[] {
                        serial,
                        curAssemblyVersions}, callback, asyncState);
        }
        
        /// <remarks/>
        public UpgradeFileInfo[] EndGetAssemblyUpgrade(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((UpgradeFileInfo[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetFile", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetFile(string serial, string fileName, string version, int offset, int maxLength) {
            object[] results = this.Invoke("GetFile", new object[] {
                        serial,
                        fileName,
                        version,
                        offset,
                        maxLength});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetFile(string serial, string fileName, string version, int offset, int maxLength, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetFile", new object[] {
                        serial,
                        fileName,
                        version,
                        offset,
                        maxLength}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetFile(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetFlights", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetFlights(string carrier, string location, [System.Xml.Serialization.SoapElementAttribute(DataType="date")] System.DateTime startDate, [System.Xml.Serialization.SoapElementAttribute(DataType="date")] System.DateTime endDate, System.DateTime lastUpdate) {
            object[] results = this.Invoke("GetFlights", new object[] {
                        carrier,
                        location,
                        startDate,
                        endDate,
                        lastUpdate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetFlights(string carrier, string location, System.DateTime startDate, System.DateTime endDate, System.DateTime lastUpdate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetFlights", new object[] {
                        carrier,
                        location,
                        startDate,
                        endDate,
                        lastUpdate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetFlights(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetHotBags", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetHotBags(string carrier, string location, [System.Xml.Serialization.SoapElementAttribute(DataType="date")] System.DateTime date, int flightNumber, System.DateTime lastUpdate) {
            object[] results = this.Invoke("GetHotBags", new object[] {
                        carrier,
                        location,
                        date,
                        flightNumber,
                        lastUpdate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetHotBags(string carrier, string location, System.DateTime date, int flightNumber, System.DateTime lastUpdate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetHotBags", new object[] {
                        carrier,
                        location,
                        date,
                        flightNumber,
                        lastUpdate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetHotBags(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:TagTrakSyncwsdl#GetMissingBags", RequestNamespace="urn:TagTrakSyncwsdl", ResponseNamespace="urn:TagTrakSyncwsdl")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetMissingBags(string carrier, string location, [System.Xml.Serialization.SoapElementAttribute(DataType="date")] System.DateTime date, int flightNumber, System.DateTime lastUpdate) {
            object[] results = this.Invoke("GetMissingBags", new object[] {
                        carrier,
                        location,
                        date,
                        flightNumber,
                        lastUpdate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetMissingBags(string carrier, string location, System.DateTime date, int flightNumber, System.DateTime lastUpdate, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetMissingBags", new object[] {
                        carrier,
                        location,
                        date,
                        flightNumber,
                        lastUpdate}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetMissingBags(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:TagTrakSyncwsdl")]
    public partial class AssemblyVersion {
        
        /// <remarks/>
        public string assemblyName;
        
        /// <remarks/>
        public string version;
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:TagTrakSyncwsdl")]
    public partial class UpgradeFileInfo {
        
        /// <remarks/>
        public string fileName;
        
        /// <remarks/>
        public string version;
        
        /// <remarks/>
        public int size;
    }
}