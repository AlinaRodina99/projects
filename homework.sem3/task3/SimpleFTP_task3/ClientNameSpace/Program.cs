using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client(49664, "localhost");
            client.Send("homework/projects");
            client.ReceiveMessages();
        }
    }
}
