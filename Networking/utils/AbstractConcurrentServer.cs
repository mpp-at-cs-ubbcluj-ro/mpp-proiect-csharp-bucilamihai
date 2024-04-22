using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Networking.utils
{
    public abstract class AbstractConcurrentServer: AbstractServer
    {
        public AbstractConcurrentServer(string host, int port) : base(host, port)
        {
            Console.WriteLine("Concurrent AbstractServer");
        }

        protected override void ProcessRequest(TcpClient client)
        {
            Thread tw = CreateWorker(client);
            tw.Start();
        }

        protected abstract Thread CreateWorker(TcpClient client);
    }
}
