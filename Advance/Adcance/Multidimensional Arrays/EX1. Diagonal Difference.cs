using System;
using System.ComponentModel;
using System.Linq;

namespace Multidimensional_ArraysEx
{
    internal class Program
    {
        static void Main()
        {
            int lenght = int.Parse(Console.ReadLine());

            int[,] matrix = new int[lenght,lenght];

            //full the matrix
            for (int row = 0; row < lenght; row++)  
            {
                int[] tempArr = CreateMatrix();

                for (int col = 0; col < lenght; col++)
                {
                    matrix[row,col] = tempArr[col];
                }
            }

            int sumOne = 0;
            int sumTwo = 0;

            //calculate 1st diagonal 
            for (int row = 0;row < lenght; row++)
            {
                for (int col = 0; col < lenght; col++)
                {
                    if(row == col)
                        sumOne += matrix[row,col];                
                }
            }
            //calculate second diagonal with recursion
            sumTwo = SecondDiagonal(matrix, 0, lenght - 1, 0);

            Console.WriteLine($"{Math.Abs(sumOne - sumTwo)}");
        }

        private static int SecondDiagonal(int[,] matrix, int row, int col, int sum)
        {
            //if the index go out of range return 0;
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
                return 0;    
            
            //sum the matrix and call the same method with diferent row and col
            sum += matrix[row, col] + SecondDiagonal(matrix, row + 1, col - 1, sum);
            return sum;
        }

        private static int[] CreateMatrix()
        {
            return Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}

//Write a program that finds the difference between the sums of the square matrix diagonals (absolute value).
