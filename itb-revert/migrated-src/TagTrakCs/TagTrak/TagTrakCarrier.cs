using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO; 
using TagTrak.TagTrakLib; 
using System.Data.SqlServerCe;
using TagTrak.Baggage;
using System.Diagnostics;
using TagTrak.TagTrakLib.com.asiscan.baggage;
using System.Net;


namespace TagTrak 
{
	public class TagTrakCarrier : System.Windows.Forms.Form 
	{ 
		private System.Windows.Forms.Timer Timer1; 
		private System.Windows.Forms.ComboBox cbxLocation; 
		private System.Windows.Forms.Label dateTimeLabel; 
		private System.Windows.Forms.Label curDateTime; 
		private System.Windows.Forms.Label headerLabel; 
		private System.Windows.Forms.PictureBox logo; 
		private System.Windows.Forms.Button syncButton;
		private System.Windows.Forms.Panel locationPanel;
		private System.Windows.Forms.Panel timePanel;
		private System.Windows.Forms.Panel iconPanel;
		private System.Windows.Forms.ImageList iconList;
		private System.Windows.Forms.ListView iconListView; 
		private System.Windows.Forms.Button confirmLocation; 

		private bool isInitialLoad = true;

		public TagTrakCarrier() 
		{

			InitializeComponent(); 

			config = ConfigSetting.Instance();
			updateFromConfig();

			this.iconListView.Activation = ItemActivation.OneClick;

			this.Load += new EventHandler(TagTrakCarrier_Load);
			this.Timer1.Tick += new EventHandler(Timer1_Tick);
			this.LostFocus += new EventHandler(TagTrakCarrier_LostFocus);

			this.config.CarrierChanged += new CarrierChangedEventHandler(config_CarrierChanged);
			ConfigSetting.ProgramExit += new EventHandler(config_ProgramExit);
			this.syncButton.Click += new EventHandler(syncButton_Click);
			this.confirmLocation.Click += new EventHandler(cbxLocationChangConfirmed);	
		} 

		public static void Main()
		{ 
			try 
			{
				Application.Run(new LoaderForm());
			} 
			catch (SqlCeException sqlex) 
			{ 
				string errMsg = ""; 
				foreach (SqlCeError err in sqlex.Errors) 
				{ 
					errMsg += err.Message + "\r\n"; 
				} 
				MessageBox.Show(errMsg, "SQL CE Error"); 
			} 
			catch (WebException ex)
			{
				MessageBox.Show("Error occurred while accessing the network: " + "\r\n" + ex.Message + ". " + "\r\n" + "Please check network connection and reboot the device.", "Network Error"); 
			}
			catch (Exception ex) 
			{ 
				MessageBox.Show("An unexpected error occurred: " + "\r\n" + ex.Message + ". " + "\r\n" + "Please reboot the device.", "Unexpected Error"); 
			} 
			finally 
			{ 
				DbAccess.CloseConnection();
			} 
		} 

		protected override void Dispose(bool disposing) 
		{ 
			base.Dispose(disposing); 
		} 


		#region Windows Form Designer generated code

