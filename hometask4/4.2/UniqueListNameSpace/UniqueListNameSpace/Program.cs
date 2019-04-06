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
                uniqueList.RemoveFromTheUniqueList("apple");
                uniqueList.AddToTheUniqueList("apple");
                uniqueList.AddToTheUniqueList("apple");
                uniqueList.AddToTheUniqueList("lemon");
                uniqueList.AddToTheUniqueList("banana");
                uniqueList.PrintList();
                uniqueList.RemoveFromTheUniqueList("lemon");
                uniqueList.PrintList();
                uniqueList.RemoveFromTheUniqueList("melon");
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

