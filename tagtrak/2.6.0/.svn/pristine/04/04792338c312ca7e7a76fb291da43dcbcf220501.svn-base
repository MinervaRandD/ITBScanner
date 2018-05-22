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

namespace sb
{
	/// <summary>
	/// Summary description for OptionsForm.
	/// </summary>
	public class OptionsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox loadLastProfileOptionCheckBox;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OptionsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.loadLastProfileOptionCheckBox = new System.Windows.Forms.CheckBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// loadLastProfileOptionCheckBox
			// 
			this.loadLastProfileOptionCheckBox.Checked = true;
			this.loadLastProfileOptionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.loadLastProfileOptionCheckBox.Location = new System.Drawing.Point(48, 24);
			this.loadLastProfileOptionCheckBox.Name = "loadLastProfileOptionCheckBox";
			this.loadLastProfileOptionCheckBox.Size = new System.Drawing.Size(183, 27);
			this.loadLastProfileOptionCheckBox.TabIndex = 0;
			this.loadLastProfileOptionCheckBox.Text = "Load last profile on start up.";
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(23, 243);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(89, 23);
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK";
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(151, 244);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(89, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// OptionsForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 289);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.loadLastProfileOptionCheckBox);
			this.Name = "OptionsForm";
			this.Text = "System Builder Options";
			this.Load += new System.EventHandler(this.OptionsForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void OKButton_Click(object sender, System.EventArgs e)
		{
			RegistryKey tagTrakKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\TagTrak\Options") ;
	
		
			if ( this.loadLastProfileOptionCheckBox.Checked )
			{
				tagTrakKey.SetValue("LoadLastProfileOnStartup", true) ;
			}

			else
			{
				tagTrakKey.SetValue("LoadLastProfileOnStartup", false) ;
			}

			this.Close() ;
		}

		private void OptionsForm_Load(object sender, System.EventArgs e)
		{
			RegistryKey tagTrakKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TagTrak\Options") ;
	
			object v = tagTrakKey.GetValue("LoadLastProfileOnStartup");
			
			if (v != null) 
			{
				if (v.ToString() == "True")
				{
					this.loadLastProfileOptionCheckBox.Checked = true;
				}
				else 
				{
					this.loadLastProfileOptionCheckBox.Checked = false;
				}		
			}
			else {
				this.loadLastProfileOptionCheckBox.Checked = false;
			}		
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
