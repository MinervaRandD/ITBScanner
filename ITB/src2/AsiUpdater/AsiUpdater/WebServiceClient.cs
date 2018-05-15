using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.IO;

namespace AsiUpdater
{
    /// <summary>
    /// Represents web service client to send and receive data from server 
    /// </summary>
    public class WebServiceClient : IDisposable
    {
        private HttpWebResponse resp;
        private HttpWebRequest req;
        private Stream reqStream;
        private StreamWriter sw;
        private Stream respStream;

        public WebServiceClient()
        {
        }

        /// <summary>
        /// Connect to server to send up load request data, and get response stream.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Stream GetStreamFromPostRequest(string request, string uri)
        {
            string rawRequest = "payload=" + request;
            req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = "POST";
            req.ContentLength = rawRequest.Length;

            reqStream = req.GetRequestStream();
            sw = new StreamWriter(reqStream);
            sw.Write(rawRequest);
            sw.Close();

            resp = (HttpWebResponse)req.GetResponse();
            respStream = resp.GetResponseStream();
            return respStream;
        }

        #region IDisposable Members

        private bool disposed;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (resp != null)
                    {
                        resp.Close();
                    }
                    if (req != null)
                    {
                        req = null;
                    }
                    if (reqStream != null)
                    {
                        reqStream.Close();
                        reqStream.Dispose();
                    }
                    if (sw != null)
                    {
                        sw.Close();
                        sw.Dispose();
                    }
                    if (respStream != null)
                    {
                        respStream.Close();
                        respStream.Dispose();
                    }
                    disposed = true;
                }
            }
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            
            // Ensure the object is not garbage collected
            // until the dispose method completes
            GC.KeepAlive(this);
        }

        ~WebServiceClient()
        {
            Dispose(false);
        }        
        #endregion
    }
}
