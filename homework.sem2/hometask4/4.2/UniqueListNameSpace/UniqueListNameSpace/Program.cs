using System;
using LinkedList;

namespace UniqueListNameSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var uniqueList = new UniqueList();
                uniqueList.AddAt(0, "apple");
                uniqueList.AddAt(1, "lemon");
                uniqueList.SetValueByPosition(1, "apple");
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

