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
using System.Reflection;
using Asi.Itb.Bll;
using Asi.Itb.Bll.Entities;

namespace Asi.Itb.UI
{
    /// <summary>
    /// Main form to perform scan activities and launch other forms.
    /// </summary>
    public partial class ScanFormBkup : BaseForm
    {
        private Hardware.Scanner.Base _scanner;

        /// <summary>
        /// Array to hold full list of menu items generated from designer, 
        /// for the use of user permission. Kindof hacky.
        /// </summary>
        private MenuItem[] _fullMenuItems;

        /// <summary>
        /// Delegate type for RefreshGpsLabel
        /// </summary>
        private delegate void RefreshGpsLabelDel();

        /// <summary>
        /// Delegate to invoke RefreshGpsLabel() method from another thread
        /// </summary>
        private RefreshGpsLabelDel refreshGpsLabelDel;

        /// <summary>
        /// Delegate type for UpdateScanSyncDisplay()
        /// </summary>
        private delegate void UpdateScanSyncDisplayDel();

        /// <summary>
        /// Delegate to invoke UpdateScanSyncDisplay() method from another thread
        /// </summary>
        private UpdateScanSyncDisplayDel updateScanSyncDisplayDel;

        /// <summary>
        /// Delegate type for UpdateLocOpDisplay()
        /// </summary>
        private delegate void UpdateLocOpDisplayDel();

        /// <summary>
        /// Delegate to invoke UpdateLocOpDisplay() from another thread.
        /// </summary>
        private UpdateLocOpDisplayDel updateLocOpDisplayDel;

        /// <summary>
        /// Delegate type for LogOut()
        /// </summary>
        private delegate void LogOutDel();

        /// <summary>
        /// Delegate type for UpdateRadioBatteryStates()
        /// </summary>
        private delegate void UpdateRadioBatteryStatesDel();

        /// <summary>
        /// Delegate to invoke UpdateRadioBatteryStates() from another thread.
        /// </summary>
        private UpdateRadioBatteryStatesDel updateRadioBatteryStatesDel;

        private System.Threading.Timer radioBatteryStateTimer;

        /// <summary>
        /// ManualResetEvent to check states on radio, battery, connectivity(ping), and upload data
        /// </summary>
        private System.Threading.ManualResetEvent radioBatteryStateResetEvent;               

        /// <summary>
        /// ManualResetEvent to sychronize back ground sync thread and UI thread.
        /// </summary>
        private ManualResetEvent syncResetEvent = new ManualResetEvent(true);

        /// <summary>
        /// Queue of scans to be saved to DB, serving as a buffer.
        /// </summary>
        private Queue<Scan> _pendingScans = new Queue<Scan>();        

        #region a group of flag variables to indicate when to slow down upload

        /// <summary>
        /// Time when last scan occurred
        /// </summary>
        private DateTime _lastScanTime = DateTime.MinValue;

        /// <summary>
        /// New scans since last successful upload
        /// </summary>
        private int _newScansSinceLastUpload = 0;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public ScanFormBkup()
        {
            _scanner = Hardware.Scanner.Base.GetInstance();

            if (_scanner != null)
            {
                SetScannerSettings();
            }
            else
            {
                // Try one more time, and let the exception be caught
                System.Threading.Thread.Sleep(3000);
                _scanner = Hardware.Scanner.Base.GetInstance();
                SetScannerSettings();
            }
#if Silent
            _scanner.Beep = false; // to reduce noise during development
#endif

            batteryFullImage = GetImage(@"\images\batteryFull.png");
            batteryEmptyImage = GetImage(@"\images\batteryEmpty.png");

            radioOnImage = new Image[5];
            for (int i = 0; i < radioOnImage.Length; i++)
            {
                radioOnImage[i] = GetImage(@"\images\radio" + i.ToString() + "bar.png");
            }
            radioOffImage = GetImage(@"\images\radioOff.png");

            pingSuccessImage = GetImage(@"\images\pingSuccess.png");
            pingFailImage = GetImage(@"\images\pingFail.png");

            uploadDataExistsImage = GetImage(@"\images\uploadDataExists.png");            
            uploadDataNotExistsImage = GetImage(@"\images\uploadDataNotExists.png");

            _scanner.IgnoreDuplicates = true;
            _scanner.BarCodeRead += new Hardware.Scanner.Base.BarCodeReadEventHandler(_scanner_BarCodeRead);

            radioBatteryStateResetEvent = new System.Threading.ManualResetEvent(true);

            refreshGpsLabelDel = new RefreshGpsLabelDel(RefreshGpsLabel);
            updateScanSyncDisplayDel = new UpdateScanSyncDisplayDel(UpdateScanSyncDisplay);
            updateLocOpDisplayDel = new UpdateLocOpDisplayDel(UpdateLocOpDisplay);
            displaySyncErrorDel = new DisplaySyncErrorDel(DisplaySyncError);
            displaySyncProgressDel = new DisplaySyncProgressDel(DisplaySyncProgress);
            setSyncTimerIntervalDel = new SetSyncTimerIntervalDel(SetSyncTimerInterval);
            updateRadioBatteryStatesDel = new UpdateRadioBatteryStatesDel(UpdateRadioBatteryStates);
        }

