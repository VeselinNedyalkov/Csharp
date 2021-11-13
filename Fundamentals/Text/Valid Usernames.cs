using System;

namespace StringsАndTextProcessingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputUserName = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var validUserName in inputUserName)
            {
                bool contains = false;
                if (validUserName.Length >= 3 && validUserName.Length <= 16)
                {
                    contains = true;
                    foreach (char contain in validUserName)
                    {
                        if (!char.IsLetter(contain) && !char.IsDigit(contain) && contain != '-' && contain != '_')
                        {
                            contains = false;
                            break;
                        }                            
                    }
                }
                if (contains)
                    Console.WriteLine(validUserName);
            }
        }
    }
}
