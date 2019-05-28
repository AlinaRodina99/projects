namespace ParseTree
{
    /// <summary>
    /// Abstract class for operator.
    /// </summary>
    public class Operator : INodeTree
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

        /// <summary>
        /// Method to pring operator.
        /// </summary>
        virtual public void Print()
        {

        }

        /// <summary>
        /// Method to calculate operator.
        /// </summary>
        /// <returns>Integer result.</returns>
        virtual public int Calculate() => 1; 
    }
}
