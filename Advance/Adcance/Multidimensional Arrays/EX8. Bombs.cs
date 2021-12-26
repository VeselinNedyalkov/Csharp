using System;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizaBoard = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizaBoard,sizaBoard];

            for (int i = 0; i < sizaBoard; i++)
            {
                int[] temp = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < sizaBoard; j++)
                {
                    matrix[i,j] = temp[j];
                }
            }

            string[] bombs = Console.ReadLine().Split();
            //we check all the bombs
            for (int i = 0;i < bombs.Length; i++)
            {
                int[] bombCords = bombs[i].Split(",").Select(int.Parse).ToArray();
                //take from the bomb the row , col and its value
                int row = bombCords[0];
                int col = bombCords[1];
                int bombValue = matrix[row, col];

                //if bomb value is less than 0 nothing happend
                if (bombValue > 0)
                {
                    //check the index row to be in range
                    int startRow = row - 1;
                    int endRow = row + 1;
                    if (startRow < 0)
                        startRow = row;
                    if (endRow > sizaBoard - 1)
                        endRow = row;
                    //we check the index col to be in range
                    int startCol = col - 1;
                    int endCol = col + 1;
                    if (startCol < 0)
                        startCol = col;
                    if (endCol > sizaBoard - 1)
                        endCol = col;

                    //reduce the values of the cells around it
                    for (int j = startRow; j <= endRow; j++)
                    {
                        for (int k = startCol; k <= endCol; k++)
                        {
                            if(matrix[j, k] > 0)
                                matrix[j, k] -= bombValue;
                        }
                    }
                }
            }//end of array

            int activCell = 0;
            int sum = 0;
            //calculate how many active cell we have and what is the sum
            for (int i = 0; i < sizaBoard; i++)
            {
                for (int j = 0; j < sizaBoard; j++)
                {
                    if (matrix[i,j] > 0)
                    {
                        activCell++;
                        sum += matrix[i, j];
                    }                  
                }               
            }
            Console.WriteLine($"Alive cells: {activCell}");
            Console.WriteLine($"Sum: {sum}");
            PrintArray(matrix, sizaBoard, sizaBoard);
        }
        private static void PrintArray(int[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}




//You will be given a square matrix of integers, each integer separated by a single space, and each row on a new line.
// Then on the last line of input you will receive indexes - coordinates to several cells separated by a single space,
//in the following format: row1,column1 row2, column2  row3, column3… 
//On those cells there are bombs. You have to proceed every bomb, one by one in the order they were given. 
//When a bomb explodes deals damage equal to its own integer value, to all the cells around it (in every direction and in all diagonals). 
//One bomb can't explode more than once and after it does, its value becomes 0. When a cell’s value reaches 0 or below, it dies.
// Dead cells can't explode.
//You must print the count of all alive cells and their sum. Afterwards, print the matrix with all of its cells (including the dead ones). 
//Input
//•	On the first line, you are given the integer N – the size of the square matrix.
//•	The next N lines holds the values for every row – N numbers separated by a space.
//•	On the last line you will receive the coordinates of the cells with the bombs in the format described above.
//Output
//•	On the first line you need to print the count of all alive cells in the format: 
//“Alive cells: { aliveCells}”
//•	On the second line you need to print the sum of all alive cell in the format: 
//“Sum: { sumOfCells}”
//•	In the end print the matrix. The cells must be separated by a single space.
//Constraints
//•	The size of the matrix will be between [0…1000].
//•	The bomb coordinates will always be in the matrix.
//•	The bomb’s values will always be greater than 0.
//•	The integers of the matrix will be in range [1…10000]. 

