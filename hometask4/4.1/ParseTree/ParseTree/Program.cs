using System;

namespace ParseTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your file: ");
            string file = Console.ReadLine();
            var tree = new BinaryTree();
            Console.WriteLine($"Your result: {tree.CalculateTree(file)}");
            tree.PrintTree();
        }
    }
}
