using System; 
using System.IO; 
using System.Windows.Forms;
using System.Threading; 
using TagTrak.TagTrakLib;
using System.Collections;
using System.Data.SqlServerCe; 
using System.Text.RegularExpressions;

namespace TagTrak.Baggage
{
	public class BagScanBaseForm : System.Windows.Forms.Form
	{ 
		internal System.Windows.Forms.Label Label23; 
		internal System.Windows.Forms.Label Label22; 
		internal System.Windows.Forms.Label Label18; 
		internal System.Windows.Forms.Label baggagePieceCountLabel; 
		internal System.Windows.Forms.Label Label43; 
		internal System.Windows.Forms.Label Label36; 
		internal System.Windows.Forms.Label Label38; 
		internal System.Windows.Forms.Label Label41; 
		internal System.Windows.Forms.Label Label42; 
		internal System.Windows.Forms.Label Label44; 
		private static BagScanBaseForm singlet; 
		private int currentCount = 0; 
		private int lastCount = 0; 
		private ConfigSetting config = ConfigSetting.Instance();
		private System.Windows.Forms.StatusBar statusBar1; 
		private Hashtable operations = new Hashtable();

		private ArrayList logs = new ArrayList();
		internal System.Windows.Forms.MenuItem showLogItem;
		private System.Windows.Forms.MenuItem enableLogItem;
		private System.Windows.Forms.MenuItem saveMenuItem;
        private System.Windows.Forms.CheckBox gateChecked;
        internal System.Windows.Forms.Label toFlightLabel;

		private bool activeLog = false;

		public static bool isClose = false;
        private System.Windows.Forms.MenuItem menuItem1;
		public static AutoResetEvent statusObj = new AutoResetEvent(false);
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private ComboBox fromFlight;
        private ComboBox toFlight;

        private Hardware.Scanner.Base _scanner;

		public static BagScanBaseForm Instance 
		{ 
			get 
			{ 
				if (singlet == null) 
				{ 
					singlet = new BagScanBaseForm(); 
				} 
				return singlet; 
			} 
		} 

		private BagScanBaseForm() 
		{ 
			Cursor.Current = Cursors.WaitCursor; 
			InitializeComponent(); 

			this.Activated += new System.EventHandler(this.formActive);
			this.Deactivate += new EventHandler(BagScanBaseForm_Deactivate);
			
			this.operationCode = new ComboBoxEx();
			this.operationCode.Location = new System.Drawing.Point(94, 28);
			this.operationCode.Size = new System.Drawing.Size(146, 30);
			this.Controls.Add(this.operationCode);
			this.operationCode.SelectedIndexChanged += new System.EventHandler(this.baggageOperationComboBox_SelectedIndexChanged);

			this.config.CarrierChanged += new CarrierChangedEventHandler(updateCarrierSpecificUI);
			this.config.LocationChanged += new LocationChangedEventHandler(config_LocationChanged);
			this.config.LoggedOut += new LoggedOutEventHandler(config_LoggedOut);
			ConfigSetting.ProgramExit += new EventHandler(config_ProgramExit);
//			NavigationMainMenu.ItemChanged += new MenuItemChangedEventHandler(navMenu_ItemChanged);
			
			carrier.Text = config.Carrier; 
			//			baggageScanTextBoxCollection = new TextBox[]{flight, tagId, cartId, holdPosition, containerPosition}; 
			this.loadLocationComboBox(); 

			this.loadOperations();

            _scanner = Hardware.Scanner.Base.GetInstance();
            _scanner.Code128 = true;
            if (_scanner.BeepSupported) _scanner.Beep = true;
            if (_scanner.VibrateSupported) _scanner.Vibrate = true;
            if (_scanner.LEDSupported) _scanner.LED = true;
            _scanner.IgnoreDuplicates = false;
            if (_scanner.ContinuousSupported) _scanner.Continuous = true;
            _scanner.VolumePercent = 100;

            _scanner.BarCodeRead += ProcessScanData;

			Cursor.Current = Cursors.Default;

            DeviceUI.HideStartButton(false);

		} 

		public ArrayList Logs
		{
			get
			{
				return this.logs;
			}
		}

		public bool ActiveLog
		{
			get
			{
				return this.activeLog;
			}
		}


		#region Designer generated codes

