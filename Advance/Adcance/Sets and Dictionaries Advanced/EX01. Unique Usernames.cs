using System;
using System.Collections.Generic;

namespace Sets_and_Dictionaries_Advanced_EX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>(); 
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string tempUser = Console.ReadLine();
                usernames.Add(tempUser);
            }

            foreach (var user in usernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
