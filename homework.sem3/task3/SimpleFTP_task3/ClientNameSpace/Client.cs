using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;

namespace ClientNameSpace
{
    /// <summary>
    /// Class that implements client.   
    /// </summary>
    public class Client
    {
        private readonly TcpClient tcpClient;
        private readonly StreamWriter writer;
        private readonly StreamReader reader;
        
        public Client(string host, int port)
        {
            if (port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
            {
                throw new ArgumentOutOfRangeException("The number of port should be between 0 and 65535!");
            }

            tcpClient = new TcpClient(host, port);
            writer = new StreamWriter(tcpClient.GetStream());
            reader = new StreamReader(tcpClient.GetStream());
        }

        public async Task<string> List(string path)
        {
            try
            {
                using (writer)
                {

                    await writer.WriteLineAsync("1 " + path);
                    var responce = new StringBuilder();
                    using (reader)
                    {
                        var size = await reader.ReadLineAsync();
                        if (size == "-1")
                        {
                            Console.WriteLine("Such directory does not exist!");
                            return "-1";
                        }

                        responce.Append(size);
                        
                        for (var i = 0; i < Convert.ToInt32(size); ++i)
                        {
                            responce.AppendLine(await reader.ReadLineAsync() + " " + Convert.ToBoolean(await reader.ReadLineAsync()));
                        }
                    }

                    return responce.ToString();
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
            finally
            {
                tcpClient?.Close();
            }
        }

        public async Task<string> Get(string path)
        {
            try
            {
                using (writer)
                {
                    await writer.WriteLineAsync("2 " + path);
                    var responce = new StringBuilder();
                    using (reader)
                    {
                        var size = await reader.ReadLineAsync();
                        if (size == "-1")
                        {
                            Console.WriteLine("This path does not exist!");
                            return "-1";
                        }

                        responce.Append(size);
                        responce.Append(await reader.ReadToEndAsync());
                    }
                    return responce.ToString();
                }
            }
            catch (Exception exception)
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
}
