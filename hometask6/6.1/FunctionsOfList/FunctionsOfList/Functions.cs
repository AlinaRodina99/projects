﻿using System;
using System.Collections.Generic;

namespace FunctionsOfList
{
    /// <summary>
    /// Class for functions of the list.
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Method that returns list with modified numbers.
        /// </summary>
        /// <param name="list">List taken as an argument.</param>
        /// <param name="function">Delegate which connected with lambda expression.</param>
        /// <returns>Modified list.</returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            MapFunctionOfElement(list, function);
            return list;
        }

        /// <summary>
        /// Method that modified the element and is used in Map method.
        /// </summary>
        /// <param name="list">List taken as an argument.</param>
        /// <param name="function">Delegate which connected with lambda expression.</param>
        /// <returns>Modified list.</returns>
        private static List<int> MapFunctionOfElement(List <int> list, Func<int, int> function)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                list[i] = function(list[i]);
            }
            return list;
        }

        /// <summary>
        /// Method that filters list depending on the logical condition.
        /// </summary>
        /// <param name="list">List taken as an argument.</param>
        /// <param name="function">Delegate which connected with lambda expression.</param>
        /// <returns>Modified list.</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            FilterFunctionOfElement(list, function);
            return list;
        }

        /// <summary>
        /// Method that removes elements from the list depending on logical condition and is used in filter method.
        /// </summary>
        /// <param name="list">List take as an argument.</param>
        /// <param name="function">Delegate which connected with lambda expression.</param>
        /// <returns></returns>
        private static List<int> FilterFunctionOfElement(List<int> list, Func<int, bool> function)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                if (!function(list[i]))
                {
                    list.RemoveAt(i);
                    --i;
                }
            }
            return list;
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
            int result = acc;
            for (int i = 0; i < list.Count; ++i)
            {
                result = function(result, list[i]);
            }
            return result;
        }
    }
}
