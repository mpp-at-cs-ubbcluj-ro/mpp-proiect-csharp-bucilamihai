using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Persistence.interfaces;
using Model;

namespace Persistence.database
{
    public class OfficeResponsableDBRepository : IOfficeResponsableRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DBUtils dbUtils;

        public OfficeResponsableDBRepository(Dictionary<string, string> properties)
        {
            log.Info($"Initializing repository.database.OfficeResponsableDBRepository with properties: {properties}");
            dbUtils = new DBUtils(properties);
        }

        public void Add(OfficeResponsable elem)
        {
            log.Info($"adding office responsable {elem} ");
            try
            {
                string sql = "INSERT INTO office_responsables (username, password) VALUES (@username, @password)";
                SQLiteConnection connection = dbUtils.GetConnection();

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@username", elem.Username);
                    command.Parameters.AddWithValue("@password", elem.Password);
                    int result = command.ExecuteNonQuery();
                    log.Info($"added {result} instances");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Delete(OfficeResponsable elem)
        {
            log.Info($"deleting office responsable {elem} ");
            try
            {
                string sql = "DELETE FROM office_responsables " +
                    "WHERE id = @id";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", elem.Id);
                    int result = command.ExecuteNonQuery();
                    log.Info($"deleted {result} instances");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public IEnumerable<OfficeResponsable> FindAll()
        {
            log.Info("finding all office responsables");
            HashSet<OfficeResponsable> officeResponsables = new HashSet<OfficeResponsable>();
            try
            {
                string sql = "SELECT * FROM office_responsables";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt64(0);
                            string username = reader.GetString(1);
                            string password = reader.GetString(2);
                            OfficeResponsable officeResponsable = new OfficeResponsable(username, password);
                            officeResponsable.Id = id;
                            officeResponsables.Add(officeResponsable);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
            log.Info($"{officeResponsables.Count} office responsables found");
            return officeResponsables;
        }

        public OfficeResponsable FindById(long id)
        {
            log.Info($"finding office responsable with id {id}");
            try
            {
                string sql = "SELECT * FROM office_responsables " +
                    "WHERE id = @id";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader.GetString(1);
                            string password = reader.GetString(2);
                            OfficeResponsable officeResponsable = new OfficeResponsable(username, password);
                            officeResponsable.Id = id;
                            log.Info($"office responsable with id {id} found");
                            return officeResponsable;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
            log.Info("office responsable not found");
            return null;
        }

        public Collection<OfficeResponsable> GetAll()
        {
            return new Collection<OfficeResponsable>(FindAll().ToList());
        }

        public OfficeResponsable GetByUsernameAndPassword(string username, string password)
        {
            log.Info($"searching for user with username {username}");
            try
            {
                string sql = "SELECT * FROM office_responsables " +
                    "WHERE username = @username AND password = @password";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long id = reader.GetInt64(0);
                            OfficeResponsable officeResponsable = new OfficeResponsable(username, password);
                            officeResponsable.Id = id;
                            log.Info($"office responsable with id {id} found");
                            return officeResponsable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            log.Info("user not found");
            return null;
        }

        public void Update(OfficeResponsable elem, long id)
        {
            log.Info($"updating office responsable {elem} ");
            try
            {
                string sql = "UPDATE office_responsables " +
                    "SET username = @username, password = @password " +
                    "WHERE id = @id";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@username", elem.Username);
                    command.Parameters.AddWithValue("@password", elem.Password);
                    int result = command.ExecuteNonQuery();
                    log.Info($"updated {result} instances");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }
}
