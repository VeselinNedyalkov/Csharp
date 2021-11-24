using System;
using System.Text;

namespace FinalExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //make StringBuilder and add the decoding word to it
            StringBuilder sb = new StringBuilder();
            sb.Append(Console.ReadLine());
            string inputWord;

            while ((inputWord = Console.ReadLine()) != "Decode")
            {
                string[] data = inputWord.Split("|");

                switch (data[0])
                {
                    case "Move":
                        int numberOfLetters = int.Parse(data[1]);
                        string temp = sb.ToString().Substring(0, numberOfLetters);
                        sb.Remove(0, numberOfLetters);
                        sb.Append(temp);
                        //Console.WriteLine(sb.ToString());
                        break;

                    case "Insert":
                        int index = int.Parse(data[1]);
                        string letter = data[2];
                        sb.Insert(index, letter);
                        break;

                    case "ChangeAll":
                        string substring = data[1];
                        string replacement = data[2];
                        sb.Replace(substring, replacement);
                        break;

                    default:
                        break;
                }
            }//while
            Console.WriteLine($"The decrypted message is: {sb}");
        }
    }
}