		private void InitializeComponent() 
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagTrakCarrier));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem();
            this.logo = new System.Windows.Forms.PictureBox();
            this.Timer1 = new System.Windows.Forms.Timer();
            this.cbxLocation = new System.Windows.Forms.ComboBox();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.curDateTime = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.syncButton = new System.Windows.Forms.Button();
            this.confirmLocation = new System.Windows.Forms.Button();
            this.locationPanel = new System.Windows.Forms.Panel();
            this.timePanel = new System.Windows.Forms.Panel();
            this.iconPanel = new System.Windows.Forms.Panel();
            this.iconListView = new System.Windows.Forms.ListView();
            this.iconList = new System.Windows.Forms.ImageList();
            this.locationPanel.SuspendLayout();
            this.timePanel.SuspendLayout();
            this.iconPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(24, 8);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(180, 60);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // Timer1
            // 
            this.Timer1.Interval = 500;
            // 
            // cbxLocation
            // 
            this.cbxLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbxLocation.Location = new System.Drawing.Point(80, 72);
            this.cbxLocation.Name = "cbxLocation";
            this.cbxLocation.Size = new System.Drawing.Size(80, 27);
            this.cbxLocation.TabIndex = 0;
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.dateTimeLabel.Location = new System.Drawing.Point(16, 24);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(208, 24);
            this.dateTimeLabel.Text = "Current Date && Time:";
            // 
            // curDateTime
            // 
            this.curDateTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.curDateTime.Location = new System.Drawing.Point(24, 72);
            this.curDateTime.Name = "curDateTime";
            this.curDateTime.Size = new System.Drawing.Size(192, 32);
            this.curDateTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.headerLabel.Location = new System.Drawing.Point(24, 24);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(200, 32);
            this.headerLabel.Text = "Please select location:";
            // 
            // syncButton
            // 
            this.syncButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.syncButton.Location = new System.Drawing.Point(56, 120);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(120, 32);
            this.syncButton.TabIndex = 2;
            this.syncButton.Text = "Synchronize";
            // 
            // confirmLocation
            // 
            this.confirmLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.confirmLocation.Location = new System.Drawing.Point(56, 120);
            this.confirmLocation.Name = "confirmLocation";
            this.confirmLocation.Size = new System.Drawing.Size(120, 32);
            this.confirmLocation.TabIndex = 1;
            this.confirmLocation.Text = "Confirm";
            // 
            // locationPanel
            // 
            this.locationPanel.Controls.Add(this.cbxLocation);
            this.locationPanel.Controls.Add(this.confirmLocation);
            this.locationPanel.Controls.Add(this.headerLabel);
            this.locationPanel.Location = new System.Drawing.Point(0, 76);
            this.locationPanel.Name = "locationPanel";
            this.locationPanel.Size = new System.Drawing.Size(240, 240);
            // 
            // timePanel
            // 
            this.timePanel.Controls.Add(this.curDateTime);
            this.timePanel.Controls.Add(this.dateTimeLabel);
            this.timePanel.Controls.Add(this.syncButton);
            this.timePanel.Location = new System.Drawing.Point(256, 76);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(240, 240);
            // 
            // iconPanel
            // 
            this.iconPanel.Controls.Add(this.iconListView);
            this.iconPanel.Location = new System.Drawing.Point(0, 328);
            this.iconPanel.Name = "iconPanel";
            this.iconPanel.Size = new System.Drawing.Size(240, 224);
            // 
            // iconListView
            // 
            this.iconListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            listViewItem1.ImageIndex = 0;
            listViewItem1.Text = "Baggage";
            listViewItem2.ImageIndex = 7;
            listViewItem2.Text = "Flights";
            listViewItem3.ImageIndex = 4;
            listViewItem3.Text = "Time";
            listViewItem4.ImageIndex = 2;
            listViewItem4.Text = "Admin";
            listViewItem5.ImageIndex = 8;
            listViewItem5.Text = "Missing Bags";
            listViewItem6.ImageIndex = 3;
            listViewItem6.Text = "Location";
            listViewItem7.ImageIndex = 6;
            listViewItem7.Text = "Logout";
            listViewItem8.ImageIndex = 5;
            listViewItem8.Text = "Reboot";
            listViewItem9.ImageIndex = 1;
            listViewItem9.Text = "About";
            this.iconListView.Items.Add(listViewItem1);
            this.iconListView.Items.Add(listViewItem2);
            this.iconListView.Items.Add(listViewItem3);
            this.iconListView.Items.Add(listViewItem4);
            this.iconListView.Items.Add(listViewItem5);
            this.iconListView.Items.Add(listViewItem6);
            this.iconListView.Items.Add(listViewItem7);
            this.iconListView.Items.Add(listViewItem8);
            this.iconListView.Items.Add(listViewItem9);
            this.iconListView.LargeImageList = this.iconList;
            this.iconListView.Location = new System.Drawing.Point(-1, -1);
            this.iconListView.Name = "iconListView";
            this.iconListView.Size = new System.Drawing.Size(242, 226);
            this.iconListView.TabIndex = 0;
            this.iconListView.ItemActivate += new System.EventHandler(this.iconListView_ItemActivate);
            // 
            // iconList
            // 
            this.iconList.ImageSize = new System.Drawing.Size(36, 36);
            this.iconList.Images.Clear();
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource7"))));
            this.iconList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource8"))));
            // 
            // TagTrakCarrier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(509, 561);
            this.ControlBox = false;
            this.Controls.Add(this.locationPanel);
            this.Controls.Add(this.iconPanel);
            this.Controls.Add(this.timePanel);
            this.Controls.Add(this.logo);
            this.Name = "TagTrakCarrier";
            this.Text = "Location";
            this.locationPanel.ResumeLayout(false);
            this.timePanel.ResumeLayout(false);
            this.iconPanel.ResumeLayout(false);
            this.ResumeLayout(false);

		} 

		#endregion

		private ConfigSetting config; 

		private void TagTrakCarrier_Load(object sender, System.EventArgs e) 
		{
            Timer1.Enabled = true;

			Cursor.Current = Cursors.WaitCursor; 

			System.Drawing.Image img = TagTrak.Resources.Logo(config.Carrier);
			if (img != null)
			{
				logo.Image = img; 
			}

			Cursor.Current = Cursors.Default; 

			showLocation();
		} 

		private void Timer1_Tick(object sender, System.EventArgs e) 
		{ 
			DeviceUI.HideStartButton(false); 
			this.curDateTime.Text = DateTime.Now.ToString(); 
		} 

		private void ExitMenuItem_Click(object sender, System.EventArgs e) 
		{ 
			AdminLoginForm.Instance.Show(); 
		} 

		private void TagTrakCarrier_LostFocus(object sender, System.EventArgs e) 
		{ 
			DeviceUI.HideStartButton(false); 
		} 

		private void config_CarrierChanged() 
		{
			updateFromConfig();
		} 

		private void updateFromConfig()
		{
			System.Drawing.Image img = TagTrak.Resources.Logo(config.Carrier);
			if (img != null)
			{
				logo.Image = img; 
			}

			this.cbxLocation.DataSource = config.CityList;

			if (config.Location != null && this.cbxLocation.Items.Contains(config.Location)) 
			{
				this.cbxLocation.SelectedItem = config.Location;
			}
		}

		private void syncButton_Click(object sender, System.EventArgs e) 
		{ 
			Cursor.Current = Cursors.WaitCursor; 
			WebSyncService ws = new WebSyncService(); 
			try 
			{ 
				DateTime gmtTime = ws.GmtTime(); 
				OpenNETCF.Win32.DateTimeEx.SetSystemTime(gmtTime);
				MessageBox.Show("System time set to " + System.DateTime.Now.ToUniversalTime().ToString(), " UTC."); 
			} 
			catch (Exception ex) 
			{ 
				DialogResult res; 
				res = MessageBox.Show(ex.Message + "\r\n" + "Set date and time manually?", "Error sychronizing with server", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1); 
				if (res == DialogResult.Yes) 
				{ 
					OpenNETCF.Diagnostics.Process.Start("clock"); 
				} 
			} 
			Cursor.Current = Cursors.Default;

			this.showIcons();

			if (this.isInitialLoad)
			{
				showBaggage();
				this.isInitialLoad = false;
			}
		} 

		private void cbxLocationChangConfirmed(object sender, System.EventArgs e) 
		{ 
			if (!(this.cbxLocation.SelectedItem == null)) 
			{
                //if (config.Location != null && ((string)(cbxLocation.SelectedItem)) != config.Location)
                //{
                //    // Prompt for password
                //    TagTrakLib.AdminLoginForm passUI = new TagTrakLib.AdminLoginForm();
                //    if (passUI.ShowDialog() != DialogResult.OK || passUI.Action != PasswordType.LOCATION)
                //    {
                //        updateFromConfig();
                //        return;
                //    }
                //}

				config.Location = ((string)(cbxLocation.SelectedItem)); 

				Flights.Update(config.Carrier, config.Location);

				if (this.isInitialLoad)
				{
					showTime();
				} 
				else
				{
					showIcons();
				}
			} 
		} 

		private void config_ProgramExit(object sender, EventArgs e)
		{
			this.Timer1.Enabled = false;
			this.Close();
		}

		private void showPanel(System.Windows.Forms.Panel panel)
		{
			panel.Top = 76;
			panel.Left = 0;
			panel.BringToFront();
		}

		private void iconListView_ItemActivate(object sender, System.EventArgs e)
		{
			string text = iconListView.FocusedItem.Text;

			switch (text)
			{
				case "Baggage":
					showBaggage();
					break;

                case "Missing Bags":
                    showMissingBags();
                    break;

				case "About":
					showAbout();
					break;

				case "Admin":
					showAdmin();
					break;

				case "Location":
					showLocation();
					break;

				case "Flights":
					showFlights();
					break;

				case "Time":
					showTime();
					break;

				case "Reboot":
					warmBoot();
					break;

				case "Logout":
					logout();
					break;
			}

			DeviceUI.HideStartButton(false);
		}

        private void showMissingBags()
        {
            MissingBagsForm mbf = new MissingBagsForm();
            mbf.Show();
        }


		private void showBaggage()
		{
			Baggage.BagScanBaseForm.Instance.Show();
		}

		private void logout()
		{
			isInitialLoad = true;

			config.logout();

			this.showLocation();

			LogInForm frm = new LogInForm();
			frm.Show();
		}

		private void warmBoot()
		{
            Hardware.Device.WarmBoot();
		}

		private void showAbout()
		{
			string aboutMsg = "ASI TagTrak Scanning Program";
			aboutMsg += "\r\n" + "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			aboutMsg += "\r\n" + "Copyright Aviation Software, Inc. 2004-2007";
			MessageBox.Show(aboutMsg, "About TagTrak");

		}

		private void showAdmin()
		{
			AdminLoginForm.Instance.Show();
		}

		private void showLocation()
		{
			showPanel(this.locationPanel);
			this.Text = "Location";
		}

		private void showTime()
		{
			showPanel(this.timePanel);
			this.Text = "Device Time";
		}

		private void showIcons()
		{
			showPanel(this.iconPanel);
			this.Text = "Main Menu";
		}

		private void showFlights()
		{
			FlightsForm frm = new FlightsForm();
			frm.Show();
		}
	}
}