using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Asi.Itb.Bll;
using Asi.Itb.Bll.Entities;

namespace Asi.Itb.UI
{
    public partial class SyncProgressForm : BaseForm
    {
        private Thread _syncThread;

        private ConnectionManager _conMgr;

        private delegate void DisplayProgressDel(SyncProgressEventArgs e);

        private delegate void DisplayErrorDel(SyncErrorEventArgs e);

        public SyncProgressForm()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeComponent();
        }

        public override void Populate()
        {
            base.Populate();

            this.syncProgressLabel.ForeColor = Color.Black;
            this.syncProgressLabel.Text = string.Empty;
            this.syncProgrssBar.Value = 0;
            this.closeButton.Enabled = false;

            Cursor.Current = Cursors.WaitCursor;

            _syncThread = new Thread(new ThreadStart(this.BeginSync));
            _syncThread.Start();
        }

        private void BeginSync()
        {
            _conMgr = new ConnectionManager();
            _conMgr.SyncProgressMade += new EventHandler<SyncProgressEventArgs>(conMgr_SyncProgressMade);
            _conMgr.SyncErrorOccurred += new EventHandler<SyncErrorEventArgs>(_conMgr_SyncErrorOccurred);
            _conMgr.Sync();
        }

        private void _conMgr_SyncErrorOccurred(object sender, SyncErrorEventArgs e)
        {
            this.Invoke(new DisplayErrorDel(DisplaySyncError), e);
        }

        private void DisplaySyncError(SyncErrorEventArgs e)
        {
            Cursor.Current = Cursors.Default;

            this.syncProgressLabel.ForeColor = Color.Red;
            this.syncProgressLabel.Text = e.Exception.Message;
            this.closeButton.Enabled = true;
        }

        private void conMgr_SyncProgressMade(object sender, SyncProgressEventArgs e)
        {
            this.Invoke(new DisplayProgressDel(DisplaySyncProgress), e);
        }

        private void DisplaySyncProgress(SyncProgressEventArgs e)
        {
            this.syncProgressLabel.Text = e.StatusMessage;
            this.syncProgrssBar.Value = e.ProgressPercentage;

            if (this.syncProgrssBar.Value == 100)
            {
                Cursor.Current = Cursors.Default;

                Program.formStack.Pop(1, false);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Program.formStack.Pop(1, false);
        }
    }
}