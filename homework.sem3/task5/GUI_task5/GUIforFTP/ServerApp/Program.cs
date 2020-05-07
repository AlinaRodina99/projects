using System.Threading.Tasks;
using System;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] _)
        {
            var server = new Server(4545);
            Task.Run(async () => await server.ServerWork());
            Console.ReadKey();
        }
    }
}