        private void SetScannerSettings()
        {
            _scanner.Code128 = true;
            _scanner.Interleaved2of5 = true;
            if (_scanner.ContinuousSupported) { _scanner.Continuous = true; }
            if (_scanner.BeepSupported) { _scanner.Beep = true; }
            if (_scanner.VibrateSupported) { _scanner.Vibrate = true; }
            if (_scanner.LEDSupported) { _scanner.LED = true; }
        }

        private Image batteryFullImage;
        private Image batteryEmptyImage;

        private Image[] radioOnImage;
        private Image radioOffImage;

        private Image pingSuccessImage;
        private Image pingFailImage;

        private Image uploadDataExistsImage;
        private Image uploadDataNotExistsImage;

        public override void Initialize()
        {
            base.Initialize();

            InitializeComponent();

            _fullMenuItems = new MenuItem[this.rootMenuItem.MenuItems.Count];
            this.rootMenuItem.MenuItems.CopyTo(_fullMenuItems, 0);

            this.ExitPictureBoxVisible = false; // have to do it here since designer not working properly

            this.syncStatusPanel.BackColor = Color.Transparent;

            SessionData.Current.GpsUpdated += new EventHandler(Current_GpsUpdated);
            SessionData.Current.GpsChanged += new EventHandler(Current_GpsMoved);
            Program.IdleTimedOut += new EventHandler(Program_IdleTimedOut);
        }

        private void Program_IdleTimedOut(object sender, EventArgs e)
        {
            if (Program.formStack.Top.GetType() != typeof(LoginForm))
            {
                this.Invoke(new LogOutDel(this.LogOut));
            }
        }

        private void Current_GpsMoved(object sender, EventArgs e)
        {
            this.Invoke(this.updateLocOpDisplayDel);
        }

        private void Current_GpsUpdated(object sender, EventArgs e)
        {
            this.Invoke(this.refreshGpsLabelDel);
        }

        private void RefreshGpsLabel()
        {
            SessionData cur = SessionData.Current;

            if (cur.GpsPosition != null)
            {
                this.gpsLabel.Text = string.Format("GPS: {0}", cur.GpsPosition.ToString());
            }
            else
            {
                this.gpsLabel.Text = "GPS: N/A";
            }
        }

        /// <summary>
        /// Overriden method to populate data on ScanForm.
        /// </summary>
        public override void Populate()
        {
            base.Populate();

            Program.LastUserActivity = DateTime.Now;

            this.tagTextBox.Text = string.Empty;
            this.destTextBox.Text = string.Empty;
            this.locationTextBox.Text = string.Empty;
            this.operationTextBox.Text = string.Empty;
            this.damageMenuItem.Checked = false;
            this.outboundFlightTextBox.Text = string.Empty;
            this.wheelsInTextBox.Text = string.Empty;
            this.etdTextBox.Text = string.Empty;
            this.SetDamagedTagStyle();
            this.scanCountButton.Text = "0";

            this.AdjustAuditScreen();

            this.SetSyncTimerInterval();
            this.syncTimer.Enabled = false;

            this.ApplyUserPermissions();
            this.InitMisdropWarning();

            this.UpdateLocOpDisplay();

            if (this.IsAudit())
            {
                ScanManager.ClearScans(false);
            }

            this.UpdateScanSyncDisplay();            
        }

