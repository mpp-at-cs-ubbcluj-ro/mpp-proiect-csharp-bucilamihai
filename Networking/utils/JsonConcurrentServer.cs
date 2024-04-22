using Networking.json;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Networking.utils
{
    public class JsonConcurrentServer : AbstractConcurrentServer
    {
        private IService server;

        public JsonConcurrentServer(string host, int port, IService server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("Contest - JsonConcurrentServer");
        }

        protected override Thread CreateWorker(TcpClient client)
        {
            ClientJsonWorker worker = new ClientJsonWorker(server, client);
            return new Thread(worker.Run);
        }
    }
}
