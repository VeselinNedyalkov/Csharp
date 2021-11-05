
using System.Collections.Generic;
using System.Linq;

namespace AssociativeArraysExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputWord = Console.ReadLine();            

            Dictionary<char, int> calculatorChars = new Dictionary<char, int>();

            for (int i = 0; i < inputWord.Length; i++)
            {
                if (inputWord[i] != ' ')
                {
                    if (!calculatorChars.ContainsKey(inputWord[i]))
                    {
                        calculatorChars.Add(inputWord[i], 0);
                    }
                    calculatorChars[inputWord[i]]++;
                }
                
            }

            foreach (var word in calculatorChars)
            {
                Console.WriteLine($"{word.Key} -> {word.Value}");
            }
        }
    }
}
