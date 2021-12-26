using System;
using System.Linq;

namespace Squares_in_Matrix
{
    internal class Program
    {
        static void Main()
        {
            int[] rowCol = ReadArrayConsole();
            int row = rowCol[0];
            int col = rowCol[1];


            char[,] matrix = new char[row, col];
            //fill the matrix 
            for (int rows = 0; rows < row; rows++)
            {
                char[] temp = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int cols = 0; cols < col; cols++)
                {
                    matrix[rows, cols] = temp[cols];
                }
            }

            int squares = 0;
            //read the matrix
            for (int rows = 0; rows < row - 1; rows++)
            {
                for (int cols = 0; cols < col - 1; cols++)
                {
                    //if the method is true we have 2x2 square
                    if(IsSquarePresent(matrix , rows , cols))
                        squares++;
                }
            }

            Console.WriteLine(squares);
        }

        private static int[] ReadArrayConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        private static bool IsSquarePresent(char[,] matrix, int rows, int cols)
        {
            //read the 2x2 and check for the same char 
            return matrix[rows,cols] == matrix[rows, cols + 1] &&
                matrix[rows, cols + 1] == matrix[rows + 1, cols ] &&
                matrix[rows + 1, cols] == matrix[rows + 1, cols + 1];
        }
    }
}

//Find the count of 2 x 2 squares of equal chars in a matrix.
//Input
//•	On the first line, you are given the integers rows and cols – the matrix’s dimensions
//•	Matrix characters come at the next rows lines (space separated)
//Output
//•	Print the number of all the squares matrixes you have found

