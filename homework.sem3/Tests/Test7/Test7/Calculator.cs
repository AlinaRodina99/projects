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
        public double Calculate(string operation, double firstNumber, double secondNumber)
        {
            switch (operation)
            {
                case "+":
                    return secondNumber + firstNumber;
                case "-":
                    return secondNumber - firstNumber;
                case "*":
                    return secondNumber * firstNumber;
                case "/":
                    if (firstNumber == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    return secondNumber / firstNumber;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
