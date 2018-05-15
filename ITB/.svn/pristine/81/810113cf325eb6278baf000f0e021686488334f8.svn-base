using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Asi.Itb.Bll.Entities
{
    /// <summary>
    /// Container containing status data related to current use session 
    /// </summary>
    public class SessionData
    {
        private static SessionData _current;

        /// <summary>
        /// Gets single instance of the current session data.
        /// </summary>
        public static SessionData Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SessionData();
                }
                return _current;
            }
        }

        /// <summary>
        /// Currently logged in user
        /// </summary>
        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// Current location in effect
        /// </summary>
        public Location Location
        {
            get;
            set;
        }

        /// <summary>
        /// Current scan operation code in effect.
        /// </summary>
        public Scan.ScanOperation? OperationCode
        {
            get;
            set;
        }

        /// <summary>
        /// Current status of bag count to be shown in BagCountDetailForm.
        /// </summary>
        public Bag.Status BagCountStatus
        {
            get;
            set;
        }

        /// <summary>
        /// Current Bag to show detail for.
        /// </summary>
        public Bag Bag
        {
            get;
            set;
        }

        /// <summary>
        /// Current Message to show detail for.
        /// </summary>
        public Message Message
        {
            get;
            set;
        }

        /// <summary>
        /// Event triggered whenever the GPS data is updated, with change or not.
        /// </summary>
        public event EventHandler GpsUpdated;

        /// <summary>
        /// Event when the device is considered moved based on GPS.
        /// </summary>
        /// <remarks>
        /// Only triggered when there is substantial move, or when GPS goes On/Off.
        /// </remarks>
        public event EventHandler GpsChanged;

        private GpsPosition _gpsPosition;

        /// <summary>
        /// Current GPS position
        /// </summary>
        public GpsPosition GpsPosition
        {
            get
            {
                return _gpsPosition;
            }
        }

        /// <summary>
        /// Set current GpsPosition directly from latitude/longitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <remarks>
        /// Use this method instead of setter for GpsPosition to avoid 
        /// create new objects when possible, since this method will be called
        /// frequently. 
        /// </remarks>
        public void SetGpsPosition(double latitude, double longitude)
        {
            if (_gpsPosition == null)
            {
                _gpsPosition = new GpsPosition(latitude, longitude);

                this.OnGpsChanged();
            }
            else
            {
                double d = _gpsPosition.GetDeviation(latitude, longitude);
                _gpsPosition.Latitude = latitude;
                _gpsPosition.Longitude = longitude;

                if (d > 1e-8)
                {
                    this.OnGpsChanged();
                }
            }

            this.OnGpsUpdated();
        }

        /// <summary>
        /// Clear GpsPosition data.
        /// </summary>
        public void ClearGpsPosition()
        {
            if (this._gpsPosition != null)
            {
                this._gpsPosition = null;

                this.OnGpsChanged();
                this.OnGpsUpdated();
            }
        }

        private string _sn;
        /// <summary>
        /// Gets device UUID. Save it in session to avoid calling back to unmanaged library every time.
        /// </summary>
        public string SN
        {
            get
            {
                if (_sn == null)
                {
                    _sn = Hardware.Device.GetUniqueID();
                }
                return _sn;
            }
        }

        /// <summary>
        /// Invoke GpsUpdated event if set.
        /// </summary>
        private void OnGpsUpdated()
        {
            if (this.GpsUpdated != null)
            {
                this.GpsUpdated(this, null);
            }
        }

        /// <summary>
        /// Invoke GpsChanged event if set.
        /// </summary>
        private void OnGpsChanged()
        {
            if (this.GpsChanged != null)
            {
                this.GpsChanged(this, null);
            }
        }
    }
}
