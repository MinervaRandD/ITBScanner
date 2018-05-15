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
    public partial class MessageListForm : BaseForm
    {
        private List<Message> _messages;

        public MessageListForm()
        {
        }

        public override void Initialize()
        {
            base.Initialize();
            InitializeComponent();
        }

        public override void LoadData()
        {
            base.LoadData();

            MessageManager mgr = new MessageManager();
            _messages = mgr.GetMessages(false);
        }

        public override void Populate()
        {
            base.Populate();

            this.messagesListView.Items.Clear();
            foreach (Message msg in _messages)
            {
                ListViewItem item = new ListViewItem(new string[]{msg.Subject, msg.MessageTime.ToLocalTime().ToString()});
                item.Tag = msg;
                if (msg.IsRead)
                {
                    item.ForeColor = Color.Gray;
                }
                else
                {
                    item.ForeColor = Color.Black;
                }
                this.messagesListView.Items.Add(item);
            }
        }

        private void messagesListView_ItemActivate(object sender, EventArgs e)
        {
            if (this.messagesListView.SelectedIndices.Count > 0)
            {
                int selectedIndex = this.messagesListView.SelectedIndices[0];
                if (selectedIndex >= 0 && this.messagesListView.Items.Count > selectedIndex)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    ListViewItem curItem = this.messagesListView.Items[selectedIndex];
                    SessionData.Current.Message = curItem.Tag as Message;

                    Program.formStack.Push(typeof(MessageDetailForm), true);

                    if (!SessionData.Current.Message.IsRead)
                    {
                        MessageManager mgr = new MessageManager();
                        mgr.MarkMessageRead(SessionData.Current.Message.Id);

                        curItem.ForeColor = Color.Gray;
                    }

                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}