using System;

namespace GenericListNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new GenericList<int>();
            myList.Add(5);
            myList.Add(6);
            myList.Add(7);
            myList.Add(8);
            myList.Add(10);
            myList.Clear();
        }
    }
}
