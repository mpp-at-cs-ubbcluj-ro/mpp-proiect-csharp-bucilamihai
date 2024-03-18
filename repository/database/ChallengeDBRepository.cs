using ChildrenContest.domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using log4net.Repository.Hierarchy;

namespace ChildrenContest.repository.database
{
    internal class ChallengeDBRepository : IChallengeRepository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        SQLiteConnection connection;

        public ChallengeDBRepository(SQLiteConnection connection) 
        { 
            this.connection = connection;
        }

        public void Add(Challenge elem)
        {
            log.Info($"adding challenge {elem} ");
            try
            {
                string sql = "INSERT INTO challenges (name, groupAge, numberOfParticipants) VALUES (@name, @groupAge, @numberOfParticipants)";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", elem.Name);
                    command.Parameters.AddWithValue("@groupAge", elem.GroupAge);
                    command.Parameters.AddWithValue("@numberOfParticipants", elem.NumberOfParticipants);
                    int result = command.ExecuteNonQuery();
                    log.Info($"added {result} instances");
                }
            }
            catch (Exception ex) 
            {
                log.Error(ex);
            }
        }

        public void Delete(Challenge elem)
        {
            log.Info($"deleting challenge {elem} ");
            try
            {
                string sql = "DELETE FROM challenges " +
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

        public IEnumerable<Challenge> FindAll()
        {
            log.Info("finding all challenges");
            HashSet<Challenge> challenges = new HashSet<Challenge>();
            try
            { 
                string sql = "SELECT * FROM challenges";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt64(0);
                            string name = reader.GetString(1);
                            string groupAge = reader.GetString(2);
                            int numberOfParticipants = reader.GetInt32(3);
                            Challenge challenge = new Challenge(name, groupAge, numberOfParticipants);
                            challenge.Id = id;
                            challenges.Add(challenge);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                log.Error(e);
            }
            log.Info($"{challenges.Count} challenges found");
            return challenges;
        }

        public Challenge FindById(long id)
        {
            log.Info($"finding challenge with id {id}");
            try
            {
                string sql = "SELECT * FROM challenges " +
                    "WHERE id = @id";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            string name = reader.GetString(1);
                            string groupAge = reader.GetString(2);
                            int numberOfParticipants = reader.GetInt32(3);
                            Challenge challenge = new Challenge(name, groupAge, numberOfParticipants);
                            challenge.Id = id;
                            log.Info($"challenge with id {id} found");
                            return challenge;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                log.Error(e);
            }
            log.Info("challenge not found");
            return null;
        }

        public Collection<Challenge> GetAll()
        {
            return new Collection<Challenge>(FindAll().ToList());
        }

        public void Update(Challenge elem, long id)
        {
            log.Info($"updating challenge {elem} ");
            try
            {
                string sql = "UPDATE challenges " +
                    "SET name = @name, groupAge = @groupAge, numberOfParticipants = @numberOfParticipants " +
                    "WHERE id = @id";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", elem.Name);
                    command.Parameters.AddWithValue("@groupAge", elem.GroupAge);
                    command.Parameters.AddWithValue("@numberOfParticipants", elem.NumberOfParticipants);
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
