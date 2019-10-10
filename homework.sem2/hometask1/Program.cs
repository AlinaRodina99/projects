using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter dimension of matrix: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[n, n];
            FillingOfMatrix(matrix);
            SpiralBypass(matrix);
        }

        static void SpiralBypass(int[,] matrix)
        {
            int dimension = matrix.GetUpperBound(0) + 1;
            int shift = 0; // сдвиг
            int i = dimension / 2;
            int j = dimension / 2;
            while (shift < dimension)
            {
                shift++;
                for (int l = 0; l < shift; l++)
                {
                    Console.Write(matrix[i, j] + " ");
                    i--; // движение вверх
                }
                if (shift == dimension)
                {
                    break;
                }
                for (int l = 0; l < shift; l++)
                {
                    Console.Write(matrix[i, j] + " ");
                    j++; // движение вправо
                }
                shift++;
                for (int l = 0; l < shift; l++)
                {
                    Console.Write(matrix[i, j] + " ");
                    i++; // движение вниз
                }
                for (int l = 0; l < shift; l++)
                {
                    Console.Write(matrix[i, j] + " ");
                    j--; // движение влево
                }
            }
        }

        static void FillingOfMatrix(int[,] matrix)
        {
            int size = matrix.GetUpperBound(0) + 1;
            int number = 0;
            for (int k = 0; k < size; k++)
            {
                for (int m = 0; m < size; m++)
                {
                    matrix[k, m] = ++number;
                }
            }
        }
    }
}
