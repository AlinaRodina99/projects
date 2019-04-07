using System;

namespace StackCalculatorNameSpace
{
    class StackCalculator
    {
        private static bool IsDelimeter(char c) => " =".IndexOf(c) != -1; /*? true : false;*/

        private static bool IsOperator(char c) => "+-/()*".IndexOf(c) != -1; /*? true : false;*/
       
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
                    return '\0';
                }
            }
            return stack.Peek();
        }

        private static double GetResult(char operation, double firstNumber, double secondNumber)
        {
            double result = 0;
            switch(operation)
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