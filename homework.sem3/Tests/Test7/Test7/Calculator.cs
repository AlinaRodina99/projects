using System;

namespace Test7
{
    /// <summary>
    /// Class that represents model of calculator providing ability to calculate simple expressions.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Method that calculates expression.
        /// </summary>
        /// <returns>Answer to expression.</returns>
        public double Calculate(string operation, string firstNumber, string secondNumber)
        {
            double answer;

            if (!CheckNumber(firstNumber) || !CheckNumber(secondNumber))
            {
                throw new ArgumentException("Неверный формат числа.");
            }

            switch (operation)
            {
                case "+":
                    answer = Convert.ToDouble(secondNumber) + Convert.ToDouble(firstNumber);
                    break;
                case "-":
                    answer =  Convert.ToDouble(secondNumber) - Convert.ToDouble(firstNumber);
                    break;
                case "*":
                    answer = Convert.ToDouble(secondNumber) * Convert.ToDouble(firstNumber);
                    break;
                case "/":
                    if (Convert.ToDouble(firstNumber) == 0)
                    {
                        throw new DivideByZeroException("На ноль делить нельзя.");
                    }
                    answer = Convert.ToDouble(secondNumber) / Convert.ToDouble(firstNumber);
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return answer;
        }

        private bool CheckNumber(string number)
        {
            if (!double.TryParse(number, out double _) || number.Substring(1).Contains("-"))
            {
                return false;
            }

            return true;
        }
    }
}
