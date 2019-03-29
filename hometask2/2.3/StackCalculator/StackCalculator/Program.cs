using System;

namespace StackCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            StackCalculatorFunctionality calculator = new StackCalculatorFunctionality();
            while (true)
            {
                Console.WriteLine("Select type of stack: 1-stack on list; 2-stack on array");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    StackOnList<double> stackOnList = new StackOnList<double>();
                    Console.WriteLine("Enter your arithmetic expression with nonnegative numbers");
                    string expression = Console.ReadLine();
                    Console.WriteLine(calculator.Counting(expression, stackOnList));
                    if (stackOnList.IsEmpty == true)
                    {
                        Console.WriteLine("Stack is empty");
                        Console.WriteLine("Either you have not entered anything or you have entered incorrect data!");
                        break;
                    }
                }
                else if (choice == "2")
                {
                    ArrayStack<double> stackOnArray = new ArrayStack<double>();
                    Console.WriteLine("Enter your arithmetic expression with nonnegative numbers");
                    string expression = Console.ReadLine();
                    Console.WriteLine(calculator.Counting(expression, stackOnArray));
                    if (stackOnArray.IsEmpty == true)
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
