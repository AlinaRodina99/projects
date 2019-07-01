using System;

namespace CalculatorNameSpace
{
    /// <summary>
    /// Class fot functionality of the expression boxes of the calculator.
    /// </summary>
    public class BoxOfExpressing
    {
        /// <summary>
        /// Variable for current result of the expression.
        /// </summary>
        private string currentResult;

        /// <summary>
        /// Variable for current operation.
        /// </summary>
        private string currentOperation;

        /// <summary>
        /// Variable for current number that was pressed.
        /// </summary>
        private string currentNumber;

        /// <summary>
        /// Variable to know if user can press operation.
        /// </summary>
        private bool canPressOperation = false;

        /// <summary>
        /// Variable to know if user can press point.
        /// </summary>
        private bool comma = true;

        /// <summary>
        /// Vraiable to know if button of calculation was pressed.
        /// </summary>
        private bool wasPressedCalculate = false;

        /// <summary>
        /// Variable to know if button of binary operation was pressed.
        /// </summary>
        private bool wasPressedBinaryOperation = false;

        /// <summary>
        /// Variable for expression box.
        /// </summary>
        public string ExpressionBox { get; private set; }

        /// <summary>
        /// Variable for expression box that is changing.
        /// </summary>
        public string CurrentExpressionBox { get; private set; }

        /// <summary>
        /// Method to check if number was correct.
        /// </summary>
        private void CorrectNumber()
        {
            if (ExpressionBox.Length >= 2 && ExpressionBox[0] == '0' && ExpressionBox[1] != ',' && currentOperation == null)
            {
                ExpressionBox = ExpressionBox.Remove(0, 1);
                CurrentExpressionBox = CurrentExpressionBox.Remove(0, 1);
                currentNumber = currentNumber.Trim();
            }

            if (ExpressionBox[0] == '-' && currentOperation == null)
            {
                if (ExpressionBox.Length >= 3 && ExpressionBox[1] == '0' && ExpressionBox[2] != ',')
                {
                    ExpressionBox = ExpressionBox.Remove(1, 1);
                    CurrentExpressionBox = CurrentExpressionBox.Remove(1, 1);
                    currentNumber = currentNumber.Trim();
                }
            }

            if (ExpressionBox.Length >= 2 && ExpressionBox[0] == '0' && ExpressionBox[1] != ',')
            {
                ExpressionBox = ExpressionBox.Remove(0, 1);
                CurrentExpressionBox = CurrentExpressionBox.Substring(0, CurrentExpressionBox.Length - 1);
                currentNumber = currentNumber.Remove(0, 1);
            }

            if (CurrentExpressionBox != null && CurrentExpressionBox.Length >= 2 && CurrentExpressionBox[CurrentExpressionBox.Length - 1] == '0')
            {
                CurrentExpressionBox = CurrentExpressionBox.Substring(0, CurrentExpressionBox.Length - 1);
                CurrentExpressionBox += currentNumber;
            }
        
            if (ExpressionBox.Length >= 2 && ExpressionBox[0] == '0' && ExpressionBox[1] != ',')
            {
                ExpressionBox = ExpressionBox.Remove(0, 1);
                ExpressionBox = ExpressionBox.Substring(0, ExpressionBox.Length - 1);
                currentNumber = currentNumber.Remove(0, 1);
            }

            if (ExpressionBox.Length >= 2 && ExpressionBox[ExpressionBox.Length - 1] == '0')
            {
                ExpressionBox = ExpressionBox.Substring(0, ExpressionBox.Length - 1);
                ExpressionBox += currentNumber;
            }
        }

        /// <summary>
        /// Method to read digit.
        /// </summary>
        /// <param name="digit">Current digit.</param>
        public void ReadDigit(string digit)
        {
            currentNumber += digit;
            if (currentOperation == null)
            {
                if (wasPressedCalculate || wasPressedBinaryOperation)
                {
                    currentResult = null;
                    ExpressionBox = "";
                    ExpressionBox = "";
                }
                ExpressionBox += digit;
                CorrectNumber();
            }
            else
            {
                ExpressionBox = currentNumber;
            }
            CurrentExpressionBox += digit;
            CorrectNumber();
            canPressOperation = true;
        }

