using System.Collections.Generic;
using System;

namespace ListMethodsNameSpace
{
    /// <summary>
    /// Class for method of counting zero elements.
    /// </summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    public static class ListMethods<T>
    {
        public static int CountOfZeroElements(List<T> list, INullElement<T> nullElement)
        {
            if (list == null || nullElement == null)
            {
                throw new ArgumentNullException();
            }

            int count = 0;
            foreach (var item in list)
            {
                if (nullElement.IsNull(item))
                {
                    ++count;
                }
            }
            return count;
        }
    }
}
