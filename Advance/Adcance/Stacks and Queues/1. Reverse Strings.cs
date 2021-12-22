using System;
using System.Collections.Generic;

namespace LabStacks_and_Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> reverse = new Stack<char>();
            string inputWord = Console.ReadLine();

            for (int i = 0; i < inputWord.Length; i++)
            {
                reverse.Push(inputWord[i]);
            }

            while (reverse.Count != 0)
            {
                Console.Write(reverse.Pop());
            }
                
            
        }
    }
}


//Create a program that:
//•	Reads an input string
//•	Reverses it using a Stack< T >
//•	Prints the result back at the terminal
