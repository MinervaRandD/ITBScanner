using System;
using System.IO ;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Security;
using System.Security.Permissions;

namespace sb
{
	/// <summary>
	/// Summary description for ProfileHistoryClass.
	/// </summary>
	public class ProfileHistoryClass
	{
		private sb.SystemBuilder systemBuilder ;

		private ArrayList profileHistoryList = new ArrayList() ;

		public ProfileHistoryClass(sb.SystemBuilder inputSystemBuilder)
		{
			systemBuilder = inputSystemBuilder ;

			RegistryKey tagTrakKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\TagTrak\ProfileHistory") ;
		
			RegistryPermission regPerm;

			string regKeyPath =  @"HKEY_CURRENT_USER\SOFTWARE\TagTrak\ProfileHistory" ;

			regPerm = new RegistryPermission(RegistryPermissionAccess.AllAccess, regKeyPath);
			regPerm.AddPathList(RegistryPermissionAccess.AllAccess, regKeyPath);

			loadProfileHistoryListFromRegistry() ;
		}

		public void update(string profilePath)
		{
			if ( this.profileHistoryList.Count <= 0 )
			{
				this.profileHistoryList.Add(profilePath) ;
				saveProfileHistoryListToRegistry();

				return ;
			}

			int itemIndex = -1 ;
			int ilmt ;
			
			ilmt = profileHistoryList.Count ;

			for ( int i = 1 ; i < ilmt ; i++ )
			{
				if ( (string) profileHistoryList[i] == profilePath )
				{
					itemIndex = i ; break ;
				}
			}

			if ( itemIndex > 0 ) profileHistoryList.RemoveAt(itemIndex) ;

			profileHistoryList.Insert(0, profilePath) ;

			this.saveProfileHistoryListToRegistry() ;

			return ;
		}

		private void loadProfileHistoryListFromRegistry()
		{
			this.profileHistoryList.Clear() ;

			RegistryKey tagTrakKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TagTrak\ProfileHistory") ;

			RegistryPermission regPerm;

			string regKeyPath =  @"HKEY_CURRENT_USER\SOFTWARE\TagTrak\ProfileHistory" ;
			regPerm = new RegistryPermission(RegistryPermissionAccess.AllAccess, regKeyPath);
			regPerm.AddPathList(RegistryPermissionAccess.AllAccess, regKeyPath);
			
			systemBuilder.recentProfilesMenuItem.MenuItems.Clear() ;
			
			for ( int i = 0 ; i < 16 ; i++ )
			{
				string profileElement = "Profile" + i.ToString().PadLeft(2,'0') ;
				string profileFilePath = (string) tagTrakKey.GetValue(profileElement) ;

				if ( Utilities.isNonNullString(profileFilePath) )
				{
					System.Windows.Forms.MenuItem profilePathMenuItem = new MenuItem(profileFilePath) ;
					systemBuilder.recentProfilesMenuItem.MenuItems.Add(profilePathMenuItem) ;

					profilePathMenuItem.Click +=new EventHandler(profilePathMenuItem_Click);

					profileHistoryList.Add(profileFilePath) ;
				}
			}

			tagTrakKey.Close();
		}

		private void saveProfileHistoryListToRegistry()
		{
			RegistryKey tagTrakKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\TagTrak\ProfileHistory", true) ;

			systemBuilder.recentProfilesMenuItem.MenuItems.Clear() ;

			for ( int i = 0 ; i < 16 ; i++ )
			{
				string profileElement = "Profile" + i.ToString().PadLeft(2,'0') ;

				if ( i < this.profileHistoryList.Count )
				{
					tagTrakKey.SetValue(profileElement, this.profileHistoryList[i]) ;

					System.Windows.Forms.MenuItem profilePathMenuItem = new MenuItem((string) profileHistoryList[i]) ;
					systemBuilder.recentProfilesMenuItem.MenuItems.Add(profilePathMenuItem) ;
				}

				else
				{
					tagTrakKey.SetValue(profileElement, "") ;
				}
			}

			tagTrakKey.Close();
		}

		public string GetLastProfilePath()
		{
			if ( profileHistoryList.Count > 0 )
			{
				return (string) profileHistoryList[0] ;
			}

			else
			{
				return null ;
			}
		}

		private void profilePathMenuItem_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.MenuItem profileMenuItem = (System.Windows.Forms.MenuItem) sender ;

			string profileFilePath = profileMenuItem.Text ;

			systemBuilder.systemProfile.loadProfile(profileFilePath) ;

			update(profileFilePath) ;
		}
	}
}
