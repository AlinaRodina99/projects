namespace ParseTree
{
    interface INodeTree
    {
        void Print();
        int Calculate();
        INodeTree LeftChild { get; set; }
        INodeTree RightChild { get; set; }
        INodeTree Parent { get; set; }
    }
}
