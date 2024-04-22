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
        private TcpListener server = null;

        public AbstractServer(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public void Start()
        {
            try
            {
                IPAddress adr = IPAddress.Parse(host);
                IPEndPoint ep = new IPEndPoint(adr, port);
                server = new TcpListener(ep);
                server.Start();
                while (true)
                {
                    Console.WriteLine("Waiting for clients ...");
                    TcpClient client = server.AcceptTcpClient();
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

        protected abstract void ProcessRequest(TcpClient client);

        public void Stop()
        {
            try
            {
                server.Stop();
            }
            catch (Exception e)
            {
                throw new ServerException("Closing server error ", e);
            }
        }
    }
}
