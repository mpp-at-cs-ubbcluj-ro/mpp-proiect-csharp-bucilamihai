using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.database
{
    public class DBUtils
    {
        private Dictionary<string, string> properties;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SQLiteConnection instance = null;

        public DBUtils(Dictionary<string, string> properties)
        {
            this.properties = properties;
        }

        public SQLiteConnection GetNewConnection()
        {
            string dataSource = properties["url"];
            string connectionString = $"Data Source={dataSource};Version=3;";

            log.Info($"trying to connect to database ... {connectionString}");
            SQLiteConnection connection = null;
            try
            {
                connection = new SQLiteConnection(connectionString);
                connection.Open();
                log.Info("Connection opened");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return connection;
        }

        public SQLiteConnection GetConnection()
        {
            try
            {
                if(instance == null || instance.State == ConnectionState.Closed)
                {
                    instance = GetNewConnection();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return instance;
        }
    }
}
