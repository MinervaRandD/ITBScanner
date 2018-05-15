using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Asi.Itb.Bll;

namespace Asi.Itb.UI
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();

            string imageFilePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\images\splash.png";
            backgroundPictureBox.Image = new Bitmap(imageFilePath);
        }

        public void KillMe(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}