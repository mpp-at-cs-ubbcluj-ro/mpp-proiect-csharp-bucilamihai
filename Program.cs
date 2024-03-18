using ChildrenContest.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data.SQLite;
using ChildrenContest.repository;
using ChildrenContest.repository.database;

namespace ChildrenContest
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log.Info("Hello logging world!");
            Console.WriteLine("Hit enter");
            Console.ReadLine();

            // Connection string
            string connectionString = "Data Source=\"C:\\Users\\bmcmi\\IdeaProjects\\databases\\children_contest.db\";Version=3;";

            // Create connection
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                IChallengeRepository challengeRepository = new ChallengeDBRepository(connection);
                //challengeRepository.Add(new Challenge("test", "test", 0));

                foreach (Challenge challenge in challengeRepository.FindAll())
                {
                    Console.WriteLine(challenge.Id + challenge.Name);
                }

                Console.WriteLine(challengeRepository.FindById(4));

                challengeRepository.Delete(challengeRepository.FindById(4));

                foreach (Challenge challenge in challengeRepository.FindAll())
                {
                    Console.WriteLine(challenge.Id + challenge.Name);
                }

                challengeRepository.Update(new Challenge("updatetest", "updatetest", 0), 3);

                foreach (Challenge challenge in challengeRepository.FindAll())
                {
                    Console.WriteLine(challenge.Id + challenge.Name);
                }

                // Close the connection
                connection.Close();
            }
        }
    }
}
