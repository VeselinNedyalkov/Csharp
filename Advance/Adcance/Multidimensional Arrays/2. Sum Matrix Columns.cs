using System;
using System.ComponentModel;
using System.Linq;

namespace Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] colRow = ReadArray();

            int[,] matrix = new int[colRow[0], colRow[1]];

            for (int row = 0; row < colRow[0]; row++)
            {
                int[] arr = ReadArray();
                for (int col = 0; col < colRow[1]; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }
            
            for (int col = 0; col < colRow[1]; col++)
            {
                int sum = 0;
                for (int row = 0; row < colRow[0]; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine().Split(new string[] { ", ", " "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}

//Write program that read a matrix from console and print the sum for each column. On first line you will get matrix rows. 
//On the next rows lines, you will get elements for each column separated with a space. 


