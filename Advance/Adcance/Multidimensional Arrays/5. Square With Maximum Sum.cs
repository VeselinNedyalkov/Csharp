using System;
using System.ComponentModel;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main()
        {
            int[] rowCol = ReadArray();
            int[,] matrix = new int[rowCol[0], rowCol[1]];

            for (int row = 0; row < rowCol[0]; row++)
            {
                int[] arr = ReadArray();
                for (int col = 0; col < rowCol[1]; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            int max = int.MinValue;
            int[] maxRowCol = new int[2];
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    sum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (sum > max)
                    {
                        max = sum;
                        maxRowCol[0] = row;
                        maxRowCol[1] = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRowCol[0], maxRowCol[1]]} {matrix[maxRowCol[0], maxRowCol[1] + 1]}");
            Console.WriteLine($"{matrix[maxRowCol[0] + 1, maxRowCol[1]]} {matrix[maxRowCol[0] + 1, maxRowCol[1] + 1]}");
            Console.WriteLine(max);
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine().Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}

//Write a program that read a matrix from console.
// Then find biggest sum of 2x2 submatrix and print it to console.
//On first line you will get matrix sizes in format rows, columns.
//One next rows lines you will get elements for each column separated with coma.
//Print biggest top-left square, which you find and sum of its elements.

