using ChildrenContest.domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildrenContest.repository.database
{
    internal class ChildDBRepository : IChildRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        SQLiteConnection connection;

        public ChildDBRepository(SQLiteConnection connection)
        {
            this.connection = connection;
        }
        public void Add(Child elem)
        {
            log.Info($"adding child {elem} ");
            try
            {
                string sql = "INSERT INTO children (cnp, name, age) VALUES (@cnp, @name, @age)";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@cnp", elem.Cnp);
                    command.Parameters.AddWithValue("@name", elem.Name);
                    command.Parameters.AddWithValue("@age", elem.Age);
                    int result = command.ExecuteNonQuery();
                    log.Info($"added {result} instances");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Delete(Child elem)
        {
            log.Info($"deleting child {elem} ");
            try
            {
                string sql = "DELETE FROM children " +
                    "WHERE id = @id";
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

        public IEnumerable<Child> FindAll()
        {
            log.Info("finding all children");
            HashSet<Child> children = new HashSet<Child>();
            try
            {
                string sql = "SELECT * FROM children";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt64(0);
                            long cnp = reader.GetInt64(1);
                            string name = reader.GetString(2);
                            int age = reader.GetInt32(3);
                            Child child = new Child(cnp, name, age);
                            child.Id = id;
                            children.Add(child);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
            log.Info($"{children.Count} children found");
            return children;
        }

        public Child FindById(long id)
        {
            log.Info($"finding child with id {id}");
            try
            {
                string sql = "SELECT * FROM children " +
                    "WHERE id = @id";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long cnp = reader.GetInt64(1);
                            string name = reader.GetString(2);
                            int age = reader.GetInt32(3);
                            Child child = new Child(cnp, name, age);
                            child.Id = id;
                            log.Info($"child with id {id} found");
                            return child;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
            log.Info("child not found");
            return null;
        }

        public Collection<Child> GetAll()
        {
            return new Collection<Child>(FindAll().ToList());
        }

        public void Update(Child elem, long id)
        {
            log.Info($"updating child {elem} ");
            try
            {
                string sql = "UPDATE children " +
                    "SET cnp = @cnp, name = @name, age = @age " +
                    "WHERE id = @id";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@cnp", elem.Cnp);
                    command.Parameters.AddWithValue("@name", elem.Name);
                    command.Parameters.AddWithValue("@age", elem.Age);
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
