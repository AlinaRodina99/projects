using System;

namespace ParseTree
{
    class Divider:Operator
    {
        public override void Print()
        {
            Console.Write(" ( / ");
            LeftChild.Print();
            RightChild.Print();
            Console.Write(" ) ");
        }

        public override int Calculate()
        {
            try
            {
                return LeftChild.Calculate() / RightChild.Calculate();
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
                return -1;
            }
        }
    }
}
