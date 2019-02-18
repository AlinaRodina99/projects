using System;

namespace MatrixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            FillingAndSortOfMatrix();
            Console.ReadKey();
        }

        static void SortOfMatrix(int[,] matrix)
        {

            int countOfRows = matrix.GetUpperBound(0) + 1;
            int countOfColumns = matrix.Length / countOfRows;
            int i, j, k;
            for ( j = 0; j < countOfColumns-1; j++)
            {
                i = 0;
                int currentMin = j;
                for ( k = j + 1; k < countOfColumns; k++)
                {
                    if (matrix[i,k]<matrix[i,currentMin])
                    {
                        currentMin = k;
                    }
                }
                if (currentMin!=j)
                {
                    for ( i = 0; i < countOfRows; i++)
                    {
                        
                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[i, currentMin];
                        matrix[i, currentMin] = temp;
                        
                    }
                }
            }

            for (i = 0; i < countOfRows; i++)
            {
                for (j = 0; j < countOfColumns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void FillingAndSortOfMatrix()
        {
            Console.WriteLine("Enter the count of rows: ");
            int countOfRows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the count of columns: ");
            int countOfColumns = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[countOfRows, countOfColumns];
            for (int i = 0; i < countOfRows; i++)
            {
                for (int j = 0; j < countOfColumns; j++)
                {
                    Console.WriteLine("Enter the element of matrix: ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            SortOfMatrix(matrix);
        }
    }
}
