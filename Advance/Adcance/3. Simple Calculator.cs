using System;
using System.Linq;
using System.Collections.Generic;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            Stack<string> calculator = new Stack<string>(input);
                               

            while (calculator.Count > 1)
            {
                int numOne = int.Parse(calculator.Pop());
                string oper = calculator.Pop();
                int numTwo = int.Parse(calculator.Pop());

                if (oper == "+")
                    calculator.Push((numOne + numTwo).ToString());
                else
                    calculator.Push((numOne - numTwo).ToString());

            }

            Console.WriteLine(calculator.Pop());
        }
    }
}


//Create a simple calculator that can evaluate simple expressions with only addition and subtraction. 
//There will not be any parentheses.Solve the problem using a Stack.
