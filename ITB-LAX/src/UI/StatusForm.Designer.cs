namespace Asi.Itb.UI
{
    partial class StatusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.changeStatusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.statusLabel.Location = new System.Drawing.Point(58, 94);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(124, 25);
            this.statusLabel.Text = "I am:";
            // 
            // statusComboBox
            // 
            this.statusComboBox.Items.Add("Normal");
            this.statusComboBox.Items.Add("Tug Blocked");
            this.statusComboBox.Items.Add("Tug Broken");
            this.statusComboBox.Location = new System.Drawing.Point(58, 132);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(124, 22);
            this.statusComboBox.TabIndex = 4;
            // 
            // changeStatusButton
            // 
            this.changeStatusButton.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.changeStatusButton.Location = new System.Drawing.Point(58, 205);
            this.changeStatusButton.Name = "changeStatusButton";
            this.changeStatusButton.Size = new System.Drawing.Size(124, 31);
            this.changeStatusButton.TabIndex = 5;
            this.changeStatusButton.Text = "Change Status";
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.changeStatusButton);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.statusLabel);
            this.ExitPictureBoxVisible = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "StatusForm";
            this.Text = "StatusForm";
            this.TitleLabelText = "Status Updates";
            this.TitleLabelVisible = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.statusLabel, 0);
            this.Controls.SetChildIndex(this.statusComboBox, 0);
            this.Controls.SetChildIndex(this.changeStatusButton, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Button changeStatusButton;
    }
}