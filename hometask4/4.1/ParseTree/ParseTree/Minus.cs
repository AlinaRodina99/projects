using System;

namespace ParseTree
{
    class Minus:Operator
    {
        public override void Print()
        {
            Console.Write(" ( - ");
            LeftChild.Print();
            RightChild.Print();
            Console.Write(" ) ");
        }

        public override int Calculate()
        {
            return LeftChild.Calculate() - RightChild.Calculate();
        }
    }
}
