using System.Collections.Generic;

namespace FinalTest2
{
    class ComparatorForStrings : IComparer<string>
    {
        public int Compare(string first, string second)
        {
            if (first.Length > second.Length)
            {
                return 1;
            }
            else if (first.Length < second.Length)
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
