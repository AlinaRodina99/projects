using System;

namespace Fibonachhi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Result: {Fibonachhi(8)}");
            Console.ReadKey();
        }

        static int Fibonachhi(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonachhi(n - 1) + Fibonachhi(n - 2);
            }
        }
    }
}
