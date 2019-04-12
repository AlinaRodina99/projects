using System;

namespace ParseTree
{
    /// <summary>
    /// Class for operator of multiplication.
    /// </summary>
    class Multiplier : Operator
    {
        /// <summary>
        /// Method of printing operator.
        /// </summary>
        public override void Print()
        {
            Console.WriteLine(" ( * ");
            LeftChild.Print();
            RightChild.Print();
            Console.WriteLine(" ) ");
        }

        /// <summary>
        /// Method to calculate operator.
        /// </summary>
        /// <returns>Result of applying operator to the left child and to the right child.</returns>
        public override int Calculate()
        {
            return LeftChild.Calculate() * RightChild.Calculate();
        }
    }
}
