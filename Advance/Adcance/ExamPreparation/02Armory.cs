using System;

namespace Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sides = int.Parse(Console.ReadLine());
            double goldEarn = 0;
            bool IsOutOFMatrix = false;

            char[,] matrix = new char[sides, sides];
            int aRow = 0;
            int aCol = 0;
            //read the matrix and save the cords for A
            for (int row = 0; row < sides; row++)
            {
                string rowInfo = Console.ReadLine();

                for (int col = 0; col < sides; col++)
                {
                    matrix[row, col] = rowInfo[col];
                    if (rowInfo[col] == 'A')
                    {
                        aRow = row;
                        aCol = col;
                    }
                }
            }

            while (true)
            {
                string comand = Console.ReadLine();

                //check if is possile to move
                if (comand == "up")
                {
                    if (aRow - 1 < 0)
                    {
                        //if A is out ot the matrix
                        IsOutOFMatrix = true;
                        matrix[aRow, aCol] = '-';
                    }
                    else
                    {
                        
                        matrix[aRow, aCol] = '-';
                        aRow--;
                        //If a is in the matrix check for Mirror or gold
                        PassTrueMirror(sides, ref goldEarn, matrix, ref aRow, ref aCol);
                        matrix[aRow, aCol] = 'A';
                    }
                }
                else if (comand == "down")
                {
                    if (aRow + 1 >= sides)
                    {
                        //if A is out ot the matrix
                        IsOutOFMatrix = true;
                        matrix[aRow, aCol] = '-';
                    }
                    else
                    {
                        matrix[aRow, aCol] = '-';
                        aRow++;
                        //If a is in the matrix check for Mirror or gold

                        PassTrueMirror(sides, ref goldEarn, matrix, ref aRow, ref aCol);
                        matrix[aRow, aCol] = 'A';
                    }
                }
                else if (comand == "left")
                {
                    if (aCol - 1 < 0)
                    {
                        //if A is out ot the matrix
                        IsOutOFMatrix = true;
                        matrix[aRow, aCol] = '-';
                    }
                    else
                    {
                        matrix[aRow, aCol] = '-';
                        aCol--;
                        //If a is in the matrix check for Mirror or gold

                        PassTrueMirror(sides, ref goldEarn, matrix, ref aRow, ref aCol);
                        matrix[aRow, aCol] = 'A';
                    }
                }
                else if (comand == "right")
                {
                    if (aCol + 1 >= sides)
                    {
                        //if A is out ot the matrix
                        IsOutOFMatrix = true;
                        matrix[aRow, aCol] = '-';
                    }
                    else
                    {
                        matrix[aRow, aCol] = '-';
                        aCol++;
                        //If a is in the matrix check for Mirror or gold

                        PassTrueMirror(sides, ref goldEarn, matrix, ref aRow, ref aCol);
                        matrix[aRow, aCol] = 'A';
                    }
                }

                //if A is out of armory
                if (IsOutOFMatrix)
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }

                //if more than 65 gold is colected
                if (goldEarn >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }
                //for testing
                //Console.WriteLine("------------------------------------");
                //PrintMatrix(sides, matrix);
            }
            Console.WriteLine($"The king paid {goldEarn} gold coins.");
            //print end matrix
            PrintMatrix(sides, matrix);
        }

        private static void PrintMatrix(int sides, char[,] matrix)
        {
            for (int row = 0; row < sides; row++)
            {
                for (int col = 0; col < sides; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void PassTrueMirror(int sides, ref double goldEarn, char[,] matrix, ref int Arow, ref int Acol)
        {
            if (char.IsDigit(matrix[Arow, Acol]))
            {
                //if cordinates in matrix are number add it to gold
                goldEarn += char.GetNumericValue(matrix[Arow, Acol]);
                matrix[Arow, Acol] = '-';
            }
            else if (matrix[Arow, Acol] == 'M')
            {
                //if is a Mirror make mirror - then faind the next M and move A to the new psn
                matrix[Arow, Acol] = '-';
                for (int row = 0; row < sides; row++)
                {
                    for (int col = 0; col < sides; col++)
                    {
                        if (matrix[row, col] == 'M')
                        {
                            Arow = row;
                            Acol = col;
                        }
                    }
                    matrix[Arow, Acol] = '-';
                }
                matrix[Arow, Acol] = 'A';
            }
        }
    }
}
