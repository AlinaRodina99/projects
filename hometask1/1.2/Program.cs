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
            if (n <= 2)
            {
                return 1;
            }
            int a = 1;
            int b = 1;
            int res = 0;
            for (int i = 3; i <= n; i++)
            {
                res = a + b;
                a = b;
                b = res;
            }
            return res;
        }
    }
}
