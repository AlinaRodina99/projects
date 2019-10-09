using System;

namespace MoveToFrontNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var algorithm = new MoveToFront();
            var list = algorithm.StringCoding("bananaaa");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}
