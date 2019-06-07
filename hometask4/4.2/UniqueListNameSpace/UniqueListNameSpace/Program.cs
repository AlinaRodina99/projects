using System;

namespace UniqueListNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var uniqueList = new UniqueList();
                uniqueList.RemoveByData("apple");
                uniqueList.AddAt(0, "apple");
                uniqueList.AddAt(0, "apple");
                uniqueList.AddAt(1, "lemon");
                uniqueList.AddAt(2, "banana");
                uniqueList.PrintList();
                uniqueList.RemoveByData("lemon");
                uniqueList.PrintList();
                uniqueList.RemoveByData("melon");
            }
            catch (AddSameElementsException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
                Console.WriteLine($"Incorrect data: {exception.Value}");
            }
            catch (RemoveNotExistentElementException exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
                Console.WriteLine($"Incorrect data: {exception.Value}");
            }
        }
    }
}

