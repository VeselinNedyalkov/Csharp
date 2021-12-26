using System;
using System.Linq;

namespace Miner
{
    internal class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] comands = Console.ReadLine().Split();
            char[,] field = new char[size, size];
            const int MOVE = 1;


            //drowing the field and when we faind the start psn we mark it!
            //also we calculate the numbers of coals
            int[] starPsn  = FillElements(size, field);
            int playerRow = starPsn[0];
            int playerCol = starPsn[1];
            int coals = starPsn[2];

            //check the cordinates and if is possible we move in the given direction
            for (int k = 0; k < comands.Length; k++)
            {
                string comand = comands[k];
                
                if(comand == "up")
                {
                    if (playerRow - MOVE >= 0)
                        playerRow -= MOVE;                    
                }
                else if(comand == "down")
                {
                    if (playerRow + MOVE < size)
                        playerRow += MOVE;                    
                }
                else if(comand == "left")
                {
                    if (playerCol - MOVE >= 0)
                        playerCol -= MOVE;                    
                }
                else if(comand == "right")
                {
                    if (playerCol + MOVE < size)
                        playerCol += MOVE;
                }


                //check the cords for coals or e(game over)
                if (field[playerRow, playerCol] == 'c')
                {
                    coals--;
                    if (coals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        return;
                    }
                    field[playerRow, playerCol] = '*';
                }
                else if (field[playerRow, playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    return ;
                }
            }//comands for
            Console.WriteLine($"{coals} coals left. ({playerRow}, {playerCol})");
        }

        private static int[] FillElements(int size, char[,] field)
        {
            int[] result = new int[3];
            int colCal = 0;

            for (int i = 0; i < size; i++)
            {
                char[] temp = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int j = 0; j < size; j++)
                {
                    field[i, j] = temp[j];
                    //when we have the char "s" we save the cordinates
                    if (field[i, j] == 's')
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                    //calculate the coals if we have the char 'c'
                    if (field[i, j] == 'c')
                        colCal++;
                }
            }
            result[2] = colCal;

            //return index 1 = start row ; 2 = start col ; 3 = numbers of coals
            return result;
        }

        
    }
}





//We get as input the size of the field in which our miner moves. 
//The field is always a square. After that we will receive the commands which represent the directions 
//in which the miner should move. The miner starts from position – ‘s’. The commands will be: left, right, up and down. 
//If the miner has reached a side edge of the field and the next command indicates that he has to get out of the field,
//he must remain on his current possition and ignore the current command. 
//The possible characters that may appear on the screen are:
//•	* – a regular position on the field.
//•	e – the end of the route. 
//•	c  - coal
//•	s - the place where the miner starts
//Each time when the miner finds a coal, he collects it and replaces it with '*'.
// Keep track of the count of the collected coals. If the miner collects all of the coals in the field,
// the program stops and you have to print the following message:
// "You collected all coals! ({rowIndex}, {colIndex})".
//If the miner steps at 'e' the game is over (the program stops) and you have to print the following message: 
//"Game over! ({rowIndex}, {colIndex})".
//If there are no more commands and none of the above cases had happened,
//you have to print the following message: "{remainingCoals} coals left. ({rowIndex}, {colIndex})".
//Input
//•	Field size – an integer number.
//•	Commands to move the miner – an array of strings separated by " ".
//•	The field: some of the following characters (*, e, c, s), separated by whitespace (" ");
//Output
//•	There are three types of output:
//o If all the coals have been collected, print the following output: "You collected all coals! ({rowIndex}, {colIndex})"
//o If you have reached the end, you have to stop moving and print the following line: "Game over! ({rowIndex}, {colIndex})"
//o If there are no more commands and none of the above cases had happened, you have to print the following message: "{totalCoals} coals left. ({rowIndex}, {colIndex})"

