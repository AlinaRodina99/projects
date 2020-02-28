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
        private readonly CancellationTokenSource tokenSource;

        public Server(int port)
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
        }

        public async Task ServerWork()
        {
            try
            {
                while (!tokenSource.IsCancellationRequested)
                {
                    var client = await tcpListener.AcceptTcpClientAsync();
                    await ClientThread();
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                tcpListener.Stop();
            }
        }

        private async Task ClientThread()
        {
            var tcpClient = await tcpListener.AcceptTcpClientAsync();
            clientObject = new ClientObject();
            var stream = tcpClient.GetStream();
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            
            var request = await reader.ReadLineAsync();
            var requestArgs = ParseRequest(request);

            switch(requestArgs[0])
            {
                case "1" :
                    await clientObject.List(requestArgs[1], writer);
                    break;
                case "2" :
                    await clientObject.Get(requestArgs[1], writer);
                    break;
                default :
                    Console.WriteLine("Wrong command!");
                    break;
            }
        }

        private string[] ParseRequest(string request)
        {
            var requestArgs = request.Split(' ');
            return requestArgs;
        }

        public void Stop() => tokenSource.Cancel();
    }
}
