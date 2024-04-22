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
    public class EnrollmentDBRepository : IEnrollmentRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DBUtils dbUtils;

        public EnrollmentDBRepository(Dictionary<string, string> properties)
        {
            log.Info($"Initializing repository.database.EnrollmentDBRepository with properties: {properties}");
            dbUtils = new DBUtils(properties);
        }
        public void Add(Enrollment elem)
        {
            log.Info($"adding enrollment {elem} ");
            try
            {
                string sql = "INSERT INTO enrollments (child_id, challenge_id) VALUES (@child_id, @challenge_id)";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@child_id", elem.child.id);
                    command.Parameters.AddWithValue("@challenge_id", elem.challenge.id);
                    int result = command.ExecuteNonQuery();
                    log.Info($"added {result} instances");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public void Delete(Enrollment elem)
        {
            log.Info($"deleting enrollment {elem} ");
            try
            {
                string sql = "DELETE FROM enrollments " +
                    "WHERE id = @id";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", elem.id);
                    int result = command.ExecuteNonQuery();
                    log.Info($"deleted {result} instances");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        public IEnumerable<Enrollment> FindAll()
        {
            log.Info("finding all enrollments");
            HashSet<Enrollment> enrollments = new HashSet<Enrollment>();
            try
            {
                string sql = "SELECT * FROM enrollments";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt64(0);

                            long child_id = reader.GetInt64(1);
                            Child child = null;
                            string sqlChild = "SELECT * FROM children " +
                                "WHERE id = @id";
                            using (SQLiteCommand commandChild = new SQLiteCommand(sqlChild, connection))
                            {
                                commandChild.Parameters.AddWithValue("@id", child_id);
                                using (SQLiteDataReader readerChild = commandChild.ExecuteReader())
                                {
                                    if (readerChild.Read())
                                    {
                                        long cnp = readerChild.GetInt64(1);
                                        string name = readerChild.GetString(2);
                                        int age = readerChild.GetInt32(3);
                                        child = new Child(cnp, name, age);
                                        child.id = child_id;
                                        log.Info($"child with id {child_id} found");
                                    }
                                }
                            }

                            long challenge_id = reader.GetInt64(2);
                            Challenge challenge = null;
                            string sqlChallenge = "SELECT * FROM challenges " +
                                "WHERE id = @id";
                            using (SQLiteCommand commandChallenge = new SQLiteCommand(sqlChallenge, connection))
                            {
                                commandChallenge.Parameters.AddWithValue("@id", id);
                                using (SQLiteDataReader readerChallenge = commandChallenge.ExecuteReader())
                                {
                                    if (readerChallenge.Read())
                                    {
                                        string name = readerChallenge.GetString(1);
                                        string groupAge = readerChallenge.GetString(2);
                                        int numberOfParticipants = readerChallenge.GetInt32(3);
                                        challenge = new Challenge(name, groupAge, numberOfParticipants);
                                        challenge.id = challenge_id;
                                        log.Info($"challenge with id {challenge_id} found");
                                    }
                                }
                            }

                            Enrollment enrollment = new Enrollment(child, challenge);
                            enrollment.id = id;
                            enrollments.Add(enrollment);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
            log.Info($"{enrollments.Count} challenges found");
            return enrollments;
        }

        public Enrollment FindById(long id)
        {
            log.Info($"finding challenge with id {id}");
            try
            {
                string sql = "SELECT * FROM challenges " +
                    "WHERE id = @id";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long child_id = reader.GetInt64(1);
                            Child child = null;
                            string sqlChild = "SELECT * FROM children " +
                                "WHERE id = @id";
                            using (SQLiteCommand commandChild = new SQLiteCommand(sqlChild, connection))
                            {
                                commandChild.Parameters.AddWithValue("@id", child_id);
                                using (SQLiteDataReader readerChild = commandChild.ExecuteReader())
                                {
                                    if (readerChild.Read())
                                    {
                                        long cnp = readerChild.GetInt64(1);
                                        string name = readerChild.GetString(2);
                                        int age = readerChild.GetInt32(3);
                                        child = new Child(cnp, name, age);
                                        child.id = child_id;
                                        log.Info($"child with id {child_id} found");
                                    }
                                }
                            }

                            long challenge_id = reader.GetInt64(2);
                            Challenge challenge = null;
                            string sqlChallenge = "SELECT * FROM challenges " +
                                "WHERE id = @id";
                            using (SQLiteCommand commandChallenge = new SQLiteCommand(sqlChallenge, connection))
                            {
                                commandChallenge.Parameters.AddWithValue("@id", id);
                                using (SQLiteDataReader readerChallenge = commandChallenge.ExecuteReader())
                                {
                                    if (readerChallenge.Read())
                                    {
                                        string name = readerChallenge.GetString(1);
                                        string groupAge = readerChallenge.GetString(2);
                                        int numberOfParticipants = readerChallenge.GetInt32(3);
                                        challenge = new Challenge(name, groupAge, numberOfParticipants);
                                        challenge.id = challenge_id;
                                        log.Info($"challenge with id {challenge_id} found");
                                    }
                                }
                            }

                            Enrollment enrollment = new Enrollment(child, challenge);
                            enrollment.id = id;
                            log.Info($"enrollment with id {id} found");
                            return enrollment;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
            log.Info("enrollment not found");
            return null;
        }

        public Collection<Enrollment> GetAll()
        {
            return new Collection<Enrollment>(FindAll().ToList());
        }

        public void Update(Enrollment elem, long id)
        {
            log.Info($"updating enrollment {elem} ");
            try
            {
                string sql = "UPDATE enrollments " +
                    "SET child_id = @child_id, challenge_id = @challenge_id " +
                    "WHERE id = @id";
                SQLiteConnection connection = dbUtils.GetConnection();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@child_id", elem.child.id);
                    command.Parameters.AddWithValue("@challenge_id", elem.challenge.id);
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
