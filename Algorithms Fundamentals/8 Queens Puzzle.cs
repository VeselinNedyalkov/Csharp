using System;
using System.Collections.Generic;

namespace Queens_Puzzle
{
    internal class Program
    {

        private static List<int> notPossRows = new List<int>();
        private static List<int> notPossCol = new List<int>();
        private static List<int> notPossLDiagonals = new List<int>();
        private static List<int> notPossRDiagonals = new List<int>();
        static void Main(string[] args)
        {
                       

            bool[,] board = new bool[8, 8];

            Quen(board, 0);


        }

        private static void Quen(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintQuens(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (IsPossible(row,col))
                {
                    notPossRows.Add(row);
                    notPossCol.Add(col);
                    notPossLDiagonals.Add(row - col);
                    notPossRDiagonals.Add(row + col);
                    board[row, col] = true;

                    Quen(board, row + 1 );

                    notPossRows.Remove(row);
                    notPossCol.Remove(col);
                    notPossLDiagonals.Remove(row - col);
                    notPossRDiagonals.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        private static void PrintQuens(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                   
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
        }

        private static bool IsPossible(int row, int col)
        {
            return !notPossRows.Contains(row) &&
                !notPossCol.Contains(col) &&
                !notPossLDiagonals.Contains(row - col) &&
                !notPossRDiagonals.Contains(row + col);
        }
    }
}
