using System;
using System.Text;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            

            StringBuilder answer = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {              
                    answer.Append((char)(input[i] + 3));                              
            }
            Console.WriteLine(answer);
        }

    }
}
