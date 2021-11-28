using System;
using System.Text;

namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder inputWord = new StringBuilder(Console.ReadLine());

            string cmd;
            while ((cmd = Console.ReadLine()) != "Done")
            {
                string[] data = cmd.Split(" ");

                switch (data[0])
                {
                    case "TakeOdd":
                        string word = inputWord.ToString(); 
                        inputWord.Clear();
                        for (int i = 1; i < word.Length; i += 2)                        
                            inputWord.Append(word[i]);
                        Console.WriteLine(inputWord);
                        break;

                    case "Cut":
                        int index = int.Parse(data[1]);
                        int lenght = int.Parse(data[2]);

                        inputWord.Remove(index, lenght);
                        Console.WriteLine(inputWord);
                        break;

                    case "Substitute":
                        string substring = data[1];
                        string substitute = data[2];

                        word = inputWord.ToString();
                        if (word.Contains(substring))
                        {
                            inputWord.Replace(substring, substitute);
                            Console.WriteLine(inputWord);
                        }                           
                        else
                            Console.WriteLine("Nothing to replace!");
                        break;

                    default:
                        break;
                }
            }//while
            Console.WriteLine($"Your password is: {inputWord}");
        }
    }
}
