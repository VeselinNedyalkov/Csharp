using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "Finish")
            {
                switch (cmd[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(cmd[1]);
                        numbers.Add(numberToAdd);
                        break;

                    case "Remove":
                        int numberToRemove = int.Parse(cmd[1]);
                        numbers.Remove(numberToRemove);
                        break;

                    case "Replace":
                        int numberToBeReplace = int.Parse(cmd[1]);
                        int replacement = int.Parse(cmd[2]);

                        int indexOfNumber = numbers.IndexOf(numberToBeReplace);
                        numbers.Remove(numberToBeReplace);
                        numbers.Insert(indexOfNumber, replacement);
                        break;

                    case "Collapse":
                        int valueCollaps = int.Parse(cmd[1]);
                        numbers.RemoveAll(x => x < valueCollaps);
                        
                        break;
                        
                    default:
                        break;
                }//switch
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }//while
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
