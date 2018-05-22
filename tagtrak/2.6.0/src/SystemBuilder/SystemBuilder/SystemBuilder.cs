using System;
using System.IO ;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace sb
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 	
	public class SystemBuilder : System.Windows.Forms.Form
	{
		[DllImport("Temp5.dll")] static extern int xx(int y) ;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem saveProfileMenuItem;
		private System.Windows.Forms.MenuItem saveProfileAsMenuItem;
		private System.Windows.Forms.MenuItem openProfileMenuItem;
		private System.Windows.Forms.MenuItem buildUpdateMenuItem;
		private System.Windows.Forms.MenuItem exitMenuItem;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem buildDistributionMenuItem;

		public SystemProfile systemProfile ;

		public ProfileHistoryClass profileHistory ;

		private BuildUpdateOutputForm buildOutputForm ;
		private System.Windows.Forms.MenuItem menuItem2;

		private System.Windows.Forms.MenuItem optionsMenuItem;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.TextBox otherDeviceTextBox;
		public System.Windows.Forms.RadioButton otherRadioButton;
		public System.Windows.Forms.RadioButton pcRadioButton;
		public System.Windows.Forms.RadioButton viewsonicRadioButton;
		public System.Windows.Forms.RadioButton symbolRadioButton;
		public System.Windows.Forms.RadioButton intermecRadioButton;
		private System.Windows.Forms.GroupBox groupBox3;
		public System.Windows.Forms.TextBox otherProcessorTextBox;
		public System.Windows.Forms.RadioButton otherProcessorRadioButton;
		public System.Windows.Forms.RadioButton armV4RadioButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button addConfigurationButton;
		public System.Windows.Forms.ComboBox configurationComboBox;
		private System.Windows.Forms.GroupBox tagTrakBaseProjectSpec;
		private System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox baseProjectSourceDirectoryTextBox;
		private System.Windows.Forms.Button baseProjectSourceFileBrowseButton;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox releaseTextBox;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox applicationNameTextBox;
		public System.Windows.Forms.CheckBox baseProjectForceRebuildCheckBox;
		private System.Windows.Forms.Button browseBaseProjectExeFileButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox baseProjectExeFileTextBox;
		public System.Windows.Forms.TextBox baseProjectDefinitionFileTextBox;
		private System.Windows.Forms.Button tagTrakSourceBrowseButton;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox airlineSoftwareLibTextBox;
		public System.Windows.Forms.CheckBox librariesForceRebuildCheckBox;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox updateOutputFileTextBox;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.TextBox distributionOutputFileTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buildUpdateButton;
		private System.Windows.Forms.Button buildDistButton;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.TextBox airlinesoftwareProj;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button button5;
		public System.Windows.Forms.TextBox migrateOutputFileTextbox;
		private System.Windows.Forms.Button buildMigrateButton;
		private System.Windows.Forms.MenuItem buildMigrateMenusItem;
		private System.Windows.Forms.Label label11;
		public System.Windows.Forms.TextBox webUpdateOutputFileTextbox;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.MenuItem buildWebUpdateMenuItem;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.ComboBox OperatingSystem;
		private System.Windows.Forms.Label label13;
		public System.Windows.Forms.CheckBox Wireless;
		public System.Windows.Forms.CheckedListBox clbCarriers;
		public System.Windows.Forms.RadioButton btnDolphin;
		public System.Windows.Forms.MenuItem recentProfilesMenuItem;


		// public static Globals globals ;

		public SystemBuilder(String inputFilePath)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			if ( ! Globals.SetupBaseDirectoryDefinitions() ) { this.Close() ; return ; }

			Utilities.ClearDirectory(Globals.workingFilesDirectory) ;

//			airlineSoftwareLibTextBox.Text = "C:\\Airline Software\\Projects\\TagTrak\\TagTrak Support Libraries\\Airline Software Lib\\AirlineSoftware.vcw" ;

			systemProfile = new SystemProfile(this) ;

			profileHistory = new ProfileHistoryClass(this) ;

			this.otherDeviceTextBox.Enabled = false ;
			this.intermecRadioButton.Checked = true ;

			//
			// Create registry sub-key if it does not exist.
			//

			RegistryKey tagTrakKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\TagTrak\Options") ;
			
//			RegistryPermission regPerm;
//
//			regPerm = new RegistryPermission(RegistryPermissionAccess.AllAccess, @"HKEY_CURRENT_USER\SOFTWARE\TagTrak");
//			regPerm.AddPathList(RegistryPermissionAccess.AllAccess, @"HKEY_CURRENT_USER\SOFTWARE\TagTrak");
//			
//			regPerm = new RegistryPermission(RegistryPermissionAccess.AllAccess, @"HKEY_CURRENT_USER\SOFTWARE\TagTrak\Options");
//			regPerm.AddPathList(RegistryPermissionAccess.AllAccess, @"HKEY_CURRENT_USER\SOFTWARE\TagTrak\Options");

			object optionValue = tagTrakKey.GetValue("LoadLastProfileOnStartup") ;
			if ( optionValue == null )
			{
				tagTrakKey.SetValue("LoadLastProfileOnStartup", true) ;

//				regPerm = new RegistryPermission(RegistryPermissionAccess.AllAccess, @"HKEY_CURRENT_USER\SOFTWARE\TagTrak\Options\LoadLastProfileOnStartup");
//				regPerm.AddPathList(RegistryPermissionAccess.AllAccess, @"HKEY_CURRENT_USER\SOFTWARE\TagTrak\Options\LoadLastProfileOnStartup");

			}
			
//			string loadLastProfile = (string) tagTrakKey.GetValue("LoadLastProfileOnStartup", false) ;
//			
//			if ( loadLastProfile == "True" )
//			{
//				string inputFilePath = profileHistory.GetLastProfilePath() ;

				if ( Utilities.isNonNullString( inputFilePath ) )
				{
					try
					{
						systemProfile.loadProfile(inputFilePath) ;
					}

					catch (Exception ex)
					{
						MessageBox.Show("Unable to load initial profile file '" + inputFilePath + "' : " + ex.Message) ;
						return ;
					}
				}
//			}

			tagTrakKey.Close();

			Globals.baseDirectory  = Directory.GetCurrentDirectory() ;

			if ( Globals.baseDirectory.EndsWith(@"\bin\Debug") )
			{
				Globals.baseDirectory  = Globals.baseDirectory.Substring(0, Globals.baseDirectory.LastIndexOf(@"\bin\Debug")) ;
			}

			else if ( Globals.baseDirectory.EndsWith(@"\bin\Release") )
			{
				Globals.baseDirectory  = Globals.baseDirectory.Substring(0, Globals.baseDirectory.LastIndexOf(@"\bin\Release")) ;
			}

//			distributionOutputFileTextBox.Text = Globals.baseDirectory  + "\\Output\\" + systemProfile.user + systemProfile.deviceType + "Distribution.cab" ;
//			updateOutputFileTextBox.Text = Globals.baseDirectory  + "\\Output\\" + systemProfile.user + systemProfile.deviceType + "Update.cab" ;

			this.configurationComboBox.Items.Clear() ;
			this.configurationComboBox.Items.Add("") ;
			this.configurationComboBox.Items.Add("Debug") ;
			this.configurationComboBox.Items.Add("Release") ;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.openProfileMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.saveProfileMenuItem = new System.Windows.Forms.MenuItem();
			this.saveProfileAsMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.recentProfilesMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.exitMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.buildUpdateMenuItem = new System.Windows.Forms.MenuItem();
			this.buildDistributionMenuItem = new System.Windows.Forms.MenuItem();
			this.buildMigrateMenusItem = new System.Windows.Forms.MenuItem();
			this.buildWebUpdateMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.optionsMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.clbCarriers = new System.Windows.Forms.CheckedListBox();
			this.Wireless = new System.Windows.Forms.CheckBox();
			this.label13 = new System.Windows.Forms.Label();
			this.OperatingSystem = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.otherProcessorTextBox = new System.Windows.Forms.TextBox();
			this.otherProcessorRadioButton = new System.Windows.Forms.RadioButton();
			this.armV4RadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnDolphin = new System.Windows.Forms.RadioButton();
			this.otherDeviceTextBox = new System.Windows.Forms.TextBox();
			this.otherRadioButton = new System.Windows.Forms.RadioButton();
			this.pcRadioButton = new System.Windows.Forms.RadioButton();
			this.viewsonicRadioButton = new System.Windows.Forms.RadioButton();
			this.symbolRadioButton = new System.Windows.Forms.RadioButton();
			this.intermecRadioButton = new System.Windows.Forms.RadioButton();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tagTrakBaseProjectSpec = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.baseProjectSourceDirectoryTextBox = new System.Windows.Forms.TextBox();
			this.baseProjectSourceFileBrowseButton = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.releaseTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.applicationNameTextBox = new System.Windows.Forms.TextBox();
			this.baseProjectForceRebuildCheckBox = new System.Windows.Forms.CheckBox();
			this.browseBaseProjectExeFileButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.baseProjectExeFileTextBox = new System.Windows.Forms.TextBox();
			this.baseProjectDefinitionFileTextBox = new System.Windows.Forms.TextBox();
			this.tagTrakSourceBrowseButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.addConfigurationButton = new System.Windows.Forms.Button();
			this.configurationComboBox = new System.Windows.Forms.ComboBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.librariesForceRebuildCheckBox = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.airlineSoftwareLibTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.airlinesoftwareProj = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.label11 = new System.Windows.Forms.Label();
			this.webUpdateOutputFileTextbox = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.migrateOutputFileTextbox = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.updateOutputFileTextBox = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.distributionOutputFileTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.buildUpdateButton = new System.Windows.Forms.Button();
			this.buildDistButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.buildMigrateButton = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tagTrakBaseProjectSpec.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem5});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.openProfileMenuItem,
																					  this.menuItem4,
																					  this.saveProfileMenuItem,
																					  this.saveProfileAsMenuItem,
																					  this.menuItem3,
																					  this.recentProfilesMenuItem,
																					  this.menuItem8,
																					  this.exitMenuItem});
			this.menuItem1.Text = "File";
			// 
			// openProfileMenuItem
			// 
			this.openProfileMenuItem.Index = 0;
			this.openProfileMenuItem.Text = "Open Profile";
			this.openProfileMenuItem.Click += new System.EventHandler(this.openProfileMenuItem_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "-";
			// 
			// saveProfileMenuItem
			// 
			this.saveProfileMenuItem.Index = 2;
			this.saveProfileMenuItem.Text = "Save Profile";
			this.saveProfileMenuItem.Click += new System.EventHandler(this.saveProfileMenuItem_Click);
			// 
			// saveProfileAsMenuItem
			// 
			this.saveProfileAsMenuItem.Index = 3;
			this.saveProfileAsMenuItem.Text = "Save Profile As ...";
			this.saveProfileAsMenuItem.Click += new System.EventHandler(this.saveProfileAsMenuItem_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 4;
			this.menuItem3.Text = "-";
			// 
			// recentProfilesMenuItem
			// 
			this.recentProfilesMenuItem.Index = 5;
			this.recentProfilesMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								   this.menuItem9});
			this.recentProfilesMenuItem.Text = "Recent Profiles";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "Profile00";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 6;
			this.menuItem8.Text = "-";
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Index = 7;
			this.exitMenuItem.Text = "Exit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.buildUpdateMenuItem,
																					  this.buildDistributionMenuItem,
																					  this.buildMigrateMenusItem,
																					  this.buildWebUpdateMenuItem,
																					  this.menuItem2,
																					  this.optionsMenuItem});
			this.menuItem5.Text = "Tools";
			// 
			// buildUpdateMenuItem
			// 
			this.buildUpdateMenuItem.Index = 0;
			this.buildUpdateMenuItem.Text = "Build Update";
			this.buildUpdateMenuItem.Click += new System.EventHandler(this.buildUpdateMenuItem_Click);
			// 
			// buildDistributionMenuItem
			// 
			this.buildDistributionMenuItem.Index = 1;
			this.buildDistributionMenuItem.Text = "Build Distribution";
			this.buildDistributionMenuItem.Click += new System.EventHandler(this.buildDistributionMenuItem_Click);
			// 
			// buildMigrateMenusItem
			// 
			this.buildMigrateMenusItem.Index = 2;
			this.buildMigrateMenusItem.Text = "Build Migrate";
			this.buildMigrateMenusItem.Click += new System.EventHandler(this.buildMigrateMenusItem_Click);
			// 
			// buildWebUpdateMenuItem
			// 
			this.buildWebUpdateMenuItem.Index = 3;
			this.buildWebUpdateMenuItem.Text = "Build Web Update";
			this.buildWebUpdateMenuItem.Click += new System.EventHandler(this.buildWebUpdateMenuItem_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 4;
			this.menuItem2.Text = "-";
			// 
			// optionsMenuItem
			// 
			this.optionsMenuItem.Index = 5;
			this.optionsMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							this.menuItem6});
			this.optionsMenuItem.Text = "Options";
			this.optionsMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 0;
			this.menuItem6.RadioCheck = true;
			this.menuItem6.Text = "Load last profile on start up";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Location = new System.Drawing.Point(13, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(541, 408);
			this.tabControl1.TabIndex = 8;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.clbCarriers);
			this.tabPage1.Controls.Add(this.Wireless);
			this.tabPage1.Controls.Add(this.label13);
			this.tabPage1.Controls.Add(this.OperatingSystem);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(533, 382);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			// 
			// clbCarriers
			// 
			this.clbCarriers.CheckOnClick = true;
			this.clbCarriers.Items.AddRange(new object[] {
															 "60",
															 "7O",
															 "99",
															 "AA",
															 "AC",
															 "AI",
															 "AM",
															 "AS",
															 "AY",
															 "AZ",
															 "B6",
															 "BD",
															 "BW",
															 "CA",
															 "CO",
															 "CV",
															 "CX",
															 "CZ",
															 "DJ",
															 "DL",
															 "EI",
															 "EK",
															 "FI",
															 "FL",
															 "GF",
															 "JL",
															 "JW",
															 "KE",
															 "KQ",
															 "KU",
															 "KX",
															 "LE",
															 "LH",
															 "LO",
															 "LX",
															 "LY",
															 "MA",
															 "NH",
															 "NK",
															 "NZ",
															 "OK",
															 "OS",
															 "OZ",
															 "PI",
															 "PR",
															 "QR",
															 "RG",
															 "SA",
															 "SK",
															 "SQ",
															 "SY",
															 "TG",
															 "TP",
															 "TZ",
															 "UA",
															 "US"});
			this.clbCarriers.Location = new System.Drawing.Point(32, 64);
			this.clbCarriers.Name = "clbCarriers";
			this.clbCarriers.Size = new System.Drawing.Size(80, 214);
			this.clbCarriers.Sorted = true;
			this.clbCarriers.TabIndex = 33;
			// 
			// Wireless
			// 
			this.Wireless.Location = new System.Drawing.Point(368, 328);
			this.Wireless.Name = "Wireless";
			this.Wireless.TabIndex = 32;
			this.Wireless.Text = "Wireless";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(80, 328);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(96, 23);
			this.label13.TabIndex = 31;
			this.label13.Text = "Operating System";
			// 
			// OperatingSystem
			// 
			this.OperatingSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.OperatingSystem.Items.AddRange(new object[] {
																 "Pocket PC 2002",
																 "Pocket PC 2003"});
			this.OperatingSystem.Location = new System.Drawing.Point(184, 328);
			this.OperatingSystem.Name = "OperatingSystem";
			this.OperatingSystem.Size = new System.Drawing.Size(121, 21);
			this.OperatingSystem.TabIndex = 30;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(48, 40);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 29;
			this.label12.Text = "Carriers";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.otherProcessorTextBox);
			this.groupBox3.Controls.Add(this.otherProcessorRadioButton);
			this.groupBox3.Controls.Add(this.armV4RadioButton);
			this.groupBox3.Location = new System.Drawing.Point(152, 192);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(360, 107);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Processor Type";
			// 
			// otherProcessorTextBox
			// 
			this.otherProcessorTextBox.Location = new System.Drawing.Point(112, 65);
			this.otherProcessorTextBox.Name = "otherProcessorTextBox";
			this.otherProcessorTextBox.Size = new System.Drawing.Size(90, 20);
			this.otherProcessorTextBox.TabIndex = 5;
			this.otherProcessorTextBox.Text = "";
			// 
			// otherProcessorRadioButton
			// 
			this.otherProcessorRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.otherProcessorRadioButton.Location = new System.Drawing.Point(22, 61);
			this.otherProcessorRadioButton.Name = "otherProcessorRadioButton";
			this.otherProcessorRadioButton.Size = new System.Drawing.Size(78, 21);
			this.otherProcessorRadioButton.TabIndex = 4;
			this.otherProcessorRadioButton.Text = "Other";
			this.otherProcessorRadioButton.CheckedChanged += new System.EventHandler(this.otherProcessorRadioButton_CheckedChanged);
			// 
			// armV4RadioButton
			// 
			this.armV4RadioButton.Checked = true;
			this.armV4RadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.armV4RadioButton.Location = new System.Drawing.Point(22, 25);
			this.armV4RadioButton.Name = "armV4RadioButton";
			this.armV4RadioButton.Size = new System.Drawing.Size(78, 21);
			this.armV4RadioButton.TabIndex = 0;
			this.armV4RadioButton.TabStop = true;
			this.armV4RadioButton.Text = "ARMV4";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnDolphin);
			this.groupBox2.Controls.Add(this.otherDeviceTextBox);
			this.groupBox2.Controls.Add(this.otherRadioButton);
			this.groupBox2.Controls.Add(this.pcRadioButton);
			this.groupBox2.Controls.Add(this.viewsonicRadioButton);
			this.groupBox2.Controls.Add(this.symbolRadioButton);
			this.groupBox2.Controls.Add(this.intermecRadioButton);
			this.groupBox2.Location = new System.Drawing.Point(152, 40);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(360, 136);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Device Type";
			// 
			// btnDolphin
			// 
			this.btnDolphin.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDolphin.Location = new System.Drawing.Point(24, 104);
			this.btnDolphin.Name = "btnDolphin";
			this.btnDolphin.Size = new System.Drawing.Size(78, 21);
			this.btnDolphin.TabIndex = 6;
			this.btnDolphin.Text = "Dolphin";
			// 
			// otherDeviceTextBox
			// 
			this.otherDeviceTextBox.Location = new System.Drawing.Point(256, 62);
			this.otherDeviceTextBox.Name = "otherDeviceTextBox";
			this.otherDeviceTextBox.Size = new System.Drawing.Size(90, 20);
			this.otherDeviceTextBox.TabIndex = 5;
			this.otherDeviceTextBox.Text = "";
			// 
			// otherRadioButton
			// 
			this.otherRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.otherRadioButton.Location = new System.Drawing.Point(136, 62);
			this.otherRadioButton.Name = "otherRadioButton";
			this.otherRadioButton.Size = new System.Drawing.Size(78, 21);
			this.otherRadioButton.TabIndex = 4;
			this.otherRadioButton.Text = "Other";
			this.otherRadioButton.CheckedChanged += new System.EventHandler(this.otherRadioButton_CheckedChanged_1);
			// 
			// pcRadioButton
			// 
			this.pcRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.pcRadioButton.Location = new System.Drawing.Point(256, 27);
			this.pcRadioButton.Name = "pcRadioButton";
			this.pcRadioButton.Size = new System.Drawing.Size(78, 21);
			this.pcRadioButton.TabIndex = 3;
			this.pcRadioButton.Text = "PC";
			// 
			// viewsonicRadioButton
			// 
			this.viewsonicRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.viewsonicRadioButton.Location = new System.Drawing.Point(136, 27);
			this.viewsonicRadioButton.Name = "viewsonicRadioButton";
			this.viewsonicRadioButton.Size = new System.Drawing.Size(78, 21);
			this.viewsonicRadioButton.TabIndex = 2;
			this.viewsonicRadioButton.Text = "ViewSonic";
			// 
			// symbolRadioButton
			// 
			this.symbolRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.symbolRadioButton.Location = new System.Drawing.Point(22, 62);
			this.symbolRadioButton.Name = "symbolRadioButton";
			this.symbolRadioButton.Size = new System.Drawing.Size(78, 21);
			this.symbolRadioButton.TabIndex = 1;
			this.symbolRadioButton.Text = "Symbol";
			// 
			// intermecRadioButton
			// 
			this.intermecRadioButton.Checked = true;
			this.intermecRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.intermecRadioButton.Location = new System.Drawing.Point(22, 27);
			this.intermecRadioButton.Name = "intermecRadioButton";
			this.intermecRadioButton.Size = new System.Drawing.Size(78, 21);
			this.intermecRadioButton.TabIndex = 0;
			this.intermecRadioButton.TabStop = true;
			this.intermecRadioButton.Text = "Intermec";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.tagTrakBaseProjectSpec);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(533, 382);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Base Project";
			// 
			// tagTrakBaseProjectSpec
			// 
			this.tagTrakBaseProjectSpec.Controls.Add(this.label8);
			this.tagTrakBaseProjectSpec.Controls.Add(this.baseProjectSourceDirectoryTextBox);
			this.tagTrakBaseProjectSpec.Controls.Add(this.baseProjectSourceFileBrowseButton);
			this.tagTrakBaseProjectSpec.Controls.Add(this.label7);
			this.tagTrakBaseProjectSpec.Controls.Add(this.releaseTextBox);
			this.tagTrakBaseProjectSpec.Controls.Add(this.label3);
			this.tagTrakBaseProjectSpec.Controls.Add(this.applicationNameTextBox);
			this.tagTrakBaseProjectSpec.Controls.Add(this.baseProjectForceRebuildCheckBox);
			this.tagTrakBaseProjectSpec.Controls.Add(this.browseBaseProjectExeFileButton);
			this.tagTrakBaseProjectSpec.Controls.Add(this.label2);
			this.tagTrakBaseProjectSpec.Controls.Add(this.label1);
			this.tagTrakBaseProjectSpec.Controls.Add(this.baseProjectExeFileTextBox);
			this.tagTrakBaseProjectSpec.Controls.Add(this.baseProjectDefinitionFileTextBox);
			this.tagTrakBaseProjectSpec.Controls.Add(this.tagTrakSourceBrowseButton);
			this.tagTrakBaseProjectSpec.Location = new System.Drawing.Point(24, 104);
			this.tagTrakBaseProjectSpec.Name = "tagTrakBaseProjectSpec";
			this.tagTrakBaseProjectSpec.Size = new System.Drawing.Size(496, 240);
			this.tagTrakBaseProjectSpec.TabIndex = 8;
			this.tagTrakBaseProjectSpec.TabStop = false;
			this.tagTrakBaseProjectSpec.Text = "Tag Trak Base Project Specification";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 71);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(198, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "Base Project Source Files Directory";
			// 
			// baseProjectSourceDirectoryTextBox
			// 
			this.baseProjectSourceDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.baseProjectSourceDirectoryTextBox.Location = new System.Drawing.Point(24, 93);
			this.baseProjectSourceDirectoryTextBox.Name = "baseProjectSourceDirectoryTextBox";
			this.baseProjectSourceDirectoryTextBox.Size = new System.Drawing.Size(352, 20);
			this.baseProjectSourceDirectoryTextBox.TabIndex = 12;
			this.baseProjectSourceDirectoryTextBox.Text = "";
			// 
			// baseProjectSourceFileBrowseButton
			// 
			this.baseProjectSourceFileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.baseProjectSourceFileBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.baseProjectSourceFileBrowseButton.Location = new System.Drawing.Point(384, 92);
			this.baseProjectSourceFileBrowseButton.Name = "baseProjectSourceFileBrowseButton";
			this.baseProjectSourceFileBrowseButton.Size = new System.Drawing.Size(84, 23);
			this.baseProjectSourceFileBrowseButton.TabIndex = 13;
			this.baseProjectSourceFileBrowseButton.Text = "Browse...";
			this.baseProjectSourceFileBrowseButton.Click += new System.EventHandler(this.baseProjectSourceFileBrowseButton_Click_1);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(216, 168);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 16);
			this.label7.TabIndex = 11;
			this.label7.Text = "Release";
			// 
			// releaseTextBox
			// 
			this.releaseTextBox.Location = new System.Drawing.Point(216, 189);
			this.releaseTextBox.Name = "releaseTextBox";
			this.releaseTextBox.Size = new System.Drawing.Size(168, 20);
			this.releaseTextBox.TabIndex = 10;
			this.releaseTextBox.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 9;
			this.label3.Text = "Application Name";
			// 
			// applicationNameTextBox
			// 
			this.applicationNameTextBox.Location = new System.Drawing.Point(24, 189);
			this.applicationNameTextBox.Name = "applicationNameTextBox";
			this.applicationNameTextBox.Size = new System.Drawing.Size(184, 20);
			this.applicationNameTextBox.TabIndex = 8;
			this.applicationNameTextBox.Text = "";
			// 
			// baseProjectForceRebuildCheckBox
			// 
			this.baseProjectForceRebuildCheckBox.Checked = true;
			this.baseProjectForceRebuildCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.baseProjectForceRebuildCheckBox.Location = new System.Drawing.Point(392, 189);
			this.baseProjectForceRebuildCheckBox.Name = "baseProjectForceRebuildCheckBox";
			this.baseProjectForceRebuildCheckBox.Size = new System.Drawing.Size(96, 21);
			this.baseProjectForceRebuildCheckBox.TabIndex = 7;
			this.baseProjectForceRebuildCheckBox.Text = "Force Rebuild";
			// 
			// browseBaseProjectExeFileButton
			// 
			this.browseBaseProjectExeFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseBaseProjectExeFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.browseBaseProjectExeFileButton.Location = new System.Drawing.Point(384, 140);
			this.browseBaseProjectExeFileButton.Name = "browseBaseProjectExeFileButton";
			this.browseBaseProjectExeFileButton.Size = new System.Drawing.Size(84, 23);
			this.browseBaseProjectExeFileButton.TabIndex = 6;
			this.browseBaseProjectExeFileButton.Text = "Browse...";
			this.browseBaseProjectExeFileButton.Click += new System.EventHandler(this.browseBaseProjectExeFileButton_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(193, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Base Project Executable (.exe) File";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Base Project Definition File";
			// 
			// baseProjectExeFileTextBox
			// 
			this.baseProjectExeFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.baseProjectExeFileTextBox.Location = new System.Drawing.Point(24, 141);
			this.baseProjectExeFileTextBox.Name = "baseProjectExeFileTextBox";
			this.baseProjectExeFileTextBox.Size = new System.Drawing.Size(352, 20);
			this.baseProjectExeFileTextBox.TabIndex = 2;
			this.baseProjectExeFileTextBox.Text = "";
			// 
			// baseProjectDefinitionFileTextBox
			// 
			this.baseProjectDefinitionFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.baseProjectDefinitionFileTextBox.Location = new System.Drawing.Point(24, 45);
			this.baseProjectDefinitionFileTextBox.Name = "baseProjectDefinitionFileTextBox";
			this.baseProjectDefinitionFileTextBox.Size = new System.Drawing.Size(352, 20);
			this.baseProjectDefinitionFileTextBox.TabIndex = 0;
			this.baseProjectDefinitionFileTextBox.Text = "";
			// 
			// tagTrakSourceBrowseButton
			// 
			this.tagTrakSourceBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tagTrakSourceBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.tagTrakSourceBrowseButton.Location = new System.Drawing.Point(384, 44);
			this.tagTrakSourceBrowseButton.Name = "tagTrakSourceBrowseButton";
			this.tagTrakSourceBrowseButton.Size = new System.Drawing.Size(84, 23);
			this.tagTrakSourceBrowseButton.TabIndex = 1;
			this.tagTrakSourceBrowseButton.Text = "Browse...";
			this.tagTrakSourceBrowseButton.Click += new System.EventHandler(this.tagTrakSourceBrowseButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.addConfigurationButton);
			this.groupBox1.Controls.Add(this.configurationComboBox);
			this.groupBox1.Location = new System.Drawing.Point(24, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 72);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Base Project Configuration";
			// 
			// addConfigurationButton
			// 
			this.addConfigurationButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.addConfigurationButton.Location = new System.Drawing.Point(320, 32);
			this.addConfigurationButton.Name = "addConfigurationButton";
			this.addConfigurationButton.Size = new System.Drawing.Size(145, 24);
			this.addConfigurationButton.TabIndex = 1;
			this.addConfigurationButton.Text = "Add Configuration To List";
			this.addConfigurationButton.Click += new System.EventHandler(this.addConfigurationButton_Click);
			// 
			// configurationComboBox
			// 
			this.configurationComboBox.Location = new System.Drawing.Point(24, 32);
			this.configurationComboBox.Name = "configurationComboBox";
			this.configurationComboBox.Size = new System.Drawing.Size(208, 21);
			this.configurationComboBox.TabIndex = 0;
			this.configurationComboBox.SelectedIndexChanged += new System.EventHandler(this.configurationComboBox_SelectedIndexChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(533, 382);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Libraries";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.librariesForceRebuildCheckBox);
			this.groupBox4.Controls.Add(this.button2);
			this.groupBox4.Controls.Add(this.airlineSoftwareLibTextBox);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.button4);
			this.groupBox4.Controls.Add(this.airlinesoftwareProj);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Location = new System.Drawing.Point(16, 24);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(504, 176);
			this.groupBox4.TabIndex = 14;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "AirlineSoftware";
			// 
			// librariesForceRebuildCheckBox
			// 
			this.librariesForceRebuildCheckBox.Checked = true;
			this.librariesForceRebuildCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.librariesForceRebuildCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.librariesForceRebuildCheckBox.Location = new System.Drawing.Point(16, 144);
			this.librariesForceRebuildCheckBox.Name = "librariesForceRebuildCheckBox";
			this.librariesForceRebuildCheckBox.Size = new System.Drawing.Size(96, 21);
			this.librariesForceRebuildCheckBox.TabIndex = 10;
			this.librariesForceRebuildCheckBox.Text = "Force Rebuild";
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button2.Location = new System.Drawing.Point(416, 112);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 23);
			this.button2.TabIndex = 11;
			this.button2.Text = "Browse...";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// airlineSoftwareLibTextBox
			// 
			this.airlineSoftwareLibTextBox.Location = new System.Drawing.Point(16, 112);
			this.airlineSoftwareLibTextBox.Name = "airlineSoftwareLibTextBox";
			this.airlineSoftwareLibTextBox.Size = new System.Drawing.Size(384, 20);
			this.airlineSoftwareLibTextBox.TabIndex = 0;
			this.airlineSoftwareLibTextBox.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 88);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "AirlineSoftware.dll";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(416, 48);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 23);
			this.button4.TabIndex = 13;
			this.button4.Text = "Browse...";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// airlinesoftwareProj
			// 
			this.airlinesoftwareProj.Location = new System.Drawing.Point(16, 48);
			this.airlinesoftwareProj.Name = "airlinesoftwareProj";
			this.airlinesoftwareProj.Size = new System.Drawing.Size(384, 20);
			this.airlinesoftwareProj.TabIndex = 12;
			this.airlinesoftwareProj.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 24);
			this.label9.Name = "label9";
			this.label9.TabIndex = 14;
			this.label9.Text = "Project File";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.label11);
			this.tabPage5.Controls.Add(this.webUpdateOutputFileTextbox);
			this.tabPage5.Controls.Add(this.button6);
			this.tabPage5.Controls.Add(this.label10);
			this.tabPage5.Controls.Add(this.migrateOutputFileTextbox);
			this.tabPage5.Controls.Add(this.button5);
			this.tabPage5.Controls.Add(this.label6);
			this.tabPage5.Controls.Add(this.updateOutputFileTextBox);
			this.tabPage5.Controls.Add(this.button3);
			this.tabPage5.Controls.Add(this.label5);
			this.tabPage5.Controls.Add(this.distributionOutputFileTextBox);
			this.tabPage5.Controls.Add(this.button1);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(533, 382);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Outputs";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(18, 248);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(167, 16);
			this.label11.TabIndex = 16;
			this.label11.Text = "Web Update Output CAB File";
			// 
			// webUpdateOutputFileTextbox
			// 
			this.webUpdateOutputFileTextbox.Location = new System.Drawing.Point(18, 264);
			this.webUpdateOutputFileTextbox.Name = "webUpdateOutputFileTextbox";
			this.webUpdateOutputFileTextbox.Size = new System.Drawing.Size(496, 20);
			this.webUpdateOutputFileTextbox.TabIndex = 14;
			this.webUpdateOutputFileTextbox.Text = "";
			// 
			// button6
			// 
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button6.Location = new System.Drawing.Point(20, 288);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(84, 23);
			this.button6.TabIndex = 15;
			this.button6.Text = "Browse...";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 168);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(167, 16);
			this.label10.TabIndex = 13;
			this.label10.Text = "Migrate Output CAB File";
			// 
			// migrateOutputFileTextbox
			// 
			this.migrateOutputFileTextbox.Location = new System.Drawing.Point(16, 184);
			this.migrateOutputFileTextbox.Name = "migrateOutputFileTextbox";
			this.migrateOutputFileTextbox.Size = new System.Drawing.Size(496, 20);
			this.migrateOutputFileTextbox.TabIndex = 11;
			this.migrateOutputFileTextbox.Text = "";
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button5.Location = new System.Drawing.Point(18, 208);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(84, 23);
			this.button5.TabIndex = 12;
			this.button5.Text = "Browse...";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 88);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Update Output CAB File";
			// 
			// updateOutputFileTextBox
			// 
			this.updateOutputFileTextBox.Location = new System.Drawing.Point(16, 104);
			this.updateOutputFileTextBox.Name = "updateOutputFileTextBox";
			this.updateOutputFileTextBox.Size = new System.Drawing.Size(496, 20);
			this.updateOutputFileTextBox.TabIndex = 8;
			this.updateOutputFileTextBox.Text = "";
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button3.Location = new System.Drawing.Point(16, 128);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(84, 23);
			this.button3.TabIndex = 9;
			this.button3.Text = "Browse...";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(167, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Distribution Output CAB File";
			// 
			// distributionOutputFileTextBox
			// 
			this.distributionOutputFileTextBox.Location = new System.Drawing.Point(16, 24);
			this.distributionOutputFileTextBox.Name = "distributionOutputFileTextBox";
			this.distributionOutputFileTextBox.Size = new System.Drawing.Size(496, 20);
			this.distributionOutputFileTextBox.TabIndex = 5;
			this.distributionOutputFileTextBox.Text = "";
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(16, 48);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Browse...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// buildUpdateButton
			// 
			this.buildUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buildUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buildUpdateButton.Location = new System.Drawing.Point(328, 440);
			this.buildUpdateButton.Name = "buildUpdateButton";
			this.buildUpdateButton.Size = new System.Drawing.Size(104, 23);
			this.buildUpdateButton.TabIndex = 9;
			this.buildUpdateButton.Text = "Build Update";
			this.buildUpdateButton.Click += new System.EventHandler(this.buildUpdateButton_Click);
			// 
			// buildDistButton
			// 
			this.buildDistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buildDistButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buildDistButton.Location = new System.Drawing.Point(208, 440);
			this.buildDistButton.Name = "buildDistButton";
			this.buildDistButton.Size = new System.Drawing.Size(104, 23);
			this.buildDistButton.TabIndex = 10;
			this.buildDistButton.Text = "Build Distribution";
			this.buildDistButton.Click += new System.EventHandler(this.buildDistButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(328, 472);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(104, 23);
			this.cancelButton.TabIndex = 11;
			this.cancelButton.Text = "Save && Close";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// buildMigrateButton
			// 
			this.buildMigrateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buildMigrateButton.Location = new System.Drawing.Point(208, 472);
			this.buildMigrateButton.Name = "buildMigrateButton";
			this.buildMigrateButton.Size = new System.Drawing.Size(104, 23);
			this.buildMigrateButton.TabIndex = 12;
			this.buildMigrateButton.Text = "Build Migrate";
			this.buildMigrateButton.Click += new System.EventHandler(this.buildMigrateButton_Click);
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.Location = new System.Drawing.Point(440, 440);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(104, 23);
			this.button7.TabIndex = 13;
			this.button7.Text = "Build Web Update";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// SystemBuilder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(567, 513);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.buildMigrateButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.buildDistButton);
			this.Controls.Add(this.buildUpdateButton);
			this.Controls.Add(this.tabControl1);
			this.Menu = this.mainMenu1;
			this.Name = "SystemBuilder";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tag Trak System Builder";
			this.Load += new System.EventHandler(this.SystemBuilder_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tagTrakBaseProjectSpec.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(String[] args) 
		{
			String fn = "";
			if (args.Length >= 1)
			{
				fn = args[0];
			}

			Application.Run(new SystemBuilder(fn));
		}

		private void getInitialBaseProjectDefinitionFileDirectory(OpenFileDialog openFileDialog)
		{
			string initialDirectory ;

			if ( Utilities.isNonNullString(baseProjectDefinitionFileTextBox.Text) )
			{
				initialDirectory = Path.GetDirectoryName(baseProjectDefinitionFileTextBox.Text) ;

				if ( Directory.Exists(initialDirectory) )
				{
					openFileDialog.InitialDirectory = initialDirectory ;

					if ( File.Exists(baseProjectDefinitionFileTextBox.Text) )
					{
						openFileDialog.FileName = Path.GetFileName(baseProjectDefinitionFileTextBox.Text) ;
					}

					return ;
				}
			}

			if ( Utilities.isNonNullString(systemProfile.baseProjectDefinitionFile) )
			{
				initialDirectory = Path.GetDirectoryName(systemProfile.baseProjectDefinitionFile) ;

				if ( Directory.Exists(initialDirectory) )
				{
					openFileDialog.InitialDirectory = initialDirectory ;
	
					return ;
				}
			}
		}

		
		private void getInitialBaseProjectExeFileDirectory(OpenFileDialog openFileDialog)
		{
			string initialDirectory ;

			if ( Utilities.isNonNullString(baseProjectExeFileTextBox.Text) )
			{
				initialDirectory = Path.GetDirectoryName(baseProjectExeFileTextBox.Text) ;

				if ( Directory.Exists(initialDirectory) )
				{
					openFileDialog.InitialDirectory = initialDirectory ;

					if ( File.Exists(baseProjectExeFileTextBox.Text) )
					{
						openFileDialog.FileName = Path.GetFileName(baseProjectExeFileTextBox.Text) ;
					}

					return ;
				}
			}

			if ( Utilities.isNonNullString(baseProjectDefinitionFileTextBox.Text) )
			{
				initialDirectory = Path.GetDirectoryName(baseProjectDefinitionFileTextBox.Text) ;

				string deviceType = systemProfile.deviceType ;

				if ( deviceType == "Intermec" || deviceType == "Symbol" || deviceType == "Viewsonic" )
				{
					initialDirectory += @"\obj\" + deviceType ;
				}

				if ( Directory.Exists(initialDirectory) )
				{
					openFileDialog.InitialDirectory = initialDirectory ;

					if ( File.Exists(baseProjectExeFileTextBox.Text) )
					{
						openFileDialog.FileName = Path.GetFileName(baseProjectExeFileTextBox.Text) ;
					}

					return ;
				}
			}

			if ( Utilities.isNonNullString(systemProfile.baseProjectDefinitionFile) )
			{
				initialDirectory = Path.GetDirectoryName(systemProfile.baseProjectDefinitionFile) ;

				string deviceType = systemProfile.deviceType ;

				if ( deviceType == "Intermec" || deviceType == "Symbol" || deviceType == "Viewsonic" )
				{
					initialDirectory += @"\obj\" + deviceType ;
				}

				if ( Directory.Exists(initialDirectory) )
				{
					openFileDialog.InitialDirectory = initialDirectory ;
	
					return ;
				}
			}
		}

		private void tagTrakSourceBrowseButton_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			getInitialBaseProjectDefinitionFileDirectory(openFileDialog) ;

			openFileDialog.Filter = "Solution Files (*.sln)|*.sln|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 1 ;
			openFileDialog.RestoreDirectory = true ;
			openFileDialog.Multiselect = false ;

			if(openFileDialog.ShowDialog() != DialogResult.OK) return ;

			baseProjectDefinitionFileTextBox.Text = openFileDialog.FileName ;
		}

		private void otherRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			this.otherDeviceTextBox.Enabled = this.otherRadioButton.Checked ;
		}

		private void saveProfileMenuItem_Click(object sender, System.EventArgs e)
		{
			if ( Utilities.isNullString(systemProfile.profileFilePath) )
			{
				saveProfileAsMenuItem_Click( sender, e) ;
				return ;
			}

			try
			{
				systemProfile.saveProfile(systemProfile.profileFilePath) ;
			}

			catch (Exception ex)
			{
				MessageBox.Show("Attempt to write profile to file '" + systemProfile.profileFilePath + "' failed: " + ex.Message) ;
				return ;
			}

		}

		private void saveProfileAsMenuItem_Click(object sender, System.EventArgs e)
		{
			RegistryKey tagTrakKey ;

			SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.AddExtension = true ;
			saveFileDialog.DefaultExt = "sbprof" ;
			saveFileDialog.Filter = "System Builder Profile Files (*.sbprof)|*.sbprof|All files (*.*)|*.*" ;
			saveFileDialog.RestoreDirectory = true;

			if ( Utilities.isNonNullString(systemProfile.profileFilePath) )
			{
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(systemProfile.profileFilePath) ;
				saveFileDialog.FileName = Path.GetFileName(systemProfile.profileFilePath) ;
			}

			else if ( Utilities.isNonNullString(systemProfile.baseProjectDefinitionFile) )
			{
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(systemProfile.baseProjectDefinitionFile) ;
				saveFileDialog.FileName = "SystemBuilderProfile.sbprof" ;
			}

			else
			{
				saveFileDialog.FileName = "SystemBuilderProfile.sbprof" ;
			}

			DialogResult result = saveFileDialog.ShowDialog(this) ;

			if ( result != DialogResult.OK ) return ;

			string outputFilePath = saveFileDialog.FileName ;

			try
			{
				systemProfile.saveProfile(outputFilePath) ;
			}

			catch (Exception ex)
			{
				MessageBox.Show("Attempt to write profile to file '" + outputFilePath + "' failed: " + ex.Message) ;
				return ;
			}

			this.profileHistory.update(outputFilePath) ;
			tagTrakKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TagTrak", true) ;

			tagTrakKey.SetValue("TagTrakProfileFilePath", outputFilePath) ;

			tagTrakKey.Close();

			systemProfile.profileFilePath = outputFilePath ;
		}

		private void openProfileMenuItem_Click(object sender, System.EventArgs e)
		{
			RegistryKey tagTrakKey ;

			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.AddExtension = true ;
			openFileDialog.DefaultExt = "sbprof" ;
			openFileDialog.Filter = "System Builder Profile Files (*.sbprof)|*.sbprof|All files (*.*)|*.*" ;

			if ( Utilities.isNonNullString(systemProfile.profileFilePath) )
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(systemProfile.profileFilePath) ;
				openFileDialog.FileName = Path.GetFileName(systemProfile.profileFilePath) ;
			}

			else if ( Utilities.isNonNullString(systemProfile.baseProjectDefinitionFile) )
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(systemProfile.baseProjectDefinitionFile) ;
				openFileDialog.FileName = "SystemBuilderProfile.sbprof" ;
			}

			else
			{
				string profileFilePath = profileHistory.GetLastProfilePath() ;

				if ( Utilities.isNonNullString(profileFilePath) )
				{
					openFileDialog.InitialDirectory = Path.GetDirectoryName(profileFilePath) ;
					openFileDialog.FileName = Path.GetFileName(profileFilePath) ;
				}
			}

			DialogResult result = openFileDialog.ShowDialog(this) ;

			if ( result != DialogResult.OK ) return ;

			string inputFilePath = openFileDialog.FileName ;

			try
			{
				systemProfile.loadProfile(inputFilePath) ;
			}

			catch (Exception ex)
			{
				MessageBox.Show("Attempt to read profile to file '" + inputFilePath + "' failed: " + ex.Message) ;
				return ;
			}

			profileHistory.update(inputFilePath) ;

			systemProfile.profileFilePath = inputFilePath ;

			tagTrakKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TagTrak", true) ;
				
			tagTrakKey.SetValue("TagTrakProfileFilePath", inputFilePath) ;

			tagTrakKey.Close();
		}

		private void browseBaseProjectExeFileButton_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			getInitialBaseProjectExeFileDirectory(openFileDialog) ;

			openFileDialog.Filter = @"Executable Files (*.exe)|*.exe|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 0 ;
			openFileDialog.RestoreDirectory = true ;
			openFileDialog.Multiselect = false ;
			openFileDialog.CheckFileExists = false;

			if(openFileDialog.ShowDialog() != DialogResult.OK) return ;

			baseProjectExeFileTextBox.Text = openFileDialog.FileName ;
		}

		private void exitMenuItem_Click(object sender, System.EventArgs e)
		{
			this.Close() ;
		}

		private void buildDistributionMenuItem_Click(object sender, System.EventArgs e)
		{

			// Prerequisites. Make sure all elements required to build the system are in place and are valid.

			if ( Utilities.isNullString(systemProfile.baseProjectDefinitionFile) )
			{
				MessageBox.Show("A base project solution file must be specified.") ;
				return ;
			}

			if ( ! File.Exists(systemProfile.baseProjectDefinitionFile) )
			{
				MessageBox.Show("The base project solution file '" + systemProfile.baseProjectDefinitionFile + "' does not exist.") ;
				return ;
			}

			buildOutputForm = new BuildUpdateOutputForm(this, systemProfile, "Build Distribution") ;
			buildOutputForm.ShowDialog(this) ;
		}


		private void optionsMenuItem_Click(object sender, System.EventArgs e)
		{
			OptionsForm optionsForm = new OptionsForm() ;
			
			optionsForm.ShowDialog() ;
		}

	
		private void editConfigurationFileButton_Click(object sender, System.EventArgs e)
		{
			
		}

		private string getInitialFolderDirectory()
		{
			string initialDirectory ;

			if ( Utilities.isNonNullString(baseProjectExeFileTextBox.Text) )
			{
				initialDirectory = Path.GetDirectoryName(baseProjectExeFileTextBox.Text) ;
				initialDirectory = Path.GetDirectoryName(initialDirectory) ;
				initialDirectory = Path.GetDirectoryName(initialDirectory) ;

				return initialDirectory ;
			}

			if ( Utilities.isNonNullString(baseProjectSourceDirectoryTextBox.Text) )
			{
				return baseProjectSourceDirectoryTextBox.Text ;
			}

			return @"C:\" ;
		}

		private void baseProjectSourceFileBrowseButton_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.FolderBrowserDialog folderBrowser = new FolderBrowserDialog() ;

			folderBrowser.SelectedPath = getInitialFolderDirectory() ;

			if(folderBrowser.ShowDialog() != DialogResult.OK) return ;

			baseProjectSourceDirectoryTextBox.Text = folderBrowser.SelectedPath ;
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void addConfigurationButton_Click(object sender, System.EventArgs e)
		{
			string newConfigurationName = this.configurationComboBox.Text.Trim() ;

			if ( Utilities.isNullString( newConfigurationName ) )
			{
				MessageBox.Show("You must specify a non-empty configuration name") ; 
				return ;
			}

			if ( this.configurationComboBox.Items.Contains(newConfigurationName) )
			{
				MessageBox.Show("Configuration \"" + newConfigurationName + "\" is already in the current list.") ; 
				return ;
			}

			this.configurationComboBox.Items.Add(newConfigurationName) ;
			
		}

		private void buildDistButton_Click(object sender, System.EventArgs e)
		{
			this.buildDistributionMenuItem_Click(sender, e);
		}

		private void buildUpdateButton_Click(object sender, System.EventArgs e)
		{
			this.buildUpdateMenuItem_Click(sender, e);	
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			getInitialBaseProjectExeFileDirectory(openFileDialog) ;

			openFileDialog.Filter = @"Library Files (*.dll)|*.dll|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 0 ;
			openFileDialog.RestoreDirectory = true ;
			openFileDialog.Multiselect = false ;
			if (airlineSoftwareLibTextBox.Text != "") 
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(airlineSoftwareLibTextBox.Text);
			}

			if(openFileDialog.ShowDialog() != DialogResult.OK) return ;

			airlineSoftwareLibTextBox.Text = openFileDialog.FileName ;	
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog openFileDialog = new SaveFileDialog();

