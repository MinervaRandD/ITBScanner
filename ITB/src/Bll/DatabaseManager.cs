using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace Asi.Itb.Bll
{
    /// <summary>
    /// Manager class responsible for initializing and updating database file.
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// Check for database file. If not exists or not right version, create database 
        /// using sql statements from resource file.
        /// </summary>
        public void InitDb()
        {
            throw new NotImplementedException();
        }

        private static SqlCeConnection _connection;
        /// <summary>
        /// Single connection to be used by all data adapters throughout the lifespan of the application.
        /// </summary>
        public static SqlCeConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    OpenConnection();
                }

                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public static void OpenConnection()
        {
            string dbFilePath = Configuration.Instance.DbFilePath;
            string conStr = string.Format("Data Source ={0};", dbFilePath); 
            _connection = new SqlCeConnection(conStr);
            _connection.Open();
        }

        /// <summary>
        /// Close connection, release resources and set connection to null.
        /// </summary>
        public static void CloseConnection()
        {
            if (_connection != null)
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                {
                    _connection.Close();
                }

                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
