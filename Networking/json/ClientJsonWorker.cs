using Model;
using Networking.dto;
using Networking.json;
using Service;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading;
using Newtonsoft.Json;

public class ClientJsonWorker : IObserver
{
    private IService server;
    private Socket connection;

    private StreamReader input;
    private StreamWriter output;
    private volatile bool connected;

    public ClientJsonWorker(IService server, Socket connection)
    {
        this.server = server;
        this.connection = connection;
        try
        {
            NetworkStream networkStream = new NetworkStream(connection);
            input = new StreamReader(networkStream);
            output = new StreamWriter(networkStream);
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
                Request request = JsonConvert.DeserializeObject<Request>(requestLine);
                //Request request = JsonSerializer.Deserialize<Request>(requestLine);
                Response response = HandleRequest(request);
                if (response != null)
                {
                    SendResponse(response);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Thread.Sleep(1000);
        }
        try
        {
            input.Close();
            output.Close();
            connection.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    private Response HandleRequest(Request request)
    {
        Response response = null;
        if (request.type == RequestType.LOGIN)
        {
            Console.WriteLine("Login request ..." + request.type);
            OfficeResponsableDTO officeResponsableDTO = request.officeResponsable;
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
        if (request.type == RequestType.GET_ALL_CHALLENGES)
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
        if (request.type == RequestType.GET_CHILDREN_BY_CHALLENGE_NAME_AND_GROUP_AGE)
        {
            Console.WriteLine("Get children by challenge name and group age request ..." + request.type);
            ChallengeDTO challengeDTO = request.challenge;
            Challenge challenge = DTOUtils.GetFromDTO(challengeDTO);
            try
            {
                Child[] children = server.GetEnrolledChildren(challenge.name, challenge.groupAge).ToArray();
                response = JsonProtocolUtils.CreateAllChildrenByChallengeNameAndGroupAgeResponse(children);
            }
            catch (ServiceException e)
            {
                throw new Exception(e.Message);
            }
        }

        if (request.type == RequestType.ENROLL_CHILD)
        {
            Console.WriteLine("Enroll child request ..." + request.type);
            try
            {
                ChildDTO childDTO = request.child;
                Child child = DTOUtils.GetFromDTO(childDTO);
                string challengeName = request.challengeName;
                server.EnrollChild(child.cnp, child.name, child.age, challengeName);
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
        //string responseLine = JsonConvert.SerializeObject(response);
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter() }
        };
        //string responseLine = JsonSerializer.Serialize(response, options);
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
