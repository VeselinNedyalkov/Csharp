using System;
using System.Collections.Generic;
using System.Linq;

namespace R_Bunnies_2
{
    internal class Program
    {
        static void Main()
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = size[0];
            int col = size[1];

            char[,] field = new char[row, col];

            int[] starPsn = FillElements(row, col, field);
            int playerRow = starPsn[0];
            int playerCol = starPsn[1];

            //this stack will hold the bunnies cordinates
            Stack<int> bunnies = new Stack<int>();

            //check if we go at the end of the field
            bool won = false;

            string comands = Console.ReadLine();
            const int MOVE = 1;


            for (int c = 0; c < comands.Length; c++)
            {
                char comand = comands[c];
                
                field[playerRow, playerCol] = '.';

                if (comand == 'U')
                {     
                //player move if is out of the field he won
                         playerRow -= MOVE;
                    if (playerRow < 0)
                    {
                        won = true;
                        playerRow += MOVE;
                    }                       
                }
                else if (comand == 'D')
                {
                        playerRow += MOVE;
                    if (playerRow > row - 1)
                    {
                        playerRow -= MOVE;
                        won = true;
                    }                     
                }
                else if (comand == 'L')
                {
                    playerCol -= MOVE;
                    if (playerCol < 0)
                    {
                        playerCol += MOVE;
                        won = true;
                    }                       
                }
                else if (comand == 'R')
                {                    
                         playerCol += MOVE;
                    if (playerCol > col - 1)
                    {
                        playerCol -= MOVE;
                        won = true;
                    }
                        
                }

                if (won)
                {
                    //we clone the bunnies one more time
                    BunniesGrow(row, col, field, bunnies);

                    //print the matrix and player psn
                    PrintMatrix(field, row, col);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

                //Grow the number of bunnies
                BunniesGrow(row, col, field, bunnies);

                //if player is on B he is dead
                if (field[playerRow, playerCol] == 'B')
                {
                    PrintMatrix(field, row, col);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }

                //if won is true he made it out of the field
               
            }
        }//main

        private static void BunniesGrow(int row, int col, char[,] field, Stack<int> bunnies)
        {
            //fill up the stack with all the bunnies cords 
            FaindBunny(field, bunnies);

            while (bunnies.Count != 0)
            {
                int bunnyCol = bunnies.Pop();
                int bunnyRow = bunnies.Pop();

                //bunny check if is possible to grow up
                if (bunnyRow > 0 && field[bunnyRow - 1, bunnyCol] != 'B')
                {
                    field[bunnyRow - 1, bunnyCol] = 'B';
                }
                //bunny check if is possible to grow down 
                if (bunnyRow < row - 1 && field[bunnyRow + 1, bunnyCol] != 'B')
                {
                    field[bunnyRow + 1, bunnyCol] = 'B';
                }
                //bunny check if is possible to grow left
                if (bunnyCol > 0 && field[bunnyRow, bunnyCol - 1] != 'B')
                {
                    field[bunnyRow, bunnyCol - 1] = 'B';
                }
                //bunny check if is possible to grow right
                if (bunnyCol < col - 1 && field[bunnyRow, bunnyCol + 1] != 'B')
                {
                    field[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }

        private static void FaindBunny(char[,] field, Stack<int> bunnies)
        {
            //read the field and save cords of all bunnies
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j] == 'B')
                    {
                        bunnies.Push(i);
                        bunnies.Push(j);
                    }
                }
            }
        }

        private static int[] FillElements(int row, int col, char[,] field)
        {
            int[] result = new int[2];


            for (int i = 0; i < row; i++)
            {
                string temp = Console.ReadLine();

                for (int j = 0; j < col; j++)
                {
                    //fill up the char to the psn on the field
                    field[i, j] = temp[j];

                    //when we have the char "P" we save the cordinates
                    if (field[i, j] == 'P')
                    {
                        result[0] = i;
                        result[1] = j;
                    }                   
                }
            }
            //return index 1 = start row ; 2 = start col ;
            return result;
        }

        private static void PrintMatrix(char[,] matrix, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}







//Browsing through GitHub, you come across an old JS Basics teamwork game.
//It is about very nasty bunnies that multiply extremely fast. There’s also a player that has to escape from their lair.
//You really like the game, so you decide to port it to C# because that’s your language of choice.
//The last thing that is left is the algorithm that decides if the player will escape the lair or not.
//First, you will receive a line holding integers N and M, which represent the rows and columns in the lair.
//Then you receive N strings that can only consist of ".", "B", "P". The bunnies are marked with "B",
//the player is marked with "P", and everything else is free space, marked with a dot ".".
//They represent the initial state of the lair. There will be only one player. Then you will receive a string with commands such as
//LLRRUUDD – where each letter represents the next move of the player (Left, Right, Up, Down).
//After each step of the player, each of the bunnies spread to the up, down, left and right (neighboring cells marked as "."
//changes their value to "B"). If the player moves to a bunny cell or a bunny reaches the player, the player has died.
//If the player goes out of the lair without encountering a bunny, the player has won.
//When the player dies or wins, the game ends. All the activities for this turn continue (e.g. all the bunnies spread normally),
//but there are no more turns. There will be no stalemates where the moves of the player end before he dies or escapes.
//Finally, print the final state of the lair with every row on a separate line. On the last line,
//print either "dead: {row} {col}" or "won: {row} {col}". Row and col are the coordinates of the cell where the player
//has died or the last cell he has been in before escaping the lair.
//Input
//•	On the first line of input, the numbers N and M are received – the number of rows and columns in the lair
//•	On the next N lines, each row is received in the form of a string. The string will contain only ".", "B", "P".
//All strings will be the same length. There will be only one "P" for all the input
//•	On the last line, the directions are received in the form of a string, containing "R", "L", "U", "D"
//Output
//•	On the first N lines, print the final state of the bunny lair
//•	On the last line, print the outcome – "won:" or "dead:" + {row} { col}

