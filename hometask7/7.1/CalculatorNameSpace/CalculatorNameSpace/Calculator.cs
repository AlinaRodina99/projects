using System;

namespace CalculatorNameSpace
{
    public static class Calculator
    {
        public static double Calculate(string operation, double firstNumber, double secondNumber)
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

        public static double BinaryCalculation(string operation, double number)
        {
            switch (operation)
            {
                case "^2":
                    return number * number;
                case "√":
                    if (number < 0)
                    {
                        throw new ArgumentException();
                    }
                    return Math.Sqrt(number);
                default:
                    throw new InvalidOperationException();
            }
        }

    }
}
