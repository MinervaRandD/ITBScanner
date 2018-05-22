using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Asi.Itb.Dal;
using Asi.Itb.Dal.ItbDataSetTableAdapters;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Manager class responsible for program execution.
    /// </summary>
    public class ProgramManager
    {
        /// <summary>
        /// Get IdleTimeOutLimit value from database.
        /// </summary>
        /// <returns></returns>
        public int GetIdleTimeOutLimit()
        {
            using (LocalVariablesTableAdapter adpt = new Asi.Itb.Dal.ItbDataSetTableAdapters.LocalVariablesTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                ItbDataSet.LocalVariablesDataTable dt = adpt.GetData();
                if (dt.Rows.Count > 0)
                {
                    return ((ItbDataSet.LocalVariablesRow)dt.Rows[0]).IdleTimeOutLimit;
                }

                return 0;
            }
        }

        /// <summary>
        /// Get GpsIdleTimeOutLimit value from database.
        /// </summary>
        /// <returns></returns>
        public int GetGpsIdleTimeOutLimit()
        {
            using (LocalVariablesTableAdapter adpt = new Asi.Itb.Dal.ItbDataSetTableAdapters.LocalVariablesTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                ItbDataSet.LocalVariablesDataTable dt = adpt.GetData();
                if (dt.Rows.Count > 0)
                {
                    return ((ItbDataSet.LocalVariablesRow)dt.Rows[0]).GpsIdleTimeOutLimit;
                }

                return 0;
            }
        }

        public int GetBatteryWarningPercent()
        {
            using (LocalVariablesTableAdapter adpt = new Asi.Itb.Dal.ItbDataSetTableAdapters.LocalVariablesTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                ItbDataSet.LocalVariablesDataTable dt = adpt.GetData();
                if (dt.Rows.Count > 0)
                {
                    return ((ItbDataSet.LocalVariablesRow)dt.Rows[0]).BatteryWarningPercent;
                }

                return 0;
            }
        }
    }
}
