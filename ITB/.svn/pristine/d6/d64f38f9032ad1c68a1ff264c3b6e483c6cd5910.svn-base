using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace Asi.Itb.TestWebService
{
    /// <summary>
    /// Test HttpHandler to return sample response xml document back to scanner.
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ScannerSync : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.IO.StreamReader rdr = new System.IO.StreamReader(context.Request.InputStream);
            string request = rdr.ReadToEnd();
            rdr.Close();

            System.IO.StreamReader rdr2 = new System.IO.StreamReader(context.Server.MapPath("~/bin/ItbResponse.xml"));
            string response = rdr2.ReadToEnd();
            rdr2.ReadToEnd();
            context.Response.ContentType = "text/xml";
            context.Response.Write(response);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
