using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();      //take the numbers for decoding
            List<string> codedWord = new List<string>(2);                                   //create List to store the words
            string input = Console.ReadLine();                                              //input the words
            

            while (input != "find")                                                     //till find command come
            {               
                codedWord.Add(input);                                                       //add to the list
                
                input = Console.ReadLine();
            }
            
            StringBuilder uncoding = new StringBuilder();                               //create SB
            string[] lastWord = new string[4];                                          //create array for the last word

            for (int i = 0; i < codedWord.Count; i++)                                   //for cicle for the LIST
            {
                string workingWord = codedWord[i];                                      //take the word with index i
                int k = 0;                                                              //counter for the numbers in numbers array
                int j = 0;                                                              //counter for the word in workingWord
                do                                                                      //do cicle
                {
                    int number = numbers[k];                                            //number = the number with index k from number array
                    char temp = workingWord[j];                                           //temp = char from the word with index j
                    char apeend = (char)(temp - number);                               //remuve the number from the char to uncode the new char
                    uncoding.Append(apeend.ToString());                                 //add the char to the SB
                    j++;                                                    //increase j by one
                    k++;                                                    // increase k by one
                    if (k == numbers.Length)                                //if k is equal to the lenght of the array make it again 0
                    {
                        k = 0;
                    }
                }
                while (j != workingWord.Length);                            //when j is equal to the lenght of the workingWord break;

                uncoding.Replace('&', ' ').Replace('>',' ').Replace('<', ' ');      //replace all simvols with space

                string tempOne = uncoding.ToString().Trim();                        //make the SB to string and trim it to remove space at the end
                lastWord = tempOne.Split(" ");                                      //split it to take the resurse name and cordinates

                Console.WriteLine($"Found {lastWord[1]} at {lastWord[lastWord.Length- 1]}");        //print
                uncoding.Clear();                                                     //SB clear for the next input          
            }
           
        }
    }
}
