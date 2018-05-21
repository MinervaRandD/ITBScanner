using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Asi.Itb;
using Asi.Itb.Bll;
using Asi.Itb.Bll.Entities;

namespace Asi.Itb.UI
{
    public partial class LoginForm : BaseForm
    {
        private static SplashForm splash;

        public LoginForm()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            InitializeComponent();

            this.ExitPictureBoxVisible = false; // have to do it here since designer not working properly

#if DEBUG
            string release = "D";
#else
            string release = "P";
#endif
            this.versionLabel.Text = string.Format("Version: {0} {1}",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                release
                );
        }

        public override void Populate()
        {
            this.usernameTextBox.Text = string.Empty;
            this.passwordTextBox.Text = string.Empty;

            base.Populate();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Program.InitializeIdleTimeOut();

            Cursor.Current = Cursors.WaitCursor;

            UserManager umgr = new UserManager();

            int nmbrOfActs = umgr.GetActivities().Count();

            if (nmbrOfActs >= 100)
            {
                MessageBox.Show("The database file on this device is too large and will not correctly sync. Please contact your systems administrator.");

                DatabaseManager.CloseConnection();
                Program.formStack.Stop();

                System.Diagnostics.Process.GetCurrentProcess().Kill();
                
            }

            Bll.Entities.User user = umgr.Authenticate(this.usernameTextBox.Text, this.passwordTextBox.Text);

            if (user != null)
            {
                SessionData.Current.User = user;
                Program.formStack.Push(typeof(ScanForm), true);
                umgr.SaveActivity(user.UserName, UserActivityType.LogIn);
                Cursor.Current = Cursors.Default;
            }
            else
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Invalid username/password.", "Login Error");
            }

            Dal.SyncLogManager.init(Configuration.Instance.SyncErrorLogging);
        }

        private void syncMenuItem_Click(object sender, EventArgs e)
        {
            Program.formStack.Push(typeof(SyncProgressForm), true);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Program.formStack.Push(typeof(ExitForm), true);
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            Thread splashThread = new Thread(new ThreadStart(StartSplash));
            splashThread.Start();

            while (splash == null)
            {
                Thread.Sleep(1000);
            }

            DatabaseManager.OpenConnection();

            CloseSplash();
        }

        public static void StartSplash()
        {
            splash = new SplashForm();
            Application.Run(splash);
        }

        private void CloseSplash()
        {
            if (splash == null)
            {
                return;
            }

            splash.Invoke(new EventHandler(splash.KillMe));
            splash.Dispose();
            splash = null;
        }

        /// <summary>
        /// Paint the form only if the splash screen is gone
        /// </summary>
        /// <param name="e">Paint event arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (splash != null)
                return;

            base.OnPaint(e);
        }

        /// <summary>
        /// Paint the form background only if the splash screen is gone
        /// </summary>
        /// <param name="e">Paint event arguments</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (splash != null)
                return;

            base.OnPaintBackground(e);
        }

        /// <summary>
        /// Ensures that if the form is somehow closed before loading is complete,
        /// the splash form will be closed and released as well.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Make sure the splash screen is closed
            CloseSplash();

            base.OnClosing(e);
        }
    }
}