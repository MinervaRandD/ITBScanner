using System.Data.SqlServerCe;
using System.IO;
//using System.Data.Common;
using System.Data;
using System.Collections;
using System;
using System.Net;
using System.Windows.Forms;
using TagTrak.TagTrakLib.com.asiscan.baggage;

namespace TagTrak.TagTrakLib
{
	public class DbAccess
	{
        private const string _schema_version = "2.2";

		private static SqlCeConnection con;

		public static SqlCeConnection OpenConnection 
		{
			get 
			{
				if (con == null) 
				{
					string dbFolder = @"\SDMMC Disk";
					string dbFile = dbFolder + @"\TagTrakDB.sdf";
					string conString = "Data Source = " + dbFile;
					SqlCeEngine engine = new SqlCeEngine(conString);
					if (!(File.Exists(dbFile))) 
					{
						if (!Directory.Exists(dbFolder))
						{
							Directory.CreateDirectory(dbFolder);
						}
						engine.CreateDatabase();
					} 
					else 
					{
						string newDbFile = dbFile + ".new";
						if (File.Exists(newDbFile)) 
						{
							File.Delete(newDbFile);
						}
						string tmpConString = "Data Source = " + newDbFile;
						engine.Compact(tmpConString);
						File.Delete(dbFile);
						File.Move(newDbFile, dbFile);
					}

					con = new SqlCeConnection(conString);
					con.Open();

					try 
					{
						InitializeSchema();
					}
					catch (WebException ex)
					{
						MessageBox.Show("Unable to load new configuration from server: " + ex.Message,
                            "Update Failed",
							MessageBoxButtons.OK, 
							MessageBoxIcon.Exclamation, 
							MessageBoxDefaultButton.Button1);
					}
				} 
				else if (con.State != ConnectionState.Open) 
				{
					con.Open();
				}

				return con;
			}
		}

		public static void CloseConnection()
		{
			if (!(con == null)) 
			{
				if (con.State != ConnectionState.Closed) 
				{
					con.Close();
				}
			}
		}

		// Convert the datatable into tab and new line delimited string, 
		// with the first row being column names

		public static string ToTxtString(DataTable dt)
		{
			return ToTxtString(dt, "\t", "\n");
		}

		public static string ToTxtString(DataTable dt, string colSeparator, string rowSeparator)
		{
			int rownum = dt.Rows.Count;
			int colnum = dt.Columns.Count;

            string[] rows = new string[rownum + 1];

			string[] headers = new string[colnum];

			for (int j = 0; j < colnum; j++) 
			{
				headers[j] = dt.Columns[j].ColumnName;
			}

			rows[0] = String.Join(colSeparator, headers);

            for (int i = 0; i < rownum; i++)
			{
				string[] cols = new string[colnum];

				for (int j = 0; j < colnum; j++)
				{
					object fld = dt.Rows[i].ItemArray[j];

					if (fld is System.DateTime)
					{
						cols[j] = ((DateTime) fld).ToString("yyyy-MM-dd HH:mm:ss");
					}
					else
					{
						cols[j] = fld.ToString();
					}
				}

				string rowstr = String.Join(colSeparator, cols);

				rows[i + 1] = rowstr;
			}

			string data = String.Join(rowSeparator, rows);

			return data;
		}

		private static void InitializeSchema() 
		{ 
			SqlCeCommand cmd = OpenConnection.CreateCommand(); 

			string cmdText = "select 'x' from information_schema.tables"
				+ " where table_name = 'config'"; 

			cmd.CommandText = cmdText; 

			object obj = cmd.ExecuteScalar();

			string schema_version = null;

			if (obj != null)
			{
				cmd.CommandText = "select schema_version from config";
				schema_version = (string) cmd.ExecuteScalar();
			}

			string[] sqls = null;

			if (schema_version == null || schema_version != _schema_version) // do not bother with upgrading db schema, which is a hassle
			{
                // Try to delete all tables up to 20 times because of foreign keys
                bool AllDeleted = true;
                for (int i = 0; i < 20; i++)
                {
                    cmd.CommandText = "select table_name from information_schema.tables where table_type = 'TABLE'";
                    System.Data.SqlServerCe.SqlCeDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        string tableName = rdr.GetString(0);
                        string dropSql = "drop table " + tableName;
                        cmd.CommandText = dropSql;
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlCeException)
                        {
                            AllDeleted = false;
                        }
                    }
                    
                    if (AllDeleted) break;
                }

