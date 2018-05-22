using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Asi.Itb.Bll;
using Asi.Itb.Bll.Entities;

namespace Asi.Itb.UI
{
    public partial class MessageDetailForm : BaseForm
    {
        public MessageDetailForm()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeComponent();
        }

        public override void Populate()
        {
            base.Populate();

            Message msg = SessionData.Current.Message;
            if (msg != null)
            {
                this.subjectTextLabel.Text = msg.Subject;
                this.TimeTextLabel.Text = msg.MessageTime.ToLocalTime().ToString();
                this.contentTextBox.Text = msg.Content;
            }
        }

        private void deleteLinkLabel_Click(object sender, EventArgs e)
        {
            Message msg = SessionData.Current.Message;
            if (msg != null)
            {
                MessageManager mgr = new MessageManager();
                mgr.DeleteMessage(msg.Id);
            }

            Program.formStack.Pop(1, true);
        }
    }
}