        /// <summary>
        /// Adjust UI elements based on whether currently logged in is audit or not
        /// </summary>
        private void AdjustAuditScreen()
        {
            this.SuspendLayout();

            int xr = this.Width / 240;
            int yr = this.Height / 294;

            if (this.IsAudit())
            {
                this.locationLabel.Location = new Point(xr * 15, yr * 130);
                this.locationTextBox.Location = new Point(xr * 106, yr * 130);
                this.tagLabel.Location = new Point(xr * 15, yr * 172);
                this.tagTextBox.Location = new Point(xr * 106, yr * 172);
                this.destLabel.Location = new Point(xr * 15, yr * 214);
                this.destTextBox.Location = new Point(xr * 106, yr * 214);

                this.auditPanel.Visible = true;
                this.operationLabel.Visible = false;
                this.operationTextBox.Visible = false;
                this.gpsLabel.Visible = false;
            }
            else
            {
                this.locationLabel.Location = new Point(xr * 15, yr * 130);
                this.locationTextBox.Location = new Point(xr * 106, yr * 130);
                this.tagLabel.Location = new Point(xr * 15, yr * 172);
                this.tagTextBox.Location = new Point(xr * 106, yr * 172);
                this.destLabel.Location = new Point(xr * 15, yr * 214);
                this.destTextBox.Location = new Point(xr * 106, yr * 214);
                this.operationLabel.Location = new Point(xr * 15, yr * 256);
                this.operationTextBox.Location = new Point(xr * 106, yr * 256);

                this.auditPanel.Visible = false;
                this.operationLabel.Visible = true;
                this.operationTextBox.Visible = true;
                this.gpsLabel.Visible = true;
            }

            this.ResumeLayout(true);
        }

        /// <summary>
        /// Check whether currently logged-in user is auditor.
        /// </summary>
        /// <returns></returns>
        private bool IsAudit()
        {
            return SessionData.Current.User.RoleName == "Auditor";
        }

        /// <summary>
        /// Apply user permission settings to hide/disable relevant UI elements.
        /// </summary>
        private void ApplyUserPermissions()
        {
            List<string> perms = SessionData.Current.User.Permissions;

            bool damageMenuItemAllowed = perms.Contains("Flag Damaged Bag");
            bool overrideAllowed = perms.Contains("Location/Scan Override");
            bool addLocationsAllowed = perms.Contains("Add Locations");

            // //////////////////////////////////////////////////////////////////////////////////////////////////
            // TODO: Enable misdrop warning for demo
            // APS doesn't want the misdrop warning menu to be shown. This feature is disabled by default.
            bool misdropWarningAllowed = false; // bool misdropWarningAllowed = perms.Contains("Misdrop Warning");                        
            // //////////////////////////////////////////////////////////////////////////////////////////////////

            // Clear everyone out first, then reload from previously save full list,
            // to ensure the sequence.
            this.rootMenuItem.MenuItems.Clear();
            foreach (MenuItem item in _fullMenuItems)
            {
                if ((item == this.damageMenuItem && !damageMenuItemAllowed)
                    ||
                    (item == this.overrideMenuItem && !overrideAllowed)
                    ||
                    (item == this.addLocationsMenuItem && !addLocationsAllowed)
                    ||
                    (item == this.misdropMenuItem && !misdropWarningAllowed)
                    )
                {
                    continue;
                }
                else
                {
                    this.rootMenuItem.MenuItems.Add(item);
                }
            }
        }

