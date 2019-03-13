using System;

namespace StackCalculator
{
    public class StackCalculatorFunctionality
    {
        private bool IsDelimeter(char c)
        {
            if (" =".IndexOf(c) != -1)
            {
                return true;
            }
            return false;
        }

        private bool IsOPerator(char c)
        {
            if("+-/^()*".IndexOf(c) != -1)
            {
                return true;
            }
            return false;
        }

        private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

        public  double Counting(string input, IStack<double> stack)
        {
            double result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(Char.IsDigit(input[i]))
                {
                    string currentString = string.Empty;
                    while(!IsDelimeter(input[i]) && !IsOPerator(input[i]))
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
                else if(IsOPerator(input[i]))
                {
                    double firstNumber = stack.Pop();
                    double secondNumber = stack.Pop();
                    switch(input[i])
                    {
                        case '+': result = secondNumber + firstNumber;
                            break;
                        case '-': result = secondNumber - firstNumber;
                            break;
                        case '*': result = secondNumber * firstNumber;
                            break;
                        case '/': result = secondNumber / firstNumber;
                            break;
                    }
                    stack.Push(result);
                }
            }
            return stack.Peek();
        }
    }
}
