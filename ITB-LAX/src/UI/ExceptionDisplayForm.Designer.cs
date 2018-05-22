namespace Asi.Itb.UI
{
    partial class ExceptionDisplayForm
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
            this.errorDetailTextBox = new System.Windows.Forms.TextBox();
            this.submitFogBugzButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // errorDetailTextBox
            // 
            this.errorDetailTextBox.Location = new System.Drawing.Point(0, 23);
            this.errorDetailTextBox.Multiline = true;
            this.errorDetailTextBox.Name = "errorDetailTextBox";
            this.errorDetailTextBox.ReadOnly = true;
            this.errorDetailTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errorDetailTextBox.Size = new System.Drawing.Size(237, 268);
            this.errorDetailTextBox.TabIndex = 0;
            // 
            // submitFogBugzButton
            // 
            this.submitFogBugzButton.Location = new System.Drawing.Point(25, 297);
            this.submitFogBugzButton.Name = "submitFogBugzButton";
            this.submitFogBugzButton.Size = new System.Drawing.Size(111, 20);
            this.submitFogBugzButton.TabIndex = 1;
            this.submitFogBugzButton.Text = "Report to ASI";
            this.submitFogBugzButton.Click += new System.EventHandler(this.submitFogBugzButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(143, 297);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(72, 20);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(240, 20);
            this.titleLabel.Text = "Error Detail";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ExceptionDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.submitFogBugzButton);
            this.Controls.Add(this.errorDetailTextBox);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "ExceptionDisplayForm";
            this.Text = "Error Detail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExceptionDisplayForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox errorDetailTextBox;
        private System.Windows.Forms.Button submitFogBugzButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label titleLabel;
    }
}