				sqls = new string[]{
					@"create table carriers ( id int identity(1, 1) primary key, code nchar(2), has_mail bit, has_international bit, has_cargo bit, has_baggage bit)",
					@"create table cities ( id int identity(1, 1) primary key, code nchar(3))",
					@"create table carrier_city (carrier_id int, city_id int)",
					@"create table config ( id int identity(1, 1) primary key, last_carrier nchar(2), last_city nchar(3), buzz_on_scan bit, buzz_length int, beep_on_scan bit, show_keyboard_on_focus bit, schema_version nvarchar(20), last_update datetime, continues_scan bit)",
					@"create table employees ( id int identity(1, 1) primary key, carrier_id int, employee_number nvarchar(20), username nvarchar(20), password nvarchar(40) )",

				    @"create table flights_updates (id int identity(1, 1) primary key, carrier_id int references carriers(id) on delete cascade on update cascade, city_id int references cities(id) on delete cascade on update cascade, last_update datetime)",
                    @"create table flights (id int identity(1, 1) primary key, flights_updates_id int references flights_updates(id) on delete cascade on update cascade, carrier nchar(2), origin nchar(3), destination nchar(3), flight_number smallint, depart_time datetime, arrive_time datetime, depart_gate nvarchar(10), arrive_gate nvarchar(10))",

                    @"create table hot_bags_updates (id int identity(1, 1) primary key, carrier_id int references carriers(id) on delete cascade on update cascade, city_id int references cities(id) on delete cascade on update cascade, flight_number smallint, last_update datetime)",
                    @"create table hot_bags (id int identity(1, 1) primary key, hot_bags_updates_id int references hot_bags_updates(id) on delete cascade on update cascade, tag nvarchar(10))",

					@"insert into config ( buzz_on_scan, buzz_length, beep_on_scan, show_keyboard_on_focus, schema_version, continues_scan ) values ( 1, 1, 1, 0, '" + _schema_version + "', 1 )",
                    
                    @"create table log (id int IDENTITY(1,1) PRIMARY KEY, event nchar(3), event_time datetime not null, carrier nchar(2), uploaded bit not null default 0)",

					@"create table bag_scans (id int IDENTITY(1,1) PRIMARY KEY,operation_code nchar(1) not null,tag nvarchar(10) not null,carrier nchar(2) not null,location nchar(3) not null,from_flight nvarchar(6),to_flight nvarchar(6),cart_id nvarchar(10),hold_position nvarchar(20),container_position nvarchar(20),scan_time datetime,employee_number nvarchar(20),uploaded bit default 0,gate_checked bit default 0)",
					@"create unique index uniq_bag_scans_idx on bag_scans (operation_code, tag, carrier, location)"
				};

