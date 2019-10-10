namespace ParseTree
{
    /// <summary>
    /// Abstract class for operator.
    /// </summary>
    public abstract class Operator : INodeTree
    {
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
        public Operator Parent { get; set; }

        public abstract int Calculate();

        public abstract void Print();
    }
}
