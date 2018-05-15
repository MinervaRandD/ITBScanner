using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Runtime.CompilerServices;

namespace TagTrak.TagTrakLib
{
    public class HotBags
    {
        const int ExpirationAgeHours = 48;

        [MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// When was this location last updated
        /// </summary>
        /// <returns>Update time or DateTime.MinValue if none</returns>
        private static DateTime LastUpdate(string Carrier, string City, int FlightNumber)
        {
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select last_update from hot_bags_updates as HBU inner join carriers as CA on CA.id = HBU.carrier_id inner join cities as CI on CI.id = HBU.cities_id where CO.code = ? and CA.code = ? and HBU.flight_number = ?";
            cmd.Parameters.Add("", City);
            cmd.Parameters.Add("", Carrier);
            cmd.Parameters.Add("", FlightNumber);
            object result = cmd.ExecuteScalar();
            if (result == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                return (DateTime)result;
            }
        }// end function

        [MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// Syncronize with web service
        /// </summary>
        public static void Update(string Carrier, string City, int FlightNumber)
        {
            WebSyncService ws = new WebSyncService();

            // Last update should be stored before the web service call just in case an updated record comes in between 
            // when the web service checks for updates and our last update signature.
            DateTime updateTime = DateTime.Now;
            
            // Get current last update
            DateTime lastUpdate = GetLastUpdate(Carrier, City, FlightNumber);

            ConfigSetting config = ConfigSetting.Instance();
            string wsStr = ws.GetHotBags(Carrier, City, DateTime.Now, FlightNumber, lastUpdate);

            if (wsStr == null)
            {
                // No updates available
                // NOTE: "" (empty string) is not the same thing, it means data set it empty
                return;
            }

            // Delete old data
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "delete from hot_bags_updates where carrier_id = ? and city_id = ? and flight_number = ?";
            cmd.Parameters.Add("", DbAccess.Get_carrier_id(Carrier));
            cmd.Parameters.Add("", DbAccess.Get_city_id(City));
            cmd.Parameters.Add("", FlightNumber);
            cmd.ExecuteNonQuery();

            //Save last update
            cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "insert into hot_bags_updates (carrier_id, city_id, flight_number, last_update) values (?, ?, ?, ?)";
            cmd.Parameters.Add("", DbAccess.Get_carrier_id(Carrier));
            cmd.Parameters.Add("", DbAccess.Get_city_id(City));
            cmd.Parameters.Add("", FlightNumber);
            cmd.Parameters.Add("", updateTime);
            cmd.ExecuteNonQuery();
            decimal updates_id = (decimal)DbAccess.Get_IDENTITY();

            // Add data
            if (wsStr != "")
            {
                cmd = DbAccess.OpenConnection.CreateCommand();
                cmd.CommandText = "insert into hot_bags(hot_bags_updates_id, tag) values (?, ?)";

                string[] rows = wsStr.Split(";".ToCharArray());
                foreach (string row in rows)
                {
                    string[] flds = row.Split(",".ToCharArray());
                    if (flds.Length != 1)
                    {
                        continue;
                    }

                    try
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("", updates_id);
                        cmd.Parameters.Add("", flds[0]);

                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        // Skip invalid records
                    }
                }
            }
        }// end function

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static DateTime GetLastUpdate(string Carrier, string City, int FlightNumber)
        {
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select last_update from hot_bags_updates where carrier_id = ? and city_id = ? and flight_number = ?";
            cmd.Parameters.Add("", DbAccess.Get_carrier_id(Carrier));
            cmd.Parameters.Add("", DbAccess.Get_city_id(City));
            cmd.Parameters.Add("", FlightNumber);
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
        /// Is this a hot bag
        /// </summary>
        /// <param name="FlightNumber">The flight being unloaded</param>
        /// <param name="Tag">The scanned tag</param>
        public static bool IsHotBag(string Carrier, string City, int FlightNumber, string Tag)
        {
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "select tag from hot_bags as HB inner join hot_bags_updates as HBU on HB.hot_bags_updates_id = HBU.id where HBU.carrier_id = ? and HBU.city_id = ? and HBU.flight_number = ? and HB.tag = ?";
            cmd.Parameters.Add("", DbAccess.Get_carrier_id(Carrier));
            cmd.Parameters.Add("", DbAccess.Get_city_id(City));
            cmd.Parameters.Add("", FlightNumber);
            cmd.Parameters.Add("", Tag);
            object result = cmd.ExecuteScalar();
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }// end function

        [MethodImpl(MethodImplOptions.Synchronized)]
        /// <summary>
        /// Clean up old data
        /// </summary>
        public static void Cleanup()
        {
            DateTime ExpireTime = DateTime.Now.Subtract(TimeSpan.FromHours(ExpirationAgeHours));
            SqlCeCommand cmd = DbAccess.OpenConnection.CreateCommand();
            cmd.CommandText = "delete from hot_bags_updates where last_update < ?";
            cmd.Parameters.Add("", ExpireTime);
            cmd.ExecuteNonQuery();

        }// end function

    }// end class

}// end namespace
