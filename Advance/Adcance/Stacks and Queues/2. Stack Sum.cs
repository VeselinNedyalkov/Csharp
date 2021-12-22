using System;
using System.Linq;
using System.Collections.Generic;

namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var num in input)
            {
                numbers.Push(num);
            }

            string cmd;
            while ((cmd = Console.ReadLine().ToLower()) != "end")
            {
                string[] inputCmd = cmd.Split();

                switch (inputCmd[0])
                {
                    case "add":
                        int numOne = int.Parse(inputCmd[1]);
                        int numTwo = int.Parse(inputCmd[2]);
                        numbers.Push(numOne);
                        numbers.Push(numTwo);   
                        break;

                    case "remove":
                        int lenght = int.Parse(inputCmd[1]);

                        if (numbers.Count >= lenght)
                        {
                            for (int i = 0; i < lenght; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        break;

                    default:
                        break;
                }

                
            }
            int sum = numbers.ToArray().Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}


//Create a program that:
//•	Reads an input of integer numbers and adds them to a stack
//•	Reads command until "end" is received
//•	Prints the sum of the remaining elements of the stack
//Input
//•	On the first line, you will receive an array of integers
//•	On the next lines, until the "end" command is given, you will receive commands –
//a single command and one or two numbers after the command, depending on what command you are given
//•	If the command is "add", you will always receive exactly two numbers after the command which you need to add to the stack
//•	If the command is "remove", you will always receive exactly one number after the command which represents the count of
//the numbers you need to remove from the stack. If there are not enough elements skip the command.
//Output
//•	When the command "end" is received, you need to print the sum of the remaining elements in the stack

