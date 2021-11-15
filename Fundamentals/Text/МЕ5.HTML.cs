using System;
using System.Collections.Generic;

namespace HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> storage = new List<string>();
            string input = Console.ReadLine();  

            while (input != "end of comments")
            {
                storage.Add(input);
                input = Console.ReadLine();
            }

            for (int i = 0; i < storage.Count; i++)
            {
                if (i == 0 )                
                    Console.WriteLine($"<h1>\n    {storage[i]}\n</h1>");

                if(i == 1)
                    Console.WriteLine($"<article>\n    {storage[i]}\n</article>" );

                if(i != 0 && i != 1)
                    Console.WriteLine($"<div>\n    {storage[i]}\n</div>");
            }
        }
    }
}