//			getInitialBaseProjectExeFileDirectory(openFileDialog) ;

			openFileDialog.Filter = @"CAB Files (*.cab)|*.cab|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 0 ;
			openFileDialog.RestoreDirectory = true ;
//			openFileDialog.Multiselect = false ;

			if (distributionOutputFileTextBox.Text != "")
			{
					openFileDialog.InitialDirectory = Path.GetDirectoryName(distributionOutputFileTextBox.Text);
			}

			if(openFileDialog.ShowDialog() != DialogResult.OK) return ;

			distributionOutputFileTextBox.Text = openFileDialog.FileName ;			
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog openFileDialog = new SaveFileDialog();

//			getInitialBaseProjectExeFileDirectory(openFileDialog) ;

			openFileDialog.Filter = @"CAB Files (*.cab)|*.cab|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 0 ;
			openFileDialog.RestoreDirectory = true ;
//			openFileDialog.Multiselect = false ;

			if (updateOutputFileTextBox.Text != "") openFileDialog.InitialDirectory = Path.GetDirectoryName(updateOutputFileTextBox.Text);

			if(openFileDialog.ShowDialog() != DialogResult.OK) return ;

			updateOutputFileTextBox.Text = openFileDialog.FileName ;				
		}

		private void otherProcessorRadioButton_CheckedChanged(object sender, System.EventArgs e)
		{
			setEnableDisables();
		}

		private void otherRadioButton_CheckedChanged_1(object sender, System.EventArgs e)
		{
			setEnableDisables();
		}

		private void setEnableDisables()
		{
			otherProcessorTextBox.Enabled = otherProcessorRadioButton.Checked;
			otherDeviceTextBox.Enabled = otherRadioButton.Checked;
		}

		private void SystemBuilder_Load(object sender, System.EventArgs e)
		{
			setEnableDisables();

			// Set option menu item status
			RegistryKey tagTrakKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TagTrak\Options") ;
			object v = tagTrakKey.GetValue("LoadLastProfileOnStartup");	
		
			if (v != null) 
			{
				if (v.ToString() == "True")
				{
					this.menuItem6.Checked = true;
				}
				else 
				{
					this.menuItem6.Checked = false;
				}		
			}
			else 
			{
				this.menuItem6.Checked = false;
			}		

		}

		private void baseProjectSourceFileBrowseButton_Click_1(object sender, System.EventArgs e)
		{
			FolderBrowserDialog fldDlg = new FolderBrowserDialog();
			fldDlg.ShowNewFolderButton = false;

			if(fldDlg.ShowDialog() != DialogResult.OK) return ;

			baseProjectSourceDirectoryTextBox.Text = fldDlg.SelectedPath ;
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			getInitialBaseProjectExeFileDirectory(openFileDialog) ;

			openFileDialog.Filter = @"Project Files (*.vcp)|*.vcp|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 0 ;
			openFileDialog.RestoreDirectory = true ;
			openFileDialog.Multiselect = false ;

			if (airlinesoftwareProj.Text != "") 
			{
				openFileDialog.InitialDirectory = Path.GetDirectoryName(airlinesoftwareProj.Text);
			}

			if(openFileDialog.ShowDialog() != DialogResult.OK) return ;

			airlinesoftwareProj.Text = openFileDialog.FileName ;			
		}

		private void buildUpdateMenuItem_Click(object sender, System.EventArgs e)
		{
			// Prerequisites. Make sure all elements required to build the system are in place and are valid.

			if ( Utilities.isNullString(systemProfile.baseProjectDefinitionFile) )
			{
				MessageBox.Show("A base project solution file must be specified.") ;
				return ;
			}

			if ( ! File.Exists(systemProfile.baseProjectDefinitionFile) )
			{
				MessageBox.Show("The base project solution file '" + systemProfile.baseProjectDefinitionFile + "' does not exist.") ;
				return ;
			}

			buildOutputForm = new BuildUpdateOutputForm(this, systemProfile, "Build Update") ;
			buildOutputForm.ShowDialog(this) ;		
		}

		private void configurationComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			RegistryKey tagTrakKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\TagTrak\Options") ;
	
		
			if ( this.menuItem6.Checked )
			{
				this.menuItem6.Checked = false;
				tagTrakKey.SetValue("LoadLastProfileOnStartup", false) ;
			}

			else
			{
				this.menuItem6.Checked = true;
				tagTrakKey.SetValue("LoadLastProfileOnStartup", true) ;
			}

		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.saveProfileMenuItem_Click(sender, e);
			this.Close();
		}


		private void button5_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog openFileDialog = new SaveFileDialog();

			openFileDialog.Filter = @"CAB Files (*.cab)|*.cab|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 0 ;
			openFileDialog.RestoreDirectory = true ;

			if (migrateOutputFileTextbox.Text != "") openFileDialog.InitialDirectory = Path.GetDirectoryName(migrateOutputFileTextbox.Text);

			if (openFileDialog.ShowDialog() != DialogResult.OK) return ;

			migrateOutputFileTextbox.Text = openFileDialog.FileName ;				
		}

		private void buildMigrateMenusItem_Click(object sender, System.EventArgs e)
		{
			// Prerequisites. Make sure all elements required to build the system are in place and are valid.

			if ( Utilities.isNullString(systemProfile.baseProjectDefinitionFile) )
			{
				MessageBox.Show("A base project solution file must be specified.") ;
				return ;
			}

			if ( ! File.Exists(systemProfile.baseProjectDefinitionFile) )
			{
				MessageBox.Show("The base project solution file '" + systemProfile.baseProjectDefinitionFile + "' does not exist.") ;
				return ;
			}

			buildOutputForm = new BuildUpdateOutputForm(this, systemProfile, "Build Migrate") ;
			buildOutputForm.ShowDialog(this) ;		
		}

		private void buildMigrateButton_Click(object sender, System.EventArgs e)
		{
			buildMigrateMenusItem_Click(sender, e);
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog openFileDialog = new SaveFileDialog();

			openFileDialog.Filter = @"CAB Files (*.cab)|*.cab|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 0 ;
			openFileDialog.RestoreDirectory = true ;

			if (webUpdateOutputFileTextbox.Text != "") openFileDialog.InitialDirectory = Path.GetDirectoryName(webUpdateOutputFileTextbox.Text);

			if (openFileDialog.ShowDialog() != DialogResult.OK) return ;

			webUpdateOutputFileTextbox.Text = openFileDialog.FileName ;	
		}

		private void buildWebUpdateMenuItem_Click(object sender, System.EventArgs e)
		{
			// Prerequisites. Make sure all elements required to build the system are in place and are valid.

			if ( Utilities.isNullString(systemProfile.baseProjectDefinitionFile) )
			{
				MessageBox.Show("A base project solution file must be specified.") ;
				return ;
			}

			if ( ! File.Exists(systemProfile.baseProjectDefinitionFile) )
			{
				MessageBox.Show("The base project solution file '" + systemProfile.baseProjectDefinitionFile + "' does not exist.") ;
				return ;
			}

			buildOutputForm = new BuildUpdateOutputForm(this, systemProfile, "Build WebUpdate") ;
			buildOutputForm.ShowDialog(this) ;		
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			buildWebUpdateMenuItem_Click(sender, e);
		}

	}
}
