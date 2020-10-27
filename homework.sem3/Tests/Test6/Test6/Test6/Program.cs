using System;

namespace Test6
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[6] { 2, 4, 1, 6, 7, 0 };
            var secondTestArray = new int[10] { 1, 67, 0, -1, 20, 40, 5, 9, 2, 3 };
            var QuickSort = new QuickSort();
            var result = QuickSort.Compare(firstTestArray);
            var secondResult = QuickSort.Compare(secondTestArray);
            Console.WriteLine(result);
            Console.WriteLine(secondResult);
        }
    }
}
