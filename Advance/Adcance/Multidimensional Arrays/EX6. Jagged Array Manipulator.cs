using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main()
        {
            int numRows = int.Parse(Console.ReadLine());

            double[][] jagged = new double[numRows][];

            for (int i = 0; i < numRows; i++)
            {
                jagged[i] = ReadArrayConsole();
            }

            for (int i = 0; i < numRows - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    jagged[i] = jagged[i].Select(x => x * 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jagged[i] = jagged[i].Select(x => x / 2).ToArray();
                    jagged[i + 1] = jagged[i + 1].Select(x => x / 2).ToArray();
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] input = cmd.Split();

                switch (input[0])
                {
                    case "Add":
                        int row = int.Parse(input[1]);
                        int col = int.Parse(input[2]);
                        int value = int.Parse(input[3]);

                        if (IsValid(jagged, row, col, numRows))
                            jagged[row][col] += value;
                        break;

                    case "Subtract":
                        row = int.Parse(input[1]);
                        col = int.Parse(input[2]);
                        value = int.Parse(input[3]);

                        if (IsValid(jagged, row, col, numRows))
                            jagged[row][col] -= value;
                        break;

                    default:
                        break;
                }
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(String.Join(" ",item));
            }
        }

        private static double[] ReadArrayConsole()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();
        }

        private static bool IsValid(double[][] jagged, int row, int col, int numRows)
        {
            return row >= 0 && row < numRows
                && col >= 0 && col < jagged[row].Length;
        }
    }
}



//Create a program that populates, analyzes and manipulates the elements of a matrix with unequal length of its rows.
//First you will receive an integer N equal to the number of rows in your matrix.
//On the next N lines, you will receive sequences of integers, separated by a single space. Each sequence is a row in the matrix.
//After populating the matrix, start analyzing it. 
//If a row and the one below it have equal length, multiply each element in both of them by 2, otherwise - divide by 2.
//Then, you will receive commands. There are three possible commands:
//•	"Add {row} {column} {value}" - add { value}
//to the element at the given indexes, if they are valid
//•	"Subtract {row} {column} {value}" - subtract {value} from the element at the given indexes, if they are valid
//•	"End" - print the final state of the matrix (all elements separated by a single space) and stop the program
//Input
//•	On the first line, you will receive the number of rows of the matrix - integer N
//•	On the next N lines, you will receive each row - sequence of integers, separated by a single space
//•	{value} will always be integer number
//•	Then you will be receiving commands until reading "End"
//Output
//•	The output should be printed on the console and it should consist of N lines
//•	Each line should contain a string representing the respective row of the final matrix, elements separated by a single space
//Constraints
//•	The number of rows N of the matrix will be integer in the range [2 … 12]
//•	The input will always follow the format above
//•	Think about data types

