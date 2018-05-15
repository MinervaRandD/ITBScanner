using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Asi.Itb.Bll.DataContracts;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Dal;
using System.Xml.Serialization;

namespace RequestTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTestLegacyRequest_Click(object sender, EventArgs e)
        {
            ItbRequest itbRequest = TestRequestGenerator.testRequests();

            XmlSerializer requestSl = new XmlSerializer(typeof(Asi.Itb.Bll.DataContracts.ItbRequest));
            StringWriter sw = new StringWriter();
            requestSl.Serialize(sw, itbRequest);
            string requestXml = sw.ToString();
            sw.Close();

            StreamWriter sw1 = new StreamWriter(@"request.xml");
            sw1.WriteLine(requestXml);
            sw1.Flush();
            sw1.Close();

            WebServiceClient wsc = new WebServiceClient();

            try
            {
                Stream s = wsc.GetStreamFromLegacyPostRequest(requestXml, @"http://jfk.itb.asiscan.com/scanner_interactions");

                StreamReader sr = new StreamReader(s);

                this.txbResults.Text = sr.ReadToEnd();
            
            }

            catch (Exception ex)
            {
                this.txbResults.Text = ex.Message;
            }
        }
    }
}