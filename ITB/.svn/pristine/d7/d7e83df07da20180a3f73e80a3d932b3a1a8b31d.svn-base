using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.WindowsCE.Forms;

namespace AsiUpdater
{
    static class Program
    {
        private enum MenuOption : uint
        {
            CheckForUpdate = 1001,
            Exit = 1002
        }        
        
        [Flags]
        private enum MenuFlags : uint
        {
            MF_STRING = 0,
            MF_BYPOSITION = 0x400,
            MF_SEPARATOR = 0x800,
            MF_REMOVE = 0x1000,
        }

        [DllImport("coredll.dll", CharSet = CharSet.Auto)]
        static extern bool AppendMenu(IntPtr hMenu, MenuFlags uFlags, uint uIDNewItem, string lpNewItem);

        [DllImport("coredll.dll")]
        static extern IntPtr CreatePopupMenu();

        [DllImport("coredll.dll")]
        static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

        [DllImport("coredll.dll")]
        static extern bool DestroyMenu(IntPtr hMenu);


        [DllImport("coredll.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("coredll.dll")]
        static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("coredll.dll", EntryPoint = "SetForegroundWindow")]
        private static extern int SetForegroundWindow(IntPtr hWnd);


        public const string RequestRoot = "ItbRequest";

        public static OpenNETCF.Windows.Forms.NotifyIcon NtfyIcon;        
        public static UpgradeManager UpgradeMgr;
        public static DownloadManager DownloadMgr;

        // private static Thread ProgramThread;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            InitNotifyIcon();
            Cursor.Current = Cursors.Default;

            // Timer must be on the main thread
            UpgradeMgr = new UpgradeManager();
            DownloadMgr = new DownloadManager();

            UpgradeMgr.AddEventHandler(DownloadMgr);
            DownloadMgr.AddEventHandler(UpgradeMgr);

            UpgradeMgr.ErrorOccurred += new UpgradeManager.ErroOccurredEventArgs(ErrorOccurred);
            DownloadMgr.ErrorOccurred += new DownloadManager.ErroOccurredEventArgs(ErrorOccurred);

            UpgradeMgr.Start();            
            OpenNETCF.Windows.Forms.Application2.Run(true);            
        }        

        private static void ErrorOccurred()
        {
            ExitUpdater();
        }

        private static void DisplayMenu()
        {
            MessageWindow mw = new MessageWindow();
            IntPtr hmTrackPopup = CreatePopupMenu();

            /////////////////////////////////////////////////////////////////////////////////////////////////////            
            // MENU OPTION
            /////////////////////////////////////////////////////////////////////////////////////////////////////            
            AppendMenu(hmTrackPopup, MenuFlags.MF_STRING, (uint)MenuOption.Exit, "Exit ASI Updater");

            /////////////////////////////////////////////////////////////////////////////////////////////////////

            uint SelectedItemID = TrackPopupMenuEx(hmTrackPopup, 0x0100, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height - 38, mw.Hwnd, IntPtr.Zero);

            switch ((MenuOption)SelectedItemID)
            {
                case MenuOption.Exit:
                    if (NtfyIcon != null)
                    {
                        ExitUpdater();
                    }
                    break;
                default:
                    break;
            }

            DestroyMenu(hmTrackPopup);
            mw.Dispose();
        }        

        private static void NtfyIcon_Click(object sender, EventArgs e)
        {
            DisplayMenu();
        }

        private static void InitNotifyIcon()
        {
            NtfyIcon = new OpenNETCF.Windows.Forms.NotifyIcon();
            NtfyIcon.Icon = Properties.Resources.Icon1;
            NtfyIcon.Text = "ASI AutoUpdater";
            NtfyIcon.Visible = true;
            NtfyIcon.Click += new EventHandler(NtfyIcon_Click);
        }

        private static void ExitUpdater()
        {
            NtfyIcon.Visible = false;
            NtfyIcon.Dispose();

            if (UpgradeMgr != null)
            {
                UpgradeMgr.Dispose();
            }
            if (DownloadMgr != null)
            {
                DownloadMgr.Dispose();
            }            
            OpenNETCF.Windows.Forms.Application2.Exit();
        }
    }
}