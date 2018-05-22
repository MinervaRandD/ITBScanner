using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Asi.Itb.Bll;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Utilities.ListViewSort;

namespace Asi.Itb.UI
{
    public partial class HandoverForm : BaseForm
    {
        private const int timeLength = 30;
        private static int timeElapsed;

        private static ListView.SelectedIndexCollection indexes;
        private static bool cancelClicked;

        private Thread syncThread;
        private static object syncLock = new object();

        private static System.Threading.Timer durationTimer;
        private static ManualResetEvent durationTimerResetEvent = new ManualResetEvent(true);

        private delegate void UpdateLocProgressBarDel(int progress);
        private UpdateLocProgressBarDel updateLocProgressBarDel;

        private delegate void LocationAddCompleteEventHandler();
        private event LocationAddCompleteEventHandler locationAddComplete;

        private delegate void SyncCompleteEventHandler();
        private event SyncCompleteEventHandler syncComplete;

        // one location with multiple gps readings
        private static List<GpsPosition> GpsPos;

        public HandoverForm()
        {
            updateLocProgressBarDel = new UpdateLocProgressBarDel(UpdateLocProgressBar);
            displaySyncErrorDel = new DisplaySyncErrorDel(DisplaySyncError);
            displaySyncProgressDel = new DisplaySyncProgressDel(DisplaySyncProgress);
            locationAddComplete += new LocationAddCompleteEventHandler(HandoverForm_locationAddComplete);
            syncComplete += new SyncCompleteEventHandler(HandoverForm_syncComplete);
        }
        
        public override void Initialize()
        {
            base.Initialize();
            InitializeComponent();

            InitComboBox(loctypeComboBox);
            InitListView();            
        }

        public override void LoadData()
        {
            base.LoadData();
        }

        public override void Populate()
        {
            base.Populate();
            InitControls();
        }

        private void UpdateLocProgressBar(int progress)
        {
            addProgressBar.Value = progress;
        }

        private void HandoverForm_locationAddComplete()
        {
            SessionData.Current.GpsUpdated -= new EventHandler(Current_GpsUpdated);
            durationTimer.Dispose();

            addProgressBar.Visible = false;
            loctypeComboBox.Enabled = true;
            addButton.Enabled = true;
            cancelButton.Enabled = false;
            sendButton.Enabled = true;
            addLabel.Text = string.Empty;
            
            if (!cancelClicked)
            {
                GpsPosition gp = GetAverageGpsPosition(GpsPos);
                if (gp == null)
                {
                    addLabel.Text = "<NO GPS SIGNAL!>";
                }
                else
                {
                    AddGpsToListView(loctypeComboBox.SelectedValue.ToString(), locTextBox.Text, gp);
                }
            }
        }
        
        private GpsPosition GetAverageGpsPosition(List<GpsPosition> gpspos)
        {
            if (gpspos == null || gpspos.Count == 0)
            {
                return null;
            }
            else
            {
                double totLat = 0;
                double totLng = 0;

                foreach (GpsPosition gps in gpspos)
                {
                    totLat += gps.Latitude;
                    totLng += gps.Longitude;
                }
                return new GpsPosition((double)(totLat / gpspos.Count), (double)(totLng / gpspos.Count));
            }
        }