        /// <summary>
        /// Method to read operation.
        /// </summary>
        /// <param name="operation">Current operation.</param>
        public void ReadOperation(string operation)
        {
            try
            {
                if (operation == "-" && currentNumber == null && currentResult == null)
                {
                    currentNumber = "-";
                    ExpressionBox = "-";
                    CurrentExpressionBox = "-";
                    canPressOperation = false;
                }

                if (canPressOperation)
                {
                    if (operation == "√" || operation == "^2")
                    {
                        GetResult();
                        if (currentResult == null)
                        {
                            currentResult = currentNumber;
                        }
                        currentOperation = operation;
                        GetResult();
                        currentNumber = null;
                        wasPressedBinaryOperation = true;
                    }
                    else
                    {
                        GetResult();
                        currentOperation = operation;
                        if (currentResult == null)
                        {
                            currentResult = currentNumber;
                        }
                        currentNumber = null;
                        CurrentExpressionBox += currentOperation;
                        canPressOperation = false;
                    }
                    wasPressedCalculate = false;
                    comma = true;
                }
            }
            catch (DivideByZeroException)
            {
                ExpressionBox = "";
                CurrentExpressionBox = "You can not divide by zero! Click c to clear.";
            }
            catch (ArgumentException)
            {
                CurrentExpressionBox = "You can not take square root of negative number! Click c to clear.";
            }
        }       

        /// <summary>
        /// Method to know current result of the expression.
        /// </summary>
        public void GetResult()
        {
            if (currentOperation == "^2" || currentOperation == "√" && currentResult != null)
            {
                double number = Convert.ToDouble(currentResult);
                ExpressionBox = Calculator.BinaryCalculation(currentOperation, number).ToString();
                CurrentExpressionBox = ExpressionBox;
                currentResult = ExpressionBox;
                currentOperation = null;
                wasPressedBinaryOperation = true;
            }

            if (currentResult != null && currentNumber != null && currentOperation != null)
            {
                ExpressionBox = Calculator.Calculate(currentOperation, Convert.ToDouble(currentNumber), Convert.ToDouble(currentResult)).ToString();
                CurrentExpressionBox = ExpressionBox;
                currentResult = ExpressionBox;
            }
        }

        /// <summary>
        /// Method to read point.
        /// </summary>
        public void ReadPoint()
        {
            if (comma)
            {
                if (currentResult == null && currentNumber == null && currentOperation == null)
                {
                    ExpressionBox = "0,";
                    CurrentExpressionBox = "0,";
                    currentNumber = "0,";
                    currentResult = null;
                    comma = false;
                    wasPressedCalculate = false;
                    wasPressedBinaryOperation = false;
                }
                else if (currentOperation != null && currentNumber == null)
                {
                    ExpressionBox = "0,";
                    CurrentExpressionBox += "0,";
                    currentNumber = "0,";
                    comma = false;
                    wasPressedCalculate = false;
                    wasPressedBinaryOperation = false;
                }
                else
                {
                    ExpressionBox += ",";
                    CurrentExpressionBox += ",";
                    currentNumber += ",";
                    comma = false;
                }
            }

            if (wasPressedCalculate || wasPressedBinaryOperation)
            {
                ExpressionBox = "0,";
                CurrentExpressionBox = "0,";
                currentNumber = "0,";
                currentResult = null;
                comma = false;
                wasPressedCalculate = false;
                wasPressedBinaryOperation = false;
            }
        }

        /// <summary>
        /// Method to read button that calculate expression.
        /// </summary>
        public void ReadCalculateSign()
        {
            try
            {
                canPressOperation = true;
                comma = true;
                if (currentNumber == null)
                {
                    CurrentExpressionBox = currentResult;
                }
                GetResult();
                currentNumber = null;
                currentOperation = null;
                wasPressedCalculate = true;
            }
            catch (DivideByZeroException)
            {
                ExpressionBox = "∞";
                CurrentExpressionBox = "You can not divide number by zero! Click c to clear";
            }
        }

        /// <summary>
        /// Method to read button that changes sign.
        /// </summary>
        public void ReadChangeSign()
        {
            if (CurrentExpressionBox != "")
            {
                bool canChangeSign = "+-".IndexOf(CurrentExpressionBox[CurrentExpressionBox.Length - 1]) != -1 ? true : false;
                if (currentOperation == "+" && canChangeSign)
                {
                    currentOperation = "-";
                    CurrentExpressionBox = CurrentExpressionBox.Trim(new char[] { '+' });
                    CurrentExpressionBox += "-";
                    canPressOperation = false;
                }
                else if (currentOperation == "-" && canChangeSign)
                {
                    currentOperation = "+";
                    CurrentExpressionBox = CurrentExpressionBox.Trim(new char[] { '-' });
                    CurrentExpressionBox += "+";
                    canPressOperation = false;
                }
            }
        }

        /// <summary>
        /// Method to read button that clears expression boxes.
        /// </summary>
        public void ReadClear()
        {
            ExpressionBox = "";
            CurrentExpressionBox = "";
            currentNumber = null;
            currentResult = null;
            currentOperation = null;
        }
    }

}
