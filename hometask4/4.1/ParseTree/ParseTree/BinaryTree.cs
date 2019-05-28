using System;
using System.IO;

namespace ParseTree
{
    /// <summary>
    /// Class for building parse tree.
    /// </summary>
    public class BinaryTree
    {
        /// <summary>
        /// Top of the tree.
        /// </summary>
        private Operator head = null;

        /// <summary>
        /// Method to define the operation.
        /// </summary>
        /// <param name="operation">Current operation.</param>
        /// <returns>Current operator.</returns>
        private Operator SwitchOperator(string operation)
        {
            switch (operation)
            {
                case "+":
                    return new Plus();
                case "-":
                    return new Minus();
                case "*":
                    return new Multiplier();
                default:
                    return new Divider();
            }
        }

        /// <summary>
        /// Method for building the tree.
        /// </summary>
        /// <param name="partsOfExpression">Аrray of expression substrings.</param>
        public void BinaryTreeBuild(string file)
        {
            var currentOperator = head;
            int currentNumber;
            var partsOfExpression = FileInput(file).Split();
            for (int i = 0; i < partsOfExpression.Length; ++i)
            {
                if (head == null)
                {
                    head = SwitchOperator(partsOfExpression[i + 1]);
                    currentOperator = head;
                    ++i;
                }
                else
                {
                    if (partsOfExpression[i] == "(")
                    {
                        if (currentOperator.LeftChild == null)
                        {
                            var temp = currentOperator;
                            currentOperator.LeftChild = SwitchOperator(partsOfExpression[i + 1]);
                            currentOperator = (Operator)currentOperator.LeftChild;
                            currentOperator.Parent = temp;
                        }
                        else if (currentOperator.RightChild == null)
                        {
                            var temp = currentOperator;
                            currentOperator.RightChild = SwitchOperator(partsOfExpression[i + 1]);
                            currentOperator = (Operator)currentOperator.RightChild;
                            currentOperator.Parent = temp;
                        }
                        else
                        {
                            while (currentOperator.RightChild != null)
                            {
                                currentOperator = currentOperator.Parent;
                            }
                            var temp = currentOperator;
                            currentOperator.RightChild = SwitchOperator(partsOfExpression[i + 1]);
                            currentOperator = (Operator)currentOperator.RightChild;
                            currentOperator.Parent = temp;
                        }
                        ++i;
                    }
                    else if (int.TryParse(partsOfExpression[i], out currentNumber))
                    {
                        var currentOperand = new Operand(currentNumber);
                        if (currentOperator.LeftChild == null)
                        {
                            currentOperator.LeftChild = currentOperand;
                            currentOperand.Parent = currentOperator;
                        }
                        else if (currentOperator.RightChild == null)
                        {
                            currentOperator.RightChild = currentOperand;
                            currentOperand.Parent = currentOperator;
                        }
                        else
                        {
                            while (currentOperator.RightChild != null)
                            {
                                currentOperator = currentOperator.Parent;
                            }
                            currentOperator.RightChild = currentOperand;
                            currentOperand.Parent = currentOperator;
                        }
                    }
                    else if (i != partsOfExpression.Length - 1)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Method to calculate expression using the tree.
        /// </summary>
        /// <returns>Integer result of our expression.</returns>
        public int CalculateTree(string file)
        {
            try
            {
                BinaryTreeBuild(file);
                return head.Calculate();
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
                return default(int);
            }
        }

        /// <summary>
        /// Method to print the tree.
        /// </summary>
        public void PrintTree()
        {
            head.Print();
        }

        /// <summary>
        /// Method for reading expression from file.
        /// </summary>
        /// <param name="file">File with tree.</param>
        /// <returns></returns>
        public string FileInput(string file)
        {
            using (var stream = new StreamReader(file))
            {
                return stream.ReadLine();
            }
        }
    }
}
