using System;

namespace _06.Triples_ofLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            char a = '`';
            char b = '`';
            char c = '`';

            for (int i = 0; i < number; i++)
            {
                b = '`';
                a++;
                for (int m = 0; m < number; m++)
                {
                    c = '`';
                    b++;
                    for (int k = 0; k < number; k++)
                    {
                        
                        c++;
                        Console.WriteLine($"{a}{b}{c}");
                    }
                }
            }
        }
    }
}
