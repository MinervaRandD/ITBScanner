﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
// 
namespace TagTrak.com.asiscan.baggage_ws {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TagTrakSyncBinding", Namespace="urn:TagTrakSync")]
    public class TagTrakSyncService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public TagTrakSyncService() {
            this.Url = "http://baggage-ws.asiscan.com/tagtraksync.php";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://schemas.xmlsoap.org/soap/envelope/#TagTrakSync#UploadBagScans", RequestNamespace="http://schemas.xmlsoap.org/soap/envelope/", ResponseNamespace="http://schemas.xmlsoap.org/soap/envelope/")]
        [return: System.Xml.Serialization.SoapElementAttribute("result")]
        public int UploadBagScans(string data, string username, string password, bool compress, string format) {
            object[] results = this.Invoke("UploadBagScans", new object[] {
                        data,
                        username,
                        password,
                        compress,
                        format});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUploadBagScans(string data, string username, string password, bool compress, string format, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UploadBagScans", new object[] {
                        data,
                        username,
                        password,
                        compress,
                        format}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndUploadBagScans(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://schemas.xmlsoap.org/soap/envelope/#TagTrakSync#GmtTime", RequestNamespace="http://schemas.xmlsoap.org/soap/envelope/", ResponseNamespace="http://schemas.xmlsoap.org/soap/envelope/")]
        [return: System.Xml.Serialization.SoapElementAttribute("gmttime")]
        public string GmtTime() {
            object[] results = this.Invoke("GmtTime", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGmtTime(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GmtTime", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGmtTime(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}