		protected override void Dispose(bool disposing) 
		{ 
			base.Dispose(disposing); 
		}
        internal System.Windows.Forms.MainMenu MainMenu1; 
		internal System.Windows.Forms.MenuItem Tools; 
		internal System.Windows.Forms.MenuItem Counter; 
		internal System.Windows.Forms.MenuItem CounterReset; 
		internal System.Windows.Forms.MenuItem CounterReload; 
		internal System.Windows.Forms.Label carrier; 
		internal System.Windows.Forms.TextBox containerPosition; 
		internal System.Windows.Forms.TextBox holdPosition; 
		internal TagTrak.TagTrakLib.ComboBoxEx operationCode; 
		internal System.Windows.Forms.TextBox cartId; 
		internal System.Windows.Forms.TextBox tagId; 
		internal System.Windows.Forms.ComboBox loc; 
		internal System.Windows.Forms.ImageList ImageList1; 
		internal System.Windows.Forms.PictureBox logo; 

		[System.Diagnostics.DebuggerStepThrough()] 
		private void InitializeComponent() 
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BagScanBaseForm));
            this.logo = new System.Windows.Forms.PictureBox();
            this.loc = new System.Windows.Forms.ComboBox();
            this.carrier = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.baggagePieceCountLabel = new System.Windows.Forms.Label();
            this.Label43 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.containerPosition = new System.Windows.Forms.TextBox();
            this.holdPosition = new System.Windows.Forms.TextBox();
            this.Label38 = new System.Windows.Forms.Label();
            this.cartId = new System.Windows.Forms.TextBox();
            this.Label41 = new System.Windows.Forms.Label();
            this.Label42 = new System.Windows.Forms.Label();
            this.tagId = new System.Windows.Forms.TextBox();
            this.Label44 = new System.Windows.Forms.Label();
            this.MainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.Tools = new System.Windows.Forms.MenuItem();
            this.enableLogItem = new System.Windows.Forms.MenuItem();
            this.showLogItem = new System.Windows.Forms.MenuItem();
            this.Counter = new System.Windows.Forms.MenuItem();
            this.CounterReset = new System.Windows.Forms.MenuItem();
            this.CounterReload = new System.Windows.Forms.MenuItem();
            this.saveMenuItem = new System.Windows.Forms.MenuItem();
            this.ImageList1 = new System.Windows.Forms.ImageList();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.gateChecked = new System.Windows.Forms.CheckBox();
            this.toFlightLabel = new System.Windows.Forms.Label();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel();
            this.fromFlight = new System.Windows.Forms.ComboBox();
            this.toFlight = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(0, 16);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(90, 30);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // loc
            // 
            this.loc.Enabled = false;
            this.loc.Location = new System.Drawing.Point(160, 72);
            this.loc.Name = "loc";
            this.loc.Size = new System.Drawing.Size(65, 22);
            this.loc.TabIndex = 6;
            // 
            // carrier
            // 
            this.carrier.Location = new System.Drawing.Point(104, 72);
            this.carrier.Name = "carrier";
            this.carrier.Size = new System.Drawing.Size(40, 16);
            this.carrier.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label23
            // 
            this.Label23.Location = new System.Drawing.Point(104, 56);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(40, 16);
            this.Label23.Text = "Carr.";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label22
            // 
            this.Label22.Location = new System.Drawing.Point(160, 56);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(46, 16);
            this.Label22.Text = "Loc";
            // 
            // Label18
            // 
            this.Label18.Location = new System.Drawing.Point(8, 200);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(72, 16);
            this.Label18.Text = "Piece Count";
            this.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // baggagePieceCountLabel
            // 
            this.baggagePieceCountLabel.BackColor = System.Drawing.Color.White;
            this.baggagePieceCountLabel.Location = new System.Drawing.Point(16, 216);
            this.baggagePieceCountLabel.Name = "baggagePieceCountLabel";
            this.baggagePieceCountLabel.Size = new System.Drawing.Size(64, 16);
            this.baggagePieceCountLabel.Text = "0";
            this.baggagePieceCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label43
            // 
            this.Label43.Location = new System.Drawing.Point(8, 152);
            this.Label43.Name = "Label43";
            this.Label43.Size = new System.Drawing.Size(88, 16);
            this.Label43.Text = "Hold / Position";
            // 
            // Label36
            // 
            this.Label36.Location = new System.Drawing.Point(96, 152);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(112, 16);
            this.Label36.Text = "Container Position";
            // 
            // containerPosition
            // 
            this.containerPosition.Location = new System.Drawing.Point(96, 168);
            this.containerPosition.Name = "containerPosition";
            this.containerPosition.Size = new System.Drawing.Size(56, 21);
            this.containerPosition.TabIndex = 14;
            this.containerPosition.GotFocus += new System.EventHandler(this.textBox_GotFocus);
            // 
            // holdPosition
            // 
            this.holdPosition.Location = new System.Drawing.Point(8, 168);
            this.holdPosition.Name = "holdPosition";
            this.holdPosition.Size = new System.Drawing.Size(56, 21);
            this.holdPosition.TabIndex = 15;
            this.holdPosition.GotFocus += new System.EventHandler(this.textBox_GotFocus);
            // 
            // Label38
            // 
            this.Label38.Location = new System.Drawing.Point(8, 104);
            this.Label38.Name = "Label38";
            this.Label38.Size = new System.Drawing.Size(72, 16);
            this.Label38.Text = "From Flight";
            // 
            // cartId
            // 
            this.cartId.Location = new System.Drawing.Point(160, 120);
            this.cartId.Name = "cartId";
            this.cartId.Size = new System.Drawing.Size(56, 21);
            this.cartId.TabIndex = 18;
            this.cartId.GotFocus += new System.EventHandler(this.textBox_GotFocus);
            // 
            // Label41
            // 
            this.Label41.Location = new System.Drawing.Point(124, 8);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(92, 16);
            this.Label41.Text = "Operation Code";
            this.Label41.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label42
            // 
            this.Label42.Location = new System.Drawing.Point(8, 56);
            this.Label42.Name = "Label42";
            this.Label42.Size = new System.Drawing.Size(47, 16);
            this.Label42.Text = "Tag ID";
            // 
            // tagId
            // 
            this.tagId.Location = new System.Drawing.Point(8, 72);
            this.tagId.Name = "tagId";
            this.tagId.Size = new System.Drawing.Size(79, 21);
            this.tagId.TabIndex = 21;
            this.tagId.GotFocus += new System.EventHandler(this.textBox_GotFocus);
            // 
            // Label44
            // 
            this.Label44.Location = new System.Drawing.Point(160, 104);
            this.Label44.Name = "Label44";
            this.Label44.Size = new System.Drawing.Size(72, 16);
            this.Label44.Text = "A/C Cart ID";
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.Add(this.menuItem1);
            this.MainMenu1.MenuItems.Add(this.Tools);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Start";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // Tools
            // 
            this.Tools.MenuItems.Add(this.enableLogItem);
            this.Tools.MenuItems.Add(this.showLogItem);
            this.Tools.MenuItems.Add(this.Counter);
            this.Tools.MenuItems.Add(this.saveMenuItem);
            this.Tools.Text = "Tools";
            // 
            // enableLogItem
            // 
            this.enableLogItem.Text = "Enable Log";
            this.enableLogItem.Click += new System.EventHandler(this.enableLogItem_Click);
            // 
            // showLogItem
            // 
            this.showLogItem.Enabled = false;
            this.showLogItem.Text = "Show Log";
            this.showLogItem.Click += new System.EventHandler(this.ShowLog_Click);
            // 
            // Counter
            // 
            this.Counter.MenuItems.Add(this.CounterReset);
            this.Counter.MenuItems.Add(this.CounterReload);
            this.Counter.Text = "Counter";
            // 
            // CounterReset
            // 
            this.CounterReset.Text = "Reset";
            this.CounterReset.Click += new System.EventHandler(this.CounterReset_Click);
            // 
            // CounterReload
            // 
            this.CounterReload.Text = "Reload";
            this.CounterReload.Click += new System.EventHandler(this.reloadBaggagePieceCounts);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            this.ImageList1.Images.Clear();
            this.ImageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 246);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(240, 22);
            // 
            // gateChecked
            // 
            this.gateChecked.Enabled = false;
            this.gateChecked.Location = new System.Drawing.Point(113, 212);
            this.gateChecked.Name = "gateChecked";
            this.gateChecked.Size = new System.Drawing.Size(112, 20);
            this.gateChecked.TabIndex = 3;
            this.gateChecked.Text = "Gate Checked";
            this.gateChecked.Click += new System.EventHandler(this.gateChecked_Click);
            // 
            // toFlightLabel
            // 
            this.toFlightLabel.Location = new System.Drawing.Point(96, 104);
            this.toFlightLabel.Name = "toFlightLabel";
            this.toFlightLabel.Size = new System.Drawing.Size(55, 16);
            this.toFlightLabel.Text = "To Flight";
            // 
            // fromFlight
            // 
            this.fromFlight.Location = new System.Drawing.Point(8, 120);
            this.fromFlight.Name = "fromFlight";
            this.fromFlight.Size = new System.Drawing.Size(72, 22);
            this.fromFlight.TabIndex = 23;
            // 
            // toFlight
            // 
            this.toFlight.Location = new System.Drawing.Point(86, 120);
            this.toFlight.Name = "toFlight";
            this.toFlight.Size = new System.Drawing.Size(68, 22);
            this.toFlight.TabIndex = 24;
            // 
            // BagScanBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.toFlight);
            this.Controls.Add(this.fromFlight);
            this.Controls.Add(this.toFlightLabel);
            this.Controls.Add(this.gateChecked);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.loc);
            this.Controls.Add(this.carrier);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.baggagePieceCountLabel);
            this.Controls.Add(this.Label43);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.containerPosition);
            this.Controls.Add(this.holdPosition);
            this.Controls.Add(this.Label38);
            this.Controls.Add(this.cartId);
            this.Controls.Add(this.Label41);
            this.Controls.Add(this.Label42);
            this.Controls.Add(this.tagId);
            this.Controls.Add(this.Label44);
            this.Menu = this.MainMenu1;
            this.Name = "BagScanBaseForm";
            this.Text = "Baggage";
            this.Load += new System.EventHandler(this.BagScanBaseForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.BagScanBaseForm_Closing);
            this.ResumeLayout(false);

		} 

		#endregion

		private void formActive(object sender, EventArgs e) 
		{
			if (operationCode.Text != "") 
			{
                _scanner.Enabled = true;
			} 
			else 
			{
                _scanner.Enabled = false;
			} 
		} 

		public void ProcessScanData(string barcode, Hardware.Scanner.Base.Symbologies symbology) 
		{ 
			tagId.Text = barcode;
            if (Validate())
            {
                this.SaveScanData();
            }
            else
            {
                _scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.BadScan);
            }
		} 

		private void reloadBaggagePieceCounts(object sender, System.EventArgs e) 
		{ 
			this.currentCount = this.lastCount; 
			this.baggagePieceCountLabel.Text = this.currentCount.ToString(); 
		} 

		private void baggageOperationComboBox_SelectedIndexChanged(object sender, System.EventArgs e) 
		{
            DialogResult dr = MessageBox.Show("Changing operation code. Continue?", "Confirm Operation Change",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            this.Hide();
            this.Show();

            if (!dr.Equals(DialogResult.Yes))
            {
                this.operationCode.SelectedIndexChanged -= new System.EventHandler(this.baggageOperationComboBox_SelectedIndexChanged);
                this.operationCode.SelectedIndex = this.operationCode.PreviousSelectedIndex;
                this.operationCode.SelectedIndexChanged += new System.EventHandler(this.baggageOperationComboBox_SelectedIndexChanged);
                return;
            }
            else
            {
                this.operationCode.PreviousSelectedIndex = this.operationCode.SelectedIndex;
            }

			if (operationCode.Text != "") 
			{ 
				resetFields();

                _scanner.Enabled = true;
                BagScan.ActiveOpCode = GetOperationCode();
			} 
			else 
			{
                _scanner.Enabled = false;
                BagScan.ActiveOpCode = null;
			} 
			this.CounterReset_Click(null, null); 
		} 

		private void loadLocationComboBox() 
		{ 
			loc.Items.Clear(); 
			foreach (string city in config.CityList) 
			{ 
				loc.Items.Add(city); 
			} 
			loc.SelectedItem = config.Location;
            this.loadFlightList();
		} 

		private void BagScanBaseForm_Load(object sender, System.EventArgs e) 
		{ 
			this.updateCarrierSpecificUI(); 
			BagScan.SetUpDatabase();
            ThreadPool.QueueUserWorkItem(new WaitCallback(BagScan.Upload), statusObj);
		} 

		private void textBox_GotFocus(object sender, System.EventArgs e) 
		{ 
			if (config.ShowKeyboardOnFocus) 
			{ 
				this.inputPanel1.Enabled = true; 
			} 
		} 

		private BagScan ExportScanData()
		{
			BagScan scan = new BagScan();
			scan.opcode = this.GetOperationCode(); 
			scan.tag = this.tagId.Text; 
			scan.carrier = this.carrier.Text; 
			scan.location = this.loc.Text; 
			scan.fromFlight = this.fromFlight.Text; 
			scan.toFlight = this.toFlight.Text; 
			scan.cartid = this.cartId.Text; 
			scan.holdpos = this.holdPosition.Text; 
			scan.containerpos = this.containerPosition.Text; 
			scan.employeeno = config.EmployeeNumber; 
			scan.scantime = System.DateTime.UtcNow; 
			scan.gatechecked = gateChecked.Checked;

			return scan;
		}

		private void SaveScanData() 
		{ 
			BagScan scan = ExportScanData();
            ConfigSetting config = ConfigSetting.Instance();

            try
			{
				scan.Save();
				currentCount += 1; 
				baggagePieceCountLabel.Text = currentCount.ToString();
                
				if (this.activeLog)
				{
					logs.Add(new ScanLog(scan.opcode + "|" + scan.tag));
				}

                // Hot bag
                if (scan.opcode == "U" && BagScan.ActiveFlightNumber.HasValue && HotBags.IsHotBag(config.Carrier, config.Location, BagScan.ActiveFlightNumber.Value, scan.tag))
                {
                    this.BackColor = System.Drawing.Color.Red;
                    _scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Warning);
                    statusBar1.Text = "HOT BAG"; 
                }
                else
                {
                    this.BackColor = System.Drawing.SystemColors.Window;
                    _scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.GoodScan);
                }

                // Save load flight number for missing bags query
                if (scan.opcode == "L")
                {
                    Info.FlightNumber F = new Info.FlightNumber(scan.toFlight);
                    if (F.IsSet() && F.IsValid)
                    {
                        TagTrakLib.MissingBagsForm.DefaultFlightNumber = F.ValueInteger;
                    }
                }

			}
			catch (SqlCeException ex)
			{
				string errs = ""; 
				foreach (SqlCeError err in ex.Errors) 
				{ 
					errs += err.Message; 
				}

                _scanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.BadScan);
				statusBar1.Text = "Warning: " + errs; 
			}
		} 

		private string GetOperationCode() 
		{ 
			string operation = this.operationCode.Text;

			if (this.operations.ContainsKey(operation))
			{
				return (string) this.operations[operation]; 
			}
			else
			{
				return null;
			}
		} 

		private bool Validate() 
		{ 
			string opCode = this.GetOperationCode();

			if (opCode == null) 
			{ 
				MessageBox.Show("Missing Operation", "Missing Operation");
                this.Hide();
                this.Show();

				return false; 
			} 

			if (fromFlight.Text != ""
				|| opCode == "D"
				|| opCode == "F"
				|| opCode == "T"
				|| opCode == "U"
				|| opCode == "O"
				)
			{
				if (!(Utilities.isValidFlightNumber(fromFlight.Text))) 
				{ 
					MessageBox.Show("Missing or Invalid From Flight Number", "Invalid From Flight Number");
                    this.Hide();
                    this.Show();

					return false; 
				}
			}

			if (toFlight.Text != ""
				|| opCode == "L"
				|| opCode == "F"
				|| opCode == "T"
				|| opCode == "X"
				)
			{
				if (!(Utilities.isValidFlightNumber(toFlight.Text))) 
				{ 
					MessageBox.Show("Missing or Invalid To Flight Number", "Invalid To Flight Number");
                    this.Hide();
                    this.Show();

					return false; 
				}
			}
 
			if (!(Utilities.isValidLocation(loc.Text))) 
			{ 
				MessageBox.Show("Missing or Invalid Location", "Invalid Location");
                this.Hide();
                this.Show();

				return false; 
			} 

			if (opCode == "L" || opCode == "T")
			{
				if (!((cartId.Text != "" && containerPosition.Text != "") || holdPosition.Text != ""))
				{
					MessageBox.Show("Either hold position, or cart ID and container position are needed for this operation");
                    this.Hide();
                    this.Show();

					return false;
				}
			}

			if (carrier.Text.Length != 2) 
			{ 
				MessageBox.Show("A Valid Carrier Code Is Required For This Operation", "Invalid Carrier Code");
                this.Hide();
                this.Show();

				return false; 
			} 
			if (tagId.Text.Length != 10) 
			{ 
				MessageBox.Show("Missing or invalid transaction tag id.", "Missing Transaction Tag ID");
                this.Hide();
                this.Show();

				return false; 
			} 
			if (cartId.Text != "" && !(Utilities.isValidACBinID(cartId.Text))) 
			{ 
				MessageBox.Show("Invalid A/C Cart ID", "Invalid A/C Cart ID");
                this.Hide();
                this.Show();

				return false; 
			} 
			if (containerPosition.Text != "" && !(Regex.IsMatch(containerPosition.Text, "^[0-9a-zA-Z]{1,10}$"))) 
			{ 
				MessageBox.Show("Invalid Container", "Invalid Container");
                this.Hide();
                this.Show();

				return false; 
			} 
			if (holdPosition.Text != "" && !(Regex.IsMatch(holdPosition.Text, "^[0-9a-zA-Z]{1,6}$"))) 
			{ 
				MessageBox.Show("Invalid hold position", "Invalid Hold Position");
                this.Hide();
                this.Show();

				return false; 
			} 
			return true; 
		} 

		private void CounterReset_Click(object sender, System.EventArgs e) 
		{ 
			this.lastCount = this.currentCount; 
			this.currentCount = 0; 
			this.baggagePieceCountLabel.Text = currentCount.ToString(); 
		} 

		public void updateStatusUpdate(object sender, System.EventArgs e) 
		{ 
			this.statusBar1.Text = BagScan.uploadStatus;
		} 

		private void updateCarrierSpecificUI() 
		{ 
			System.Drawing.Image img = TagTrak.Resources.Logo(config.Carrier);
			if (img != null)
			{
				logo.Image = img; 
			}
			carrier.Text = config.Carrier; 
			loadLocationComboBox(); 
		} 

		private void config_LocationChanged() 
		{ 
			this.loc.SelectedItem = config.Location;
            this.loadFlightList();
		} 

