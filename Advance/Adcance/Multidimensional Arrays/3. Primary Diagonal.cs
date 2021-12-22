using System;
using System.ComponentModel;
using System.Linq;

namespace Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[,] matrix = new int[num,num];

            for (int row = 0; row < num; row++)
            {
                int[] arr = ReadArray();
                for (int col = 0; col < num; col++)
                {
                    matrix[row,col] = arr[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < num; row++)
            {
                for (int col = 0; col < num; col++)
                {
                    if(row == col)
                        sum += matrix[row,col];
                }
            }
            Console.WriteLine(sum);
        }


        private static int[] ReadArray()
        {
            return Console.ReadLine().Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}

//Write a program that finds the sum of matrix primary diagonal.
