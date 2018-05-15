using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Asi.Itb.Bll;
using Asi.Itb.Bll.DataContracts;

namespace Asi.Itb.UI
{
    public static class TestAndDebug
    {
        public static void UpdatedPostRequestTester()
        {
            List<Scan> ScanList = new List<Scan>();

            Scan scan1 = new Scan()
            {
                Barcode = "001000123",
                Operation = 1,
                Location = "LOC0001",
                Damaged = 0,
                ScanTime = DateTime.UtcNow.AddHours(-1.0),
                UserName = "USER0001"
            };

            ScanList.Add(scan1);

            Scan scan2 = new Scan()
            {
                Barcode = "001123000",
                Operation = 1,
                Location = "LOC0002",
                Damaged = 1,
                ScanTime = DateTime.UtcNow.AddHours(-2.0),
                UserName = "USER0002"
            };

            ScanList.Add(scan2);

            List<UserActivity> UserActivityList = new List<UserActivity>();

            UserActivity userActivity1 = new UserActivity()
            {
                ActivityType = UserActivityType.LogIn,
                UserName = "USER0001",
                ActivityTime = DateTime.UtcNow.AddHours(-1)
            };

            UserActivityList.Add(userActivity1);

            UserActivity userActivity2 = new UserActivity()
            {
                ActivityType = UserActivityType.LogOut,
                UserName = "USER0002",
                ActivityTime = DateTime.UtcNow.AddHours(-2)
            };

            UserActivityList.Add(userActivity2);

            List<HandoverLocation> HandoverLocationList = new List<HandoverLocation>();

            HandoverLocation handoverLocation1 = new HandoverLocation()
            {
                Latitude = "LAT0001",
                Longitude = "LNG0001",
                Type = "TYPE00001",
                Name = "NAME00001"
            };

            HandoverLocationList.Add(handoverLocation1);

            HandoverLocation handoverLocation2 = new HandoverLocation()
            {
                Latitude = "LAT0002",
                Longitude = "LNG0002",
                Type = "TYPE00002",
                Name = "NAME00002"
            };

            HandoverLocationList.Add(handoverLocation2);

            ItbRequest request = new ItbRequest()
            {
                SN = "SN0001",
                Gps = "GPS0001",
                LastUpdateServerTime = DateTime.UtcNow,
                Scans = ScanList,
                UserActivities = UserActivityList,
                HandoverLocations = HandoverLocationList,
                BatteryPercent = 100
            };

            ConnectionManager cm = new ConnectionManager();
            cm.PerformLegacySync(
                request,
                new List<Asi.Itb.Bll.Entities.Scan>(),
                new List<Asi.Itb.Bll.Entities.UserActivity>(),
                new UserManager());

        }
    }
}