        private void _scanner_BarCodeRead(string barCode, Hardware.Scanner.Base.Symbologies symBology)
        {
            Program.LastUserActivity = DateTime.Now;
            this._lastScanTime = DateTime.Now;

            if (Configuration.Instance.MisdropWarning)
                _scanner.IgnoreDuplicates = true;

            Regex bagTagRegex = new Regex(@"^\d{10}$");
            if (symBology != Hardware.Scanner.Base.Symbologies.Code128 && bagTagRegex.IsMatch(barCode))
            {
                Bag bag = ScanManager.GetBagByBarcode(barCode);
                if (Configuration.Instance.MisdropWarning)
                {
                    try
                    {
                        if (!IsValidDropOffLocation(bag))
                        {
                            if (ShowDropOffWarning(barCode, bag) == DialogResult.No)
                            {
                                _scanner.IgnoreDuplicates = false;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionDisplayForm frm = new ExceptionDisplayForm();
                        frm.exception = ex;
                        frm.ShowDialog();
                    }
                }

                this.tagTextBox.Text = barCode;
                DoSaveTag();

                // alert if bag is to be departed in less than 60 mins or already departed.
                if (bag.DepartureTime != null &&
                    bag.DepartureTime.Value.Subtract(DateTime.Now).TotalMinutes < 60)
                {
                    this._scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Warning);
                    string depart = bag.DepartureTime.Value.CompareTo(DateTime.Now) > 0 ?
                        "is departing" : "departed";
                    MessageBox.Show(string.Format("Outgoing flight {0}{1} {2} on {3}", bag.OutboundCarrier,
                        bag.OutboundFlight, depart, bag.DepartureTime),
                        string.Format("Warning [Tag: {0}]", barCode),
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                LocationManager mgr = new LocationManager();
                Location loc = mgr.GetLocationByBarcode(barCode);
                if (loc != null)
                {
                    loc.Source = LocationSource.BarcodeScan;
                    SessionData.Current.Location = loc;
                    SessionData.Current.OperationCode = loc.AllowedOperation;
                    this.locationTextBox.Text = barCode;
                    if (SessionData.Current.OperationCode.HasValue)
                    {
                        this.operationTextBox.Text = SessionData.Current.OperationCode.Value.ToString();
                    }
                    this._scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.GoodScan);
                }
                else
                {
                    _scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Warning);
                    MessageBox.Show("Location scan invalid.", "Invalid Location");
                }
            }
        }


        private void DoSaveTag()
        {
            Debug.WriteLine(string.Format("{0}: Entering", DateTime.Now.Ticks), "DoSaveTag");
            if (this.locationTextBox.Text == string.Empty)
            {
                _scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Warning);
                MessageBox.Show("Please scan or override location", "Location Missing");
                this.tagTextBox.Text = string.Empty;
            }
            else
            {
                Debug.WriteLine(string.Format("{0}: Before SaveScan", DateTime.Now.Ticks), "DoSaveTag");
                this.SaveScan();
                Debug.WriteLine(string.Format("{0}: After SaveScan", DateTime.Now.Ticks), "DoSaveTag");
                this._scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.GoodScan);
                Debug.WriteLine(string.Format("{0}: After Feedback", DateTime.Now.Ticks), "DoSaveTag");
                this.UpdateScanSyncDisplay();
            }
        }

        /// <summary>
        /// Update the BSM related fields from the barcode from tag textbox
        /// </summary>
        private void UpdateBsmFields()
        {
            Regex bagTagRegex = new Regex(@"^\d{10}$");            
            
            if (bagTagRegex.IsMatch(this.tagTextBox.Text))
            {
                Bag bag = ScanManager.GetBagByBarcode(this.tagTextBox.Text);
                this.destTextBox.Text = bag != null ? bag.DestinationLocationCode : string.Empty;
                if (this.IsAudit())
                {
                    this.wheelsInTextBox.Text = bag != null && bag.ArrivalTime != null ? bag.ArrivalTime.Value.ToString("HH:mm") : "Unknown";
                    this.outboundFlightTextBox.Text = bag != null && bag.OutboundFlight != 0 ? bag.OutboundCarrier + bag.OutboundFlight.ToString() : "Unknown";
                    this.etdTextBox.Text = bag != null && bag.DepartureTime != null ? bag.DepartureTime.Value.ToString("HH:mm") : "Unknown";
                }
            }
        }

        /// <summary>
        /// Create Scan object from screen field values and save to database.
        /// </summary>
        private void SaveScan()
        {
            Scan scanData = new Scan();
            scanData.Barcode = this.tagTextBox.Text;
            scanData.LocationCode = SessionData.Current.Location.Barcode;
            scanData.Operation = this.IsAudit() ? Scan.ScanOperation.CarrierDropOff : SessionData.Current.OperationCode.Value;
            scanData.ScanTime = DateTime.UtcNow;
            scanData.UserName = SessionData.Current.User.UserName;
            scanData.Damaged = this.damageMenuItem.Checked;

            ScanManager.SaveLocalScan(scanData);
            this._newScansSinceLastUpload++;
        }

