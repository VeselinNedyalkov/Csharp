using System;
using System.Text;

namespace Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StringBuilder input = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < input.Length - 1; i++)
            {
                int calc = 0;
                for (int k = i + 1 ; k < input.Length; k++)
                {                    
                    if (input[i] == input[k])
                        calc++;
                    else if (calc == 0)
                        break;
                    else
                    {
                        input = input.Remove(i, calc);
                        break;
                    }
                    if (k == input.Length - 1 && calc > 0)
                    {
                        input = input.Remove(i, calc);
                        break;
                    }
                }
            }
            Console.WriteLine(input);
        }
    }
}
