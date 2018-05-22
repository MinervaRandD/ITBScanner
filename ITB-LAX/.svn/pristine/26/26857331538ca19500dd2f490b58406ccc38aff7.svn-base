using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Represents composite value for latitude/longitude.
    /// </summary>
    public class GpsPosition
    {
        /// <summary>
        /// Contructor to take latitude/longitude values.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public GpsPosition(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Latitude value in decimal format.
        /// </summary>
        public double Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// Longitude value in decimal format.
        /// </summary>
        public double Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// Overriden string representation of GPS location as Latitude,Longitude
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0:0.000000},{1:0.000000}", this.Latitude, this.Longitude);
        }

        /// <summary>
        /// Gets standard deviation of latitude/longitude between two GpsPosition's 
        /// </summary>
        /// <param name="otherPosition"></param>
        /// <returns></returns>
        public double GetDeviation(GpsPosition otherPosition)
        {
            return this.GetDeviation(otherPosition.Latitude, otherPosition.Longitude);
        }

        /// <summary>
        /// Get standard deviation of latitude/longitude between current GpsPosition and given lat/long
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        /// <remarks>
        /// This is just a rough number to determine whether there is substantial movement,
        /// thus more rigorous formula is not needed.
        /// </remarks>
        public double GetDeviation(double latitude, double longitude)
        {
            double dLat = latitude - this.Latitude;
            double dLong = longitude - this.Longitude;
            return dLat * dLat + dLong * dLong;
        }
    }
}
