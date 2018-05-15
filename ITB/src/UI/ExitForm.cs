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
    public partial class ExitForm : BaseForm
    {
        public ExitForm()
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
            this.exitCodeTextBox.Text = string.Empty;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            UserManager mgr = new UserManager();

            if (mgr.IsValidExitCode(this.exitCodeTextBox.Text))
            {
                Cursor.Current = Cursors.WaitCursor;

                DatabaseManager.CloseConnection();
                Program.formStack.Stop();

                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Invalid exit code.", "Invalid Input");
            }
        }
    }
}