using System;
using System.Text;
using System.Collections.Generic;

namespace Simple_Text_Editor
{
    internal class Program
    {
        static void Main()
        {
            int orders = int.Parse(Console.ReadLine());

            Stack<string> comadsStack = new Stack<string>();
            StringBuilder word = new StringBuilder();
            comadsStack.Push(word.ToString());

            for (int i = 0; i < orders; i++)
            {
                string[] comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (comand[0])
                {
                    case "1":
                        string someString = comand[1];
                        word.Append(someString);
                        comadsStack.Push(word.ToString());
                        break;

                    case "2":
                        int lenght = int.Parse(comand[1]);
                        word.Remove(word.Length - lenght, lenght);
                        comadsStack.Push(word.ToString());
                        break;

                    case "3":
                        int index = int.Parse(comand[1]);
                        Console.WriteLine(word[index - 1]);
                        break;

                    case "4":
                        comadsStack.Pop();
                        word = new StringBuilder();
                        word.Append(comadsStack.Peek());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
//You are given an empty text. Your task is to implement 4 commands related to manipulating the text
//•	1 someString - appends someString to the end of the text
//•	2 count - erases the last count elements from the text
//•	3 index - returns the element at position index from the text
//•	4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
