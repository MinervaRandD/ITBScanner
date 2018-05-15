using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Asi.Itb.UI
{
    public partial class BaseForm : StackForm
    {
        public BaseForm()
        {
            InitializeComponent();

            string imageFilePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\images\logo.png";
            this.logoPictureBox.Image = new Bitmap(imageFilePath);
        }

        private void exitPictureBox_Click(object sender, EventArgs e)
        {
            Program.formStack.Pop(1, false);
        }

        public string TitleLabelText
        {
            get
            {
                return this.titleLabel.Text;
            }
            set
            {
                this.titleLabel.Text = value;
            }
        }

        public bool TitleLabelVisible
        {
            get
            {
                return this.titleLabel.Visible;
            }
            set
            {
                this.titleLabel.Visible = value;
            }
        }

        public bool ExitPictureBoxVisible
        {
            get
            {
                return this.exitPictureBox.Visible;
            }
            set
            {
                this.exitPictureBox.Visible = value;
            }
        }
    }
}