using System;
using System.Collections.Generic;
using System.Linq;

namespace EX08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();           

            while (true)
            {
            string command = Console.ReadLine();                                
                if (command=="3:1")
                {
                    break;
                }

                string[] parts = command.Split();                               //разделяме командата на три части
                string action = parts[0];

                if (action == "merge")
                {                                                               //проверяваме дали е в обхвата на листа
                    int startIndex = int.Parse(parts[1]);
                    int endIndex = int.Parse(parts[2]);


                    if (startIndex >= names.Count || endIndex < 0)              //това се двата невалидни случая - ако startIndex < 0 и/или endIndex < 0
                    {
                        continue;
                    }
                    if (startIndex < 0)                                         //ако startIndex < 0 го сетваме на първи елемент                                    
                    {
                        startIndex = 0;
                    }
                    if (endIndex >= names.Count)                                //ако endIndex >листа -> сетваме го за последен елемент
                    {
                        endIndex = names.Count - 1;
                    }

                    string mergedString = string.Empty;                         //създаваме една временна променлива, която да съдържа обединените стрингове

                    for (int i = startIndex; i <= endIndex; i++)                //обхождаме само елементите между зададените от входа startInedex и endIndex
                    {
                        string name = names[i];                                 //взимаме текущия елемент за всяка итерация
                        mergedString += name;                                   //на всяка итерация долепяме текущия елемент в новия mergedString
                    }

                    names.RemoveRange(startIndex, endIndex - startIndex + 1);   //от startIndex премахваме елементите, които са били първоначално в списъка преди да ги конкатенираме
                    names.Insert(startIndex, mergedString);                     //на startIndex присвояваме mergedString, за да формираме новия лист
                }


                else if (action == "divide")
                {
                    int index = int.Parse(parts[1]);
                    int partitions = int.Parse(parts[2]);

                    string element = names[index];
                    names.RemoveAt(index);

                    int partitionSize = element.Length / partitions;

                    List<string> substrings = new List<string>();

                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string substring = element.Substring(i * partitionSize, partitionSize);
                        substrings.Add(substring);
                    }

                    string lastSubstring = element.Substring((partitions - 1) * partitionSize);
                    substrings.Add(lastSubstring);

                    names.InsertRange(index, substrings);
                }
            }
            Console.WriteLine(string.Join(" ", names));
        }
    }
}

//NB from Gergana
