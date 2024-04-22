using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Networking.utils
{
    public abstract class AbstractServer
    {
        private int port;
        private string host;
        private Socket server = null;

        public AbstractServer(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public void Start()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(host);
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
                server = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(localEndPoint);
                server.Listen(10);
                while (true)
                {
                    Console.WriteLine("Waiting for clients ...");
                    Socket client = server.Accept();
                    Console.WriteLine("Client connected ...");
                    //Task.Run(() => ProcessRequest(client));
                    ProcessRequest(client);
                }
            }
            catch (Exception e)
            {
                throw new ServerException("Starting server error ", e);
            }
            finally
            {
                Stop();
            }
        }

        protected abstract void ProcessRequest(Socket client);

        public void Stop()
        {
            try
            {
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            catch (Exception e)
            {
                throw new ServerException("Closing server error ", e);
            }
        }
    }
}
