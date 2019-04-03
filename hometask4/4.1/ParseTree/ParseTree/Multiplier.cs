using System;

namespace ParseTree
{
    class Multiplier : Operator
    {
        public override void Print()
        {
            Console.WriteLine(" ( * ");
            LeftChild.Print();
            RightChild.Print();
            Console.WriteLine(" ) ");
        }
        public override int Calculate()
        {
            return LeftChild.Calculate() * RightChild.Calculate();
        }
    }
}
