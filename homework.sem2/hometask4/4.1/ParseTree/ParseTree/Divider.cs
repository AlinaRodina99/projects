using System;

namespace ParseTree
{
    /// <summary>
    /// Class for operator of division.
    /// </summary>
    class Divider : Operator
    {
        /// <summary>
        /// Method of printing operator.
        /// </summary>
        public override void Print()
        {
            Console.Write(" ( / ");
            LeftChild.Print();
            RightChild.Print();
            Console.Write(" ) ");
        }

        /// <summary>
        /// Method to calculate operator.
        /// </summary>
        /// <returns>Result of applying the operator to the left child and to the right child.</returns>
        public override int Calculate() => LeftChild.Calculate() / RightChild.Calculate();
    }
}
