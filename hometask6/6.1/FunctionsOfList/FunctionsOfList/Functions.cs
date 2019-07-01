using System;
using System.Collections.Generic;

namespace FunctionsOfList
{
    /// <summary>
    /// Class for functions of the list.
    /// </summary>
    public static class Functions
    {
        /// <summary>
        /// Method that returns list with modified numbers.
        /// </summary>
        /// <param name="list">List taken as an argument.</param>
        /// <param name="function">Delegate which connected with lambda expression.</param>
        /// <returns>Modified list.</returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            var newList = new List<int>();
            for (int i = 0; i < list.Count; ++i)
            {
                newList.Add(function(list[i]));
            }
            return newList;
        }

        /// <summary>
        /// Method that filters elements of the list depending on the condition.
        /// </summary>
        /// <param name="list">List taken as an argument.</param>
        /// <param name="function">Delegate which connected with lambda expression.</param>
        /// <returns>Modified list.</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            var newList = new List<int>();
            for (int i = 0; i < list.Count; ++i)
            {
                if (function(list[i]))
                {
                    newList.Add(list[i]);
                }
            }
            return newList;
        }

        /// <summary>
        /// Method that returns integer result by a certain multiplication of elements.
        /// </summary>
        /// <param name="list">List taken as an argument.</param>
        /// <param name="element">Current accumulated value.</param>
        /// <param name="function">Delegate which cinnected with lambda expression.</param>
        /// <returns>Integer result.</returns>
        public static int Fold(List<int> list, int acc, Func<int, int, int> function)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                acc = function(acc, list[i]);
            }
            return acc;
        }
    }
}
