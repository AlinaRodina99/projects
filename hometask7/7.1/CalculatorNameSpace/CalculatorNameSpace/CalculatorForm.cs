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
        /// Private variable for box of the expression.
        /// </summary>
        private BoxOfExpressing box;

        /// <summary>
        /// Constructor which initializes form.
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
            box = new BoxOfExpressing();
        }

        /// <summary>
        /// Method to change text.
        /// </summary>
        private void ChangeText()
        {
            expressionBox.Text = box.ExpressionBox;
            currentExpressionBox.Text = box.CurrentExpressionBox;
        }

        /// <summary>
        /// Private method to read operation.
        /// </summary>
        /// <param name="operation">Current operation.</param>
        private void ReadOperation(string operation)
        {
            box.ReadOperation(operation);
            ChangeText();
        }

        /// <summary>
        /// Private method to read digit two.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void DigitClick(object sender, EventArgs e)
        {
            var digitButton = (Button)sender;
            box.ReadDigit(digitButton.Text);
            ChangeText();
        }

        /// <summary>
        /// Private method to read point.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void PointClick(object sender, EventArgs e)
        {
            box.ReadPoint();
            ChangeText();
        }

        /// <summary>
        /// Private method to read operation plus.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void OperationClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            box.ReadOperation(button.Text);
            ChangeText();
        }
        private void CalculateClick(object sender, EventArgs e)
        {
            box.ReadCalculateSign();
            ChangeText();
        }

        /// <summary>
        /// Private method to read operation of changing sign.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void ChangeSignClick(object sender, EventArgs e)
        {
            box.ReadChangeSign();
            ChangeText();
        }

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
        /// Private method to clear expression.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void ClearAllExpressionClick(object sender, EventArgs e)
        {
            box.ReadClear();
            ChangeText();
        }
    }
}
