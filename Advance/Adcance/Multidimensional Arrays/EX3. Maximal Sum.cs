using System;
using System.Linq;

namespace Maximal_Sum
{
    internal class Program
    {
        static void Main()
        {
            int[] input = ReadArrayConsole();
            int row = input[0];
            int col = input[1];

            int[,] matrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                int[] temp = ReadArrayConsole();

                for (int j = 0; j < col; j++)
                {
                    matrix[i,j] = temp[j];
                }
            }

            int maxSum = 0;
            int[] cordinates = new int[2];


            for (int i = 0; i < row - 2; i++)
            {
                int sum = 0;

                for (int j = 0; j < col - 2; j++)
                {
                    sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        cordinates[0] = i;
                        cordinates[1] = j;
                    }                      
                }
            }
            
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = cordinates[0]; i < cordinates[0] + 3; i++)
            {
                for (int j = cordinates[1]; j < cordinates[1] + 3; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        private static int[] ReadArrayConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}


//Write a program that reads a rectangular integer matrix of size N x M and 
//finds in it the square 3 x 3 that has maximal sum of its elements.
//Input
//•	On the first line, you will receive the rows N and columns M. 
//•	On the next N lines you will receive each row with its columns
//Output
//•	Print the elements of the 3 x 3 square as a matrix, along with their sum
