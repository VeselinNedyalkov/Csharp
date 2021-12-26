using System;
using System.Collections.Generic;

namespace Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int numb = int.Parse(Console.ReadLine());

            for (int i = 0; i < numb; i++)
            {
                names.Add(Console.ReadLine());
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}




//Create a program, which will take a list of names and print only the unique names in the list.
