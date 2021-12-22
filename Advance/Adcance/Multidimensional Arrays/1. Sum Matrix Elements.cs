using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace Multidimensional_ArraysLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowCol = ReadArray();
            int[,] twoDimArr = new int[rowCol[0], rowCol[1]];

            for (int row = 0; row < rowCol[0]; row++)
            {
                int[] arr = ReadArray();
                for (int col = 0; col < rowCol[1]; col++)
                {
                    twoDimArr[row, col] = arr[col];
                }
            }

            Console.WriteLine(twoDimArr.GetLength(0));
            Console.WriteLine(twoDimArr.GetLength(1));

            int sum = 0;

            foreach (var item in twoDimArr)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
}
}
}

//Write program that reads a matrix from the console and print:
//•	Count of rows
//•	Count of columns
//•	Sum of all matrix elements
//On first line you will get matrix sizes in format [rows, columns]

