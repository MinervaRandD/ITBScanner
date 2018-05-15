namespace RequestTester
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnTestLegacyRequest = new System.Windows.Forms.Button();
            this.btnTestUpdatedRequest = new System.Windows.Forms.Button();
            this.txbResults = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTestLegacyRequest
            // 
            this.btnTestLegacyRequest.Location = new System.Drawing.Point(47, 14);
            this.btnTestLegacyRequest.Name = "btnTestLegacyRequest";
            this.btnTestLegacyRequest.Size = new System.Drawing.Size(158, 20);
            this.btnTestLegacyRequest.TabIndex = 0;
            this.btnTestLegacyRequest.Text = "Test Legacy Request";
            this.btnTestLegacyRequest.Click += new System.EventHandler(this.btnTestLegacyRequest_Click);
            // 
            // btnTestUpdatedRequest
            // 
            this.btnTestUpdatedRequest.Location = new System.Drawing.Point(47, 53);
            this.btnTestUpdatedRequest.Name = "btnTestUpdatedRequest";
            this.btnTestUpdatedRequest.Size = new System.Drawing.Size(158, 20);
            this.btnTestUpdatedRequest.TabIndex = 1;
            this.btnTestUpdatedRequest.Text = "Test Updated Request";
            // 
            // txbResults
            // 
            this.txbResults.AcceptsReturn = true;
            this.txbResults.AcceptsTab = true;
            this.txbResults.Location = new System.Drawing.Point(21, 84);
            this.txbResults.Multiline = true;
            this.txbResults.Name = "txbResults";
            this.txbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbResults.Size = new System.Drawing.Size(195, 163);
            this.txbResults.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.txbResults);
            this.Controls.Add(this.btnTestUpdatedRequest);
            this.Controls.Add(this.btnTestLegacyRequest);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Request Tester";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestLegacyRequest;
        private System.Windows.Forms.Button btnTestUpdatedRequest;
        private System.Windows.Forms.TextBox txbResults;
    }
}

