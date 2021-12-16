using System;
using System.Collections.Generic;
using System.Linq;

namespace Paths_in_Labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            char[,] arr = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                string elements = Console.ReadLine();

                for (int j = 0; j < elements.Length; j++)
                {
                    arr[i, j] = elements[j];
                }                             
            }
            List<string> directions = new List<string>();

            Pathfainder(arr, 0, 0, directions, string.Empty);
        }

        static void Pathfainder(char[,] arr, int row, int col, List<string> directions, string direction)
        {
            if (col < 0 || col >= arr.GetLength(1) || row < 0 || row >= arr.GetLength(0))
                return;

            if (arr[row, col] == '*' || arr[row, col] == 'v')
                return;

            directions.Add(direction);
            if(arr[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            arr[row, col] = 'v';
            //Console.WriteLine(string.Join(" ", arr.Cast<char>()));

            Pathfainder(arr, row, col + 1, directions, "R");
            Pathfainder(arr, row, col - 1, directions, "L");
            Pathfainder(arr, row - 1, col, directions, "U");
            Pathfainder(arr, row + 1, col, directions, "D");

            arr[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);
        }

    }
}
