using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Asi.Itb.Bll.Entities;
using Asi.Itb.Dal;
using Asi.Itb.Utilities;
using Asi.Itb.Dal.ItbDataSetTableAdapters;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Represents manager of login related activities
    /// </summary>
    public class UserManager
    {
        /// <summary>
        /// Authenticate specific userName and password. 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Authenticated user entity.</returns>
        public User Authenticate(string userName, string password)
        {
            using (UserTableAdapter uadpt = new UserTableAdapter())
            {
                uadpt.Connection = DatabaseManager.Connection;
                ItbDataSet.UserDataTable udt = uadpt.GetUserByUserName(userName);
                if (udt.Rows.Count > 0)
                {
                    ItbDataSet.UserRow urow = udt.Rows[0] as ItbDataSet.UserRow;
                    if (urow.Password != Cryptography.Sha1Encrypt(password, urow.Salt))
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

            using (vwUserPermissionTableAdapter adpt = new vwUserPermissionTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                Dal.ItbDataSet.vwUserPermissionDataTable dt = adpt.GetUserPermissions(userName);
                if (dt.Rows.Count > 0)
                {
                    ItbDataSet.vwUserPermissionRow row = (ItbDataSet.vwUserPermissionRow)dt.Rows[0];
                    User user = new User();
                    user.UserId = (int)row.userId;
                    user.UserName = row.UserName;
                    user.RoleName = row.RoleName;
                    user.Permissions = new List<string>();
                    foreach (ItbDataSet.vwUserPermissionRow pRow in dt.Rows)
                    {
                        user.Permissions.Add(pRow.PermissionName);
                    }

                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Checks whether input exit code matches stored value
        /// </summary>
        /// <param name="exitCode"></param>
        /// <returns></returns>
        public bool IsValidExitCode(string exitCode)
        {
            using (LocalVariablesTableAdapter adpt = new LocalVariablesTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                ItbDataSet.LocalVariablesDataTable dt = adpt.GetData();
                if (dt.Rows.Count > 0)
                {
                    string actualExitCode = ((ItbDataSet.LocalVariablesRow)dt.Rows[0]).ExitCode;
                    if (actualExitCode != null)
                    {
                        return Cryptography.Sha1Encrypt(exitCode) == actualExitCode;
                    }
                }

                return exitCode == "3577101"; // default password
            }
        }

        /// <summary>
        /// Record activity into database
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="type"></param>
        public void SaveActivity(string userName, UserActivityType type)
        {
            using (UserActivityTableAdapter adpt = new UserActivityTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                adpt.InsertUserActivity(userName, DateTime.UtcNow, (byte)type);
            }
        }

        /// <summary>
        /// Get list of user activities from database
        /// </summary>
        /// <returns></returns>
        public List<UserActivity> GetActivities()
        {
            using (UserActivityTableAdapter adpt = new UserActivityTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                ItbDataSet.UserActivityDataTable dt = adpt.GetData();
                List<UserActivity> ret = new List<UserActivity>();
                foreach (ItbDataSet.UserActivityRow row in dt.Rows)
                {
                    UserActivity ua = new UserActivity();
                    ua.Id = row.Id;
                    ua.ActivityTime = row.ActivityTime;
                    ua.ActivityType = (UserActivityType)row.ActivityType;
                    ua.UserName = row.UserName;
                    ret.Add(ua);
                }

                return ret;
            }
        }

        /// <summary>
        /// Delete specified activities
        /// </summary>
        /// <remarks>
        /// Not deleting all records, in case some new activity was inserted while uploading. 
        /// </remarks>
        public void DeleteActivities(List<UserActivity> activities)
        {
            using (UserActivityTableAdapter adpt = new UserActivityTableAdapter())
            {
                adpt.Connection = DatabaseManager.Connection;
                foreach (UserActivity act in activities)
                {
                    adpt.Delete(act.Id);
                }
            }
        }
    }
}
