﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Asi.Itb.Dal;
using Asi.Itb.Utilities;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Dal.ItbDataSetTableAdapters;
using System.Collections;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Manager class for scan related activities
    /// </summary>
    public static class ScanManager
    {
        private static ScanTableAdapter _sadpt = new ScanTableAdapter();
        private static BsmTableAdapter _badpt = new BsmTableAdapter();
        private static UserTableAdapter _uadpt = new UserTableAdapter();
        private static UserActivityTableAdapter _uaadpt = new UserActivityTableAdapter();

        /// <summary>
        /// Unique set of onhand bag barcodes
        /// </summary>
        private static Hashtable _onhandTags = new Hashtable();

        /// <summary>
        /// Unique set of dropped-off bag barcodes
        /// </summary>
        private static Hashtable _droppedOffTags = new Hashtable();

        /// <summary>
        /// Unique set of all bag barcodes
        /// </summary>
        private static Hashtable _allTags = new Hashtable();

        /// <summary>
        /// Object used to sync write access to the three HashTables
        /// </summary>
        private static object _counterSyncObj = new object();

        /// <summary>
        /// Static initializer, to instantiate adapter only once.
        /// </summary>
        public static void Init(DebugLogger debugLogger) // MDD Debug
        {
                                                                if (debugLogger != null) { debugLogger.logMessage("Init", "sadpt"); }
            _sadpt.Connection = DatabaseManager.Connection;     if (debugLogger != null) { debugLogger.logMessage("Init", "badpt"); }
            _badpt.Connection = DatabaseManager.Connection;     if (debugLogger != null) { debugLogger.logMessage("Init", "uadpt"); }
            _uadpt.Connection = DatabaseManager.Connection;     if (debugLogger != null) { debugLogger.logMessage("Init", "uaadpt"); }
            _uaadpt.Connection = DatabaseManager.Connection;

            InitCountersFromDb(debugLogger);
        }

        /// <summary>
        /// Initialize three hashtables from database
        /// </summary>
        private static void InitCountersFromDb(DebugLogger debugLogger) // MDD Debug
        {
            if (debugLogger != null) { debugLogger.logMessage("InitCountersFromDb", "allBags"); }

            List<Bag> allBags = GetBags(Bag.Status.All);
            foreach (Bag bag in allBags)
            {
                _allTags.Add(bag.Barcode, null);
            }

            if (debugLogger != null) { debugLogger.logMessage("InitCountersFromDb", "onhandBags"); }

            List<Bag> onhandBags = GetBags(Bag.Status.OnHand);
            foreach (Bag bag in onhandBags)
            {
                _onhandTags.Add(bag.Barcode, null);
            }

            if (debugLogger != null) { debugLogger.logMessage("InitCountersFromDb", "droppedoffBags"); }

            List<Bag> droppedoffBags = GetBags(Bag.Status.DroppedOff);
            foreach (Bag bag in droppedoffBags)
            {
                _droppedOffTags.Add(bag.Barcode, null);
            }
        }

        /// <summary>
        /// Clean up static member resources
        /// </summary>
        public static void Dispose()
        {
            if (_sadpt != null)
            {
                _sadpt.Dispose();
            }

            if (_badpt != null)
            {
                _badpt.Dispose();
            }

            if (_uaadpt != null)
            {
                _uaadpt.Dispose();
            }

            if (_uadpt != null)
            {
                _uadpt.Dispose();
            }
        }

        /// <summary>
        /// Clear all hashtables used to generate counts
        /// </summary>
        private static void ClearCounters()
        {
            lock (_counterSyncObj)
            {
                _onhandTags.Clear();
                _allTags.Clear();
                _droppedOffTags.Clear();
            }
        }

        /// <summary>
        /// Saves local scan to database.
        /// </summary>
        public static void SaveLocalScan(Scan scanData)
        {
            _sadpt.InsertScan(scanData.Barcode, (byte)scanData.Operation, scanData.ScanTime, false, SessionData.Current.User.UserName, scanData.LocationCode, scanData.Damaged);
            UpdateCounters(scanData);

        }

        /// <summary>
        /// Update internal hashtables based on new scan
        /// </summary>
        /// <param name="scan"></param>
        private static void UpdateCounters(Scan scan)
        {
            lock (_counterSyncObj)
            {
                string tag = scan.Barcode;
                bool isPickup = scan.IsPickUp;

                if (!_allTags.Contains(tag))
                {
                    _allTags.Add(tag, null);
                }

                if (isPickup)
                {
                    if (!_onhandTags.Contains(tag))
                    {
                        _onhandTags.Add(tag, null);
                    }
                }
                else
                {
                    if (_onhandTags.Contains(tag))
                    {
                        _onhandTags.Remove(tag);
                    }
                    if (!_droppedOffTags.Contains(tag))
                    {
                        _droppedOffTags.Add(tag, null);
                    }
                }
            }
        }

        /// <summary>
        /// Save scans generated by other scans to database.
        /// </summary>
        /// <param name="scanData"></param>
        public static void SaveExternalScan(Scan scanData)
        {
            _sadpt.InsertScan(scanData.Barcode, (byte)scanData.Operation, scanData.ScanTime, true, null, scanData.LocationCode, scanData.Damaged);
            UpdateCounters(scanData);
        }

        /// <summary>
        /// Get count of bags
        /// </summary>
        /// <returns></returns>
        public static int GetBagCount(Bag.Status status)
        {

            switch (status)
            {
                case Bag.Status.All:
                    return _allTags.Count;
                case Bag.Status.OnHand:
                    return _onhandTags.Count;
                case Bag.Status.DroppedOff:
                    return _droppedOffTags.Count;
                default:
                    throw new InvalidOperationException("Not recognized status");
            }
        }

        /// <summary>
        /// Get list of bags 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<Bag> GetBags(Bag.Status status)
        {
            ItbDataSet.BsmDataTable dt;

            switch (status)
            {
                case Bag.Status.All:
                    dt = _badpt.GetAllBags();
                    break;
                case Bag.Status.OnHand:
                    dt = _badpt.GetOnHandBags();
                    break;
                case Bag.Status.DroppedOff:
                    dt = _badpt.GetDroppedOffBags();
                    break;
                default:
                    throw new InvalidOperationException("Not recognized status");
            }

            // uniqify based on barcode, to remove duplicate barcodes with different Damaged flag.
            Dictionary<string, Bag> uniqList = new Dictionary<string, Bag>();
            foreach (ItbDataSet.BsmRow row in dt.Rows)
            {
                Bag bag = new Bag();
                bag.Barcode = row.Barcode;
                bag.DestinationLocationCode = row.DestLocationCode;
                bag.InboundCarrier = row.InboundCarrier;
                bag.OutboundCarrier = row.OutboundCarrier;
                if (!(row.IsDamagedNull()))
                {
                    bag.Damaged = row.Damaged;
                }
                if (uniqList.ContainsKey(bag.Barcode))
                {
                    if (bag.Damaged == true)
                    {
                        uniqList[bag.Barcode].Damaged = true;
                    }
                }
                else
                {
                    uniqList.Add(bag.Barcode, bag);
                }
            }

            List<Bag> ret = new List<Bag>(uniqList.Values);

            return ret;
        }

        /// <summary>
        /// Get list of scans for given barcode.
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public static List<Scan> GetScansByBarcode(string barcode)
        {
            ItbDataSet.ScanDataTable dt;
            dt = _sadpt.GetScansByBarcode(barcode);

            List<Scan> ret = new List<Scan>();
            foreach (ItbDataSet.ScanRow row in dt.Rows)
            {
                Scan scan = new Scan();
                scan.Id = row.Id;
                scan.Barcode = row.Barcode;
                scan.Damaged = row.Damaged;
                scan.IsUploaded = row.Uploaded;
                scan.LocationCode = row.LocationCode;
                scan.Operation = (Scan.ScanOperation)row.OperationCode;
                scan.ScanTime = row.ScanTime;
                scan.UserName = row.UserName;
                ret.Add(scan);
            }

            return ret;
        }

        /// <summary>
        /// Get BSM bag record based on barcode
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public static Bag GetBagByBarcode(string barcode)
        {
            ItbDataSet.BsmDataTable dt = _badpt.GetBagByBarcode(barcode);
            if (dt.Rows.Count > 0)
            {
                ItbDataSet.BsmRow row = (ItbDataSet.BsmRow)dt.Rows[0];
                Bag bag = new Bag();
                bag.Barcode = row.Barcode;
                bag.DestinationLocationCode = row.DestLocationCode;
                bag.InboundCarrier = row.InboundCarrier;
                bag.OutboundCarrier = row.OutboundCarrier;
                bag.InboundFlight = row.InboundFlight;
                bag.OutboundFlight = row.OutboundFlight;
                bag.ArrivalTime =
                    row.IsArrivalTimeNull() ? null : row.ArrivalTime as DateTime?;
                bag.DepartureTime =
                    row.IsDepartureTimeNull() ? null : row.DepartureTime as DateTime?;
                return bag;
            }

            return null;
        }

        /// <summary>
        /// Get list of local scans not yet uploaded
        /// </summary>
        /// <returns></returns>
        public static List<Scan> GetToBeUploadedScans()
        {
            ItbDataSet.ScanDataTable dt;
            dt = _sadpt.GetToBeUploadedScans();

            List<Scan> ret = new List<Scan>();
            foreach (ItbDataSet.ScanRow row in dt.Rows)
            {
                Scan scan = new Scan();
                scan.Id = row.Id;
                scan.Barcode = row.Barcode;
                scan.Damaged = row.Damaged;
                scan.IsUploaded = row.Uploaded;
                scan.LocationCode = row.LocationCode;
                scan.Operation = (Scan.ScanOperation)row.OperationCode;
                scan.ScanTime = row.ScanTime;
                scan.UserName = row.UserName;
                ret.Add(scan);
            }
            return ret;
        }

        /// <summary>
        /// Marks specified list of scans as already uploaded in db.
        /// </summary>
        /// <param name="scans"></param>
        public static void MarkScansUploaded(List<Scan> scans)
        {
            foreach (Scan scan in scans)
            {
                _sadpt.UpdateUploadedScan(scan.Id);
            }
        }

        /// <summary>
        /// Clear all current scans after deleting already uploaded ones,
        /// effectively resetting counters on scan form.
        /// </summary>
        /// <param name="byUser">
        /// Whether the action is initiated by user, in which case 
        /// also record this action into UserActivity table
        /// </param>
        /// <remarks>
        /// Delete scans first so we have fewer scans to clear, for performance sake.
        /// </remarks>
        public static void ClearScans(bool byUser)
        {
            _sadpt.DeleteUploadedScans();
            _sadpt.ClearAllScans();

            ClearCounters();

            if (byUser)
            {
                _uaadpt.InsertUserActivity(SessionData.Current.User.UserName, DateTime.UtcNow, (byte)UserActivityType.ResetCounter);
            }
        }

        /// <summary>
        /// Get time interval in seconds for specified barcode
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns></returns>
        public static int? GetOnhandTimeInSeconds(string barcode)
        {
            int? ret = _sadpt.SelectOnHandTimeInSeconds(barcode) as int?;
            return ret;
        }

        /// <summary>
        /// Return true if upload scans exists
        /// </summary>
        /// <returns></returns>
        public static bool UploadScansExists()
        {
            int? uploadScanCount = _sadpt.GetToBeUploadedScansCount() as int?;
            if (uploadScanCount == null)
            {
                return false;
            }
            else
            {
                if (uploadScanCount == 0)
                    return false;
                else
                    return true;
            }
        }
    }
}
