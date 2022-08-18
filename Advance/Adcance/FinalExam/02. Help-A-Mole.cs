using System;

namespace Help_A_Mole
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];
            int moleRow = 0;
            int moleCol = 0;

            for (int row = 0; row < size; row++)
            {
                string temp = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = temp[col];

                    if (board[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                }
            }

            string escape = "Don't try to escape the playing field!";
            int score = 0;
            board[moleRow, moleCol] = '-';

            string comands;
            while ((comands = Console.ReadLine()) != "End")
            {
                if (score >= 25)
                {
                    break;
                }

                switch (comands)
                {
                    case "up":
                        if (isItOnBoard(size, moleRow - 1, moleCol))
                        {
                            moleRow--;
                        }
                        else
                        {
                            Console.WriteLine(escape);
                        }
                        break;

                    case "down":
                        if (isItOnBoard(size, moleRow + 1, moleCol))
                        {
                            moleRow++;
                        }
                        else
                        {
                            Console.WriteLine(escape);
                        }
                        break;

                    case "left":
                        if (isItOnBoard(size, moleRow, moleCol - 1))
                        {
                            moleCol--;
                        }
                        else
                        {
                            Console.WriteLine(escape);
                        }
                        break;

                    case "right":
                        if (isItOnBoard(size, moleRow, moleCol + 1))
                        {
                            moleCol++;
                        }
                        else
                        {
                            Console.WriteLine(escape);
                        }
                        break;

                    default:
                        break;
                }

                if (board[moleRow, moleCol] == 'S')
                {
                    bool isTeleported = false;
                    board[moleRow, moleCol] = '-';

                    for (int row = 0; row < size; row++)
                    {
                        if (isTeleported) break;

                        for (int col = 0; col < size; col++)
                        {
                            if (board[row, col] == 'S')
                            {
                                moleRow = row;
                                moleCol = col;
                                isTeleported = true;
                            }
                        }
                    }

                    score -= 3;
                }

                if (char.IsDigit(board[moleRow, moleCol]))
                {
                    score += (int)char.GetNumericValue(board[moleRow, moleCol]);
                }

                board[moleRow, moleCol] = '-';
            }

            board[moleRow, moleCol] = 'M';

            if (score < 25)
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {score} points.");
            }
            else
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {score} points.");
            }

            printBoard(size, board);
        }

        private static void printBoard(int size, char[,] board)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool isItOnBoard(int size, int moleRow, int moleCol)
        {
            return moleRow >= 0 && moleRow < size && moleCol >= 0 && moleCol < size;
        }
    }
}
