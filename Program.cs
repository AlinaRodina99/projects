using System;


namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Result: {Factorial(7)} ");
            Console.ReadKey();
        }
        static int Factorial(int n)
        {
            if (n<=1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
    }
}
