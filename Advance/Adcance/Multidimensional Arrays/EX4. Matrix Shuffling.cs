using System;
using System.Linq;

namespace Matrix_Shuffling
{
    internal class Program
    {
        static void Main()
        {
            int[] input = ReadArrayConsole();
            int row = input[0];
            int col = input[1]; 

            string[,] matrix = new string[row, col];

            for (int i = 0; i < row; i++)
            {
                string[] temp = Console.ReadLine().Split();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdInput = cmd.Split();

                if (cmdInput[0] != "swap" || cmdInput.Length != 5 
                    || IsValid(matrix, int.Parse(cmdInput[1]), int.Parse(cmdInput[2]), 
                    int.Parse(cmdInput[3]), int.Parse(cmdInput[4])))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rowOne = int.Parse(cmdInput[1]);
                int colOne = int.Parse(cmdInput[2]);
                int rowTwo = int.Parse(cmdInput[3]);
                int colTwo = int.Parse(cmdInput[4]);               
                    
                string temp = matrix[rowOne, colOne];
                matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
                matrix[rowTwo, colTwo] = temp;

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

        private static bool IsValid(string[,] matrix, int rowOne, int colOne, int rowTwo, int colTwo)
        {
            return  rowOne < 0 || rowOne >= matrix.GetLength(0)
                || rowTwo < 0 || rowTwo >= matrix.GetLength(0) || colOne < 0 ||
                colOne >= matrix.GetLength(1) || colTwo < 0 || colTwo >= matrix.GetLength(1);
        }

        private static int[] ReadArrayConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
    }
}

//Write a program which reads a string matrix from the console and performs 
//certain operations with its elements. User input is provided in a similar way like in the 
//problems above – first you read the dimensions and then the data. 
//Your program should then receive commands in format: "swap row1 col1 row2 col2"
// where row1, col1, row2, col2 are coordinates in the matrix. In order for a command to be valid,
// it should start with the "swap" keyword along with four valid coordinates (no more, no less).
// You should swap the values at the given coordinates (cell [row1, col1] with cell[row2, col2]) 
//and print the matrix at each step (thus you'll be able to check if the operation was performed correctly). 
//If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered 
//or the given coordinates do not exist), print "Invalid input!" and move on to the next command.
// Your program should finish when the string "END" is entered

