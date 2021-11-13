using System;
using System.Text;

namespace String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder inputWord = new StringBuilder(Console.ReadLine());
            int inMind = 0;

            for (int i = 0; i < inputWord.Length; i++)
            {
                
                if (inputWord[i] == '>')
                {
                    int bomba = (int)char.GetNumericValue(inputWord[i + 1]);
                    bomba += inMind;
                    int distance = 0;
                    for (int k = i + 1; k < inputWord.Length; k++)
                    {
                        if (inputWord[k] == '>')
                            break;
                        distance++;
                    }
                    if (bomba <= distance)
                    {
                        inputWord = inputWord.Remove(i + 1, bomba);
                        inMind = 0;
                    }
                    else
                    {
                        inputWord = inputWord.Remove(i + 1, distance);
                        inMind = bomba - distance;
                    }
                        
                }
            }
            Console.WriteLine(inputWord);
        }
    }
}
