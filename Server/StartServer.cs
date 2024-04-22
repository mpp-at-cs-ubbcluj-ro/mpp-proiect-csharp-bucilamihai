using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Service;
using Persistence.database;
using Persistence.interfaces;
using Networking;
using System.Net.Sockets;
using Networking.utils;


namespace Server
{
    public class StartServer
    {
        private static int DEFAULT_PORT = 55556;
        private static String DEFAULT_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            Console.WriteLine("Reading properties from app.config ...");
            int port = DEFAULT_PORT;
            String ip = DEFAULT_IP;
            String portStr = ConfigurationManager.AppSettings["port"];
            if(portStr == null)
            {
                Console.WriteLine("Port property not set. Using default value " + DEFAULT_PORT);
            }
            else
            {
                bool result = Int32.TryParse(portStr, out port);
                if(!result)
                {
                    Console.WriteLine("Port property is not a valid number. Using default value " + DEFAULT_PORT);
                    port = DEFAULT_PORT;
                }
                Console.WriteLine("Port property set to " + port);
            }
            String ipStr = ConfigurationManager.AppSettings["ip"];
            if(ipStr == null)
            {
                Console.WriteLine("IP property not set. Using default value " + DEFAULT_IP);
            }
            Console.WriteLine("Configuration Settings for database {0}", GetConnectionStringByName("url"));

            Dictionary<string, string> properties = new Dictionary<string, string>();
            string url = ConfigurationManager.ConnectionStrings["url"].ConnectionString;
            properties["url"] = url;
            IOfficeResponsableRepository officeResponsableRepository = new OfficeResponsableDBRepository(properties);
            IChallengeRepository challengeRepository = new ChallengeDBRepository(properties);
            IChildRepository childRepository = new ChildDBRepository(properties);
            IEnrollmentRepository enrollmentRepository = new EnrollmentDBRepository(properties);
            IService officeService = new OfficeService(officeResponsableRepository, challengeRepository, childRepository, enrollmentRepository);

            Console.WriteLine("Starting server on IP {0} and port {1} ...", ip, port);
            AbstractServer server = new JsonConcurrentServer(ip, port, officeService);
            server.Start();
            Console.WriteLine("Server started ...");
        }

        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if(settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }
    }
}
