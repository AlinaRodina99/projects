using System.Collections.Generic;
using System;

namespace MoveToFrontNameSpace
{
    /// <summary>
    /// Class for functionality of MTF algorithm.
    /// </summary>
    public class MoveToFront
    {
        /// <summary>
        /// Method for coding string alogorithm.
        /// </summary>
        /// <param name="input">Current string</param>
        /// <returns>Sequence of numbers.</returns>
        public List<int> StringCoding(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException();
            }

            var list = new List<char>();

            for (char k = 'A'; k < 'z'; ++k)
            {
                list.Add(k);
            }

            var partsOfString = input.ToCharArray();
            var resultList = new List<int>();
            for (int i = 0; i < partsOfString.Length; ++i)
            {
                for (int j = 0; j < list.Count; ++j)
                {
                    var currentChar = list[j];
                    if (partsOfString[i] == currentChar)
                    {
                        list.RemoveAt(j);
                        list.Insert(0, currentChar);
                        resultList.Add(j);
                    }
                }
            }
            return resultList;
        }
    }
}
