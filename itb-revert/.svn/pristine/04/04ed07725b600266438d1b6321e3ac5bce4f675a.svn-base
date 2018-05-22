using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data;

namespace TagTrak.TagTrakLib
{
	/// <summary>
	/// Summary description for LogInForm.
	/// </summary>
	public class LogInForm : System.Windows.Forms.Form
	{
		private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
		private System.Windows.Forms.Label userNameLabel;
		private System.Windows.Forms.TextBox userName;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.Label carrierLabel;
		private System.Windows.Forms.ComboBox cbxCarrier;
		private System.Windows.Forms.MainMenu mainMenu2;
		private System.Windows.Forms.MenuItem exitMenuItem;
		private System.Windows.Forms.Button loginButton;
	
		public LogInForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			cbxCarrier.DataSource = this.GetCarrierList(); 

			cbxCarrier.SelectedItem = ConfigSetting.Instance().Carrier;

			this.Deactivate += new EventHandler(LogInForm_Deactivate);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.carrierLabel = new System.Windows.Forms.Label();
            this.cbxCarrier = new System.Windows.Forms.ComboBox();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.exitMenuItem = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.Location = new System.Drawing.Point(24, 72);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(72, 20);
            this.userNameLabel.Text = "Username";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(104, 72);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(96, 21);
            this.userName.TabIndex = 0;
            this.userName.GotFocus += new System.EventHandler(this.userName_GotFocus);
            // 
            // passwordLabel
            // 
            this.passwordLabel.Location = new System.Drawing.Point(32, 104);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(64, 20);
            this.passwordLabel.Text = "Password";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(104, 104);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(96, 21);
            this.password.TabIndex = 1;
            this.password.GotFocus += new System.EventHandler(this.password_GotFocus);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(24, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(184, 40);
            this.titleLabel.Text = "Please enter username and password to log in";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(104, 168);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(72, 24);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Log In";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // carrierLabel
            // 
            this.carrierLabel.Location = new System.Drawing.Point(48, 136);
            this.carrierLabel.Name = "carrierLabel";
            this.carrierLabel.Size = new System.Drawing.Size(48, 20);
            this.carrierLabel.Text = "Carrier";
            this.carrierLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbxCarrier
            // 
            this.cbxCarrier.DisplayMember = "code";
            this.cbxCarrier.Location = new System.Drawing.Point(104, 136);
            this.cbxCarrier.Name = "cbxCarrier";
            this.cbxCarrier.Size = new System.Drawing.Size(40, 22);
            this.cbxCarrier.TabIndex = 2;
            this.cbxCarrier.ValueMember = "code";
            // 
            // mainMenu2
            // 
            this.mainMenu2.MenuItems.Add(this.exitMenuItem);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.carrierLabel);
            this.Controls.Add(this.cbxCarrier);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userNameLabel);
            this.Menu = this.mainMenu2;
            this.Name = "LogInForm";
            this.Text = "Log In";
            this.ResumeLayout(false);

		}
		#endregion

		private void loginButton_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			string uname = this.userName.Text;
			string pwd = this.password.Text;
			string carrierCode = (string) (cbxCarrier.SelectedValue);

			string encryptPwd = Utilities.getSha1Hash(pwd);

			string sql = "select e.employee_number " +
				         "from employees e " +
				         "join carriers c on e.carrier_id = c.id " +
						 "where e.username = '" + uname + "' " +
						 "and e.password = '" + encryptPwd + "' " +
						 "and c.code = '" + carrierCode + "'"
						 ;

			SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
			cmd.CommandText = sql;

			string employeeNumber = (string) cmd.ExecuteScalar();
			if (employeeNumber != null) 
			{
				ConfigSetting.Instance().EmployeeNumber = employeeNumber;
				ConfigSetting.Instance().Carrier = carrierCode;

				Cursor.Current = Cursors.Default;
				this.Close();
			}
			else
			{
				Cursor.Current = Cursors.Default;
				MessageBox.Show("Username and/or password not found. Please check your input and try again.", "Login Failed");
			}

		}

		private void userName_GotFocus(object sender, System.EventArgs e)
		{
			if (ConfigSetting.Instance().ShowKeyboardOnFocus)
			{
				this.inputPanel1.Enabled = true;
			}
		}

		private void password_GotFocus(object sender, System.EventArgs e)
		{
			if (ConfigSetting.Instance().ShowKeyboardOnFocus)
			{
				this.inputPanel1.Enabled = true;
			}
		}

		private DataTable GetCarrierList() 
		{ 
			SqlCeConnection con = DbAccess.OpenConnection; 
			SqlCeDataAdapter da = new SqlCeDataAdapter("select code from carriers", con); 
			DataTable dt = new DataTable(); 
			da.Fill(dt); 
			return dt; 
		}

		private void exitMenuItem_Click(object sender, System.EventArgs e)
		{
#if DEBUG
            ConfigSetting.ExitProgram(this, null);

            Application.DoEvents();

            this.Close();

            Application.Exit();
#else
            AdminLoginForm.Instance.Show();
#endif
        }

		private void LogInForm_Deactivate(object sender, EventArgs e)
		{
			this.inputPanel1.Enabled = false;
		}
	}
}
