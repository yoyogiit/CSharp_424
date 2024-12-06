using System;

namespace Lab3
{
 class MatrixManipulation
    {
        // Method to shuffle an array
        static void Shuffle(int[] array)
        {
            Random rand = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        // Method to fill the matrix with shuffled integers
        static int[,] FillMatrix(int rows, int cols)
        {
            int[] numbers = new int[rows * cols];

            // Fill numbers array with integers from 0 to rows * cols - 1
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            // Shuffle the numbers array
            Shuffle(numbers);

            // Create the 2D matrix and fill it
            int[,] matrix = new int[rows, cols];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = numbers[index++];
                }
            }

            return matrix;
        }

        // Method to sort the matrix by the first column using row exchanges
        static void SortMatrixByFirstColumn(ref int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = i + 1; j < rows; j++)
                {
                    if (matrix[i, 0] > matrix[j, 0])
                    {
                        // Swap rows i and j
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = matrix[i, k];
                            matrix[i, k] = matrix[j, k];
                            matrix[j, k] = temp;
                        }
                    }
                }
            }
        }

        // Method to print the matrix
        static void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            // Get user input for rows and columns
            Console.Write("Enter the number of rows: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns: ");
            int cols = int.Parse(Console.ReadLine());

            // Fill the matrix with shuffled integers
            int[,] matrix = FillMatrix(rows, cols);

            Console.WriteLine("\nOriginal Matrix:");
            PrintMatrix(matrix, rows, cols);

            // Sort the matrix by the first column
            SortMatrixByFirstColumn(ref matrix, rows, cols);

            Console.WriteLine("\nSorted Matrix:");
            PrintMatrix(matrix, rows, cols);
        }
    }
}
