namespace Asi.Itb.UI
{
    partial class SyncProgressForm
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

            if (this._syncThread != null)
            {
                this._syncThread.Join();
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
            this.syncProgrssBar = new System.Windows.Forms.ProgressBar();
            this.syncProgressLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // syncProgrssBar
            // 
            this.syncProgrssBar.Location = new System.Drawing.Point(21, 137);
            this.syncProgrssBar.Name = "syncProgrssBar";
            this.syncProgrssBar.Size = new System.Drawing.Size(199, 26);
            // 
            // syncProgressLabel
            // 
            this.syncProgressLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.syncProgressLabel.Location = new System.Drawing.Point(3, 188);
            this.syncProgressLabel.Name = "syncProgressLabel";
            this.syncProgressLabel.Size = new System.Drawing.Size(234, 74);
            this.syncProgressLabel.Text = "Loading...";
            this.syncProgressLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // closeButton
            // 
            this.closeButton.Enabled = false;
            this.closeButton.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.closeButton.Location = new System.Drawing.Point(84, 265);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(72, 26);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SyncProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.syncProgressLabel);
            this.Controls.Add(this.syncProgrssBar);
            this.ExitPictureBoxVisible = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SyncProgressForm";
            this.Text = "SyncProgressForm";
            this.TitleLabelText = "Sync Progress";
            this.TitleLabelVisible = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar syncProgrssBar;
        private System.Windows.Forms.Label syncProgressLabel;
        private System.Windows.Forms.Button closeButton;
    }
}