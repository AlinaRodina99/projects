using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList mylist = new MyList();
            mylist.AddAt(0, "apple");
            mylist.AddAt(1, "pineapple");
            mylist.AddAt(0, "melon");
            mylist.RemoveAt(0);
            mylist[0] = "orange";
            mylist.RemoveAt(0);
            mylist.AddAt(0, "banana");
            mylist.PrintList();
            Console.WriteLine(mylist[0]);
            Console.WriteLine(mylist.Size);
            Console.WriteLine(mylist.IsEmpty);
        }
    }
}
