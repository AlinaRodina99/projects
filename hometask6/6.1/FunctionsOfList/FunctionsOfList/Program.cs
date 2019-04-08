using System;
using System.Collections.Generic;

namespace FunctionsOfList
{
    class Program
    {
        /// <summary>
        /// Method for printing list.
        /// </summary>
        /// <param name="list">Current list taken as an argument.</param>
        static void WriteList(List<int> list)
        {
            foreach (var element in list)
            {
                Console.Write(element + "; ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var functions = new Functions();
            var newList = functions.Map(new List<int>() { 1, 2, 3 }, x => x * 2);
            WriteList(newList);
            newList = functions.Filter(new List<int>() { -1, 0, 3, 4 }, x => x >= 4);
            WriteList(newList);
            int result = functions.Fold(new List<int>() { 1, 2, 3 }, 1, (acc, elem) => acc * elem);
            Console.WriteLine(result);
        }
    }
}
