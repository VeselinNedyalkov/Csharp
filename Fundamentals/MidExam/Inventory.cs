using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] cmd = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "Craft!")
            {
                switch (cmd[0])
                {
                    case "Collect":
                        if (items.Contains(cmd[1])) break;

                        items.Add(cmd[1]);                       
                        break;

                    case "Drop":
                        if (!items.Contains(cmd[1])) break;

                        items.Remove(cmd[1]);
                        break;
                        
                    case "Combine Items":
                        string[] newOldItems = cmd[1].Split(":");
                        if (!items.Contains(newOldItems[0])) break;

                        int indexOldItem = items.IndexOf(newOldItems[0]);
                        items.Insert(indexOldItem + 1, newOldItems[1]);
                        break;

                    case "Renew":
                        if (!items.Contains(cmd[1])) break;

                        indexOldItem = items.IndexOf(cmd[1]);
                        items.Add(cmd[1]);
                        items.RemoveAt(indexOldItem);
                        break;

                    default:
                        break;
                }

                cmd = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            }//while

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
