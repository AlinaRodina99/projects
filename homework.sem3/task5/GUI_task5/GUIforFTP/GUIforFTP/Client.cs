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
        private readonly TcpClient tcpClient;
        private readonly StreamWriter writer;
        private readonly StreamReader reader;

        /// <summary>
        /// Constructor to create client.
        /// </summary>
        /// <param name="port">Port of the server.</param>
        /// <param name="host">Localhost.</param>
        public Client(int port, string host = "localhost")
        {
            if (port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
            {
                throw new ArgumentOutOfRangeException("Port should be from 0 to 65535");
            }

            tcpClient = new TcpClient(host, port);
            writer = new StreamWriter(tcpClient.GetStream()) { AutoFlush = true };
            reader = new StreamReader(tcpClient.GetStream());
        }

        /// <summary>
        /// Method that makes request for list function.
        /// </summary>
        /// <param name="path">Specified path.</param>
        public async Task<List<(string name, string type)>> List(string path)
        {
            try
            {
                using (writer)
                {
                    await writer.WriteLineAsync($"1 {path}");
                    var list = new List<(string, string)>();
                    using (reader)
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
                            var fileAndIsDir = (file, isDir);
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
                tcpClient.Close();
            }
        }

        public void Close() => tcpClient.Close();

        /// <summary>
        /// Method that makes request for get function.
        /// </summary>
        /// <param name="path">Specified path.</param>
        public async Task<(long, byte[])> Get(string path)
        {
            try
            {
                using (writer)
                {
                    await writer.WriteLineAsync("2 " + path);
                    using (reader)
                    {
                        var size = Convert.ToInt32(await reader.ReadLineAsync());
                        if (size == -1)
                        {
                            Console.WriteLine("This path does not exist!");
                            return (-1, null);
                        }

                        var content = new byte[size];
                        await reader.BaseStream.ReadAsync(content, 0, size);
                        return (size, content);
                    }
                }
            }
            catch (SocketException exception)
            {
                Console.WriteLine(exception.Message);
                return (-1, null);
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}
