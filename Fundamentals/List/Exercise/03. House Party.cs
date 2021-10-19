using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberComands = int.Parse(Console.ReadLine());
            List<string> peopleOnParty = new List<string>(numberComands);

            for (int i = 0; i < numberComands; i++)
            {
                string[] comands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (comands[2])
                {
                    case "going!":
                        if (peopleOnParty.Contains(comands[0]))
{
                            Console.WriteLine($"{comands[0]} is already in the list!");
                        }
                        else
                        {
                            peopleOnParty.Add(comands[0]);
                        }
                            break;
                    case "not":
                        if (peopleOnParty.Contains(comands[0]))
                        {
                            peopleOnParty.Remove(comands[0]);
                        }
                        else
                        {
                            Console.WriteLine($"{comands[0]} is not in the list!");
                        }
                        break;
                    default:
                        break;
                }
            }//for
            Console.WriteLine(string.Join("\n",peopleOnParty));
        }
    }
}
