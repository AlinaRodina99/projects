using System.Collections.Generic;

namespace FinalTest2
{
    public class GenericMethods<T>
    {
        public void PubbleSort<U>(List<T> list, IComparer<T> comparer)
        {
            for (int i = 0; i < list.Count - 1; ++i)
            {
                for (int j = i + 1; j < list.Count; ++j)
                {
                    if (comparer.Compare(list[i], list[j]) > 0)
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = list[i];
                    }
                }
            }
        }
    }
}
