using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    brackets.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex = brackets.Pop();
                    Console.WriteLine(expression.Substring(startIndex,i - startIndex + 1));
                }
            }
        }
    }
}

//We are given an arithmetic 	 with brackets. Scan through the string and extract each sub-expression.
//Print the result back at the terminal.
