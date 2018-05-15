namespace Asi.Itb.UI
{
    partial class ScanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            this.syncResetEvent.WaitOne();

            Asi.Itb.Bll.Entities.SessionData.Current.GpsUpdated -= new System.EventHandler(this.Current_GpsUpdated);
            Asi.Itb.Bll.Entities.SessionData.Current.GpsChanged -= new System.EventHandler(this.Current_GpsMoved);
            Program.IdleTimedOut -= new System.EventHandler(this.Program_IdleTimedOut);

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanForm));
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.operationLabel = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.rootMenuItem = new System.Windows.Forms.MenuItem();
            this.addLocationsMenuItem = new System.Windows.Forms.MenuItem();
            this.countDetailMenuItem = new System.Windows.Forms.MenuItem();
            this.damageMenuItem = new System.Windows.Forms.MenuItem();
            this.overrideMenuItem = new System.Windows.Forms.MenuItem();
            this.messagesMenuItem = new System.Windows.Forms.MenuItem();
            this.syncMenuItem = new System.Windows.Forms.MenuItem();
            this.resetCountersMenuItem = new System.Windows.Forms.MenuItem();
            this.misdropMenuItem = new System.Windows.Forms.MenuItem();
            this.misdropOnMenuItem = new System.Windows.Forms.MenuItem();
            this.misdropOffMenuItem = new System.Windows.Forms.MenuItem();
            this.logoutMenuItem = new System.Windows.Forms.MenuItem();
            this.timeMenuItem = new System.Windows.Forms.MenuItem();
            this.tagLabel = new System.Windows.Forms.Label();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.destLabel = new System.Windows.Forms.Label();
            this.destTextBox = new System.Windows.Forms.TextBox();
            this.onHandLabel = new System.Windows.Forms.Label();
            this.onHandButton = new System.Windows.Forms.Button();
            this.dropOffButton = new System.Windows.Forms.Button();
            this.dropOffLabel = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.messagePictureBox = new System.Windows.Forms.PictureBox();
            this.operationTextBox = new System.Windows.Forms.TextBox();
            this.gpsLabel = new System.Windows.Forms.Label();
            this.syncStatusPanel = new System.Windows.Forms.Panel();
            this.syncStatusLabel = new System.Windows.Forms.Label();
            this.syncProgressBar = new System.Windows.Forms.ProgressBar();
            this.syncTimer = new System.Windows.Forms.Timer();
            this.auditPanel = new System.Windows.Forms.Panel();
            this.scanCountButton = new System.Windows.Forms.Button();
            this.scanCountLabel = new System.Windows.Forms.Label();
            this.etdTextBox = new System.Windows.Forms.TextBox();
            this.etdLabel = new System.Windows.Forms.Label();
            this.outboundFlightTextBox = new System.Windows.Forms.TextBox();
            this.outboundFlightLabel = new System.Windows.Forms.Label();
            this.wheelsInTextBox = new System.Windows.Forms.TextBox();
            this.wheelsLabel = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer();
            this.batteryPictureBox = new System.Windows.Forms.PictureBox();
            this.radioPictureBox = new System.Windows.Forms.PictureBox();
            this.pingPictureBox = new System.Windows.Forms.PictureBox();
            this.uploadPictureBox = new System.Windows.Forms.PictureBox();
            this.syncStatusPanel.SuspendLayout();
            this.auditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // locationLabel
            // 
            this.locationLabel.Location = new System.Drawing.Point(15, 76);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(85, 20);
            this.locationLabel.Text = "Location";
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(106, 76);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.ReadOnly = true;
            this.locationTextBox.Size = new System.Drawing.Size(113, 21);
            this.locationTextBox.TabIndex = 2;
            this.locationTextBox.TabStop = false;
            // 
            // operationLabel
            // 
            this.operationLabel.Location = new System.Drawing.Point(15, 103);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(85, 20);
            this.operationLabel.Text = "Operation";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.rootMenuItem);
            this.mainMenu1.MenuItems.Add(this.timeMenuItem);
            // 
            // rootMenuItem
            // 
            this.rootMenuItem.MenuItems.Add(this.addLocationsMenuItem);
            this.rootMenuItem.MenuItems.Add(this.countDetailMenuItem);
            this.rootMenuItem.MenuItems.Add(this.damageMenuItem);
            this.rootMenuItem.MenuItems.Add(this.overrideMenuItem);
            this.rootMenuItem.MenuItems.Add(this.messagesMenuItem);
            this.rootMenuItem.MenuItems.Add(this.syncMenuItem);
            this.rootMenuItem.MenuItems.Add(this.resetCountersMenuItem);
            this.rootMenuItem.MenuItems.Add(this.misdropMenuItem);
            this.rootMenuItem.MenuItems.Add(this.logoutMenuItem);
            this.rootMenuItem.Text = "Menu";
            // 
            // addLocationsMenuItem
            // 
            this.addLocationsMenuItem.Text = "Add Locations";
            this.addLocationsMenuItem.Click += new System.EventHandler(this.addLocationsMenuItem_Click);
            // 
            // countDetailMenuItem
            // 
            this.countDetailMenuItem.Text = "Count Detail";
            this.countDetailMenuItem.Click += new System.EventHandler(this.countDetailMenuItem_Click);
            // 
            // damageMenuItem
            // 
            this.damageMenuItem.Text = "Damage";
            this.damageMenuItem.Click += new System.EventHandler(this.damageMenuItem_Click);
            // 
            // overrideMenuItem
            // 
            this.overrideMenuItem.Text = "Location/Scan Override";
            this.overrideMenuItem.Click += new System.EventHandler(this.overrideMenuItem_Click);
            // 
            // messagesMenuItem
            // 
            this.messagesMenuItem.Text = "Messages";
            this.messagesMenuItem.Click += new System.EventHandler(this.messagesPictureBox_Click);
            // 
            // syncMenuItem
            // 
            this.syncMenuItem.Text = "Sync";
            this.syncMenuItem.Click += new System.EventHandler(this.syncMenuItem_Click);
            // 
            // resetCountersMenuItem
            // 
            this.resetCountersMenuItem.Text = "Clear Counters";
            this.resetCountersMenuItem.Click += new System.EventHandler(this.resetCountersMenuItem_Click);
            // 
            // misdropMenuItem
            // 
            this.misdropMenuItem.MenuItems.Add(this.misdropOnMenuItem);
            this.misdropMenuItem.MenuItems.Add(this.misdropOffMenuItem);
            this.misdropMenuItem.Text = "Misdrop Warning";
            // 
            // misdropOnMenuItem
            // 
            this.misdropOnMenuItem.Text = "On";
            this.misdropOnMenuItem.Click += new System.EventHandler(this.misdropOnMenuItem_Click);
            // 
            // misdropOffMenuItem
            // 
            this.misdropOffMenuItem.Text = "Off";
            this.misdropOffMenuItem.Click += new System.EventHandler(this.misdropOffMenuItem_Click);
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.Text = "Logout";
            this.logoutMenuItem.Click += new System.EventHandler(this.logoutMenuItem_Click);
            // 
            // timeMenuItem
            // 
            this.timeMenuItem.Text = "";
            // 
            // tagLabel
            // 
            this.tagLabel.Location = new System.Drawing.Point(15, 130);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(85, 20);
            this.tagLabel.Text = "Bag Tag";
            // 
            // tagTextBox
            // 
            this.tagTextBox.Location = new System.Drawing.Point(106, 130);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(113, 21);
            this.tagTextBox.TabIndex = 7;
            this.tagTextBox.TabStop = false;
            this.tagTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tagTextBox_KeyPress);
            // 
            // destLabel
            // 
            this.destLabel.Location = new System.Drawing.Point(16, 158);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(85, 20);
            this.destLabel.Text = "Destination";
            // 
            // destTextBox
            // 
            this.destTextBox.Location = new System.Drawing.Point(106, 157);
            this.destTextBox.Name = "destTextBox";
            this.destTextBox.ReadOnly = true;
            this.destTextBox.Size = new System.Drawing.Size(113, 21);
            this.destTextBox.TabIndex = 9;
            this.destTextBox.TabStop = false;
            // 
            // onHandLabel
            // 
            this.onHandLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.onHandLabel.Location = new System.Drawing.Point(21, 192);
            this.onHandLabel.Name = "onHandLabel";
            this.onHandLabel.Size = new System.Drawing.Size(72, 20);
            this.onHandLabel.Text = "On Hand";
            this.onHandLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // onHandButton
            // 
            this.onHandButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.onHandButton.Location = new System.Drawing.Point(36, 215);
            this.onHandButton.Name = "onHandButton";
            this.onHandButton.Size = new System.Drawing.Size(43, 29);
            this.onHandButton.TabIndex = 11;
            this.onHandButton.Click += new System.EventHandler(this.onHandButton_Click);
            // 
            // dropOffButton
            // 
            this.dropOffButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.dropOffButton.Location = new System.Drawing.Point(142, 215);
            this.dropOffButton.Name = "dropOffButton";
            this.dropOffButton.Size = new System.Drawing.Size(43, 29);
            this.dropOffButton.TabIndex = 13;
            this.dropOffButton.Click += new System.EventHandler(this.dropOffButton_Click);
            // 
            // dropOffLabel
            // 
            this.dropOffLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.dropOffLabel.Location = new System.Drawing.Point(114, 192);
            this.dropOffLabel.Name = "dropOffLabel";
            this.dropOffLabel.Size = new System.Drawing.Size(99, 20);
            this.dropOffLabel.Text = "Dropped Off";
            this.dropOffLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // messagePictureBox
            // 
            this.messagePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("messagePictureBox.Image")));
            this.messagePictureBox.Location = new System.Drawing.Point(197, 259);
            this.messagePictureBox.Name = "messagePictureBox";
            this.messagePictureBox.Size = new System.Drawing.Size(21, 16);
            this.messagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.messagePictureBox.Visible = false;
            this.messagePictureBox.Click += new System.EventHandler(this.messagesPictureBox_Click);
            // 
            // operationTextBox
            // 
            this.operationTextBox.Location = new System.Drawing.Point(106, 103);
            this.operationTextBox.Name = "operationTextBox";
            this.operationTextBox.ReadOnly = true;
            this.operationTextBox.Size = new System.Drawing.Size(113, 21);
            this.operationTextBox.TabIndex = 20;
            this.operationTextBox.TabStop = false;
            // 
            // gpsLabel
            // 
            this.gpsLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.gpsLabel.Location = new System.Drawing.Point(2, 261);
            this.gpsLabel.Name = "gpsLabel";
            this.gpsLabel.Size = new System.Drawing.Size(145, 16);
            this.gpsLabel.Text = "GPS: N/A";
            // 
            // syncStatusPanel
            // 
            this.syncStatusPanel.Controls.Add(this.syncStatusLabel);
            this.syncStatusPanel.Controls.Add(this.syncProgressBar);
            this.syncStatusPanel.Location = new System.Drawing.Point(0, 251);
            this.syncStatusPanel.Name = "syncStatusPanel";
            this.syncStatusPanel.Size = new System.Drawing.Size(134, 26);
            this.syncStatusPanel.Visible = false;
            // 
            // syncStatusLabel
            // 
            this.syncStatusLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.syncStatusLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.syncStatusLabel.Location = new System.Drawing.Point(3, 4);
            this.syncStatusLabel.Name = "syncStatusLabel";
            this.syncStatusLabel.Size = new System.Drawing.Size(130, 13);
            // 
            // syncProgressBar
            // 
            this.syncProgressBar.Location = new System.Drawing.Point(1, 18);
            this.syncProgressBar.Name = "syncProgressBar";
            this.syncProgressBar.Size = new System.Drawing.Size(130, 6);
            // 
            // syncTimer
            // 
            this.syncTimer.Interval = 2;
            this.syncTimer.Tick += new System.EventHandler(this.syncTimer_Tick);
            // 
            // auditPanel
            // 
            this.auditPanel.Controls.Add(this.scanCountButton);
            this.auditPanel.Controls.Add(this.scanCountLabel);
            this.auditPanel.Controls.Add(this.etdTextBox);
            this.auditPanel.Controls.Add(this.etdLabel);
            this.auditPanel.Controls.Add(this.outboundFlightTextBox);
            this.auditPanel.Controls.Add(this.outboundFlightLabel);
            this.auditPanel.Controls.Add(this.wheelsInTextBox);
            this.auditPanel.Controls.Add(this.wheelsLabel);
            this.auditPanel.Location = new System.Drawing.Point(5, 153);
            this.auditPanel.Name = "auditPanel";
            this.auditPanel.Size = new System.Drawing.Size(219, 98);
            this.auditPanel.Visible = false;
            // 
            // scanCountButton
            // 
            this.scanCountButton.Location = new System.Drawing.Point(99, 72);
            this.scanCountButton.Name = "scanCountButton";
            this.scanCountButton.Size = new System.Drawing.Size(55, 20);
            this.scanCountButton.TabIndex = 7;
            this.scanCountButton.Text = "0";
            this.scanCountButton.Click += new System.EventHandler(this.scanCountButton_Click);
            // 
            // scanCountLabel
            // 
            this.scanCountLabel.Location = new System.Drawing.Point(12, 71);
            this.scanCountLabel.Name = "scanCountLabel";
            this.scanCountLabel.Size = new System.Drawing.Size(85, 20);
            this.scanCountLabel.Text = "Scan Count";
            // 
            // etdTextBox
            // 
            this.etdTextBox.Location = new System.Drawing.Point(100, 47);
            this.etdTextBox.Name = "etdTextBox";
            this.etdTextBox.ReadOnly = true;
            this.etdTextBox.Size = new System.Drawing.Size(113, 21);
            this.etdTextBox.TabIndex = 5;
            // 
            // etdLabel
            // 
            this.etdLabel.Location = new System.Drawing.Point(13, 48);
            this.etdLabel.Name = "etdLabel";
            this.etdLabel.Size = new System.Drawing.Size(80, 20);
            this.etdLabel.Text = "ETD";
            // 
            // outboundFlightTextBox
            // 
            this.outboundFlightTextBox.Location = new System.Drawing.Point(100, 24);
            this.outboundFlightTextBox.Name = "outboundFlightTextBox";
            this.outboundFlightTextBox.ReadOnly = true;
            this.outboundFlightTextBox.Size = new System.Drawing.Size(113, 21);
            this.outboundFlightTextBox.TabIndex = 3;
            // 
            // outboundFlightLabel
            // 
            this.outboundFlightLabel.Location = new System.Drawing.Point(11, 25);
            this.outboundFlightLabel.Name = "outboundFlightLabel";
            this.outboundFlightLabel.Size = new System.Drawing.Size(91, 20);
            this.outboundFlightLabel.Text = "Outbound Flt.";
            // 
            // wheelsInTextBox
            // 
            this.wheelsInTextBox.Location = new System.Drawing.Point(100, 1);
            this.wheelsInTextBox.Name = "wheelsInTextBox";
            this.wheelsInTextBox.ReadOnly = true;
            this.wheelsInTextBox.Size = new System.Drawing.Size(113, 21);
            this.wheelsInTextBox.TabIndex = 1;
            // 
            // wheelsLabel
            // 
            this.wheelsLabel.Location = new System.Drawing.Point(10, 3);
            this.wheelsLabel.Name = "wheelsLabel";
            this.wheelsLabel.Size = new System.Drawing.Size(64, 20);
            this.wheelsLabel.Text = "Wheels In";
            // 
            // clockTimer
            // 
            this.clockTimer.Interval = 1000;
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // batteryPictureBox
            // 
            this.batteryPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.batteryPictureBox.Location = new System.Drawing.Point(201, 259);
            this.batteryPictureBox.Name = "batteryPictureBox";
            this.batteryPictureBox.Size = new System.Drawing.Size(16, 16);
            this.batteryPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // radioPictureBox
            // 
            this.radioPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.radioPictureBox.Location = new System.Drawing.Point(179, 259);
            this.radioPictureBox.Name = "radioPictureBox";
            this.radioPictureBox.Size = new System.Drawing.Size(16, 16);
            this.radioPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pingPictureBox
            // 
            this.pingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pingPictureBox.Location = new System.Drawing.Point(159, 259);
            this.pingPictureBox.Name = "pingPictureBox";
            this.pingPictureBox.Size = new System.Drawing.Size(16, 16);
            this.pingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // uploadPictureBox
            // 
            this.uploadPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.uploadPictureBox.Location = new System.Drawing.Point(139, 259);
            this.uploadPictureBox.Name = "uploadPictureBox";
            this.uploadPictureBox.Size = new System.Drawing.Size(16, 16);
            this.uploadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // ScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.uploadPictureBox);
            this.Controls.Add(this.pingPictureBox);
            this.Controls.Add(this.auditPanel);
            this.Controls.Add(this.syncStatusPanel);
            this.Controls.Add(this.batteryPictureBox);
            this.Controls.Add(this.radioPictureBox);
            this.Controls.Add(this.gpsLabel);
            this.Controls.Add(this.operationTextBox);
            this.Controls.Add(this.messagePictureBox);
            this.Controls.Add(this.dropOffButton);
            this.Controls.Add(this.dropOffLabel);
            this.Controls.Add(this.onHandButton);
            this.Controls.Add(this.onHandLabel);
            this.Controls.Add(this.destTextBox);
            this.Controls.Add(this.destLabel);
            this.Controls.Add(this.tagTextBox);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.locationTextBox);
            this.ExitPictureBoxVisible = true;
            this.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.Location = new System.Drawing.Point(0, 0);
            this.Menu = this.mainMenu1;
            this.Name = "ScanForm";
            this.Text = "ScanForm";
            this.TitleLabelText = "Scan";
            this.TitleLabelVisible = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.ScanForm_Activated);
            this.Click += new System.EventHandler(this.ScanForm_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScanForm_KeyPress);
            this.Deactivate += new System.EventHandler(this.ScanForm_Deactivate);
            this.syncStatusPanel.ResumeLayout(false);
            this.auditPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem rootMenuItem;
        private System.Windows.Forms.MenuItem countDetailMenuItem;
        private System.Windows.Forms.MenuItem logoutMenuItem;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.TextBox destTextBox;
        private System.Windows.Forms.Label onHandLabel;
        private System.Windows.Forms.Button onHandButton;
        private System.Windows.Forms.Button dropOffButton;
        private System.Windows.Forms.Label dropOffLabel;
        private System.Windows.Forms.MenuItem damageMenuItem;
        private System.Windows.Forms.MenuItem overrideMenuItem;
        private System.Windows.Forms.MenuItem messagesMenuItem;
        private System.Windows.Forms.MenuItem syncMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox messagePictureBox;
        private System.Windows.Forms.TextBox operationTextBox;
        private System.Windows.Forms.Label gpsLabel;
        private System.Windows.Forms.Panel syncStatusPanel;
        private System.Windows.Forms.ProgressBar syncProgressBar;
        private System.Windows.Forms.Label syncStatusLabel;
        private System.Windows.Forms.Timer syncTimer;
        private System.Windows.Forms.MenuItem resetCountersMenuItem;
        private System.Windows.Forms.Panel auditPanel;
        private System.Windows.Forms.Label wheelsLabel;
        private System.Windows.Forms.TextBox outboundFlightTextBox;
        private System.Windows.Forms.Label outboundFlightLabel;
        private System.Windows.Forms.TextBox wheelsInTextBox;
        private System.Windows.Forms.TextBox etdTextBox;
        private System.Windows.Forms.Label etdLabel;
        private System.Windows.Forms.Button scanCountButton;
        private System.Windows.Forms.Label scanCountLabel;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.MenuItem timeMenuItem;
        private System.Windows.Forms.MenuItem addLocationsMenuItem;
        private System.Windows.Forms.PictureBox batteryPictureBox;
        private System.Windows.Forms.PictureBox radioPictureBox;
        private System.Windows.Forms.MenuItem misdropMenuItem;
        private System.Windows.Forms.MenuItem misdropOnMenuItem;
        private System.Windows.Forms.MenuItem misdropOffMenuItem;
        private System.Windows.Forms.PictureBox pingPictureBox;
        private System.Windows.Forms.PictureBox uploadPictureBox;
    }
}