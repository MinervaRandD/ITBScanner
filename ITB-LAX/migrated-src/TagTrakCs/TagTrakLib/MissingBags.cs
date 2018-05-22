using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TagTrak.TagTrakLib
{
    class MissingBags
    {
        public struct Bag
        {
            public string Tag;
            public string LastKnownStatus;
            public DateTime MissingSince;

            public Bag(string Tag, string LastKnownStatus, DateTime MissingSince)
            {
                this.Tag = Tag;
                this.LastKnownStatus = LastKnownStatus;
                this.MissingSince = MissingSince;
            }
        }

        public static DataTable GetDataTable(string Carrier, string City, int FlightNumber)
        {
            System.Data.DataTable DT = new System.Data.DataTable("Missing Bags");

            DT.Columns.Add("Tag", typeof(string));
            DT.Columns.Add("When", typeof(DateTime));
            DT.Columns.Add("Status", typeof(string));

            List<Bag> Bags = GetList(Carrier, City, FlightNumber);

            DataRow Row;
            foreach (Bag B in Bags)
            {
                Row = DT.NewRow();
                Row[0] = B.Tag;
                Row[1] = B.MissingSince;
                Row[2] = B.LastKnownStatus;
                DT.Rows.Add(Row);
            }

            return DT;
        }

        public static List<Bag> GetList(string Carrier, string City, int FlightNumber)
        {
            WebSyncService ws = new WebSyncService();

            List<Bag> Result = new List<Bag>();

            string wsStr = ws.GetMissingBags(Carrier, City, DateTime.Now, FlightNumber, DateTime.MinValue);

#if DEBUG
            if (wsStr == null)
            {
                throw new NullReferenceException("Received null from web service for missing bags, this has no meaning.");
            }
#endif

            // Add data
            if (!String.IsNullOrEmpty(wsStr))
            {
                string[] rows = wsStr.Split(";".ToCharArray());
                foreach (string row in rows)
                {
                    string[] flds = row.Split(",".ToCharArray());
                    if (flds.Length != 3)
                    {
                        continue;
                    }

                    try
                    {
                        Result.Add(new Bag(flds[0], flds[1], DateTime.Parse(flds[2])));
                    }
                    catch
                    {
                        // Skip invalid records
                    }
                }
            }

            return Result;

        } //end function

    }// end class

}// end namespace