using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var mylist = new MyList();
            mylist.AddAt(0, "apple");
            mylist.AddAt(1, "pineapple");
            mylist.AddAt(0, "melon");
            mylist.RemoveAt(0);
            mylist[0] = "orange";
            mylist.RemoveAt(0);
            mylist.AddAt(0, "banana");
            mylist.PrintList();
            Console.WriteLine(mylist[1]);
            Console.WriteLine(mylist[0]);
            mylist.AddAt(2, "lemon");
            Console.WriteLine(mylist[2]);
            Console.WriteLine(mylist.Size);
            Console.WriteLine(mylist.IsEmpty);
            mylist[-1] = "apple";
            Console.WriteLine(mylist[20]);
            mylist.AddAt(5, "melon");

        }
    }
}
