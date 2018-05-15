using System.Data.SqlServerCe;
using System.Collections;
using System.Drawing;
using System;
using System.Data;
using System.Reflection;

namespace TagTrak.TagTrakLib
{
	public class ConfigSetting
	{
		private static ConfigSetting singlet;
		private string carrierCode;
		private bool bzOnScan;
		private int bzLen;
		private bool bpOnScan;
		private string loc;
		private ArrayList cityLst = new ArrayList();
		private bool showKbOnfocus =  false;
		private string employNo = null;
		private bool lockdown = true;
		private bool continuesScan = true;

		public event CarrierChangedEventHandler CarrierChanged;
		public event LocationChangedEventHandler LocationChanged;
		public event LoggedOutEventHandler LoggedOut;
		public static event EventHandler ProgramExit;
		private SqlCeCommand updateCommand;

		public string Carrier 
		{
			get 
			{
				return carrierCode;
			}
			set 
			{
				carrierCode = value;
				cityLst = DbAccess.GetCityList(carrierCode);
				if (CarrierChanged != null) 
				{
					CarrierChanged();
				}

				SaveToDb();
			}
		}

		private ConfigSetting()
		{
			LoadFromDb();
		}

		private void LoadFromDb()
		{
			SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();

			cmd.CommandText = "select cf.last_carrier" +
				", cf.last_city" +
				", cf.buzz_on_scan" +
				", cf.buzz_length" +
				", cf.beep_on_scan" +
				", cf.show_keyboard_on_focus" +
				" from config cf"
				;

			SqlCeDataReader reader = cmd.ExecuteReader();

			if (reader.Read())
			{
				if (!reader.IsDBNull(0)) 
				{
					this.carrierCode = reader.GetString(0);
				}
				if (!reader.IsDBNull(1)) 
				{
					this.loc = reader.GetString(1);
				}
				if (!reader.IsDBNull(2)) 
				{
					this.bzOnScan = reader.GetBoolean(2);
				}
				if (!reader.IsDBNull(3)) 
				{
					this.bzLen = reader.GetInt32(3);
				}
				if (!reader.IsDBNull(4)) 
				{
					this.bpOnScan = reader.GetBoolean(4);
				}
				if (!reader.IsDBNull(5)) 
				{
					this.showKbOnfocus = reader.GetBoolean(5);
				}
			}
		}

		
		private void PrepareUpdateCommand()
		{
			updateCommand = DbAccess.OpenConnection.CreateCommand();

			updateCommand.CommandText = "update config set last_city = ?" +
				", last_carrier = ?" +
				", buzz_on_scan = ?" +
				", buzz_length = ?" +
				", beep_on_scan = ?" +
				", show_keyboard_on_focus = ?" 
				;

			SqlCeParameterCollection pars = updateCommand.Parameters;

			pars.Add(new SqlCeParameter("lastCityCode", DbType.String));
			pars.Add(new SqlCeParameter("lastCarrierCode", DbType.String));
			pars.Add(new SqlCeParameter("buzzOnScan", DbType.Boolean));
			pars.Add(new SqlCeParameter("buzzLength", DbType.Int32));
			pars.Add(new SqlCeParameter("beepOnScan", DbType.Boolean));
			pars.Add(new SqlCeParameter("showKeyboardOnFocus", DbType.Boolean));

			pars["lastCityCode"].Size = 3;
			pars["lastCarrierCode"].Size = 2;
			pars["buzzOnScan"].Size = 1;
			pars["buzzLength"].Size = 32;
			pars["beepOnScan"].Size = 1;
			pars["showKeyboardOnFocus"].Size = 1;

			pars["buzzOnScan"].IsNullable = true;
			pars["buzzLength"].IsNullable = true;
			pars["beepOnScan"].IsNullable = true;
			pars["showKeyboardOnFocus"].IsNullable = true;
			pars["lastCityCode"].IsNullable = true;
			pars["lastCarrierCode"].IsNullable = true;

			updateCommand.Prepare();
		}

		private void SaveToDb()
		{
			ArrayList sqls = new ArrayList();

			if (loc != null)
			{
				sqls.Add("last_city = '" + loc + "'");
			}
			if (carrierCode != null)
			{
				sqls.Add("last_carrier = '" + carrierCode + "'");
			}
			sqls.Add("buzz_on_scan = " + (bzOnScan ? 1 : 0));
			sqls.Add("buzz_length = " + bzLen);
			sqls.Add("show_keyboard_on_focus = " + (showKbOnfocus ? 1 : 0));

			string sql = "update config set ";
			sql += String.Join(", ", (string[]) sqls.ToArray(Type.GetType("System.String")));

			SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();

			cmd.CommandText = sql;

			cmd.ExecuteNonQuery();
		}

		public static ConfigSetting Instance()
		{
			if (singlet == null) 
			{
				singlet = new ConfigSetting();
			}
			return singlet;
		}

		public bool BuzzOnScan 
		{
			get 
			{
				return this.bzOnScan;
			}
			set 
			{
				this.bzOnScan = value;

				SaveToDb();
			}
		}

		public int BuzzLength 
		{
			get 
			{
				return this.bzLen;
			}
			set 
			{
				this.bzLen = value;

				SaveToDb();
			}
		}

		public bool BeepOnScan 
		{
			get 
			{
				return this.bpOnScan;
			}
			set 
			{
				this.bpOnScan = value;

				SaveToDb();
			}
		}

		public string Location 
		{
			get 
			{
				return loc;
			}
			set 
			{
				loc = value;
				if (LocationChanged != null) 
				{
					LocationChanged();
				}

				SaveToDb();
			}
		}

		public Array CityList 
		{
			get 
			{
				return cityLst.ToArray();
			}
		}

		public bool ShowKeyboardOnFocus 
		{
			get 
			{
				return this.showKbOnfocus;
			}
			set 
			{
				this.showKbOnfocus = value;

				SaveToDb();
			}
		}

		public string EmployeeNumber 
		{
			get 
			{
				return employNo;
			}
			set 
			{
				employNo = value;
			}
		}

		public bool LockDown
		{
			get
			{
				return lockdown;
			}
			set
			{
				lockdown = value;

				SaveToDb();
			}
		}


		public bool ContinuesScan
		{
			get
			{
				return continuesScan;
			}
			set
			{
				continuesScan = value;

				SaveToDb();
			}
		}

		public static void ExitProgram(object sender, EventArgs e)
		{
			if (ProgramExit != null)
			{
				ProgramExit(sender, e);
			}
		}

		public void logout()
		{
			this.EmployeeNumber = null;
			this.LoggedOut();
		}
	}

	public delegate void CarrierChangedEventHandler();

	public delegate void LocationChangedEventHandler();

	public delegate void LoggedOutEventHandler();
}
