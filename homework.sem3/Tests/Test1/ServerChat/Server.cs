using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerChat
{
    public class Server
    {
        private static TcpListener tcpListener; // сервер для прослушивания
        private static TcpClient tcpClient = tcpListener.AcceptTcpClient();
        private Client client;
        private int port;

        public Server(int port)
        {
            this.port = port;
        }

        protected internal void AddConnection(Client client)
        {
            this.client = client;
        }

        // прослушивание входящих подключений
        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(port);
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Thread clientThread = new Thread(new ThreadStart(client.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }

        protected internal void BroadcastMessage(string message, string id)
        {
            if (message == "exit")
            {
                Disconnect();
            }
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Stream.Write(data, 0, data.Length); //передача данных
        }

        protected internal void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера
            client.Close();
            Environment.Exit(0); //завершение процесса
        }
    }
}

