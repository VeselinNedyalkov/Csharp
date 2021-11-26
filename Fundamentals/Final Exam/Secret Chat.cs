using System;
using System.Linq;
using System.Text;

namespace Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder word = new StringBuilder(Console.ReadLine());

            string cmd;

            while ((cmd = Console.ReadLine()) != "Reveal")
            {
                string[] data = cmd.Split(":|:");

                switch (data[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(data[1]);
                        word.Insert(index, " ");
                        Console.WriteLine(word);
                        break;

                    case "Reverse":
                        string substring = data[1];
                        string test = word.ToString();
                        if (test.Contains(substring))
                        {
                            int indexSub = test.IndexOf(substring);
                            word.Remove(indexSub, substring.Length);
                            char[] reversed = substring.Reverse().ToArray();
                            word.Append(string.Join("", reversed));
                            Console.WriteLine(word);
                        }
                        else
                            Console.WriteLine("error");
                        break;

                    case "ChangeAll":
                        substring = data[1];
                        string replacement = data[2];
                        word.Replace(substring, replacement);
                        Console.WriteLine(word);
                        break;

                    default:
                        break;
                }
                
            }

            Console.WriteLine($"You have a new text message: {word}");
        }
    }
}
