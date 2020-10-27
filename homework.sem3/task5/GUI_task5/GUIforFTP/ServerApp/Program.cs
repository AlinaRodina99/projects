using System.Threading.Tasks;
using System;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] _)
        {
            var server = new Server(8888);
            Task.Run(async () => await server.ServerWork());
            Console.ReadKey();
        }
    }
}
