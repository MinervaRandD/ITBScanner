using System.Runtime.InteropServices;
using System;

namespace TagTrak.TagTrakLib
{
	public class DeviceUI
	{

		[DllImport("coredll.dll", EntryPoint="GetForegroundWindow", SetLastError=true)]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("aygshell.dll", EntryPoint="SHFullScreen", SetLastError=true)]
		private static extern bool SHFullScreen(IntPtr hwndRequester, int dwState);

        private enum SHFullScreenState : int
        {
            SHFS_SHOWTASKBAR   =  0x0001,
            SHFS_HIDETASKBAR   =  0x0002,
            SHFS_SHOWSIPBUTTON =  0x0004,
            SHFS_HIDESIPBUTTON =  0x0008,
            SHFS_SHOWSTARTICON =  0x0010,
            SHFS_HIDESTARTICON =  0x0020
        }
        
		private static IntPtr lastHwnd;

		private static bool SetStartButtonVisible(bool visible, bool newWindowOnly)
		{
			IntPtr hwnd = GetForegroundWindow();
			if (newWindowOnly & hwnd.Equals(lastHwnd)) 
			{
				return true;
			}
			lastHwnd = hwnd;
			if (!(hwnd.Equals(IntPtr.Zero))) 
			{
				if (visible) 
				{
                    return SHFullScreen(hwnd, (int)SHFullScreenState.SHFS_SHOWSTARTICON);
				} 
				else 
				{
                    return SHFullScreen(hwnd, (int)SHFullScreenState.SHFS_HIDESTARTICON);
				}
			}
			return true;
		}

        private static bool SetSipVisible(bool visible, bool newWindowOnly)
        {
            IntPtr hwnd = GetForegroundWindow();
            if (newWindowOnly & hwnd.Equals(lastHwnd))
            {
                return true;
            }
            lastHwnd = hwnd;
            if (!(hwnd.Equals(IntPtr.Zero)))
            {
                if (visible)
                {
                    return SHFullScreen(hwnd, (int)SHFullScreenState.SHFS_SHOWSIPBUTTON);
                }
                else
                {
                    return SHFullScreen(hwnd, (int)SHFullScreenState.SHFS_HIDESIPBUTTON);
                }
            }
            return true;
        }

		public static void HideStartButton(bool newWindowOnly)
		{
			SetStartButtonVisible(false, newWindowOnly);
		}

		public static void ShowStartButton(bool newWindowOnly)
		{
			SetStartButtonVisible(true, newWindowOnly);
		}

        public static void HideSip(bool newWindowOnly)
        {
            SetSipVisible(false, newWindowOnly);
        }

        public static void ShowSip(bool newWindowOnly)
        {
            SetSipVisible(true, newWindowOnly);
        }

	}
}
