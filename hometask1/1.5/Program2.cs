using System;

namespace MatrixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the count of rows: ");
            int countOfRows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the count of columns: ");
            int countOfColumns = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[countOfRows, countOfColumns];
            FillingOfMatrix(matrix);
            SortOfMatrix(matrix);
            PrintOfMatrix(matrix);
        }

        static void SortOfMatrix(int[,] matrix)
        {
            int countOfRows = matrix.GetLength(0);
            int countOfColumns = matrix.Length / countOfRows;
            for (int j = 0; j < countOfColumns - 1; j++)
            {
                int i = 0;
                int currentMin = j;
                for (int k = j + 1; k < countOfColumns; k++)
                {
                    if (matrix[i, k] < matrix[i, currentMin])
                    {
                        currentMin = k;
                    }
                }
                if (currentMin != j)
                {
                    for (i = 0; i < countOfRows; i++)
                    {

                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[i, currentMin];
                        matrix[i, currentMin] = temp;

                    }
                }
            }
        }