        private bool IsValidDropOffLocation(Bag bag)
        {
            bool result = true;

            try { if (SessionData.Current.Location.Barcode == null) { } }
            catch (NullReferenceException) { return result; }

            try { if (bag == null) { } }
            catch (NullReferenceException) { return result; }

            LocationManager mgr = new LocationManager();
            Location loc = mgr.GetLocationByBarcode(SessionData.Current.Location.Barcode == null ? "" : SessionData.Current.Location.Barcode);
            
            if (loc != null && bag != null)
            {
                if (loc.Type == "D")
                {
                    try { if (bag.DestinationLocationCode == null) { } }
                    catch (NullReferenceException) { return result; }

                    if (bag.DestinationLocationCode == null)
                    {
                        return result;
                    }
                    if (bag.DestinationLocationCode.Trim().ToLower() != SessionData.Current.Location.Barcode.Trim().ToLower())
                    {
                        result = false;
                    }       
                }
            }
            return result;
        }

        private DialogResult ShowDropOffWarning(string barcode, Bag bag)
        {
            DialogResult dr;
            string message = "WRONG drop off location <" + SessionData.Current.Location.Barcode + ">\n"
                              + "CORRECT drop off location is <" + bag.DestinationLocationCode + ">\n"
                              + "Continue to drop off at WRONG location?";
            _scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Warning);
            dr = MessageBox.Show(message, "Warning [Tag:" + barcode + "]", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            return dr;
        }

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.LogOut();

