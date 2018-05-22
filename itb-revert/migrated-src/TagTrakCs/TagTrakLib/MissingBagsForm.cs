using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;	
using System.Reflection;
using System.Data;

namespace TagTrak.TagTrakLib
{
	/// <summary>
	/// Form showing flight schedules for current location
	/// </summary>
	public class MissingBagsForm : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.DataGrid dataGridMain;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private Label labelFlightInfo;
        private NumericUpDown numericUpDownFlightNumber;
        private Button buttonGet;
        private Label labelTitle;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private MainMenu mainMenu1;
        private Label labelLoadInfo;

        private static int? _DefaultFlightNumber = null;
        public static int? DefaultFlightNumber
        {
            set
            {
                _DefaultFlightNumber = value;
            }
        }

        public MissingBagsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			BindingFlags flags = BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
			FieldInfo fiCyRow = dataGridMain.GetType().GetField("m_cyRow", flags);
			fiCyRow.SetValue(dataGridMain, 30);
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
            this.dataGridMain = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.closeButton = new System.Windows.Forms.Button();
            this.labelFlightInfo = new System.Windows.Forms.Label();
            this.numericUpDownFlightNumber = new System.Windows.Forms.NumericUpDown();
            this.buttonGet = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.labelLoadInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dataGridMain
            // 
            this.dataGridMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGridMain.Location = new System.Drawing.Point(8, 55);
            this.dataGridMain.Name = "dataGridMain";
            this.dataGridMain.Size = new System.Drawing.Size(224, 169);
            this.dataGridMain.TabIndex = 2;
            this.dataGridMain.TableStyles.Add(this.dataGridTableStyle1);
            this.dataGridMain.Visible = false;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.MappingName = "flights";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Status";
            this.dataGridTextBoxColumn3.MappingName = "status";
            this.dataGridTextBoxColumn3.Width = 40;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Details";
            this.dataGridTextBoxColumn1.MappingName = "status_details";
            this.dataGridTextBoxColumn1.Width = 180;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(80, 230);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(72, 31);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // labelFlightInfo
            // 
            this.labelFlightInfo.Location = new System.Drawing.Point(8, 29);
            this.labelFlightInfo.Name = "labelFlightInfo";
            this.labelFlightInfo.Size = new System.Drawing.Size(95, 18);
            this.labelFlightInfo.Text = "Flight Number:";
            // 
            // numericUpDownFlightNumber
            // 
            this.numericUpDownFlightNumber.Location = new System.Drawing.Point(110, 27);
            this.numericUpDownFlightNumber.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownFlightNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFlightNumber.Name = "numericUpDownFlightNumber";
            this.numericUpDownFlightNumber.Size = new System.Drawing.Size(66, 22);
            this.numericUpDownFlightNumber.TabIndex = 0;
            this.numericUpDownFlightNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(183, 27);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(49, 20);
            this.buttonGet.TabIndex = 1;
            this.buttonGet.Text = "Get";
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(8, 4);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(224, 20);
            this.labelTitle.Text = "Missing Bags";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelLoadInfo
            // 
            this.labelLoadInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLoadInfo.Enabled = false;
            this.labelLoadInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this.labelLoadInfo.Location = new System.Drawing.Point(8, 99);
            this.labelLoadInfo.Name = "labelLoadInfo";
            this.labelLoadInfo.Size = new System.Drawing.Size(224, 20);
            this.labelLoadInfo.Text = "Enter flight number and tap Get";
            this.labelLoadInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MissingBagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.labelLoadInfo);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonGet);
            this.Controls.Add(this.numericUpDownFlightNumber);
            this.Controls.Add(this.labelFlightInfo);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.dataGridMain);
            this.Menu = this.mainMenu1;
            this.Name = "MissingBagsForm";
            this.Text = "Missing Bags";
            this.Load += new System.EventHandler(this.MissingBagsForm_Load);
            this.ResumeLayout(false);

		}
		#endregion

        private void MissingBagsForm_Load(object sender, EventArgs e)
        {
            if (_DefaultFlightNumber != null)
            {
                numericUpDownFlightNumber.Value = (int)_DefaultFlightNumber.Value;
                populateMissingBagsView();
            }
            else
            {
                numericUpDownFlightNumber.Value = 1;
            }
        }

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void populateMissingBagsView()
		{
            Loading lUI = new Loading();
            lUI.Show();
            
            lUI.Update();
            DeviceUI.HideStartButton(false);

            ConfigSetting config = ConfigSetting.Instance();

            try
            {
                dataGridMain.DataSource = MissingBags.GetDataTable(config.Carrier, config.Location, (int)numericUpDownFlightNumber.Value);
                dataGridMain.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to retrieve missing bags:\n" + ex.Message, "TagTrak", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            lUI.Hide();

            labelLoadInfo.Visible = false;
            dataGridMain.Visible = true;
		}

        private void buttonGet_Click(object sender, EventArgs e)
        {
            populateMissingBagsView();
        }
	}
}
