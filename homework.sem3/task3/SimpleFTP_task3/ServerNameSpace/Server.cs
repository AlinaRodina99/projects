using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ServerNameSpace
{
    public class Server 
    {
        private readonly TcpListener tcpListener;
        private ClientObject clientObject = new ClientObject();
        private readonly CancellationTokenSource cancellationTokenSource;

        public Server(int port)
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
        }

        public async Task ServerWork()
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                ThreadPool.QueueUserWorkItem(ClientThread);
            }
        }

        private async Task ClientThread()
        {
            var tcpClient = await tcpListener.AcceptTcpClientAsync();
            var stream = tcpClient.GetStream();
            var reader = new StreamReader(stream);

            var request = await reader.ReadLineAsync();
            var chars = request.ToCharArray();

            while ()
        }

        public async Task Start()
        {
            var tcpClient = new TcpClient();
            clientObject = new ClientObject(tcpClient);
            if (!cancellationTokenSource.IsCancellationRequested)
            {
                ThreadPool.QueueUserWorkItem(GetRequestFromClient(), await tcpListener.AcceptTcpClientAsync());

            }
        }

        private async void GetRequestFromClient()
        {
            try
            {
                var tcpClient = 
            }
            catch(IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private (string, string) ParseRequest(string request)
        {
            var charRequest = request.Split(' ');
            if (charRequest[0] == "1")
            {
                return 
            }
        }

        public void Stop() => tcpListener?.Stop();
    }
}