        private void AddGpsToListView(string loctype, string loc, GpsPosition gps)
        {
            if (loc.Trim().Length > 0 && gps != null)
            {
                ListViewItem lvitem = new ListViewItem(
                    new string[]{
                        loctype,
                        loc,
                        gps.Latitude.ToString(),
                        gps.Longitude.ToString()
                    });
                locListView.Items.Add(lvitem);
                sendButtonToggle();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (locTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Location cannot be blank");
                return;
            }
            else
            {
                Regex LocRegEx = new Regex(@"^[a-zA-Z0-9_ ]*$");
                if (!LocRegEx.IsMatch(locTextBox.Text.Trim()))
                {
                    MessageBox.Show("Special characters are not allowed!");
                    locTextBox.Text = string.Empty;
                    locTextBox.Focus();
                    return;
                }
            }

            //////////////////////////////////////////
            timeElapsed = 0;
            
            addProgressBar.Value = 0;
            addProgressBar.Visible = true;

            loctypeComboBox.Enabled = false;
            addButton.Enabled = false;
            cancelButton.Enabled = true;
            cancelClicked = false;
            sendButton.Enabled = false;

            addLabel.Text = "Analyzing GPS data...";
            /////////////////////////////////////////

            GpsPos = null;
            durationTimer = new System.Threading.Timer(new System.Threading.TimerCallback(durationTimer_Tick), null, 1000, 1000);
            SessionData.Current.GpsUpdated += new EventHandler(Current_GpsUpdated);
        }

        private void Current_GpsUpdated(object sender, EventArgs e)
        {
            SessionData cur = SessionData.Current;

            if (cur.GpsPosition != null)
            {
                if (GpsPos == null)
                {
                    GpsPos = new List<GpsPosition>();
                }
                GpsPos.Add(cur.GpsPosition);
            }
        }

        private void durationTimer_Tick(object stateinfo)
        {
            durationTimerResetEvent.Reset();

            timeElapsed += 1;
            this.Invoke(updateLocProgressBarDel, (int)((timeElapsed * 100) / timeLength));
            if (timeElapsed >= timeLength)
            {
                this.Invoke(locationAddComplete);
            }

            durationTimerResetEvent.Set();
        }

        private void sendButton_Click(object sender, EventArgs e) // Changed caption to "Send"
        {
            if (locListView.Items.Count > 0)
            {
                List<Asi.Itb.Bll.DataContracts.HandoverLocation> HandoverLocations = new List<Asi.Itb.Bll.DataContracts.HandoverLocation>();
                Asi.Itb.Bll.DataContracts.HandoverLocation hloc;

                foreach (ListViewItem li in locListView.Items)
                {
                    hloc = new Asi.Itb.Bll.DataContracts.HandoverLocation();
                    hloc.Type = li.Text;
                    hloc.Name = li.SubItems[1].Text;
                    hloc.Latitude = li.SubItems[2].Text;
                    hloc.Longitude = li.SubItems[3].Text;
                    HandoverLocations.Add(hloc);
                }

                ThreadStart SendHandoverLocations = delegate { BackgroundSync(HandoverLocations); };
                syncThread = new Thread(SendHandoverLocations);
                ToggleComboAndButtons(false);           
                syncThread.Start();
            }
        }
                
        private void InitControls()
        {
            locTextBox.Text = string.Empty;
            addLabel.Text = string.Empty;
            addButton.Enabled = true;
            addProgressBar.Visible = false;
            cancelButton.Enabled = false;
            loctypeComboBox.Enabled = true;
            locListView.Items.Clear();
            removeButton.Enabled = false;
            sendButton.Enabled = false;
            syncStatusPanel.Visible = false;
            loctypeComboBox.SelectedValue = "P";
            
            sendButtonToggle();
        }

        private void InitComboBox(ComboBox cb)
        {
            Hashtable ht = new Hashtable();
            ht.Add("P", "Pickup");
            ht.Add("D", "Dropoff");

            BindingSource src = new BindingSource();
            src.DataSource = ht;

            cb.DataSource = src;
            cb.ValueMember = "Key";
            cb.DisplayMember = "Value";
            cb.SelectedValue = "P";
        }

        private void InitListView()
        {
            if (locListView.Columns.Count > 0)
            {
                locListView.Columns.Clear();
            }

            // MC75 resolution is different from PPC. Column width should be x2
            locListView.Columns.Add(new ColHeader("Type", 36, HorizontalAlignment.Left, true));
            locListView.Columns.Add(new ColHeader("Location", 104, HorizontalAlignment.Left, true));
            locListView.Columns.Add(new ColHeader("Lat", 45, HorizontalAlignment.Left, false));
            locListView.Columns.Add(new ColHeader("Long", 45, HorizontalAlignment.Left, false));

            locListView.ColumnClick += new ColumnClickEventHandler(locListView_ColumnClick);
        }
        
        private void locListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ColHeader clickedCol = (ColHeader)this.locListView.Columns[e.Column];
            clickedCol.ascending = !clickedCol.ascending;
            int numItems = this.locListView.Items.Count;
            this.locListView.BeginUpdate();
            ArrayList SortArray = new ArrayList();

            for (int i = 0; i < numItems; i++)
            {
                SortArray.Add(new SortWrapper(this.locListView.Items[i], e.Column));
            }
            SortArray.Sort(0, SortArray.Count, new SortWrapper.SortComparer(clickedCol.ascending));
            this.locListView.Items.Clear();

            for (int i = 0; i < numItems; i++)
            {
                this.locListView.Items.Add(((SortWrapper)SortArray[i]).sortItem);
            }
            this.locListView.EndUpdate();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelClicked = true;
            HandoverForm_locationAddComplete();
        }

