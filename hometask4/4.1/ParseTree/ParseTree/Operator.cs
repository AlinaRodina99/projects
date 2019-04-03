namespace ParseTree
{
    /// <summary>
    /// Abstract class for operator.
    /// </summary>
    abstract class Operator:INodeTree
    {
        /// <summary>
        /// Method for printing operator
        /// </summary>
        public abstract void Print();
        /// <summary>
        /// Method to calculate operator.
        /// </summary>
        /// <returns></returns>
        public abstract int Calculate();
        /// <summary>
        /// Property for the left child.
        /// </summary>
        public INodeTree LeftChild { get; set; }
        /// <summary>
        /// Property for the right child.
        /// </summary>
        public INodeTree RightChild { get; set; }
        /// <summary>
        /// Property for parent.
        /// </summary>
        public INodeTree Parent { get; set; }
    }
}
