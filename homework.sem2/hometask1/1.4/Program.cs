using System;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter dimension of matrix: ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[N, N];
            SpiralBypass(matrix);
            Console.ReadKey();
        }

        static void SpiralBypass(int[,] matrix)
        {
            int dimension = matrix.GetUpperBound(0) + 1;
            int i, j, number = 0;
            for  (i = 0; i < dimension; i++)
            {
                for (j = 0; j < dimension; j++)
                {
                   matrix[i, j] = ++number;
                }
            }
            int shift = 0;//сдвиг
            i = dimension / 2;
            j = dimension / 2;
            while (shift < dimension)
            {
                shift++;
                for (int l = 0; l < shift; l++)
                {
                    Console.Write(matrix[i--, j] + " ");//движение вверх
                }
                if (shift==dimension)
                {
                    break;
                }
                for (int l = 0; l < shift; l++)
                {
                    Console.Write(matrix[i, j++] + " ");//движение вправо
                }
                shift++;
                for (int l = 0; l < shift; l++)
                {
                    Console.Write(matrix[i++, j] + " ");//движение вниз
                }
                for (int l = 0; l < shift; l++)
                {
                    Console.Write(matrix[i, j--] + " ");//движение влево
                }
            }
        }
    }
}
