#If False Then

Imports System
Imports System.Runtime.InteropServices

Public Class LockDown


    ' PInvoke wrappers

        [DllImport("user32", EntryPoint="ShowWindow",SetLastError=true)]
        internal static extern int ShowWindowFull(IntPtr hWnd, ShowWindowFlags nCmdShow);

        [DllImport("user32", EntryPoint="FindWindow",SetLastError=true)]
        internal static extern IntPtr FindWindowFull(string lpClassName, string lpWindowName);

        [DllImport("user32", EntryPoint="FindWindowEx",SetLastError=true)]
        internal static extern IntPtr FindWindowExFull(          
            IntPtr hwndParent,
            IntPtr hwndChildAfter,
            string lpszClass,
            string lpszWindow
            );

        [DllImport("user32", EntryPoint="SetWindowPos",SetLastError=true)]
        internal static extern int SetWindowPosFull(
            IntPtr hWnd, 
            SetWindowPosZOrder pos,
            int X, 
            int Y, 
            int cx, 
            int cy, 
            SetWindowPosFlags uFlags
            );

        [DllImport("user32", EntryPoint="GetWindowRect", SetLastError=true)]
        internal static extern bool GetWindowRectFull (
            IntPtr hwnd,
            ref RECT prc
            );

        [DllImport("coredll", EntryPoint="ShowWindow",SetLastError=true)]
        internal static extern int ShowWindowCF(IntPtr hWnd, ShowWindowFlags nCmdShow);

        [DllImport("coredll", EntryPoint="FindWindow",SetLastError=true)]
        internal static extern IntPtr FindWindowCF(string lpClassName, string lpWindowName);

        [DllImport("coredll", EntryPoint="FindWindowEx",SetLastError=true)]
        internal static extern IntPtr FindWindowExCF(          
            IntPtr hwndParent,
            IntPtr hwndChildAfter,
            string lpszClass,
            string lpszWindow
            );

        [DllImport("coredll", EntryPoint="SetWindowPos", SetLastError=true)]
        internal static extern int SetWindowPosCF(
            IntPtr hWnd, 
            SetWindowPosZOrder pos,
            int X, 
            int Y, 
            int cx, 
            int cy, 
            SetWindowPosFlags uFlags
            );

        [DllImport("coredll", EntryPoint="GetWindowRect", SetLastError=true)]
        internal static extern bool GetWindowRectCF (
            IntPtr hwnd,
            ref RECT prc
            );

        [DllImport("aygshell.dll", EntryPoint="SHFullScreen",SetLastError=true)]
        private static extern bool SHFullScreen(IntPtr hWnd, SHFullScreenState dwState);

        [ StructLayout( LayoutKind.Sequential )]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        } ;

            Public Enum SetWindowPosZOrder
        {
            HWND_TOP        =  0,
            HWND_BOTTOM     =  1,
            HWND_TOPMOST    = -1,
            HWND_NOTOPMOST  = -2,
            HWND_MESSAGE    = -3
        }

            Public Enum SetWindowPosFlags
        {
            SWP_NOSIZE          = 0x0001,
            SWP_NOMOVE          = 0x0002,
            SWP_NOZORDER        = 0x0004,
            SWP_NOREDRAW        = 0x0008,
            SWP_NOACTIVATE      = 0x0010,
            SWP_FRAMECHANGED    = 0x0020,
            SWP_SHOWWINDOW      = 0x0040,
            SWP_HIDEWINDOW      = 0x0080,
            SWP_NOCOPYBITS      = 0x0100,
            SWP_NOOWNERZORDER   = 0x0200,
            SWP_NOSENDCHANGING  = 0x0400,
            SWP_DRAWFRAME       = SWP_FRAMECHANGED,
            SWP_NOREPOSITION    = SWP_NOOWNERZORDER,
            SWP_DEFERERASE      = 0x2000,
            SWP_ASYNCWINDOWPOS  = 0x4000
        }

            Public Enum ShowWindowFlags
        {
            SW_HIDE           =  0,
            SW_SHOWNORMAL     =  1,
            SW_SHOWNOACTIVATE =  4,
            SW_SHOW           =  5,
            SW_MINIMIZE       =  6,
            SW_SHOWNA         =  8,
            SW_SHOWMAXIMIZED  = 11,
            SW_MAXIMIZE       = 12,
            SW_RESTORE        = 13
        }

            Public Enum SHFullScreenState : int
        {
            SHFS_SHOWTASKBAR   =  0x0001,
            SHFS_HIDETASKBAR   =  0x0002,
            SHFS_SHOWSIPBUTTON =  0x0004,
            SHFS_HIDESIPBUTTON =  0x0008,
            SHFS_SHOWSTARTICON =  0x0010,
            SHFS_HIDESTARTICON =  0x0020
        }

        //
        // Class Variables
        //
        static RECT rcTaskBar = new RECT();       // holds the coordinates for the taskbar
        static bool bDiscoveryDone = false;

            Public LockDown()
		{
            try
            {

                if (!bDiscoveryDone)
                {
                    UnitInformation.DiscoverUnitInformation();
                    bDiscoveryDone = true;
                }

                if (String.Compare(Environment.OSVersion.Platform.ToString(), "wince", true) == 0)
                {  // this is CE/PPC or CE/PPC emulation with .Net Compact Framework
//                    LockDownCF();
                    if (String.Compare(UnitInformation.PlatformType, "PocketPC", true) != 0)
                    {   // this is not Pocket PC but some other CE device
                        ShowTaskbarCF(false);
                        //ShowStartButtonCF(false);
                    }
                }
                else
                {  // this must be the desktop with full .Net framework
//                    LockDownFF();
                    ShowTaskbarFF(false);
                    ShowStartButtonFF(false);
                }
            }
            catch(Exception Ex)
            {
//                if (String.Compare(Ex.Message, "Unable to load DLL (coredll).", true) != 0)
                    MessageBox.Show(Ex.Message, "Lockdown Exception");
            }

		}  // end LockDown()

