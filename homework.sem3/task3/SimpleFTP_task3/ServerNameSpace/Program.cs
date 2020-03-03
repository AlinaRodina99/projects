using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerNameSpace
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new Server(8888);
            await server.ServerWork();
            Console.ReadKey();
            server.Stop();
        }
    }
}
