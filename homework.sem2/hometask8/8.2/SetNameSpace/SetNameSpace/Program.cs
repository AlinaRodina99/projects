using System;

namespace SetNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new Set<int>() { 1, 2, 3, 4 };
            var anotherSet = new Set<int>() { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(set.IsProperSubsetOf(anotherSet));
        }
    }
}
