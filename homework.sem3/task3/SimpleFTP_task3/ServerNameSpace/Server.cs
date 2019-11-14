using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerNameSpace
{
    public class Server
    {
        private TcpListener tcpListener;

        public Server(int port)
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
        }

        public void Listen()
        {
            try
            {
                while (true)
                {
                    var tcpClient = tcpListener.AcceptTcpClient();
                    var client = new ClientObject(tcpClient);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                tcpListener?.Stop();
            }
        }
    }
}
