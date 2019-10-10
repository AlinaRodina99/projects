using System;

namespace ParseTree
{
    /// <summary>
    /// Class of operation plus.
    /// </summary>
    class Plus : Operator
    {
        /// <summary>
        /// Method for printing part of our expression with plus.
        /// </summary>
        public override void Print()
        {
            Console.Write(" ( + ");
            LeftChild.Print();
            RightChild.Print();
            Console.Write(" ) ");
        }

        /// <summary>
        /// Method to calculate operation.
        /// </summary>
        /// <returns>Integer result of adding left child and right child.</returns>
        public override int Calculate() => LeftChild.Calculate() + RightChild.Calculate();
    }
}
