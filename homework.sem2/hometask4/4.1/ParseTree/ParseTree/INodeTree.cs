﻿namespace ParseTree
{
    /// <summary>
    /// Interface for the node of the binary tree.
    /// </summary>
    public interface INodeTree
    {
        /// <summary>
        /// Method of printing node.
        /// </summary>
        void Print();

        /// <summary>
        /// Method to calculate node of the tree.
        /// </summary>
        /// <returns>Result of applying operator to the numbers.</returns>
        int Calculate();
    }
}
