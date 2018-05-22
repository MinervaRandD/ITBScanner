using TagTrak.TagTrakLib;
using System.Collections;
using System.Windows.Forms;

namespace TagTrak.TagTrakLib
{
	internal class NavigationMainMenu : System.Windows.Forms.MenuItem
	{
		private MenuItem aboutMenuItem;
		private MenuItem warmBootMenuItem;
		private MenuItem logoutMenuItem;
		private static Hashtable itemModuleMap = new Hashtable();
		private static ArrayList itemList = new ArrayList();
		public static event MenuItemChangedEventHandler ItemChanged;

		public static void AddNewForm(Form frm, string title)
		{
			itemModuleMap.Add(title, frm);
			itemList.Add(title);
		}

		public static void RefreshItems()
		{
			if (ItemChanged != null) 
			{
				ItemChanged();
			}
		}

		public static void ClearModules()
		{
			itemModuleMap.Clear();
			itemList.Clear();
		}

		public NavigationMainMenu()
		{
			aboutMenuItem = new MenuItem();
			warmBootMenuItem = new MenuItem();
			logoutMenuItem = new MenuItem();
			Text = "Start";
			warmBootMenuItem.Text = "Warm Boot";
			aboutMenuItem.Text = "About TagTrak";
			logoutMenuItem.Text = "Log Out";
			loadMenuItems();
		}

		private void aboutMenuItem_Click(object sender, System.EventArgs e)
		{
			string aboutMsg = "ASI TagTrak Scanning Program";
			aboutMsg += "\r\n" + "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			aboutMsg += "\r\n" + "Copyright Aviation Software, Inc. 2004-2007";
			MessageBox.Show(aboutMsg, "About TagTrak");
		}

		private void warmBootMenuItem_Click(object sender, System.EventArgs e)
		{
            Hardware.Device.WarmBoot();
		}

		private void loadMenuItems()
		{
			MenuItems.Clear();
			foreach (string mItem in itemList) 
			{
				MenuItem newItem = new MenuItem();
				newItem.Text = mItem;
				newItem.Click += new System.EventHandler(moduleMenuItem_Click);
				MenuItems.Add(newItem);
			}
			MenuItems.Add(warmBootMenuItem);
			MenuItems.Add(aboutMenuItem);
			MenuItems.Add(logoutMenuItem);

			aboutMenuItem.Click += new System.EventHandler(aboutMenuItem_Click);

			warmBootMenuItem.Click += new System.EventHandler(warmBootMenuItem_Click);

			logoutMenuItem.Click += new System.EventHandler(logoutMenuItem_Click);
		}

		private void moduleMenuItem_Click(object sender, System.EventArgs e)
		{
			Form frm = (Form) itemModuleMap[((MenuItem) sender).Text];
			if (!(frm == null)) 
			{
				frm.Show();
				DeviceUI.HideStartButton(false);
			}
		}

		private void logoutMenuItem_Click(object sender, System.EventArgs e)
		{
			LogInForm frm = new LogInForm();
			frm.Show();
		}
	}

	public delegate void MenuItemChangedEventHandler();
}
