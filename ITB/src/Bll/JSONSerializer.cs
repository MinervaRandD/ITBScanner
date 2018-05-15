using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asi.Itb.Bll.DataContracts;

namespace Asi.Itb.Bll
{
    public class JSONSerializer
    {
        public string Serialize(ItbRequestRev2 itbRequestRev2)
        {
            string s = string.Empty;

            s += "\"Entity\": " + fmt(itbRequestRev2.Entity) + ", ";
            s += "\"TransactionId\": " + fmt(itbRequestRev2.TransactionId) + ", ";
            s += "\"SN\": " + fmt(itbRequestRev2.SN) + ", ";
            s += "\"SessionUserName\": " + fmt(itbRequestRev2.SessionUserName) + ", ";
            s += "\"SessionUserId\": " + itbRequestRev2.SessionUserId + ", ";
            s += "\"RequestTimeXml\": " + fmt(itbRequestRev2.RequestTimeXml) + ", ";
            s += "\"Gps\": " + fmt(itbRequestRev2.Gps) + ", ";
            s += "\"LastUpdateServerTimeXml\": " + fmt(itbRequestRev2.LastUpdateServerTimeXml) + ", ";
            s += "\"Scans\": " + Serialize(itbRequestRev2.Scans) + ", ";
            s += "\"UserActivities\": " + Serialize(itbRequestRev2.UserActivities) + ", ";
            s += "\"HandoverLocations\": " + Serialize(itbRequestRev2.HandoverLocations) + ", ";
            s += "\"BatteryPercent\": " + itbRequestRev2.BatteryPercent;

            return "{ " + s + " }" ;
        }

        public string Serialize(List<Scan> scanList)
        {
            if (scanList == null)
            {
                return "[]";
            }

            if (scanList.Count == 0)
            {
                return "[]";
            }

            return "[ " + string.Join(", ", scanList.Select(s => Serialize(s)).ToArray()) + " ]";
        }

        public string Serialize(List<UserActivity> userActivitiesList)
        {
            if (userActivitiesList == null)
            {
                return "[]";
            }

            if (userActivitiesList.Count == 0)
            {
                return "[]";
            }

            return "[ " + string.Join(", ", userActivitiesList.Select(s => Serialize(s)).ToArray()) + " ]";
        }

        public string Serialize(List<HandoverLocation> handoverLocationList)
        {
            if (handoverLocationList == null)
            {
                return "[]";
            }

            if (handoverLocationList.Count == 0)
            {
                return "[]";
            }

            return "[ " + string.Join(", ", handoverLocationList.Select(s => Serialize(s)).ToArray()) + " ]";
        }

        public string Serialize(Scan scan)
        {
            string s = string.Empty;

            s += "\"Barcode\": " + fmt(scan.Barcode) + ", ";
            s += "\"Operation\": " + scan.Operation + ", ";
            s += "\"Location\": " + fmt(scan.Location) + ", ";
            s += "\"Damaged\": " + fmt(scan.Damaged) + ", ";
            s += "\"ScanTimeXml\": " + fmt(scan.ScanTimeXml) + ", ";
            s += "\"UserName\": " + fmt(scan.UserName);

            return "{ " + s + " }" ;
        }

        public string Serialize(UserActivity userActivity)
        {
            string s = string.Empty;

            s += "\"ActivityType\": " + (int) userActivity.ActivityType + ", ";
            s += "\"UserName\": " + fmt(userActivity.UserName) + ", ";
            s += "\"ActivityTimeXml\": " + fmt(userActivity.ActivityTimeXml);
          
            return "{ " + s + " }";
        }

        public string Serialize(HandoverLocation handoverLocation)
        {
            string s = string.Empty;

            s += "\"Name\": " + fmt(handoverLocation.Name) + ", ";
            s += "\"Type\": " + fmt(handoverLocation.Type) + ", ";
            s += "\"Latitude\": " + fmt(handoverLocation.Latitude) + ", ";
            s += "\"Longitude\": " + fmt(handoverLocation.Longitude);

            return "{ " + s + " }";
        }

        public string fmt(string s)
        {
            if (s == null)
            {
                return "null";
            }

            return '"' + s + '"';
        }

        public string fmt(DateTime d)
        {
            return '"' + d.ToString("yyyy-MM-ddThh:mm:ss") + '"';
        }

        public string fmt(DateTime? d)
        {
            if (d == null)
            {
                return "null";
            }

            return fmt(d.Value);
        }

        public string fmt(int? i)
        {
            if (i == null)
            {
                return "null";
            }

            return '"' + i.Value.ToString() + '"';
        }
    }
}