        private void locListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexes = locListView.SelectedIndices;
            removeButton.Enabled = indexes.Count > 0 ? true : false;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            while (locListView.SelectedIndices.Count > 0)
            {
                locListView.Items.RemoveAt(locListView.SelectedIndices[0]);
            }
            sendButtonToggle();
        }

        private void sendButtonToggle()
        {
            sendButton.Enabled = locListView.Items.Count > 0 ? true : false;
        }

        private void HandoverForm_syncComplete()
        {
            InitControls();
        }

        private void ToggleComboAndButtons(bool enable)
        {
            foreach (Control ctl in Controls)
            {
                if (ctl is Button || ctl is ComboBox)
                {
                    ctl.Enabled = enable;
                }
            }
        }

        // ////////////////////////////////////////////////////////////////////////////
        // Reusing components from ScanForm.cs
        // ////////////////////////////////////////////////////////////////////////////
        private void BackgroundSync(List<Asi.Itb.Bll.DataContracts.HandoverLocation> HandoverLocations)
        {
            lock (syncLock)
            {
                ConnectionManager mgr = new ConnectionManager(HandoverLocations);

                mgr.SyncProgressMade += new EventHandler<SyncProgressEventArgs>(mgr_SyncProgressMade);
                mgr.SyncErrorOccurred += new EventHandler<SyncErrorEventArgs>(mgr_SyncErrorOccurred);
                               
                mgr.Sync();                                       
                
                mgr.SyncProgressMade -= new EventHandler<SyncProgressEventArgs>(mgr_SyncProgressMade);
                mgr.SyncErrorOccurred -= new EventHandler<SyncErrorEventArgs>(mgr_SyncErrorOccurred);

                this.Invoke(syncComplete);                
            }
        }        
        
        private delegate void DisplaySyncProgressDel(SyncProgressEventArgs e);
        private DisplaySyncProgressDel displaySyncProgressDel;
        private void DisplaySyncProgress(SyncProgressEventArgs e)
        {
            this.syncStatusPanel.Visible = true;
            this.syncStatusLabel.ForeColor = Color.Gray;
            this.syncStatusLabel.Text = e.StatusMessage;
            this.syncProgressBar.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                this.syncStatusPanel.Visible = false;
            }
        }

        private void mgr_SyncProgressMade(object sender, SyncProgressEventArgs e)
        {
            this.Invoke(this.displaySyncProgressDel, e);
        }

        private delegate void DisplaySyncErrorDel(SyncErrorEventArgs e);
        private DisplaySyncErrorDel displaySyncErrorDel;
        private void DisplaySyncError(SyncErrorEventArgs e)
        {
            this.syncStatusLabel.Text = e.Exception.Message;
            this.syncStatusLabel.ForeColor = Color.Red;
            this.syncStatusPanel.Visible = true;
        }

        private void mgr_SyncErrorOccurred(object sender, SyncErrorEventArgs e)
        {
            this.Invoke(this.displaySyncErrorDel, e);
        }       
        // ////////////////////////////////////////////////////////////////////////////
    }
}