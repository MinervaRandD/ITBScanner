using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;	
using System.Reflection;

namespace TagTrak.TagTrakLib
{
	/// <summary>
	/// Form showing flight schedules for current location
	/// </summary>
	public class FlightsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private DataGridTextBoxColumn dataGridTextBoxColumn6;
        private DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
	
		public FlightsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			BindingFlags flags = BindingFlags.FlattenHierarchy | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
			FieldInfo fiCyRow = dataGrid1.GetType().GetField("m_cyRow", flags);
			fiCyRow.SetValue(dataGrid1, 30);

			this.populateFlightsView();
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
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.refreshButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(224, 252);
            this.dataGrid1.TabIndex = 2;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            this.dataGridTableStyle1.MappingName = "flights";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Flt";
            this.dataGridTextBoxColumn3.MappingName = "full_flight_number";
            this.dataGridTextBoxColumn3.Width = 40;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Org";
            this.dataGridTextBoxColumn1.MappingName = "origin";
            this.dataGridTextBoxColumn1.Width = 25;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Dst";
            this.dataGridTextBoxColumn2.MappingName = "destination";
            this.dataGridTextBoxColumn2.Width = 25;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Depart";
            this.dataGridTextBoxColumn4.MappingName = "depart_time";
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Gate";
            this.dataGridTextBoxColumn6.MappingName = "depart_gate";
            this.dataGridTextBoxColumn6.Width = 30;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Arrive";
            this.dataGridTextBoxColumn5.MappingName = "arrive_time";
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Gate";
            this.dataGridTextBoxColumn7.MappingName = "arrive_gate";
            this.dataGridTextBoxColumn7.Width = 30;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(48, 266);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(72, 20);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(144, 266);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(72, 20);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // FlightsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.dataGrid1);
            this.Name = "FlightsForm";
            this.Text = "Flights";
            this.ResumeLayout(false);

		}
		#endregion

		private void closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void refreshButton_Click(object sender, System.EventArgs e)
		{
            ConfigSetting config = ConfigSetting.Instance();

            try
            {
                Flights.Update(config.Carrier, config.Location);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to retrieve flights:\n" + ex.Message, "TagTrak", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

			this.populateFlightsView();
		}

		private void populateFlightsView()
		{
            Loading lUI = new Loading();
            lUI.Show();

            lUI.Update();
            DeviceUI.HideStartButton(false);

            ConfigSetting config = ConfigSetting.Instance();

            try
            {
                dataGrid1.DataSource = Flights.GetCurrentFlights(config.Carrier, config.Location);
                dataGrid1.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to retrieve flights:\n" + ex.Message, "TagTrak", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }


            lUI.Hide();
		}
	}
}
