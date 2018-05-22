using System;
using System.Data.SqlServerCe;
using System.Data;
using System.Runtime.CompilerServices;

namespace TagTrak.TagTrakLib
{
	/// <summary>
	/// Summary description for Flights.
	/// </summary>
	public class Flights
	{
        const int ExpirationAgeHours = 48;

        [MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// When was this location last updated
        /// </summary>
        /// <returns>Update time or DateTime.MinValue if none</returns>
        private static DateTime LastUpdate(string Carrier, string City)
        {
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select last_update from flights_updates as FU inner join carriers as CA on CA.id = FU.carrier_id inner join cities as CI on CI.id = FU.cities_id where CO.code = ? and CA.code = ?";
            cmd.Parameters.Add("", City);
            cmd.Parameters.Add("", Carrier);
            object result = cmd.ExecuteScalar();
            if (result == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                return (DateTime)result;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// Syncronize with web service
        /// </summary>
        public static void Update(string Carrier, string City)
		{
			WebSyncService ws = new WebSyncService();

            // Last update should be stored before the web service call just in case an updated record comes in between 
            // when the web service checks for updates and our last update signature.
            DateTime updateTime = DateTime.Now;
            
            // Get current last update
            DateTime lastUpdate = GetLastUpdate(Carrier, City);

			ConfigSetting config = ConfigSetting.Instance();
            string wsStr = ws.GetFlights(Carrier, City, DateTime.Today, DateTime.Today, lastUpdate);

            if (wsStr == null)
            {
                // No updates available
                // NOTE: "" (empty string) is not the same thing, it means data set it empty
                return;
            }

            // Delete old flights
			SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "delete from flights_updates where carrier_id = ? and city_id = ?";
            cmd.Parameters.Add("", DbAccess.Get_carrier_id(Carrier));
            cmd.Parameters.Add("", DbAccess.Get_city_id(City));
			cmd.ExecuteNonQuery();

            //Save last update
            cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "insert into flights_updates (carrier_id, city_id, last_update) values (?, ?, ?)";
            cmd.Parameters.Add("", DbAccess.Get_carrier_id(Carrier));
            cmd.Parameters.Add("", DbAccess.Get_city_id(City));
            cmd.Parameters.Add("", updateTime);
            cmd.ExecuteNonQuery();
            decimal flights_updates_id = (decimal)DbAccess.Get_IDENTITY();

            // Add flights
			if (wsStr != "")
			{
                cmd = DbAccess.OpenConnection.CreateCommand();
                cmd.CommandText = "insert into flights(flights_updates_id, carrier, origin, destination, flight_number, depart_time, arrive_time, depart_gate, arrive_gate) values (?, ?, ?, ?, ?, ?, ?, ?, ?)";

				string[] rows = wsStr.Split(";".ToCharArray());
				foreach (string row in rows)
				{
					string[] flds = row.Split(",".ToCharArray());
                    if (flds.Length != 7)
                    {
                        continue;
                    }

                    cmd.Parameters.Clear();
                    try
                    {
                        cmd.Parameters.Add("", flights_updates_id);
                        cmd.Parameters.Add("", config.Carrier);
                        cmd.Parameters.Add("", flds[0]);
                        cmd.Parameters.Add("", flds[1]);
                        cmd.Parameters.Add("", int.Parse(flds[2]));
                        cmd.Parameters.Add("", DateTime.Parse(flds[3]));
                        cmd.Parameters.Add("", DateTime.Parse(flds[4]));
                        cmd.Parameters.Add("", flds[5]);
                        cmd.Parameters.Add("", flds[6]);

                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        // Skip invalid records
                    }
				}
			}
		}

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static DateTime GetLastUpdate(string Carrier, string City)
        {
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select last_update from flights_updates where carrier_id = ? and city_id = ?";
            cmd.Parameters.Add("", DbAccess.Get_carrier_id(Carrier));
            cmd.Parameters.Add("", DbAccess.Get_city_id(City));
            object r = cmd.ExecuteScalar();

            if (r == DBNull.Value || r == null || r.GetType() != typeof(DateTime))
            {
                return DateTime.MinValue;
            }
            else
            {
                return (DateTime)r;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// Return all known flights from local store
        /// </summary>
		public static DataTable GetCurrentFlights(string Carrier, string City)
		{
			SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select F.carrier + convert(nvarchar(4), F.flight_number) as full_flight_number, F.origin, F.destination, F.depart_time, F.arrive_time, F.depart_gate, F.arrive_gate from flights as F inner join flights_updates as FU on F.flights_updates_id = FU.id where FU.carrier_id = ? and FU.city_id = ?";
            cmd.Parameters.Add("", DbAccess.Get_carrier_id(Carrier));
            cmd.Parameters.Add("", DbAccess.Get_city_id(City));
			SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);
			DataTable flightsTable = new DataTable("flights");
            da.Fill(flightsTable);

			return flightsTable;
		}

        [MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// Clean up old data
        /// </summary>
        /// <remarks>Flight schedule data can go out of date if a different carrier or city is being used or 
        /// an update wasn't performed recently.</remarks>
        public static void Cleanup()
        {
            DateTime ExpireTime = DateTime.Now.Subtract(TimeSpan.FromHours(ExpirationAgeHours));
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "delete from flights_updates where last_update < ?";
            cmd.Parameters.Add("", ExpireTime);
            cmd.ExecuteNonQuery();
        }
	}
}
