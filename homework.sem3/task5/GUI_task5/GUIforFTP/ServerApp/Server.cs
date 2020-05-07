using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ServerApp
{
    public class Server 
    {
        private readonly TcpListener tcpListener;
        private readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

        /// <summary>
        /// Constructor to create server.
        /// </summary>
        /// <param name="port">Port of the server.</param>
        public Server(int port)
        {
            if (port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
            {
                throw new ArgumentOutOfRangeException("Port should be from 0 to 65535");
            }

            tcpListener = new TcpListener(IPAddress.Any, port);
        }

        /// <summary>
        /// Method to run server.
        /// </summary>
        public async Task ServerWork()
        {
            tcpListener.Start();

            while (!tokenSource.IsCancellationRequested)
            {
                var client = await tcpListener.AcceptTcpClientAsync();
                await Task.Run(() => ClientThread(client));
            }

            tcpListener.Stop();
        }

        /// <summary>
        /// Method to work with client.
        /// </summary>
        /// <param name="tcpClient">Client that is served by the server./param>
        private async Task ClientThread(TcpClient tcpClient)
        {
            try
            {
                using (var stream = tcpClient.GetStream())
                {
                    var reader = new StreamReader(stream);
                    var writer = new StreamWriter(stream) { AutoFlush = true };

                    var request = await reader.ReadLineAsync();
                    var requestArgs = ParseRequest(request);

                    switch (requestArgs[0])
                    {
                        case "1":
                            await List(requestArgs[1], writer);
                            break;
                        case "2":
                            await Get(requestArgs[1], writer);
                            break;
                        default:
                            Console.WriteLine("Wrong command!");
                            break;
                    }
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Method to get listing of files and directories on the specified path.
        /// </summary>
        /// <param name="path">Path to the files and directories.</param>
        /// <param name="writer">Stream to write responce to the client.</param>
        public async Task List(string path, StreamWriter writer)
        {
            if (!Directory.Exists(path))
            {
                await writer.WriteLineAsync("-1");
                return;
            }

            var files = Directory.GetFiles(path);
            var dirs = Directory.GetDirectories(path);

            await writer.WriteLineAsync($"{files.Length + dirs.Length}");

            foreach (var file in files)
            {
                await writer.WriteLineAsync(file);
                await writer.WriteLineAsync("false");
            }

            foreach (var dir in dirs)
            {
                await writer.WriteLineAsync(dir);
                await writer.WriteLineAsync("true");
            }
        }

        /// <summary>
        /// Method to download file from server.
        /// </summary>
        /// <param name="path">Specified path of the file.</param>
        /// <param name="writer">Stream to write responce to the client.</param>
        public async Task Get(string path, StreamWriter writer)
        {
            if (!File.Exists(path))
            {
                await writer.WriteLineAsync("-1");
                return;
            }

            await writer.WriteLineAsync($"{new FileInfo(path).Length}");

            using (var file = File.OpenRead(path))
            {
                await file.CopyToAsync(writer.BaseStream);
            }
        }

        /// <summary>
        /// Method to parse query string.
        /// </summary>
        /// <param name="request">Query string.</param>
        /// <returns>Array of strings.</returns>
        private string[] ParseRequest(string request)
        {
            var requestArgs = request.Split();
            return requestArgs;
        }

        /// <summary>
        /// Method to stop server work.
        /// </summary>
        public void Stop() => tokenSource.Cancel();
    }
}
