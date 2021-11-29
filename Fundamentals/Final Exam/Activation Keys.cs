using System;
using System.Linq;
using System.Text;

namespace Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string cmd;
            while ((cmd = Console.ReadLine()) != "Generate")
            {
                string[] comand = cmd.Split(">>>");

                switch (comand[0])
                {
                    case "Contains":
                        string substring = comand[1];
                        string tempWord = word.ToString();

                        if (tempWord.Contains(substring))
                            Console.WriteLine($"{tempWord} contains {substring}");
                        else
                            Console.WriteLine("Substring not found!");
                        break;

                    case "Flip":
                        string index = comand[1];                       
                        int startIndex = int.Parse(comand[2]);
                        int endIndex = int.Parse(comand[3]);
                        int length = endIndex - startIndex;

                        if (index == "Upper")
                        {                          
                            string temp = word.Substring(startIndex,length);
                            word = word.Remove(startIndex, length);
                            temp = temp.ToUpper();
                            word = word.Insert(startIndex, temp);
                        }                            
                        else if (index == "Lower")
                        {
                            string temp = word.Substring(startIndex, length);
                            word = word.Remove(startIndex, length);
                            temp = temp.ToLower();
                            word = word.Insert(startIndex, temp);
                        }

                        Console.WriteLine(word);
                        break;

                    case "Slice":
                        startIndex = int.Parse(comand[1]);
                        endIndex = int.Parse(comand[2]);

                        word =  word.Remove(startIndex, endIndex - startIndex);
                        Console.WriteLine(word);
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine($"Your activation key is: {word}");
        }
    }
}
