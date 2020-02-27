using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server(49664);
            server.Listen();
        }
    }
}
