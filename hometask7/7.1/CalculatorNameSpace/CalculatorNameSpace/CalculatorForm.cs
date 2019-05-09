using System;
using System.Windows.Forms;

namespace CalculatorNameSpace
{
    /// <summary>
    /// Class for calculator form.
    /// </summary>
    public partial class CalculatorForm : Form 
    {
        /// <summary>
        /// Private variable for calculator.
        /// </summary>
        private Calculator calculator;

        /// <summary>
        /// Private variable for current result of the expression.
        /// </summary>
        private string currentResult;

        /// <summary>
        /// Private variable for current number that user is typing.
        /// </summary>
        private string currentNumber;

        /// <summary>
        /// Private variable for current operation that is used now.
        /// </summary>
        private string currentOperation;

        /// <summary>
        /// Private bool variable for the point of the number.
        /// </summary>
        private bool comma = true;

        /// <summary>
        /// Private variable to know if user can press button with operation.
        /// </summary>
        private bool canPressOperation = false;

        /// <summary>
        /// Private variable to know if user pressed 
        /// </summary>
        private bool wasPressedCalculate = false;

        /// <summary>
        /// Private variable to know if user pressed binary operation.
        /// </summary>
        private bool wasPressedBinaryOperation = false;

        /// <summary>
        /// Constructor which initializes form.
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
            calculator = new Calculator();
        }

        /// <summary>
        /// Private method to check whether number was entered correct or was not.
        /// </summary>
        private void CorrectNumber()
        {
            if (expressionBox.Text.Length >= 2 && expressionBox.Text[0] == '0' && expressionBox.Text[1] != ',' && currentOperation == null)
            {
                expressionBox.Text = expressionBox.Text.Remove(0, 1);
                currentExpressionBox.Text = currentExpressionBox.Text.Remove(0, 1);
                currentNumber = currentNumber.Trim();
            }

            if (expressionBox.Text[0] == '-' && currentOperation == null)
            {
                if (expressionBox.Text.Length >= 3 && expressionBox.Text[1] == '0' && expressionBox.Text[2] != ',')
                {
                    expressionBox.Text = expressionBox.Text.Remove(1, 1);
                    currentExpressionBox.Text = currentExpressionBox.Text.Remove(1, 1);
                    currentNumber = currentNumber.Trim();
                }
            }

            if (expressionBox.Text.Length >= 2 && expressionBox.Text[0] == '0' && expressionBox.Text[1] != ',')
            {
                expressionBox.Text = expressionBox.Text.Remove(0, 1);
                currentExpressionBox.Text = currentExpressionBox.Text.Substring(0, currentExpressionBox.Text.Length - 1);
                currentNumber = currentNumber.Remove(0, 1);
            }

            if (currentExpressionBox.Text.Length >= 2 && currentExpressionBox.Text[currentExpressionBox.Text.Length - 1] == '0')
            {
                currentExpressionBox.Text = currentExpressionBox.Text.Substring(0, currentExpressionBox.Text.Length - 1);
                currentExpressionBox.Text += currentNumber;
            }
        }

        /// <summary>
        /// Private method to read numbers.
        /// </summary>
        /// <param name="digit">Current digit of the number.</param>
        private void ReadDigit(char digit)
        {
            currentNumber += digit;
            if (currentOperation == null)
            { 
                if (wasPressedCalculate || wasPressedBinaryOperation)
                {
                    currentResult = null;
                    expressionBox.Text = "";
                    currentExpressionBox.Text = "";
                }
                expressionBox.Text += digit;
                CorrectNumber();
            }
            else
            {
                expressionBox.Text = currentNumber;
            }
            currentExpressionBox.Text += digit;
            CorrectNumber();
            canPressOperation = true;
        }

