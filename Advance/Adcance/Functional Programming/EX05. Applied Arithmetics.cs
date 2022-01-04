using System;
using System.Linq;

namespace Applied_Arithmetics
{
    internal class Program
    {
        public delegate int Calculator (int x); //set delegate
        static void Main(string[] args)
        {
            //diferent actions with delegate
            Calculator add = x => x + 1;               
            Calculator subtract = x => x - 1;
            Calculator multiply = x => x * 2;
           

            //read numbers from console
            int[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {
                switch (cmd)
                {
                    //if add we call add delegate
                    case "add":
                        Calc(add, numbers);
                        break;
                    
                    //if multiply we call multiply delegate
                    case "multiply":
                        Calc(multiply, numbers);
                        break;

                    //if subtract we call subtract delegate
                    case "subtract":
                        Calc(subtract, numbers);
                        break;
                    
                        //print the numbers
                    case "print":
                        Console.WriteLine(string.Join(" ",numbers));
                        break;

                    default:
                        break;
                }
            }
        }


        //method that receve delegate (method)
        public static void Calc(Calculator delegat , int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = delegat(numbers[i]);
            }
        }        
    }
}




//Create a program that executes some mathematical operations on a given collection. 
//On the first line, you are given a list of numbers. On the next lines you are passed 
//different commands that you need to apply to all the numbers in the list:
//•	"add"->add 1 to each number
//•	"multiply" -> multiply each number by 2
//•	"subtract" -> subtract 1 from each number
//•	"print" -> print the collection
//•	"end" -> ends the input 
//Note: Use functions.

