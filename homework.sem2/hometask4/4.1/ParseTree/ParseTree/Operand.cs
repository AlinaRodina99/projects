using System;

namespace ParseTree
{
    /// <summary>
    /// Class for operand.
    /// </summary>
    class Operand : INodeTree
    {
        /// <summary>
        /// Private variable for operand.
        /// </summary>
        private int operand;

        /// <summary>
        /// Method for printing operand.
        /// </summary>
        public void Print()
        {
            Console.Write($"{operand} ");
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="operand">Current operand.</param>
        public Operand(int operand)
        {
            this.operand = operand;
        }

        /// <summary>
        /// Method to calculate operand.
        /// </summary>
        /// <returns>Integer value of operand.</returns>
        public int Calculate()
        {
            return operand;
        }
        
        /// <summary>
        /// Property for the parent.
        /// </summary>
        public Operator Parent { get; set; }
    }
}
