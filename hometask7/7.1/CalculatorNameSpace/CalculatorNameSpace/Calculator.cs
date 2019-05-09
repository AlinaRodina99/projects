using System;

namespace CalculatorNameSpace
{
    public class Calculator
    {
        public double Calculate(string operation, double firstNumber, double secondNumber)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = secondNumber + firstNumber;
                    break;
                case "-":
                    result = secondNumber - firstNumber;
                    break;
                case "*":
                    result = secondNumber * firstNumber;
                    break;
                case "/":
                    if (firstNumber == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    result = secondNumber / firstNumber;
                    break;
            }
            return result;
        }

        public double BinaryCalculation(string operation, double number)
        {
            double result = 0;
            switch (operation)
            {
                case "^2":
                    result = number * number;
                    break;
                case "√":
                    if (number < 0)
                    {
                        throw new ArgumentException();
                    }
                    result = Math.Sqrt(number);
                    break;
            }
            return result;
        }
    }
}
