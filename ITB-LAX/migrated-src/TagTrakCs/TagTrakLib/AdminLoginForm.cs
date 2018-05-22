using System;
using System.IO;
using System.Windows.Forms;

namespace TagTrak.TagTrakLib
{

	public class AdminLoginForm : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Button cancelButton;
		internal System.Windows.Forms.TextBox passwordTextBox;
		internal System.Windows.Forms.Button adminLoginButton;
		internal System.Windows.Forms.Label Label24;
		private static AdminLoginForm singlet;
		private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
		private ConfigSetting config = ConfigSetting.Instance();

        public PasswordType Action = PasswordType.INVALID;

		public static AdminLoginForm Instance 
		{
			get 
			{
				if (singlet == null) 
				{
					singlet = new AdminLoginForm();
				}
				return singlet;
			}
		}

		public AdminLoginForm()
		{
			Cursor.Current = Cursors.WaitCursor;

			InitializeComponent();

			baseFormUTCDateTimeLabel.Text = System.DateTime.UtcNow.ToString();
			baseFormLocalDateTimeLabel.Text = System.DateTime.Now.ToString();

			baseFormTimer.Enabled = true;

			config.CarrierChanged += new CarrierChangedEventHandler(loadAdminFormLogo);
			this.Deactivate += new EventHandler(AdminLoginForm_Deactivate);

			loadAdminFormLogo();

			passwordSeedLabel.Text = PasswordGenerator.GenerateSeed();

			Cursor.Current = Cursors.Default;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
		internal System.Windows.Forms.Timer baseFormTimer;
		internal System.Windows.Forms.Label passwordSeedLabel;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.PictureBox adminFormLogoPictureBox;
		internal System.Windows.Forms.Label baseFormUTCDateTimeLabel;
		internal System.Windows.Forms.Label baseFormLocalDateTimeLabel;
		internal System.Windows.Forms.MainMenu MainMenu1;

		#region Windows Form Designer generated code

		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLoginForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.adminFormLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.adminLoginButton = new System.Windows.Forms.Button();
            this.baseFormUTCDateTimeLabel = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.baseFormTimer = new System.Windows.Forms.Timer();
            this.passwordSeedLabel = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.baseFormLocalDateTimeLabel = new System.Windows.Forms.Label();
            this.MainMenu1 = new System.Windows.Forms.MainMenu();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(128, 136);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(72, 21);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // adminFormLogoPictureBox
            // 
            this.adminFormLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("adminFormLogoPictureBox.Image")));
            this.adminFormLogoPictureBox.Location = new System.Drawing.Point(24, 8);
            this.adminFormLogoPictureBox.Name = "adminFormLogoPictureBox";
            this.adminFormLogoPictureBox.Size = new System.Drawing.Size(180, 60);
            this.adminFormLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(31, 104);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(173, 21);
            this.passwordTextBox.TabIndex = 0;
            this.passwordTextBox.GotFocus += new System.EventHandler(this.passwordTextBox_GotFocus);
            // 
            // adminLoginButton
            // 
            this.adminLoginButton.Location = new System.Drawing.Point(40, 136);
            this.adminLoginButton.Name = "adminLoginButton";
            this.adminLoginButton.Size = new System.Drawing.Size(79, 21);
            this.adminLoginButton.TabIndex = 1;
            this.adminLoginButton.Text = "Continue";
            this.adminLoginButton.Click += new System.EventHandler(this.adminLoginButton_Click);
            // 
            // baseFormUTCDateTimeLabel
            // 
            this.baseFormUTCDateTimeLabel.Location = new System.Drawing.Point(16, 216);
            this.baseFormUTCDateTimeLabel.Name = "baseFormUTCDateTimeLabel";
            this.baseFormUTCDateTimeLabel.Size = new System.Drawing.Size(208, 16);
            // 
            // Label24
            // 
            this.Label24.Location = new System.Drawing.Point(8, 72);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(216, 32);
            this.Label24.Text = "Enter password then tap continue or cancel to return to scan application";
            this.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // baseFormTimer
            // 
            this.baseFormTimer.Tick += new System.EventHandler(this.baseFormTimer_Tick);
            // 
            // passwordSeedLabel
            // 
            this.passwordSeedLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.passwordSeedLabel.Location = new System.Drawing.Point(48, 184);
            this.passwordSeedLabel.Name = "passwordSeedLabel";
            this.passwordSeedLabel.Size = new System.Drawing.Size(145, 16);
            this.passwordSeedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(8, 160);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(224, 16);
            this.Label1.Text = "Report this String to Request Password";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // baseFormLocalDateTimeLabel
            // 
            this.baseFormLocalDateTimeLabel.Location = new System.Drawing.Point(16, 240);
            this.baseFormLocalDateTimeLabel.Name = "baseFormLocalDateTimeLabel";
            this.baseFormLocalDateTimeLabel.Size = new System.Drawing.Size(208, 16);
            // 
            // AdminLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.baseFormLocalDateTimeLabel);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.passwordSeedLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.adminFormLogoPictureBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.adminLoginButton);
            this.Controls.Add(this.baseFormUTCDateTimeLabel);
            this.Controls.Add(this.Label24);
            this.Menu = this.MainMenu1;
            this.Name = "AdminLoginForm";
            this.Text = "Admin Login";
            this.ResumeLayout(false);

		}

		#endregion

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.passwordTextBox.Text = "";
            this.Action = PasswordType.INVALID;
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
		}

		private void adminLoginButton_Click(object sender, System.EventArgs e)
		{
			string inputPassword = passwordTextBox.Text;
			
			if (inputPassword == "")
			{
				MessageBox.Show("Please enter password", "Missing Password");
				return;
			}
			else if (!System.Text.RegularExpressions.Regex.IsMatch(inputPassword, @"^\d{10}$")) 
			{
				MessageBox.Show("Password must contain 10 digits", "Invalid Password Format");
				return;
			}

			PasswordType pwdType = PasswordGenerator.CheckPasswordType(passwordTextBox.Text, passwordSeedLabel.Text);

			switch (pwdType)
			{
				case PasswordType.EXIT:                    
					this.baseFormTimer.Enabled = false;
					EndProgram();
					return;
				case PasswordType.ADMIN:
					break;

				case PasswordType.DATETIME:
					OpenNETCF.Diagnostics.Process.Start("clock.exe");
					break;

                case PasswordType.LOCATION:
                    Action = PasswordType.LOCATION;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;

				default:
					MessageBox.Show("Invalid password input", "Invalid Password");
					return;
			}

			this.passwordSeedLabel.Text = PasswordGenerator.GenerateSeed();

			passwordTextBox.Text = "";
		}

		private void baseFormTimer_Tick(object sender, System.EventArgs e)
		{
			baseFormUTCDateTimeLabel.Text = "UTC Time: " + DateTime.UtcNow.ToString();
			baseFormLocalDateTimeLabel.Text = "Local Time: " + DateTime.Now.ToString();
		}

		public void loadAdminFormLogo()
		{
			System.Drawing.Image img = TagTrak.Resources.Logo(config.Carrier);
			if (img != null) 
			{
				adminFormLogoPictureBox.Image = img;
			}
		}

		private void EndProgram()
		{
			ConfigSetting.ExitProgram(this, null);

			Application.DoEvents();

			this.Close();

			Application.Exit();
		}

		private void passwordTextBox_GotFocus(object sender, System.EventArgs e)
		{
			if (config.ShowKeyboardOnFocus) 
			{
				this.inputPanel1.Enabled = true;
			}
		}

		private void AdminLoginForm_Deactivate(object sender, EventArgs e)
		{
			this.inputPanel1.Enabled = false;
		}
	}
}
