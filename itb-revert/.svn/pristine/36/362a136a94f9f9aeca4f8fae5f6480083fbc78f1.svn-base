using System;
using System.Collections.Generic;
using System.Text;
using Asi.Itb.Dal;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Dal.ItbDataSetTableAdapters;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Manager class managing location data
    /// </summary>
    public class LocationManager
    {
        /// <summary>
        /// Get list of all locations available
        /// </summary>
        /// <returns></returns>
        public List<Entities.Location> GetLocations()
        {
            using (LocationTableAdapter adpt = new LocationTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;

                ItbDataSet.LocationDataTable dt = adpt.GetData();

                List<Entities.Location> ret = new List<Location>();

                foreach (ItbDataSet.LocationRow row in dt.Rows)
                {
                    Location obj = new Location();
                    obj.Barcode = row.Barcode;
                    obj.Carriers = new List<string>(row.Carriers.Split(",".ToCharArray()));
                    obj.Latitude = row.Latitude;
                    obj.Longitude = row.Longitude;
                    obj.Type = row.Type;
                    ret.Add(obj);
                }

                return ret;
            }
        }

        /// <summary>
        /// Get location entity based on scanned barcode.
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public Entities.Location GetLocationByBarcode(string barcode)
        {
            using (LocationTableAdapter adpt = new LocationTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                ItbDataSet.LocationDataTable dt = adpt.GetLocationByBarcode(barcode);

                if (dt.Rows.Count > 0)
                {
                    ItbDataSet.LocationRow row = (ItbDataSet.LocationRow)dt.Rows[0];
                    Location obj = new Location();
                    obj.Barcode = row.Barcode;
                    obj.Carriers = new List<string>(row.Carriers.Split(",".ToCharArray()));
                    obj.Latitude = row.Latitude;
                    obj.Longitude = row.Longitude;
                    obj.Type = row.Type;
                    return obj;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets location entity based on GPS data.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public Entities.Location GetLocationByGpsData(double latitude, double longitude)
        {
            using (LocationTableAdapter adpt = new LocationTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                ItbDataSet.LocationDataTable dt = adpt.GetLocationByGps(latitude, longitude);

                if (dt.Rows.Count > 0)
                {
                    ItbDataSet.LocationRow row = (ItbDataSet.LocationRow)dt.Rows[0];
                    Location obj = new Location();
                    obj.Barcode = row.Barcode;
                    obj.Carriers = new List<string>(row.Carriers.Split(",".ToCharArray()));
                    obj.Latitude = row.Latitude;
                    obj.Longitude = row.Longitude;
                    obj.Type = row.Type;
                    return obj;
                }
            }

            return null;
        }

        /// <summary>
        /// Saves input location data into database
        /// </summary>
        /// <param name="location"></param>
        public void SaveLocation(Location location)
        {
            using (LocationTableAdapter adpt = new LocationTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                adpt.InsertLocation(location.Barcode, location.Latitude, location.Longitude, location.Type, string.Join(",", location.Carriers.ToArray()));
            }
        }

        /// <summary>
        /// Delete all locations data in database.
        /// </summary>
        public void DeleteAllLocations()
        {
            using (LocationTableAdapter adpt = new LocationTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                adpt.DeleteAll();
            }
        }
    }
}
