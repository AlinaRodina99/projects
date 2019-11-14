using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientNameSpace
{
    public class Client
    {
        private readonly TcpClient tcpClient;

        public Client(int port, string address)
        {
            tcpClient = new TcpClient(address, port);
        }

        public void Send(string path)
        {
            try
            {
                var stream = tcpClient.GetStream();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                tcpClient.Close();
            }
        }
    }
}
