using System;

namespace ArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new [] { 2, 9, 4, 3, 5 };
            SelectionSort(array);
            Console.ReadKey();
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int currentminimum = i;
                for (int j = i + 1; j < array.Length-1; j++)
                {
                    if (array[j] < array[currentminimum])
                    {
                        currentminimum = j;
                    }
                }
                if (currentminimum != i)
                {
                    int temp = array[i];
                    array[i] = array[currentminimum];
                    array[currentminimum] = temp;
                }
            }
            foreach (int element in array)
            {
                Console.Write($"{element}");
            }
        }
    }
}
