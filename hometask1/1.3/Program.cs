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
            for (int i = 0; i < array.Length - 1; i++)
            {
                int currentMinimum = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[currentMinimum])
                    {
                        currentMinimum = j;
                    }
                }
                if (currentMinimum != i)
                {
                    int temp = array[i];
                    array[i] = array[currentMinimum];
                    array[currentMinimum] = temp;
                }
            }
            foreach (int element in array)
            {
                Console.Write($"{element}");
            }
        }
    }
}
