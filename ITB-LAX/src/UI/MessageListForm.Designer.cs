namespace Asi.Itb.UI
{
    partial class MessageListForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem();
            this.messagesListView = new System.Windows.Forms.ListView();
            this.subjectHeader = new System.Windows.Forms.ColumnHeader();
            this.timeHeader = new System.Windows.Forms.ColumnHeader();
            this.composeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // messagesListView
            // 
            this.messagesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.messagesListView.Columns.Add(this.subjectHeader);
            this.messagesListView.Columns.Add(this.timeHeader);
            this.messagesListView.FullRowSelect = true;
            listViewItem1.Text = "Demo Message 1";
            listViewItem2.Text = "Demo Message 2";
            listViewItem3.Checked = true;
            listViewItem3.Text = "Demo Messge 3";
            listViewItem4.Text = "Demo Message 4";
            this.messagesListView.Items.Add(listViewItem1);
            this.messagesListView.Items.Add(listViewItem2);
            this.messagesListView.Items.Add(listViewItem3);
            this.messagesListView.Items.Add(listViewItem4);
            this.messagesListView.Location = new System.Drawing.Point(3, 92);
            this.messagesListView.Name = "messagesListView";
            this.messagesListView.Size = new System.Drawing.Size(234, 225);
            this.messagesListView.TabIndex = 3;
            this.messagesListView.View = System.Windows.Forms.View.Details;
            this.messagesListView.ItemActivate += new System.EventHandler(this.messagesListView_ItemActivate);
            // 
            // subjectHeader
            // 
            this.subjectHeader.Text = "Subject";
            this.subjectHeader.Width = 141;
            // 
            // timeHeader
            // 
            this.timeHeader.Text = "Time";
            this.timeHeader.Width = 87;
            // 
            // composeLinkLabel
            // 
            this.composeLinkLabel.Enabled = false;
            this.composeLinkLabel.Location = new System.Drawing.Point(3, 69);
            this.composeLinkLabel.Name = "composeLinkLabel";
            this.composeLinkLabel.Size = new System.Drawing.Size(111, 20);
            this.composeLinkLabel.TabIndex = 4;
            this.composeLinkLabel.Text = "Compose Message";
            // 
            // MessageListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.composeLinkLabel);
            this.Controls.Add(this.messagesListView);
            this.ExitPictureBoxVisible = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MessageListForm";
            this.Text = "MessageListForm";
            this.TitleLabelText = "Messages";
            this.TitleLabelVisible = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView messagesListView;
        private System.Windows.Forms.ColumnHeader subjectHeader;
        private System.Windows.Forms.ColumnHeader timeHeader;
        private System.Windows.Forms.LinkLabel composeLinkLabel;
    }
}