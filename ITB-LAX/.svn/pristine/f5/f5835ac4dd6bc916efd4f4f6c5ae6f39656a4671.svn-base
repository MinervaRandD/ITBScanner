using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Asi.Itb.Bll;
using Asi.Itb.Dal;
using Asi.Itb.Dal.ItbDataSetTableAdapters;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Represent business manager class to save and retrieve flights
    /// </summary>
    public class FlightManager
    {
        /// <summary>
        /// Insert new flight into local database, after removing possible old record 
        /// with same carrier and number
        /// </summary>
        /// <param name="flight"></param>
        public void InsertFlights(List<DataContracts.Flight> flights)
        {
            using (FlightTableAdapter adpt = new FlightTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                foreach (DataContracts.Flight flight in flights)
                {
                    adpt.DeleteFlight(flight.Carrier, flight.Number);
                    adpt.InsertNewFlight(flight.Carrier, flight.Number, flight.ArrivalTime, flight.DepartureTime, DateTime.Now);
                }
            }
        }

        /// <summary>
        /// Flush flight records older than 1 day.
        /// </summary>
        public void FlushOldFlights()
        {
            using (FlightTableAdapter adpt = new FlightTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                adpt.DeleteOldFlights();
            }
        }
    }
}
