using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTest2
{
    public class ComparatorForIntNums : IComparer<int>
    {
        public int Compare(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return 1;
            }
            else if (firstNumber < secondNumber)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
