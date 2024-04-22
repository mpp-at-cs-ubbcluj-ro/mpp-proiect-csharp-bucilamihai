using Model;
using Networking.dto;
using Networking.json;
using Newtonsoft.Json;
using Service;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading;

public class ClientJsonWorker : IObserver
{
    private IService server;
    private TcpClient connection;

    private StreamReader input;
    private StreamWriter output;
    private JsonSerializer jsonSerializer;
    private volatile bool connected;

    public ClientJsonWorker(IService server, TcpClient connection)
    {
        this.server = server;
        this.connection = connection;
        jsonSerializer = new JsonSerializer();
        try
        {
            output = new StreamWriter(connection.GetStream());
            input = new StreamReader(connection.GetStream());
            connected = true;
        }
        catch (IOException e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    public void Run()
    {
        while (connected)
        {
            try
            {
                string requestLine = input.ReadLine();
                if (requestLine != null)
                {
                    Request request = JsonConvert.DeserializeObject<Request>(requestLine);
                    Response response = HandleRequest(request);
                    if (response != null)
                    {
                        SendResponse(response);
                    }
                }
                else
                {
                    connected = false;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            try
            {
                Thread.Sleep(1000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        try
        {
            input.Close();
            output.Close();
            connection.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine("Error " + e);
        }
    }

    private Response HandleRequest(Request request)
    {
        Response response = null;
        if (request.Type == RequestType.LOGIN)
        {
            Console.WriteLine("Login request ..." + request.Type);
            OfficeResponsableDTO officeResponsableDTO = request.OfficeResponsable;
            OfficeResponsable officeResponsable = DTOUtils.GetFromDTO(officeResponsableDTO);
            try
            {
                server.Login(officeResponsable, this);
                return JsonProtocolUtils.CreateOkResponse();
            }
            catch (ServiceException e)
            {
                connected = false;
                return JsonProtocolUtils.CreateErrorResponse(e.Message);
            }
        }
        if (request.Type == RequestType.GET_ALL_CHALLENGES)
        {
            Console.WriteLine("Get all challenges request ...");
            try
            {
                Challenge[] challenges = server.GetAllChallenges().ToArray();
                response = JsonProtocolUtils.CreateAllChallengesResponse(challenges);
            }
            catch (ServiceException e)
            {
                return JsonProtocolUtils.CreateErrorResponse(e.Message);
            }
        }
        if (request.Type == RequestType.GET_CHILDREN_BY_CHALLENGE_NAME_AND_GROUP_AGE)
        {
            Console.WriteLine("Get children by challenge name and group age request ..." + request.Type);
            ChallengeDTO challengeDTO = request.Challenge;
            Challenge challenge = DTOUtils.GetFromDTO(challengeDTO);
            try
            {
                Child[] children = server.GetEnrolledChildren(challenge.Name, challenge.GroupAge).ToArray();
                response = JsonProtocolUtils.CreateAllChildrenByChallengeNameAndGroupAgeResponse(children);
            }
            catch (ServiceException e)
            {
                throw new Exception(e.Message);
            }
        }

        if (request.Type == RequestType.ENROLL_CHILD)
        {
            Console.WriteLine("Enroll child request ..." + request.Type);
            try
            {
                ChildDTO childDTO = request.Child;
                Child child = DTOUtils.GetFromDTO(childDTO);
                string challengeName = request.ChallengeName;
                server.EnrollChild(child.Cnp, child.Name, child.Age, challengeName);
                return JsonProtocolUtils.CreateUpdateChallengesResponse();
            }
            catch (ServiceException e)
            {
                return JsonProtocolUtils.CreateErrorResponse(e.Message);
            }
        }
        return response;
    }

    private void SendResponse(Response response)
    {
        string responseLine = JsonConvert.SerializeObject(response);
        Console.WriteLine("sending response " + responseLine);
        lock (output)
        {
            output.WriteLine(responseLine);
            output.Flush();
        }
    }

    public virtual void UpdateEnrolledChildren()
    {
        try
        {
            SendResponse(new Response());
        }
        catch (Exception e)
        {
            throw new ServiceException("Sending error: " + e);
        }
    }
}
