using System;


namespace Knight_Game
{
    internal class Program
    {
        static void Main()
        {
            int boardSiza = int.Parse(Console.ReadLine());
            char[,] matrix = new char[boardSiza, boardSiza];

            for (int i = 0; i < boardSiza; i++)
            {
                string temp = Console.ReadLine();

                for (int j = 0; j < boardSiza; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
            int bestResult = 0;

            //we start to search the matrix  for K that can hit molst others K
            while (true)
            {
                int maxHits = 0;
                int[] cordsMaxHits = new int[2];

                for (int i = 0; i < boardSiza; i++)
                {
                    
                    for (int j = 0; j < boardSiza; j++)
                    {
                        int knightCount = 0;
                        if (matrix[i, j] == 'K')
                        {
                            //check for knight going up and left
                            if (i - 2 >= 0 && j - 1 >= 0)
                                if (matrix[i - 2, j - 1] == 'K')
                                    knightCount++;

                            //check for knight going up and right
                            if (i - 2 >= 0 && j + 1 < boardSiza)
                                if (matrix[i - 2, j + 1] == 'K')
                                    knightCount++;

                            //check for knight going down and left
                            if (i + 2 < boardSiza && j - 1 >= 0)
                                if (matrix[i + 2, j - 1] == 'K')
                                    knightCount++;

                            //check for knight going down and right
                            if (i + 2 < boardSiza && j + 1 < boardSiza)
                                if (matrix[i + 2, j + 1] == 'K')
                                    knightCount++;

                            //check for knight going left and up
                            if (i - 1 >= 0 && j - 2 >= 0)
                                if (matrix[i - 1, j - 2] == 'K')
                                    knightCount++;

                            //check for knight going left and down
                            if (i + 1 < boardSiza && j - 2 >= 0)
                                if (matrix[i + 1, j - 2] == 'K')
                                    knightCount++;

                            //check for knight going right and up
                            if (i - 1 >= 0 && j + 2 < boardSiza)
                                if (matrix[i - 1, j + 2] == 'K')
                                    knightCount++;

                            //check for knight going right and down
                            if (i + 1 < boardSiza && j + 2 < boardSiza)
                                if (matrix[i + 1, j + 2] == 'K')
                                    knightCount++;


                        }
                        //the knight with molst possible hits we add him
                        if (knightCount > maxHits)
                        {
                            maxHits = knightCount;
                            cordsMaxHits[0] = i;
                            cordsMaxHits[1] = j;
                        }
                    }//for j                                                             
                }//for i
                //if max hits is diferet from 0 we make the cords of this K = 0 , make maxhits back to 0 and increas our counter
                if (maxHits != 0)
                {
                    matrix[cordsMaxHits[0], cordsMaxHits[1]] = '0';
                    maxHits = 0;
                    bestResult++;                   
                }
                else
                {
                    //if max hits is 0 this mean no more K can hit other K so we print and end the program
                    Console.WriteLine(bestResult);
                    return;
                }
            }//while         

        } //main   
    }
}



//Chess is the oldest game, but it is still popular these days.
// For this task we will use only one chess piece – the Knight. 
//The knight moves to the nearest square but not on the same row, column, or diagonal. 
//(This can be thought of as moving two squares horizontally, then one square vertically,
//or moving one square horizontally then two squares vertically— i.e. in an "L" pattern.) 
//The knight game is played on a board with dimensions N x N and a lot of chess knights 0 <= K <= N2. 
//You will receive a board with K for knights and '0' for empty cells. Your task is to remove a minimum of the knights,
//so there will be no knights left that can attack another knight. 
//Input
//On the first line, you will receive the N size of the board
//On the next N lines, you will receive strings with Ks and 0s.
//Output
//Print a single integer with the minimum number of knights that needs to be removed

