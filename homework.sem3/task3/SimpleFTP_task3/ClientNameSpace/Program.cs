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
            var client = new Client(8888);
            Console.WriteLine("Choose List or Get function: 1 - List, 2 - Get");
            var requestNumber = Console.ReadLine();
            Console.WriteLine("Enter path: ");
            var path = Console.ReadLine();
            if (Int32.TryParse(requestNumber, out int number))
            {
                if (number == 1)
                {
                    var responce = client.List(path).Result;
                    Console.WriteLine(responce);
                }
                else if (number == 2)
                {

                }
                else
                {
                    Console.WriteLine("Wrong command!");
                }
            }
            else
            {
                Console.WriteLine("Incorrect data!");
            }
        }
    }
}
