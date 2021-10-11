using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            if (b < a)
            {
                char temp = b;
                b = a;
                a = temp;
            }


            Console.WriteLine(CompareCharts(a,b));
        }

        static string CompareCharts(char a,char b)
        {
            string result = string.Empty;
            for (int i = a + 1; i < b; i++)
            {
                result += (char)i + " ";
            }

            return result;
        }
    }
}