        /// <summary>
        /// Private method to read operation.
        /// </summary>
        /// <param name="operation">Current operation.</param>
        private void ReadOperation(string operation)
        {
            try
            {
                if (operation == "-" && currentNumber == null && currentResult == null)
                {
                    currentNumber = "-";
                    expressionBox.Text = "-";
                    currentExpressionBox.Text = "-";
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
                        currentExpressionBox.Text += currentOperation;
                        canPressOperation = false;
                    }
                    wasPressedCalculate = false;
                    comma = true;
                }
            }
            catch(DivideByZeroException)
            {
                expressionBox.Text = "";
                currentExpressionBox.Text = "You can not divide by zero! Click c to clear.";
            }
            catch(ArgumentException)
            {
                currentExpressionBox.Text = "You can not take square root of negative number! Click c to clear.";
            }
        }
        
        /// <summary>
        /// Private method to get result of the expression.
        /// </summary>
        private void GetResult()
        {
            if (currentOperation == "^2" || currentOperation == "√" && currentResult != null)
            {
                double number = Convert.ToDouble(currentResult);
                expressionBox.Text = calculator.BinaryCalculation(currentOperation, number).ToString();
                currentExpressionBox.Text = expressionBox.Text;
                currentResult = expressionBox.Text;
                currentOperation = null;
                wasPressedBinaryOperation = true;
            }

            if (currentResult != null && currentNumber != null && currentOperation != null)
            {
                expressionBox.Text = calculator.Calculate(currentOperation, Convert.ToDouble(currentNumber), Convert.ToDouble(currentResult)).ToString();
                currentExpressionBox.Text = expressionBox.Text;
                currentResult = expressionBox.Text;
            }
        }

        /// <summary>
        /// Private method to read digit one.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberOneClick(object sender, EventArgs e) => ReadDigit('1');

        /// <summary>
        /// Private method to read digit two.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberTwoClick(object sender, EventArgs e) => ReadDigit('2');

        /// <summary>
        /// Private method to read digit three.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberThreeClick(object sender, EventArgs e) => ReadDigit('3');

        /// <summary>
        /// Private method to read digit four.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberFourClick(object sender, EventArgs e) => ReadDigit('4');

        /// <summary>
        /// Private method to read digit five.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberFiveClick(object sender, EventArgs e) => ReadDigit('5');

        /// <summary>
        /// Private method to read digit six.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberSixClick(object sender, EventArgs e) => ReadDigit('6');

        /// <summary>
        /// Private method to read digit seven.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberSevenClick(object sender, EventArgs e) => ReadDigit('7');

        /// <summary>
        /// Private method to read digit nine.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberNineClick(object sender, EventArgs e) => ReadDigit('9');

        /// <summary>
        /// Private method to read digit eight.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void NumberEightClick(object sender, EventArgs e) => ReadDigit('8');

        /// <summary>
        /// Private method to read digit zero.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">>Argument that holds information about event.</param>
        private void NumberZeroClick(object sender, EventArgs e) => ReadDigit('0');

        /// <summary>
        /// Private method to read point.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void PointClick(object sender, EventArgs e)
        {
            if (comma)
            {
                if (currentResult == null && currentNumber == null && currentOperation == null)
                {
                    expressionBox.Text = "0,";
                    currentExpressionBox.Text = "0,";
                    currentNumber = "0,";
                    currentResult = null;
                    comma = false;
                    wasPressedCalculate = false;
                    wasPressedBinaryOperation = false;
                }
                else if (currentOperation != null && currentNumber == null)
                {
                    expressionBox.Text = "0,";
                    currentExpressionBox.Text += "0,";
                    currentNumber = "0,";
                    comma = false;
                    wasPressedCalculate = false;
                    wasPressedBinaryOperation = false;
                }
                else
                {
                    expressionBox.Text += ",";
                    currentExpressionBox.Text += ",";
                    currentNumber += ",";
                    comma = false;
                }
            }

            if (wasPressedCalculate || wasPressedBinaryOperation)
            {
                expressionBox.Text = "0,";
                currentExpressionBox.Text = "0,";
                currentNumber = "0,";
                currentResult = null;
                comma = false;
                wasPressedCalculate = false;
                wasPressedBinaryOperation = false;
            }
        }

        /// <summary>
        /// Private method to read operation plus.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void PlusClick(object sender, EventArgs e) => ReadOperation("+");

        /// <summary>
        /// Private method to read operation minus.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void MinusClick(object sender, EventArgs e) => ReadOperation("-");

        /// <summary>
        /// Private method to read operation multiply.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void MultiplyClick(object sender, EventArgs e) => ReadOperation("*");

        /// <summary>
        /// Private method to read operation divide.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void DivideClick(object sender, EventArgs e) => ReadOperation("/");

        /// <summary>
        /// Private method to read operation of taking square root.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void SqrtClick(object sender, EventArgs e) => ReadOperation("√");

        /// <summary>
        /// Private method to read squaring operation.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void SquareClick(object sender, EventArgs e) => ReadOperation("^2");

        /// <summary>
        /// Private method to press equal sign.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void CalculateClick(object sender, EventArgs e)
        {
            try
            {
                canPressOperation = true;
                comma = true;
                if (currentNumber == null)
                {
                    currentExpressionBox.Text = currentResult;
                }
                GetResult();
                currentNumber = null;
                currentOperation = null;
                wasPressedCalculate = true;
            }
            catch(DivideByZeroException)
            {
                expressionBox.Text = "∞";
                currentExpressionBox.Text = "You can not divide number by zero! Click c to clear";
            }
        }

        /// <summary>
        /// Private method to read operation of changing sign.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void ChangeSignClick(object sender, EventArgs e)
        {
            if (currentExpressionBox.Text != "")
            {
                bool canChangeSign = "+-".IndexOf(currentExpressionBox.Text[currentExpressionBox.Text.Length - 1]) != -1 ? true : false;
                if (currentOperation == "+" && canChangeSign)
                {
                    currentOperation = "-";
                    currentExpressionBox.Text = currentExpressionBox.Text.Trim(new char[] { '+' });
                    currentExpressionBox.Text += "-";
                    canPressOperation = false;
                }
                else if (currentOperation == "-" && canChangeSign)
                {
                    currentOperation = "+";
                    currentExpressionBox.Text = currentExpressionBox.Text.Trim(new char[] { '-' });
                    currentExpressionBox.Text += "+";
                    canPressOperation = false;
                }
            }
        }

        /// <summary>
        /// Private method to clear expression.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void ClearAllExpressionClick(object sender, EventArgs e)
        {
            expressionBox.Text = "";
            currentExpressionBox.Text = "";
            currentNumber = null;
            currentResult = null;
            currentOperation = null;
        }

        /// <summary>
        /// Private method to read operations and numbers from keyboard.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void CalculatorFormKeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '1':
                    ReadDigit('1');
                    break;
                case '2':
                    ReadDigit('2');
                    break;
                case '3':
                    ReadDigit('3');
                    break;
                case '4':
                    ReadDigit('4');
                    break;
                case '5':
                    ReadDigit('5');
                    break;
                case '6':
                    ReadDigit('6');
                    break;
                case '7':
                    ReadDigit('7');
                    break;
                case '8':
                    ReadDigit('8');
                    break;
                case '9':
                    ReadDigit('9');
                    break;
                case '0':
                    ReadDigit('0');
                    break;
                case '=':
                    GetResult();
                    currentNumber = null;
                    break;
                case '+':
                    ReadOperation("+");
                    break;
                case '-':
                    ReadOperation("-");
                    break;
                case '/':
                    ReadOperation("/");
                    break;
                case '*':
                    ReadOperation("*");
                    break;
                case '√':
                    ReadOperation("√");
                    break;
                case '^':
                    ReadOperation("^2");
                    break;
                case ',':
                    PointClick(sender, e);
                    break;
            }
        }
    }
}
