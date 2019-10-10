using System;

namespace StackCalculatorNameSpace
{
    public class StackCalculator
    {
        private static bool IsDelimeter(char c) => " =".IndexOf(c) != -1;

        private static bool IsOperator(char c) => "+-/()*".IndexOf(c) != -1;
       
        public static double Counting(string input, IStack<double> stack)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string currentString = string.Empty;
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        currentString += input[i];
                        i++;
                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    stack.Push(double.Parse(currentString));
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    double firstNumber = stack.Pop();
                    double secondNumber = stack.Pop();
                    result = GetResult(input[i], firstNumber, secondNumber);
                    stack.Push(result);
                }
                else if (IsDelimeter(input[i]))
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("You entered incorrect data!");
                    return default(char);
                }
            }
            return stack.Peek();
        }

        private static double GetResult(char operation, double firstNumber, double secondNumber)
        {
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = secondNumber + firstNumber;
                    break;
                case '-':
                    result = secondNumber - firstNumber;
                    break;
                case '*':
                    result = secondNumber * firstNumber;
                    break;
                case '/':
                    result = secondNumber / firstNumber;
                    break;
            }
            return result;
        }
    }
}