
using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;

            for (int i = userName.Length -1; i >= 0; i--)
            {
                password += userName[i];
            }
            int count = 0;
            string input = Console.ReadLine();

            while (input != password)
            {
                count++;
                if (count > 3)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                
                input = Console.ReadLine();
            }

            if (input == password)       
            {
                Console.WriteLine($"User {userName} logged in.");
            }
        }
    }
}
