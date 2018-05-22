using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace sb
{
	/// <summary>
	/// Summary description for BuildUpdateOutputForm.
	/// </summary>
	public class BuildUpdateOutputForm : System.Windows.Forms.Form
	{
		public System.Windows.Forms.ListBox outputListBox;
		public System.Windows.Forms.Button closeButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		SystemBuilder systemBuilder ;
		SystemProfile systemProfile ;

		string action ;

		public BuildUpdateOutputForm(SystemBuilder inputSystemBuilder, SystemProfile inputSystemProfile, string inputAction)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.closeButton.Enabled = false ;

			systemBuilder = inputSystemBuilder ;
			systemProfile = inputSystemProfile ;

			action = inputAction ;

			this.Activated +=new EventHandler(BuildUpdateOutputForm_Activated);
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
			this.outputListBox = new System.Windows.Forms.ListBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// outputListBox
			// 
			this.outputListBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.outputListBox.HorizontalScrollbar = true;
			this.outputListBox.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.outputListBox.ItemHeight = 11;
			this.outputListBox.Location = new System.Drawing.Point(20, 22);
			this.outputListBox.Name = "outputListBox";
			this.outputListBox.ScrollAlwaysVisible = true;
			this.outputListBox.Size = new System.Drawing.Size(700, 378);
			this.outputListBox.TabIndex = 0;
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(536, 417);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(106, 29);
			this.closeButton.TabIndex = 1;
			this.closeButton.Text = "Close";
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// BuildUpdateOutputForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(741, 480);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.outputListBox);
			this.Name = "BuildUpdateOutputForm";
			this.Text = "Build Distribution / Update";
			this.ResumeLayout(false);

		}
		#endregion

		private int getLineBreakPosition(string inputLine)
		{
			if ( inputLine.Length <= 256 ) return 256 ;

			for ( int i = 254 ; i >= (254-64) ; i-- )
			{
				char nextChar = inputLine[i] ;

				if ( Char.IsWhiteSpace(nextChar) ) return i + 1 ;
			}

			return 255 ;
		}

		public void addLines(string inputLineSet, string prefix)
		{
			ArrayList outputLineSet = new ArrayList() ;

			string[] outputLines = inputLineSet.Split('\n') ;

//			foreach (string outputLine in outputLines)
//			{
//				string outputLineX = prefix + outputLine ;
//
//				while ( true )
//				{
//					if ( outputLineX.Length <= 256 )
//					{
//						outputLineSet.Add(outputLineX) ;
//						break ;
//					}
//
//					int breakPosition = getLineBreakPosition(outputLineX) ;
//
//					outputLineSet.Add(outputLineX.Substring(0, breakPosition)) ;
//
//					outputLineX = prefix + " - " + outputLineX.Substring(breakPosition) ;
//				}
//			}

			foreach ( string outputLine in outputLines )
			{
				outputLineSet.Add(outputLine + "                ") ;
			}

			foreach (string outputLine in outputLineSet)
			{
				int returnPosition =  outputLine.IndexOf('\r') ;

				if ( returnPosition == 0 )
				{
					outputListBox.Items.Add(prefix) ;
				}

				else if ( returnPosition >  0 ) outputListBox.Items.Add(prefix + outputLine.Substring(0,returnPosition)) ; else
					outputListBox.Items.Add(prefix + outputLine) ;

				Application.DoEvents() ;
			}

			outputListBox.SelectedIndex = outputListBox.Items.Count - 1 ;
		}

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close() ;
		}

		public void addLines(string inputLineSet)
		{
			addLines(inputLineSet, "") ;
		}

		private bool buildUpdateOutputFormActivated = false ;

		private void BuildUpdateOutputForm_Activated(object sender, EventArgs e)
		{
			if ( buildUpdateOutputFormActivated ) return ;

			buildUpdateOutputFormActivated = true ;

			if ( ! Globals.SetupBuildSpecificDirectoryDefinitions(systemProfile) ) { this.Close() ; return ; }

			if ( action == "Build Distribution" )
			{
				BaseProjectBuilder      baseProjectBuilder      = new BaseProjectBuilder(systemBuilder, systemProfile) ;
				DependentFileBuilder    dependentFileBuilder    = new DependentFileBuilder(systemBuilder, systemProfile) ;
				DistributionFileBuilder distributionFileBuilder = new DistributionFileBuilder(systemBuilder, systemProfile) ;

				string outputCabFilePath = systemBuilder.distributionOutputFileTextBox.Text ;

				if ( ! baseProjectBuilder.buildBaseProject(this)           ) { closeButton.Enabled = true ; return ; }
				if ( ! dependentFileBuilder.buildDependentFiles(this)      ) { closeButton.Enabled = true ; return ; }
				if ( ! distributionFileBuilder.buildDistributionFile(this, outputCabFilePath) ) { closeButton.Enabled = true ; return ; }

				closeButton.Enabled = true ;
			} 
			else if ( action == "Build Update" )
			{
				BaseProjectBuilder      baseProjectBuilder      = new BaseProjectBuilder(systemBuilder, systemProfile) ;
				UpdateFileBuilder updateFileBuilder = new UpdateFileBuilder(systemBuilder, systemProfile) ;
				string outputCabFilePath = systemBuilder.updateOutputFileTextBox.Text ;

				if ( ! baseProjectBuilder.buildBaseProject(this)           ) { closeButton.Enabled = true ; return ; }
				if ( ! updateFileBuilder.buildUpdateFile(this, outputCabFilePath) ) { closeButton.Enabled = true ; return ; }
				closeButton.Enabled = true ;
			}
			else if ( action == "Build Migrate" )
			{
				BaseProjectBuilder      baseProjectBuilder      = new BaseProjectBuilder(systemBuilder, systemProfile) ;
				DependentFileBuilder    dependentFileBuilder    = new DependentFileBuilder(systemBuilder, systemProfile) ;
				MigrateFileBuilder migrateFileBuilder = new MigrateFileBuilder(systemBuilder, systemProfile) ;

				string outputCabFilePath = systemBuilder.migrateOutputFileTextbox.Text ;

				if (!baseProjectBuilder.buildBaseProject(this)) { closeButton.Enabled = true ; return ; }
				if (!dependentFileBuilder.buildDependentFiles(this)) { closeButton.Enabled = true ; return ; }
				if (!baseProjectBuilder.buildBaseProjectForMigrate(this)) { closeButton.Enabled = true; return; }
				if (!migrateFileBuilder.buildMigrateFile(this, outputCabFilePath)) { closeButton.Enabled = true ; return ; }

				closeButton.Enabled = true ;
			}
			else if ( action == "Build WebUpdate" )
			{
				BaseProjectBuilder      baseProjectBuilder      = new BaseProjectBuilder(systemBuilder, systemProfile) ;
				WebUpdateFileBuilder webUpdateFileBuilder = new WebUpdateFileBuilder(systemBuilder, systemProfile) ;
				DependentFileBuilder    dependentFileBuilder    = new DependentFileBuilder(systemBuilder, systemProfile) ;
				string outputCabFilePath = systemBuilder.webUpdateOutputFileTextbox.Text ;

				if ( ! baseProjectBuilder.buildBaseProject(this)           ) { closeButton.Enabled = true ; return ; }
				if ( !dependentFileBuilder.buildDependentFiles(this)) { closeButton.Enabled = true ; return ; }
				if ( ! webUpdateFileBuilder.buildWebUpdateFile(this, outputCabFilePath) ) { closeButton.Enabled = true ; return ; }

				closeButton.Enabled = true ;
			} 


		}
	}
}
