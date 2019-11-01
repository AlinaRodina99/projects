using System;
using System.Threading;

namespace ServerChat
{
    class Program
    {
        static Server server; // сервер
        static Thread listenThread; // потока для прослушивания
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите порт: ");
                var port = Convert.ToInt32(Console.ReadLine());
                server = new Server(port);
                listenThread = new Thread(server.Listen);
                listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
