using System.Data.SqlServerCe;
using System;
using System.Drawing;
using System.Windows.Forms;
using TagTrak.TagTrakLib;
using System.Net;

namespace TagTrak
{
	public class LoaderForm : System.Windows.Forms.Form 
	{
		private System.Windows.Forms.Button continueButton; 
		private System.Windows.Forms.Label Label1; 
		
		public LoaderForm() 
		{ 
			InitializeComponent(); 

			this.Load += new EventHandler(LoaderForm_Load);
		} 

		protected override void Dispose(bool disposing) 
		{ 
			base.Dispose(disposing); 
		} 

		#region Windows Form Designer generated code

		private void InitializeComponent() 
		{
            this.Label1 = new System.Windows.Forms.Label();
            this.continueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.SystemColors.Info;
            this.Label1.Location = new System.Drawing.Point(24, 64);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(192, 64);
            this.Label1.Text = "With the device connected, tap \"Continue\"";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.continueButton.Location = new System.Drawing.Point(64, 208);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(104, 32);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // LoaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.Label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "LoaderForm";
            this.Text = "Scanner Program Loading";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

		} 

		#endregion

		private void LoaderForm_Load(object sender, System.EventArgs e) 
		{ 
			this.WindowState = FormWindowState.Maximized;
		} 

		private void ServerSync()
		{
			try
			{
				Label1.Text = "Checking for program upgrade ...";
				Label1.Update();
				ProgVersionManager.CheckForUpgrade(Label1);

				Label1.Text = "Checking for new downloads ...";
				Label1.Update();
				DbAccess.Update();
			}
			catch (WebException ex)
			{
				MessageBox.Show("Unable to connect to server to check for update:" + ex.Message, 
					"Update Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 
					MessageBoxDefaultButton.Button1);
			}
		}

		private void continueButton_Click(object sender, System.EventArgs e)
		{
			this.continueButton.Enabled = false;

			Label1.Text = "Connecting ...";
			Label1.Update();

			Cursor.Current = Cursors.WaitCursor; 

			System.Threading.Thread.Sleep(5000); // wait for possible dhcp sync

			ServerSync();

			Cursor.Current = Cursors.Default; 

			TagTrakCarrier frm = new TagTrakCarrier();
			frm.Show();

			LogInForm loginFrm = new LogInForm();
			loginFrm.Show();
		}
	}
}