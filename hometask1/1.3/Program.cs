using System;

namespace array_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5] { 2, 9, 4, 3, 5 };
            SelectionSort(array);
            Console.ReadKey();
        }

        static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int current_minimum = i;
                for (int j = i + 1; j < array.Length-1; j++)
                {
                    if (array[j] < array[current_minimum])
                    {
                        current_minimum = j;
                    }
                }
                if (current_minimum != i)
                {
                    int temp = array[i];
                    array[i] = array[current_minimum];
                    array[current_minimum] = temp;
                }
            }
            foreach (int element in array)
            {
                Console.Write($"{element}");
            }
        }
    }
}
