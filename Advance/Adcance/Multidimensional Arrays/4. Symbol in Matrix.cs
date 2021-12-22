using System;
using System.ComponentModel;
using System.Linq;

namespace Symbol_in_Matrix
{
    internal class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            char[,] matrix = new char[num, num]; 

            for (int row = 0; row < num; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < num; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            char isPresent = char.Parse(Console.ReadLine());
            bool presen = false;

            for (int row = 0; row < num; row++)
            {
                for (int col = 0; col < num; col++)
                {
                    if(isPresent == matrix[row, col])
                    {
                        presen = true;
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                        
                }
            }

            if (!presen)
                Console.WriteLine($"{isPresent} does not occur in the matrix ");
        }
    }
}


//Write a program that reads N, number representing rows and cols of a matrix. 
//On the next N lines, you will receive rows of the matrix. 
//Each row consists of ASCII characters. After that, you will receive a symbol. 
//Find the first occurrence of that symbol in the matrix and print its position in the format: 
//"({row}, {col})".If there is no such symbol print an error message 
//"{symbol} does not occur in the matrix "

