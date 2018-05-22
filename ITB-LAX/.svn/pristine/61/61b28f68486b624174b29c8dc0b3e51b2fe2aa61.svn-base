using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using Asi.Itb.Utilities;

namespace Asi.Itb.UI
{
    public partial class ExceptionDisplayForm : Form
    {
        public Exception exception;

        public ExceptionDisplayForm()
        {
            InitializeComponent();
        }

        private void ShowExceptionDetail()
        {
            if (this.exception != null)
            {
                this.errorDetailTextBox.Text = this.exception.ToString();
            }
        }

        private void ExceptionDisplayForm_Load(object sender, EventArgs e)
        {
            this.ShowExceptionDetail();
        }

        private void submitFogBugzButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Bll.FogBugzSettings conf = Bll.Configuration.Instance.FogBugzSettings;
                System.Net.ServicePointManager.CertificatePolicy = new AcceptAllCertificatePolicy(); 

                // submit exception
                FogBugz.BugReport report = new FogBugz.BugReport(conf.Uri, conf.User);
                report.Project = conf.Project;
                report.Area = conf.Area;
                report.SetException(this.exception, true, "{0}.{1}.{2}.{3}");
                report.AppendAssemblyInfo(System.Reflection.Assembly.GetExecutingAssembly());
                report.Email = conf.Email;
                report.ForceNewBug = false;
    			report.DefaultMsg = "Error from ITB scanner";

                // submit trace log file
                Trace.Close();
                string logFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\itblog.txt";
                if (File.Exists(logFilePath))
                {
                    StreamReader sr = new StreamReader(logFilePath);
                    string traceLogContent = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    report.ExtraInformation += Environment.NewLine + "Trace Log Content:" + Environment.NewLine + traceLogContent;
                }

                string ret = report.Submit();

                Cursor.Current = Cursors.Default;

                MessageBox.Show(ret, "Report Succeeded");
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Report to ASI failed");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}