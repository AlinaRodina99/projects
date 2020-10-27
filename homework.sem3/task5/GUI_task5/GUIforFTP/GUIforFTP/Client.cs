using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Net;

namespace GUIforFTP
{
    /// <summary>
    /// Class that implements client.   
    /// </summary>
    public class Client
    {
        private readonly string host;
        private readonly int port;

        /// <summary>
        /// Constructor to create client.
        /// </summary>
        /// <param name="port">Port of the server.</param>
        /// <param name="host">Localhost on default mode..</param>
        public Client(int port, string host = "localhost")
        {
            if (port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
            {
                throw new ArgumentOutOfRangeException($"Port should be from { IPEndPoint.MinPort } to { IPEndPoint.MaxPort}");
            }

            this.port = port;
            this.host = host;
        }

        /// <summary>
        /// Method that makes request for list function.
        /// </summary>
        /// <param name="path">Specified path.</param>
        public async Task<List<(string name, string type)>> List(string path)
        {
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(host, port);
                try
                {
                    using (var writer = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true })
                    {
                        await writer.WriteLineAsync($"1 {path}");
                        var list = new List<(string, string)>();
                        using (var reader = new StreamReader(tcpClient.GetStream()))
                        {
                            var size = await reader.ReadLineAsync();
                            if (size == "-1")
                            {
                                Console.WriteLine("Such directory does not exist!");
                                return null;
                            }

                            for (var i = 0; i < Convert.ToInt32(size); ++i)
                            {
                                var file = await reader.ReadLineAsync();
                                var isDir = await reader.ReadLineAsync();
                                (string, string) fileAndIsDir = (null, null);

                                if (Convert.ToBoolean(isDir))
                                {
                                    fileAndIsDir = (file, "Folder");
                                }
                                else
                                {
                                    fileAndIsDir = (file, "File");
                                }

                                list.Add(fileAndIsDir);
                            }
                        }

                        return list;
                    }
                }

                catch (SocketException exception)
                {
                    Console.WriteLine(exception.Message);
                    return null;
                }
                finally
                {
                    tcpClient?.Close();
                }
            }
        }

        /// <summary>
        /// Method that makes request for get function.
        /// </summary>
        /// <param name="path">Specified path.</param>
        public async Task Get(string path, string newPath)
        {
            using (var tcpClient = new TcpClient())
            {
                await tcpClient.ConnectAsync(host, port);
                try
                {
                    using (var writer = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true })
                    {
                        await writer.WriteLineAsync("2 " + path);
                        using (var reader = new StreamReader(tcpClient.GetStream()))
                        {
                            var size = Convert.ToInt32(await reader.ReadLineAsync());
                            if (size == -1)
                            {
                                throw new FtpClientException("This path does not exist!");
                            }

                            using (var fileResult = new FileStream(newPath, FileMode.Create, FileAccess.Write))
                            {
                                await reader.BaseStream.CopyToAsync(fileResult);

                                fileResult.Flush();
                                fileResult.Close();
                            }
                        }
                    }
                }
                catch (SocketException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