//		private void navMenu_ItemChanged() 
//		{ 
//			this.MainMenu1.MenuItems.Clear(); 
//			this.MainMenu1.MenuItems.Add(new NavigationMainMenu()); 
//			this.MainMenu1.MenuItems.Add(this.Tools); 
//		}
//
		private void config_ProgramExit(object sender, EventArgs e)
		{
			isClose = true;
			statusObj.WaitOne();			
			this.Close();
		}

		private void loadOperations()
		{
			// also use arraylist to keep order
			ArrayList opList = new ArrayList();

			opList.Add("From TSA");
			opList.Add("Load");
			opList.Add("Offload");
			opList.Add("Transfer Online");
			opList.Add("Transfer to OAL");
			opList.Add("Transfer from OAL");
			opList.Add("Unload");
			opList.Add("Delivery");
			opList.Add("Baggage Office Repossession");

			// initialize hashtable first
			int i = 0;
			this.operations.Clear();
			this.operations.Add(opList[i++], "C");
			this.operations.Add(opList[i++], "L");
			this.operations.Add(opList[i++], "O");
			this.operations.Add(opList[i++], "T");
			this.operations.Add(opList[i++], "X");
			this.operations.Add(opList[i++], "F");
			this.operations.Add(opList[i++], "U");
			this.operations.Add(opList[i++], "D");
			this.operations.Add(opList[i++], "R");			

			// load combobox
			this.operationCode.Items.Clear();
			this.operationCode.Items.Add("");
			foreach (string s in opList)
			{
				this.operationCode.Items.Add(s);
			}
		}

		private void resetFields()
		{
            this.BackColor = System.Drawing.SystemColors.Window;

			this.tagId.Text = "";
			this.cartId.Text = "";
			this.containerPosition.Text = "";
			this.holdPosition.Text = "";
			this.gateChecked.Checked = false;
			this.fromFlight.Text = "";
			this.toFlight.Text = "";
			this.baggagePieceCountLabel.Text = "0";
			this.inputPanel1.Enabled = false;

			if (this.GetOperationCode() == "R")
			{
				this.cartId.Enabled = false;
				this.holdPosition.Enabled = false;
				this.containerPosition.Enabled = false;
				this.gateChecked.Enabled = false;
			} 
			else 
			{
				this.cartId.Enabled = true;
				this.holdPosition.Enabled = true;
				this.containerPosition.Enabled = true;
				if (this.GetOperationCode() == "L")
				{
					this.gateChecked.Enabled = true;
				}
				else
				{
					this.gateChecked.Enabled = false;
				}
			}
		}

		private void ShowLog_Click(object sender, System.EventArgs e)
		{
			LogViewer.Display(logs, "Baggage Scan Log");
		}

		private void enableLogItem_Click(object sender, System.EventArgs e)
		{
			this.activeLog = !this.activeLog;
			((MenuItem) sender).Checked = this.activeLog;
			this.showLogItem.Enabled = this.activeLog;
		}

		private void saveMenuItem_Click(object sender, System.EventArgs e)
		{
			if (Validate()) 
			{ 
				SaveScanData();	
			} 
		}

		private void gateChecked_Click(object sender, System.EventArgs e)
		{
			if (this.gateChecked.Checked) 
			{
				DialogResult res = MessageBox.Show("I assert that I have inspected the bags I will scan from now on " +
					"until I uncheck \"Gate Checked\" again.", 
					"Confirm Gate Checked", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, 
					MessageBoxDefaultButton.Button1);
                this.Hide();
                this.Show();

				if (res != DialogResult.Yes)
				{
					this.gateChecked.Checked = false;
				}
			}
			else
			{
				MessageBox.Show("End of Scanning Gate Checked Baggages.", "End Gate Checked");
                this.Hide();
                this.Show();
			}
		}


		private void appendCarrierToFlight(TextBox flight)
		{
            Info.FlightNumber F = new Info.FlightNumber(flight.Text);

            if (F.IsSet() && F.IsValid)
            {
                if (F.Carrier.IsNotSet() || !F.Carrier.IsValid)
                {
                    // Flight number has no carrier, user carrier field
                    Info.Carrier C = new Info.Carrier(carrier.Text);
                    if (C.IsSet() && C.IsValid)
                    {
                        flight.Text = C.Value + F.Value;
                    }
                    else
                    {
                        // No entered carrier, use default
                        flight.Text = config.Carrier + F.Value;
                    }
                }
                else
                {
                    // Flight number already has a valid carrier, normalize it
                    flight.Text = F.Carrier.Value + F.Value;
                }
            }
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void config_LoggedOut()
		{
			this.operationCode.SelectedIndexChanged -= new System.EventHandler(this.baggageOperationComboBox_SelectedIndexChanged);
			this.operationCode.SelectedIndex = 0;
			this.operationCode.SelectedIndexChanged += new System.EventHandler(this.baggageOperationComboBox_SelectedIndexChanged);		

			this.resetFields();
		}

		private void BagScanBaseForm_Deactivate(object sender, EventArgs e)
		{
            _scanner.Enabled = false;
			this.inputPanel1.Enabled = false;
        }

        private void BagScanBaseForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _scanner.Dispose();
            _scanner = null;
        }

        private void fromFlight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Info.FlightNumber N = new Info.FlightNumber(fromFlight.Text);

                if (N.IsSet() && N.IsValid)
                {
                    BagScan.ActiveFlightNumber = N.ValueInteger;
                }
            }
            catch
            {
                BagScan.ActiveFlightNumber = null;
            }
        }

        private void loadFlightList()
        {
            System.Data.DataTable flightDt = Flights.GetCurrentFlights(config.Carrier, config.Location);

            ArrayList toFlightList = new ArrayList(flightDt.Rows.Count);
            ArrayList fromFlightList = new ArrayList(flightDt.Rows.Count);

            toFlightList.Add("");
            fromFlightList.Add("");

            foreach (System.Data.DataRow row in flightDt.Rows)
            {
                if (row["origin"].ToString() == config.Location)
                {
                    toFlightList.Add(row["full_flight_number"]);
                }
                else
                {
                    fromFlightList.Add(row["full_flight_number"]);
                }
            }

            this.toFlight.DataSource = toFlightList;            
            this.fromFlight.DataSource = fromFlightList;
        }
	}
}