//        private void LockDownCF()
//        {
//            if (String.Compare(UnitInformation.PlatformType, "PocketPC", true) != 0)
//            {   // this is not Pocket PC but some other CE device
//                ShowTaskbarCF(false);
//                //ShowStartButtonCF(false);
//            }
//        }
//
//        private void LockDownFF()
//        {
//            ShowTaskbarFF(false);
//            ShowStartButtonFF(false);
//        }



        public void Unlock()
        {
            try
            {
                if (String.Compare(Environment.OSVersion.Platform.ToString(), "wince", true) == 0)
                {  // this is CE/PPC or CE/PPC emulation with .Net Compact Framework
                    if (String.Compare(UnitInformation.PlatformType, "PocketPC", true) != 0)
                    {   // this is not a Pocket PC device or emulation
                        ShowTaskbarCF(true);
                        //ShowStartButtonCF(true);
                    }
                }
                else
                {  // this must be the desktop with full .Net framework
                    ShowTaskbarFF(true);
                    ShowStartButtonFF(true);
                }
            }
            catch(Exception Ex)
            {
//                if (String.Compare(Ex.Message, "Unable to load DLL (coredll).", true) != 0)
                    MessageBox.Show(Ex.Message, "Unlock Exception");
            }
        }  // end Unlock()

        private void ShowTaskbarCF(bool bShow)
        {
            IntPtr piTrayWnd = FindWindowCF("HHTaskBar", "");

            if (rcTaskBar.bottom == 0)
            {
                // the bottom of the taskbar should only be 0 if we have not checked the position of the
                // taskbar before.  So check the position and save it off so it can be reset when we exit
                GetWindowRectCF(piTrayWnd, ref rcTaskBar);
            }

            if (bShow)
                SetWindowPosCF(piTrayWnd, 
                                SetWindowPosZOrder.HWND_TOP, 
                                rcTaskBar.left, 
                                rcTaskBar.top, 
                                rcTaskBar.bottom - rcTaskBar.top,   // setwindowpos takes height not ending coordinates
                                rcTaskBar.right  - rcTaskBar.left,  // setwindowpos takes width not ending coordinates
                                SetWindowPosFlags.SWP_SHOWWINDOW);  // show taskbar
            else
                SetWindowPosCF(piTrayWnd, SetWindowPosZOrder.HWND_TOP, 0, 0, 0, 0, SetWindowPosFlags.SWP_HIDEWINDOW);  // show taskbar
        }  // end ShowTaskbarCF()

        private void ShowStartButtonFF(bool bShow)
        {
            IntPtr piTrayWnd;
            IntPtr piButton;

            piTrayWnd = FindWindowFull("Shell_TrayWnd", "");
            piButton = FindWindowExFull(piTrayWnd, IntPtr.Zero, "Button", null);

            if (bShow)
                ShowWindowFull(piButton, ShowWindowFlags.SW_SHOW);   // show start button
            else
                ShowWindowFull(piButton, ShowWindowFlags.SW_HIDE);   // hide the start button
        }  // end ShowStartButtonFF()

        private void ShowTaskbarFF(bool bShow)
        {
            IntPtr piTrayWnd = FindWindowFull("Shell_TrayWnd", "");

            if (rcTaskBar.bottom == 0)
            {
                // the bottom of the taskbar should only be 0 if we have not checked the position of the
                // taskbar before.  So check the position and save it off so it can be reset when we exit
                GetWindowRectFull(piTrayWnd, ref rcTaskBar);
            }

            if (bShow)
                SetWindowPosFull(piTrayWnd, 
                    SetWindowPosZOrder.HWND_TOP, 
                    rcTaskBar.left, 
                    rcTaskBar.top, 
                    rcTaskBar.bottom - rcTaskBar.top,   // setwindowpos takes height not ending coordinates
                    rcTaskBar.right  - rcTaskBar.left,  // setwindowpos takes width not ending coordinates
                    SetWindowPosFlags.SWP_SHOWWINDOW);  // show taskbar
            else
                SetWindowPosFull(piTrayWnd, SetWindowPosZOrder.HWND_TOP, 0, 0, 0, 0, SetWindowPosFlags.SWP_HIDEWINDOW);  // show taskbar

        }  // end ShowTaskbarFF()

        private void ShowStartButtonCF(bool bShow)
        {
            int lastError;
            try
            {
                IntPtr piTrayWnd;
                IntPtr piButton;

                piTrayWnd = FindWindowCF("HHTaskBar", "");
                piButton = FindWindowExCF(piTrayWnd, IntPtr.Zero, "HHTaskBarTray", "");

                if (bShow)
                    ShowWindowCF(piButton, ShowWindowFlags.SW_SHOW);   // show start button
                else
                    ShowWindowCF(piButton, ShowWindowFlags.SW_HIDE);   // hide the start button
            }
            catch(Exception exSB)
            {
                lastError = Marshal.GetLastWin32Error();
                MessageBox.Show(exSB.Message, "Exception (ShowStartButtonCF)");
            }

        }  // end ShowStartButtonCF()

	}
}

        End Class

#End If
