using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;


namespace Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parenthesis = Console.ReadLine();
            Stack<char> roundBracket = new Stack<char>();
            bool isOk = true;

            foreach (var item in parenthesis)
            {
                if (item == '(' || item == '[' || item == '{')
                {
                    roundBracket.Push(item);
                    continue;
                }
                if (roundBracket.Count == 0)
                {
                    isOk = false;
                    break;
                }
                    

                if (roundBracket.Peek() == '(' && item == ')')
                {
                    roundBracket.Pop();
                    continue;
                }
                else if (roundBracket.Peek() == '[' && item == ']')
                {
                    roundBracket.Pop();
                    continue;
                }
                else if (roundBracket.Peek() == '{' && item == '}')
                {
                    roundBracket.Pop();
                    continue;
                }
                else
                {
                    isOk = false;
                    break;
                }
                    
            }                                

            if (isOk)
                Console.WriteLine("YES");            
            else
                Console.WriteLine("NO");
        }
    }
}

//Given a sequence consisting of parentheses, determine whether the expression is balanced.
// A sequence of parentheses is balanced if every open parenthesis can be paired uniquely with a 
//closed parenthesis that occurs after the former. Also, the interval between them must be balanced.
// You will be given three types of parentheses: (, {, and[.
//{[()]}
//    -This is a balanced parenthesis.
//{[(])}
//    -This is not a balanced parenthesis.
//Input
//•	Each input consists of a single line, the sequence of parentheses.
//Output
//•	For each test case, print on a new line "YES" if the parentheses are balanced.
//Otherwise, print "NO".Do not print the quotes.
//Constraints
//•	1 ≤ lens ≤ 1000, where lens is the length of the sequence.
//•	Each character of the sequence will be one of {, }, (, ), [,].

