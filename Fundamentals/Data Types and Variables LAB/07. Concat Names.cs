using System;

namespace _07._Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string lastName = Console.ReadLine();
            var simvol = Console.ReadLine();

            Console.WriteLine($"{name}{simvol}{lastName}");
        }
       
    }
}