            Cursor.Current = Cursors.Default;
        }

        private void overrideMenuItem_Click(object sender, EventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;

            Cursor.Current = Cursors.WaitCursor;

            Program.formStack.Push(typeof(OverrideForm), true);

            Cursor.Current = Cursors.Default;
        }

        private void messagesPictureBox_Click(object sender, EventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;

            Cursor.Current = Cursors.WaitCursor;

            Program.formStack.Push(typeof(MessageListForm), true);

            Cursor.Current = Cursors.Default;
        }

        private void addLocationsMenuItem_Click(object sender, EventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;

            Cursor.Current = Cursors.WaitCursor;

            Program.formStack.Push(typeof(HandoverForm), true);

            Cursor.Current = Cursors.Default;
        }

        private void countDetailMenuItem_Click(object sender, EventArgs e)
        {
            ShowCountDetail();
        }

        private static void ShowCountDetail()
        {
            Program.LastUserActivity = DateTime.Now;

            Cursor.Current = Cursors.WaitCursor;

            SessionData.Current.BagCountStatus = Bag.Status.All;
            Program.formStack.Push(typeof(BagCountForm), true);

            Cursor.Current = Cursors.Default;
        }

        private void damageMenuItem_Click(object sender, EventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;

            damageMenuItem.Checked = !damageMenuItem.Checked;
            this.tagTextBox.Text = string.Empty;

            SetDamagedTagStyle();
        }

        private void SetDamagedTagStyle()
        {
            this.tagTextBox.BackColor = damageMenuItem.Checked ? Color.Coral : Color.White;
        }

        private void syncMenuItem_Click(object sender, EventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;

            Program.formStack.Push(typeof(SyncProgressForm), true);
        }


        private void onHandButton_Click(object sender, EventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;

            Cursor.Current = Cursors.WaitCursor;

            SessionData.Current.BagCountStatus = Bag.Status.OnHand;
            Program.formStack.Push(typeof(BagCountForm), true);

            Cursor.Current = Cursors.Default;
        }

        private void dropOffButton_Click(object sender, EventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;

            Cursor.Current = Cursors.WaitCursor;

            SessionData.Current.BagCountStatus = Bag.Status.DroppedOff;
            Program.formStack.Push(typeof(BagCountForm), true);

            Cursor.Current = Cursors.Default;
        }

        private void ScanForm_Activated(object sender, EventArgs e)
        {
            _scanner.Enabled = true;
            syncTimer.Enabled = false;
            clockTimer.Enabled = true;
            radioBatteryStateTimer = new System.Threading.Timer(new System.Threading.TimerCallback(this.UpdateRadioBatteryStatesThread), null, 0, 5000);
        }

        private void ScanForm_Deactivate(object sender, EventArgs e)
        {
            _scanner.Enabled = false;
            syncTimer.Enabled = false;
            clockTimer.Enabled = false;

            if (radioBatteryStateTimer != null)
            {
                radioBatteryStateResetEvent.WaitOne(5000, false);
                radioBatteryStateTimer.Dispose();
            }
        }

        /// <summary>
        /// Update UI fields dependent on scan and sync data, including Dest location box and counters.
        /// </summary>
        private void UpdateScanSyncDisplay()
        {
            this.UpdateBsmFields();

            this.UpdateCounters();

            this.ShowNewMessage();
        }

        /// <summary>
        /// Update counter values.
        /// </summary>
        private void UpdateCounters()
        {
            if (this.IsAudit())
            {
                int scanCount = ScanManager.GetBagCount(Bag.Status.All);
                this.scanCountButton.Text = scanCount.ToString();
            }
            else
            {
                int onHandCount = ScanManager.GetBagCount(Bag.Status.OnHand);
                int dropOffCount = onHandCount == 0 ? 0 : ScanManager.GetBagCount(Bag.Status.DroppedOff);
                if (onHandCount == 0)
                {
                    ScanManager.ClearScans(false);
                }
                this.onHandButton.Text = onHandCount.ToString();
                this.dropOffButton.Text = dropOffCount.ToString();
            }
        }

        /// <summary>
        /// Show new message
        /// </summary>
        private void ShowNewMessage()
        {
            MessageManager mmgr = new MessageManager();
            bool hasUnReadMessages = mmgr.HasUnreadMessages();
            if (hasUnReadMessages && this.Visible)
            {
                List<Message> msgs = mmgr.GetMessages(true);
                if (msgs.Count > 0)
                {
                    this._scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Warning);
                    Message msg = msgs[0];
                    SessionData.Current.Message = msg;
                    Program.formStack.Push(typeof(MessageDetailForm), true);
                    mmgr.MarkMessageRead(msg.Id);
                }
            }
        }

        /// <summary>
        /// Update location and operation display from current sessionData
        /// </summary>
        private void UpdateLocOpDisplay()
        {
            SessionData cur = SessionData.Current;

            if (cur.GpsPosition != null)
            {
                if (cur.Location == null || cur.Location.Source == LocationSource.GPS)
                {
                    if (Configuration.Instance.GetLocationByGpsData)
                    {
                        LocationManager lmgr = new LocationManager();
                        Bll.Entities.Location loc = lmgr.GetLocationByGpsData(cur.GpsPosition.Latitude, cur.GpsPosition.Longitude);
                        if (loc != null)
                        {
                            loc.Source = LocationSource.GPS;
                            cur.Location = loc;
                            cur.OperationCode = loc.AllowedOperation;
                        }
                    }
                }
            }
            else if (cur.Location != null && cur.Location.Source == LocationSource.GPS)
            {
                cur.Location = null;
            }

            if (cur.Location != null)
            {
                this.locationTextBox.Text = cur.Location.Barcode;
            }
            else
            {
                this.locationTextBox.Text = string.Empty;
            }

            if (cur.OperationCode != null)
            {
                this.operationTextBox.Text = cur.OperationCode.ToString();
            }
            else
            {
                this.operationTextBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Background process to sync scanner periodically
        /// </summary>        
        private void BackgroundSync()
        {
            Debug.WriteLine("Entering", "BackgroundSync");
            ConnectionManager mgr = new ConnectionManager();

            mgr.SyncProgressMade += new EventHandler<SyncProgressEventArgs>(mgr_SyncProgressMade);
            mgr.SyncErrorOccurred += new EventHandler<SyncErrorEventArgs>(mgr_SyncErrorOccurred);
            mgr.ScannerUpdateIntervalUpdated += new EventHandler(mgr_ScannerUpdateIntervalUpdated);
            mgr.IdleTimeOutUpdated += new EventHandler(mgr_IdleTimeOutUpdated);
            mgr.GpsIdleTimeOutUpdated += new EventHandler(mgr_GpsIdleTimeOutUpdated);
            mgr.BatteryWarningPercentUpdated += new EventHandler(mgr_BatteryWarningPercentUpdated);

            Debug.WriteLine("Calling Sync()", "BackgroundSync");

            mgr.Sync();

            this._newScansSinceLastUpload = 0;

            Debug.WriteLine("Calling refreshUiFromDB()", "BackgroundSync");

            this.Invoke(this.updateScanSyncDisplayDel);

            Debug.WriteLine("Calling syncResetEvent.Set()", "BackgroundSync");

            this.syncResetEvent.Set();

            Debug.WriteLine("Exiting", "BackgroundSync");
        }

        private void mgr_GpsIdleTimeOutUpdated(object sender, EventArgs e)
        {
            Program.SetGpsIdleTimeOut();
        }

        private void mgr_IdleTimeOutUpdated(object sender, EventArgs e)
        {
            Program.SetIdleTimeOut();
        }

        private void mgr_ScannerUpdateIntervalUpdated(object sender, EventArgs e)
        {
            this.Invoke(this.setSyncTimerIntervalDel);
        }

        private void mgr_BatteryWarningPercentUpdated(object sender, EventArgs e)
        {
            Program.SetBatteryWarningPercent();
        }

        private delegate void SetSyncTimerIntervalDel();
        private SetSyncTimerIntervalDel setSyncTimerIntervalDel;
        /// <summary>
        /// Set interval value for syncTimer with value from db
        /// </summary>
        private void SetSyncTimerInterval()
        {
            ConnectionManager mgr = new ConnectionManager();
            int? interval = mgr.GetScannerUpdateInterval();
            Debug.WriteLine("Got interval", "SetSyncTimerInterval");
            if (interval == null)
            {
                Debug.WriteLine("Interval is null", "SetSyncTimerInterval");
                interval = 30;
            }
            Debug.WriteLine("Interval: " + interval, "SetSyncTimerInterval");
            this.syncTimer.Interval = 1000 * interval.Value;
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

        /// <summary>
        /// Save manually entered tag when Enter is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tagTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string barcode = this.tagTextBox.Text;
                Regex bagTagRegex = new Regex(@"^\d{10}$");
                if (bagTagRegex.IsMatch(barcode))
                {
                    if (Configuration.Instance.MisdropWarning)
                    {
                        Bag bag = ScanManager.GetBagByBarcode(barcode);
                        if (!IsValidDropOffLocation(bag))
                        {
                            if (ShowDropOffWarning(barcode, bag) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }

                    this.DoSaveTag();
                }
                else
                {
                    _scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Warning);
                    MessageBox.Show("Bag tag needs to contain 10 digits", "Invalid Bag Tag");
                }
            }
        }

        private void ScanForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;
        }

        private void ScanForm_Click(object sender, EventArgs e)
        {
            Program.LastUserActivity = DateTime.Now;
        }

        private void syncTimer_Tick(object sender, EventArgs e)
        {
            // check flag variables and skip the sync under certain conditions
            bool lastScanLessThan20Secs = DateTime.Now.Subtract(this._lastScanTime).TotalSeconds < 20;
            bool lessThan50ScansToUpload = _newScansSinceLastUpload < 50;
            bool lastSyncFailLessThan5Mins = ConnectionManager.SyncFailureTime.HasValue && DateTime.Now.Subtract(ConnectionManager.SyncFailureTime.Value).TotalMinutes < 5;
            bool idleForMoreThan60Secs = DateTime.Now.Subtract(Program.LastUserActivity).TotalSeconds > 60;
            bool standForMoreThan60Secs = DateTime.Now.Subtract(Program.LastGpsMovement).TotalSeconds > 60;
            bool noScansToUpload = _newScansSinceLastUpload == 0;

            if ((lastScanLessThan20Secs && lessThan50ScansToUpload) ||
                lastSyncFailLessThan5Mins ||
                (idleForMoreThan60Secs && standForMoreThan60Secs && noScansToUpload))
            {
                return;
            }

            // if a previous sync thread is running, do not wait and come back next time.
            bool signaled = this.syncResetEvent.WaitOne(0, false);

            if (signaled)
            {
                this.syncResetEvent.Reset();

                Thread backgroundSyncThread = new Thread(new ThreadStart(this.BackgroundSync));
                backgroundSyncThread.Priority = ThreadPriority.Lowest;
                backgroundSyncThread.IsBackground = true;
                backgroundSyncThread.Start();           
            }
        }

        /// <summary>
        /// Logout via popping all forms until login is left.
        /// </summary>
        private void LogOut()
        {
            UserManager umgr = new UserManager();
            umgr.SaveActivity(SessionData.Current.User.UserName, UserActivityType.LogOut);

            MessageManager mmgr = new MessageManager();
            mmgr.DeleteAllMessages();

            while (true)
            {
                StackForm top = Program.formStack.Top;

                if (top == null)
                {
                    Program.formStack.Stop();
                    break;
                }
                else
                {
                    Type topType = top.GetType();
                    if (topType == typeof(ScanForm))
                    {
                        Program.formStack.Pop(1, true);
                        SessionData.Current.Location = null;
                        SessionData.Current.OperationCode = null;
                        break;
                    }
                    else if (
                        topType == typeof(LoginForm) 
                     || topType == typeof(SyncProgressForm) 
                     || topType == typeof(ExitForm))
                    {
                        return;
                    }
                    else
                    {
                        Program.formStack.Pop(1, false);
                    }
                }
            }
        }

        private void resetCountersMenuItem_Click(object sender, EventArgs e)
        {
            ScanManager.ClearScans(true);

            this.UpdateScanSyncDisplay();
        }

        private void scanCountButton_Click(object sender, EventArgs e)
        {
            ShowCountDetail();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToShortTimeString();
            if (this.timeMenuItem.Text != time) // only update ui when there is change
            {
                this.timeMenuItem.Text = time;
            }
        }     

        /// <summary>
        /// Update the image used to show states of radio, batteries, ping, and upload data
        /// </summary>
        private void UpdateRadioBatteryStatesThread(object state)
        {
            bool signaled = this.radioBatteryStateResetEvent.WaitOne(0, false);
            bool syncSignaled = this.syncResetEvent.WaitOne(0, false);

            if (signaled && syncSignaled)
            {
                this.radioBatteryStateResetEvent.Reset();
                this.Invoke(updateRadioBatteryStatesDel);
                this.radioBatteryStateResetEvent.Set();
            }
        }

        private void UpdateRadioBatteryStates()
        {
            // GPRS Signal Strength
            switch (Program.radioStrength)
            {
                case Hardware.Networking.GPRS.SignalBars.Bar0:
                    this.radioPictureBox.Image = this.radioOnImage[0];
                    break;
                case Hardware.Networking.GPRS.SignalBars.Bar1:
                    this.radioPictureBox.Image = this.radioOnImage[1];
                    break;
                case Hardware.Networking.GPRS.SignalBars.Bar2:
                    this.radioPictureBox.Image = this.radioOnImage[2];
                    break;
                case Hardware.Networking.GPRS.SignalBars.Bar3:
                    this.radioPictureBox.Image = this.radioOnImage[3];
                    break;
                case Hardware.Networking.GPRS.SignalBars.Bar4:
                    this.radioPictureBox.Image = this.radioOnImage[4];
                    break;
                case Hardware.Networking.GPRS.SignalBars.RadioOff:
                    this.radioPictureBox.Image = this.radioOffImage;
                    break;
                default:
                    this.radioPictureBox.Image = this.radioOffImage;
                    break;
            }

            // Battery Status
            if (Hardware.Power.BatteryPercent() >= Program.BatteryWarningPercent)
            {
                this.batteryPictureBox.Image = this.batteryFullImage;
            }
            else
            {
                this.batteryPictureBox.Image = this.batteryEmptyImage;
            }

            // Ping Status
            if (Program.IsPingSuccess())
            {
                this.pingPictureBox.Image = this.pingSuccessImage;
            }
            else
            {
                this.pingPictureBox.Image = this.pingFailImage;
            }

            // Upload Scan Status
            if (ScanManager.UploadScansExists())
            {
                this.uploadPictureBox.Image = this.uploadDataExistsImage;
            }
            else
            {
                this.uploadPictureBox.Image = this.uploadDataNotExistsImage;
            }
        }

        private void misdropOnMenuItem_Click(object sender, EventArgs e)
        {
            misdropOnMenuItem.Enabled = false;
            misdropOffMenuItem.Enabled = true;
            Configuration.SaveMisdropWarning(true);
        }

        private void misdropOffMenuItem_Click(object sender, EventArgs e)
        {
            misdropOnMenuItem.Enabled = true;
            misdropOffMenuItem.Enabled = false;
            Configuration.SaveMisdropWarning(false);
        }

        private void InitMisdropWarning()
        {
            if (rootMenuItem.MenuItems.Contains(misdropMenuItem))
            {
                if (Configuration.Instance.MisdropWarning)
                {
                    misdropOnMenuItem.Enabled = false;                    
                    misdropOffMenuItem.Enabled = true;
                }
                else
                {
                    misdropOnMenuItem.Enabled = true;
                    misdropOffMenuItem.Enabled = false;
                }
            }
        }
        
        private Bitmap GetImage(string filePath)
        {
            string imageFilePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + filePath;
            return new Bitmap(imageFilePath);
        }

       
    }
}