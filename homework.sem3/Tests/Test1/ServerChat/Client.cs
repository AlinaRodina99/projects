using System;
using System.Net.Sockets;
using System.Text;

namespace ServerChat
{
    public class Client
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        private TcpClient client;
        private Server server;

        public Client(TcpClient tcpClient, Server server)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            this.server = server;
            server.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                string message = GetMessage();
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {

                    message = GetMessage();
                    message = String.Format("{0}", message);
                    Console.WriteLine(message);
                    if (message == "exit")
                    {
                        Close();
                        server.Disconnect();
                    }
                    server.BroadcastMessage(message, Id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.Disconnect();
                Close();
            }
        }

        private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void Close()
        {
            if (Stream != null)
            {
                Stream.Close();
            }

            if (client != null)
            {
                client.Close();
            }
            Environment.Exit(0);
        }
    }
}
