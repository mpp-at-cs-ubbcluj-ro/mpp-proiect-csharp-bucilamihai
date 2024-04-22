using Model;
using Networking.dto;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Networking.json
{
    public class ServiceJsonProxy : IService
    {
        private string host;
        private int port;

        private IObserver client;

        private StreamReader input;
        private StreamWriter output;

        private Socket connection;

        private BlockingCollection<Response> qresponses;
        private volatile bool finished;

        public ServiceJsonProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            qresponses = new BlockingCollection<Response>();
        }

        public void Login(OfficeResponsable officeResponsable, IObserver client)
        {
            InitializeConnection();
            Request request = JsonProtocolUtils.CreateLoginRequest(officeResponsable);
            SendRequest(request);
            Response response = ReadResponse();
            if (response.type == ResponseType.OK)
            {
                this.client = client;
                return;
            }
            if (response.type == ResponseType.ERROR)
            {
                string error = response.errorMessage;
                CloseConnection();
                throw new ServiceException(error);
            }
        }

        public Collection<Challenge> GetAllChallenges()
        {
            Request request = JsonProtocolUtils.CreateAllChallengesRequest();
            SendRequest(request);
            Response response = ReadResponse();
            if (response.type == ResponseType.ERROR)
            {
                string error = response.errorMessage;
                throw new ServiceException(error);
            }
            ChallengeDTO[] challengeDTO = response.challenges;
            Challenge[] challenges = DTOUtils.GetFromDTO(challengeDTO);
            return new Collection<Challenge>(challenges);
        }

        public Collection<Child> GetEnrolledChildren(string challengeName, string groupAge)
        {
            Challenge challenge = new Challenge(challengeName, groupAge, 0);
            Request request = JsonProtocolUtils.CreateGetChildrenByChallengeNameAndGroupAgeRequest(challenge);
            SendRequest(request);
            Response response = ReadResponse();
            if (response.type == ResponseType.ERROR)
            {
                string error = response.errorMessage;
                throw new ServiceException(error);
            }
            ChildDTO[] childrenDTO = response.children;
            Child[] children = DTOUtils.GetFromDTO(childrenDTO);
            return new Collection<Child>(children);
        }

        public void EnrollChild(long cnp, string name, int age, string challengeName)
        {
            Child child = new Child(cnp, name, age);
            Request request = JsonProtocolUtils.CreateEnrollChildRequest(child, challengeName);
            SendRequest(request);
            Response response = JsonProtocolUtils.CreateUpdateChallengesResponse();
            if (response.type == ResponseType.ERROR)
            {
                string error = response.errorMessage;
                throw new ServiceException(error);
            }
        }

        private void CloseConnection()
        {
            finished = true;
            try
            {
                input.Close();
                output.Close();
                connection.Close();
                client = null;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void SendRequest(Request request)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            }; // server C# - client java

            string reqLine = JsonConvert.SerializeObject(request);
            //string reqLine = JsonSerializer.Serialize(request);
            try
            {
                Console.WriteLine($"output: {reqLine}");
                output.WriteLine(reqLine);
                output.Flush();
            }
            catch (Exception e)
            {
                throw new ServiceException("Error sending object " + e);
            }
        }

        private Response ReadResponse()
        {
            try
            {
                Response response = qresponses.Take();
                return response;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Timeout waiting for response.");
                return null;
            }
        }

        private void InitializeConnection()
        {
            try
            {
                connection = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                connection.Connect(host, port);
                NetworkStream networkStream = new NetworkStream(connection);
                input = new StreamReader(networkStream);
                output = new StreamWriter(networkStream);
                finished = false;
                StartReader();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void HandleUpdate(Response response)
        {
            if (response.type == ResponseType.UPDATE_CHALLENGES)
            {
                Console.WriteLine("(handleUpdate) - update challenges");
                client.UpdateEnrolledChildren();
            }
        }

        private bool IsUpdate(Response response)
        {
            return response.type == ResponseType.UPDATE_CHALLENGES;
        }

        private void StartReader()
        {
            Thread tw = new Thread(new ThreadStart(new ReaderThread(this).Run));
            tw.Start();
        }

        private class ReaderThread
        {
            private ServiceJsonProxy serviceJsonProxy;

            public ReaderThread(ServiceJsonProxy serviceJsonProxy)
            {
                this.serviceJsonProxy = serviceJsonProxy;
            }

            public void Run()
            {
                while (!serviceJsonProxy.finished)
                {
                    try
                    {
                        string responseLine = serviceJsonProxy.input.ReadLine();
                        Console.WriteLine("response received " + responseLine);
                        Response response = JsonConvert.DeserializeObject<Response>(responseLine);
                        //Response response = JsonSerializer.Deserialize<Response>(responseLine);                    
                        if (serviceJsonProxy.IsUpdate(response))
                        {
                            serviceJsonProxy.HandleUpdate(response);
                        }
                        else
                        {
                            try
                            {
                                serviceJsonProxy.qresponses.Add(response);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Reading error " + e);
                    }
                }
            }
        }
    }
}
