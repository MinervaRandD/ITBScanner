using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TagTrak.TagTrakLib
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();

            // Center on screen
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(Color.Black), 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
        }
    }
}