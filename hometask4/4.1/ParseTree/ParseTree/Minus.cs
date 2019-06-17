using System;

namespace ParseTree
{
    /// <summary>
    /// Class for operator of adding.
    /// </summary>
    class Minus : Operator
    {
        /// <summary>
        /// Method of printing operator.
        /// </summary>
        public override void Print()
        {
            Console.Write(" ( - ");
            LeftChild.Print();
            RightChild.Print();
            Console.Write(" ) ");
        }

        /// <summary>
        /// Method to calculate operator.
        /// </summary>
        /// <returns>Result of applying operator to the left child and to the right child.</returns>
        public override int Calculate()
        {
            return LeftChild.Calculate() - RightChild.Calculate();
        }
    }
}
