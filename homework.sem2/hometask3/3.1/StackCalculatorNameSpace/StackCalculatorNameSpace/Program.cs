using System;

namespace StackCalculatorNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select type of stack: 1-stack on list; 2-stack on array");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    var stackOnList = new StackOnList<double>();
                    Console.WriteLine("Enter your arithmetic expression with nonnegative numbers");
                    string expression = Console.ReadLine();
                    Console.WriteLine(StackCalculator.Counting(expression, stackOnList));
                    if (stackOnList.IsEmpty)
                    {
                        Console.WriteLine("Stack is empty");
                        Console.WriteLine("Either you have not entered anything or you have entered incorrect data!");
                        break;
                    }
                }
                else if (choice == "2")
                {
                    var stackOnArray = new ArrayStack<double>();
                    Console.WriteLine("Enter your arithmetic expression with nonnegative numbers");
                    string expression = Console.ReadLine();
                    Console.WriteLine(StackCalculator.Counting(expression, stackOnArray));
                    if (stackOnArray.IsEmpty)
                    {
                        Console.WriteLine("Stack is empty");
                        Console.WriteLine("Either you have not entered anything or you have entered incorrect data!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect data entered!");
                    break;
                }
            }
        }
    }
}

