using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            int[][] jagged = new int[row][];

            for (int rows = 0; rows < row; rows++)
            {
                jagged[rows] = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            string cmd;

            while ((cmd = Console.ReadLine().ToUpper()) != "END")
            {
                string[] data = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int indexRow = int.Parse(data[1]);
                int idndexCol = int.Parse(data[2]);
                int num = int.Parse(data[3]);

                if (indexRow < 0 || indexRow >= row || idndexCol < 0 || idndexCol >= row)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;

                }

                switch (data[0])
                {
                    case "ADD":
                        jagged[indexRow][idndexCol] += num;
                        break;


                    case "SUBTRACT":
                        jagged[indexRow][idndexCol] -= num;
                        break;

                    default:
                        break;
                }
            }

            for (int i = 0; i < row; i++)
            {
                Console.WriteLine(String.Join(" ",jagged[i]));
            }
        }
    }
}

//Write a program that reads a matrix from the console. On the first line you will get matrix rows. 
//On next rows lines you will get elements for each column separated with space. You will be receiving commands in the following format:
//•	Add
//{ row}
//{ col}
//{ value} – Increase the number at the given coordinates with the value.
//•	Subtract {row} { col}
//{ value} – Decrease the number at the given coordinates by the value.
//Coordinates might be invalid. In this case you should print "Invalid coordinates". 
//When you receive "END" you should print the matrix and stop the program.

