using System;
using System.Collections.Generic;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                if (cmd == "Paid")
                {
                    Console.WriteLine(string.Join("\n", names));
                    names.Clear();
                }
                else
                {
                    names.Enqueue(cmd);
                }
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}


//Reads an input consisting of a name and adds it to a queue until "End" is received. 
//    If you receive "Paid", print every customer name and empty the queue, otherwise, we receive
//    a client and we have to add him to the queue. When we receive "End" we have to print the count
//    of the remaining people in the queue in the format: "{count} people remaining.".
