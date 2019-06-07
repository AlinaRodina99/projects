using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList();
            myList.AddAt(0, "apple");
            myList.AddAt(1, "pineapple");
            myList.AddAt(0, "melon");
            myList.RemoveAt(0);
            myList[0] = "orange";
            myList.RemoveAt(0);
            myList.AddAt(0, "banana");
            myList.PrintList();
            Console.WriteLine(myList[1]);
            Console.WriteLine(myList[0]);
            myList.AddAt(2, "lemon");
            Console.WriteLine(myList[2]);
            Console.WriteLine(myList.Size);
            Console.WriteLine(myList.IsEmpty);
            myList[-1] = "apple";
            Console.WriteLine(myList[20]);
            myList.AddAt(5, "melon");
        }
    }
}