				foreach (string sql in sqls)
				{
					cmd.CommandText = sql; 
					cmd.ExecuteNonQuery(); 
				}
			}
		} 

		private static void ReloadConfiguration() 
		{ 
			SqlCeCommand cmd = OpenConnection.CreateCommand(); 

			cmd.CommandText = "select last_update from config";
			object obj = cmd.ExecuteScalar();
			DateTime lastUpdate = new DateTime(1900, 1, 1);
			if (obj != DBNull.Value) 
			{
				lastUpdate = (DateTime) obj;
			}

			bool updated = false;

            string sn = Utilities.SerialNo;
			string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

			WebSyncService cnn = new WebSyncService();

			string carriersString = cnn.GetCarriers(sn, lastUpdate);
			if (carriersString != null)
			{
				cmd.CommandText = "delete from carriers";
				cmd.ExecuteNonQuery();

				cmd.Parameters.Clear();

				cmd.CommandText = "insert into carriers (code, has_mail, has_international, has_cargo, has_baggage)" 
					+ "values (?, ?, ?, ?, ?)";
				cmd.Parameters.Add(new SqlCeParameter("code", DbType.String));
				cmd.Parameters.Add(new SqlCeParameter("has_mail", DbType.Boolean));
				cmd.Parameters.Add(new SqlCeParameter("has_international", DbType.Boolean));
				cmd.Parameters.Add(new SqlCeParameter("has_cargo", DbType.Boolean));
				cmd.Parameters.Add(new SqlCeParameter("has_baggage", DbType.Boolean));
				cmd.Parameters["code"].Size = 2;
				cmd.Parameters["has_mail"].Size = 8;
				cmd.Parameters["has_international"].Size = 8;
				cmd.Parameters["has_cargo"].Size = 8;
				cmd.Parameters["has_baggage"].Size = 8;
				cmd.Prepare();

				string[] lines = carriersString.Split(new char[]{';'});
				foreach (string line in lines)
				{
					string[] fields = line.Split(new char[]{','});
					cmd.Parameters["code"].Value = fields[0];
					cmd.Parameters["has_mail"].Value = fields[1] == "1";
					cmd.Parameters["has_international"].Value = fields[2] == "1";
					cmd.Parameters["has_cargo"].Value = fields[3] == "1";
					cmd.Parameters["has_baggage"].Value = fields[4] == "1";
					cmd.ExecuteNonQuery();
				}

				updated = true;
			}

			string citiesString = cnn.GetCities(sn, lastUpdate);
            if (citiesString != null)
			{
				cmd.CommandText = "delete from cities";
				cmd.ExecuteNonQuery();

				cmd.Parameters.Clear();

				cmd.CommandText = "insert into cities (code) values (?)";
				cmd.Parameters.Add(new SqlCeParameter("code", DbType.String));
				cmd.Parameters["code"].Size = 3;
				cmd.Prepare();

				string[] lines = citiesString.Split(new char[]{';'});
				foreach (string line in lines)
				{
					cmd.Parameters["code"].Value = line;
					cmd.ExecuteNonQuery();
				}

				updated = true;
			}

			string carriersCitiesString = cnn.GetCarrierCity(sn, lastUpdate);
            if (carriersCitiesString != null)
			{
				cmd.CommandText = "delete from carrier_city";
				cmd.ExecuteNonQuery();

				cmd.Parameters.Clear();

				cmd.CommandText = "insert into carrier_city(carrier_id, city_id) " +
					"select cr.id, ct.id from carriers cr, cities ct " +
					"where cr.code = ? and ct.code = ?";
				cmd.Parameters.Add(new SqlCeParameter("carrier_code", DbType.String));
				cmd.Parameters.Add(new SqlCeParameter("city_code", DbType.String));
				cmd.Parameters["carrier_code"].Size = 2;
				cmd.Parameters["city_code"].Size = 3;
				cmd.Prepare();

				string[] lines = carriersCitiesString.Split(new char[]{';'});
				foreach (string line in lines)
				{
					string[] fields = line.Split(new char[]{','});
					cmd.Parameters["carrier_code"].Value = fields[0];
					cmd.Parameters["city_code"].Value = fields[1];
					cmd.ExecuteNonQuery();
				}

				updated = true;
			}

			string employeesString = cnn.GetEmployees(sn, lastUpdate);
            if (employeesString != null)
			{
				cmd.CommandText = "delete from employees";
				cmd.ExecuteNonQuery();

				cmd.Parameters.Clear();

				cmd.CommandText = "insert into employees(carrier_id, employee_number, username, password) " +
					"values (?, ?, ?, ?)";

				cmd.Parameters.Add(new SqlCeParameter("carrier_id", DbType.Int32));
				cmd.Parameters.Add(new SqlCeParameter("employee_number", DbType.String));
				cmd.Parameters.Add(new SqlCeParameter("username", DbType.String));
				cmd.Parameters.Add(new SqlCeParameter("password", DbType.String));
                //cmd.Parameters["carrier_id"].Size = 4;
                //cmd.Parameters["employee_number"].Size = 20;
                //cmd.Parameters["username"].Size = 20;
                //cmd.Parameters["password"].Size = 40;
				cmd.Prepare();

				SqlCeCommand carrierCmd = OpenConnection.CreateCommand();
				carrierCmd.CommandText = "select id from carriers where code = ?";
				carrierCmd.Parameters.Add(new SqlCeParameter("code", DbType.String));
				carrierCmd.Parameters["code"].Size = 2;
				carrierCmd.Prepare();

				string[] lines = employeesString.Split(new char[]{';'});
				foreach (string line in lines)
				{
					string[] fields = line.Split(new char[]{','});
					carrierCmd.Parameters["code"].Value = fields[0];
					object cid = carrierCmd.ExecuteScalar();
					if (cid != null)
					{
						cmd.Parameters["carrier_id"].Value = (int) cid;
						cmd.Parameters["employee_number"].Value = fields[1];
						cmd.Parameters["username"].Value = fields[2];
						cmd.Parameters["password"].Value = fields[3];
						cmd.ExecuteNonQuery();
					}
				}

				updated = true;
			}	
			
			if (updated)
			{
				cmd.Parameters.Clear();

				cmd.CommandText = "update config set last_update = '" + DateTime.UtcNow + "'";
				cmd.ExecuteNonQuery();
			}
		} 

		public static CarrierAttributes GetCarrierAttributes(string code)
		{
			SqlCeConnection dbcon = OpenConnection; 
			SqlCeCommand cmd = dbcon.CreateCommand(); 
			cmd.CommandText = "select has_mail, has_international, has_cargo, has_baggage " + "from carriers where code = '" + code + "'"; 
			SqlCeDataReader rd = cmd.ExecuteReader(); 

			CarrierAttributes cr = new CarrierAttributes();

			if (rd.Read()) 
			{ 

				cr.HasMail = rd.GetBoolean(0); 
				cr.HasInternational = rd.GetBoolean(1);
				cr.HasCargo = rd.GetBoolean(2);
				cr.HasBaggage = rd.GetBoolean(3);
 
			}

			return cr;
		}

		public static ArrayList GetCityList(string carrierCode)
		{
			SqlCeConnection con = DbAccess.OpenConnection;
			string sql = "select ct.code from cities ct " + "inner join carrier_city cc on ct.id = cc.city_id " + "inner join carriers cr on cc.carrier_id = cr.id " + "where cr.code = '" + carrierCode + "'";
			SqlCeCommand cmd = new SqlCeCommand(sql, con);
			SqlCeDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

			ArrayList cityList = new ArrayList();
			while (dr.Read()) 
			{
				cityList.Add(dr.GetString(0));
			}

			dr.Close();

			return cityList;
		}

		public static void Update()
		{
			ReloadConfiguration();
		}

        public static int? Get_carrier_id(string Carrier)
        {
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select id from carriers where code = ?";
            cmd.Parameters.Add("", Carrier);
            object r = cmd.ExecuteScalar();
            if (r == DBNull.Value || r == null)
            {
                return null;
            }
            else
            {
                return (int)r;
            }
        }

        public static int? Get_city_id(string City)
        {
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select id from cities where code = ?";
            cmd.Parameters.Add("", City);
            object r = cmd.ExecuteScalar();
            if (r == DBNull.Value || r == null)
            {
                return null;
            }
            else
            {
                return (int)r;
            }
        }

        public static decimal? Get_IDENTITY()
        {
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select @@IDENTITY";
            object r = cmd.ExecuteScalar();
            if (r == DBNull.Value || r == null)
            {
                return null;
            }
            else
            {
                return (decimal)r;
            }
        }

	}
}
