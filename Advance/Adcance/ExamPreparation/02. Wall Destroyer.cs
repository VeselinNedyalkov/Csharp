using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < size; row++)
            {
                string temp = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = temp[col];

                    if (board[row, col] == 'V')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            board[playerRow, playerCol] = '*';

            string cmd = String.Empty;
            bool wall = false;
            bool electrocuted = false;
            int holesCounter = 1;
            int rodsCounter = 0;

            while ((cmd = Console.ReadLine()) != "End")
            {
                int movementSpeed = 1;

                switch (cmd)
                {
                    case "up":
                        if (!IsItInsideBoard(size, playerRow - movementSpeed, playerCol))
                        {
                            playerRow--;
                        }
                        else
                        {
                            wall = true;
                        }

                        if (board[playerRow, playerCol] == 'R')
                        {
                            rodsCounter++;
                            playerRow++;
                            Console.WriteLine("Vanko hit a rod!");
                            continue;
                        }
                        break;

                    case "down":
                        if (!IsItInsideBoard(size, playerRow + movementSpeed, playerCol))
                        {
                            playerRow++;
                        }
                        else
                        {
                            wall = true;
                        }

                        if (board[playerRow, playerCol] == 'R')
                        {
                            rodsCounter++;
                            playerRow--;
                            Console.WriteLine("Vanko hit a rod!");
                            continue;
                        }
                        break;

                    case "left":
                        if (!IsItInsideBoard(size, playerRow, playerCol - movementSpeed))
                        {
                            playerCol--;
                        }
                        else
                        {
                            wall = true;
                        }


                        if (board[playerRow, playerCol] == 'R')
                        {
                            rodsCounter++;
                            playerCol++;
                            Console.WriteLine("Vanko hit a rod!");
                            continue;
                        }
                        break;

                    case "right":
                        if (!IsItInsideBoard(size, playerRow, playerCol + movementSpeed))
                        {
                            playerCol++;
                        }
                        else
                        {
                            wall = true;
                        }

                        if (board[playerRow, playerCol] == 'R')
                        {
                            playerCol--;
                            rodsCounter++;
                            Console.WriteLine("Vanko hit a rod!");
                            continue;
                        }
                        break;

                    default:
                        break;
                }

                if (board[playerRow, playerCol] == '*' && !wall)
                {
                    Console.WriteLine($"The wall is already destroyed at position [{playerRow}, {playerCol}]!");
                }

                if (board[playerRow, playerCol] == '-' || board[playerRow, playerCol] == 'V')
                {
                    holesCounter++;
                    board[playerRow, playerCol] = '*';
                }

                if (board[playerRow, playerCol] == 'C')
                {
                    holesCounter++;
                    board[playerRow, playerCol] = 'E';
                    electrocuted = true;
                    break;
                }

                wall = false;
                //PrintMatrix(size, board);
            }



            if (!electrocuted)
            {
                board[playerRow, playerCol] = 'V';
                Console.WriteLine($"Vanko managed to make {holesCounter}" +
                    $" hole(s) and he hit only {rodsCounter} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed " +
                    $"to make {holesCounter} hole(s).");
            }

            PrintMatrix(size, board);
        }

        private static void PrintMatrix(int size, char[,] board)
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

        private static bool IsItInsideBoard(int size, int playerRow, int playerCol)
        {
            bool outside = true;

            if (playerRow >= 0 && playerRow < size &&
               playerCol >= 0 && playerCol < size)
            {
                outside = false;
            }

            return outside;
        }
    }
}
