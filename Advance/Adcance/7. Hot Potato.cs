using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            int russianRulet = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(inputNames);

            while (names.Count > 1)
            {
                for (int i = 1; i < russianRulet; i++)
                {
                    names.Enqueue(names.Dequeue()); //we add adnd remove a name (rotate the queue)
                }
                Console.WriteLine($"Removed {names.Dequeue()}");//when we rotate all the names remove the number we need
            }
            Console.WriteLine($"Last is {names.Dequeue()}");//last name in queue
        }
    }
}


//Hot potato is a game in which children form a circle and start passing a hot potato. The counting starts with the first kid.
//Every nth toss the child left with the potato leaves the game. When a kid leaves the game, it passes the potato along. This continues until there is only one kid left.
//Create a program that simulates the game of Hot Potato.  Print every kid that is removed from the circle. In the end, print the kid that is left last.
