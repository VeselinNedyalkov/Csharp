
using System;
using System.Text;

namespace TextMoreExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

             

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string name = "";
                int age = 0;

                int startIndexName = input.IndexOf("@") + 1;
                int endIndexName = input.IndexOf("|");
                int lenghtName = endIndexName - startIndexName;



                name = input.Substring(startIndexName, lenghtName);

                int startIndexAge = input.IndexOf("#") + 1; 
                int endIndexAge = input.IndexOf("*"); 
                int lenghtAge = endIndexAge - startIndexAge;

                age = int.Parse(input.Substring(startIndexAge, lenghtAge));

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
