using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialLoot = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "Yohoho!")
            {
                switch (cmd[0])
                {
                    case "Loot":                       
                            for (int i = 1; i < cmd.Length; i++)
                            {
                                if (!initialLoot.Contains(cmd[i]))
                                    initialLoot.Insert(0, cmd[i]);
                            }
                        break;

                    case "Drop":
                        int indexDrop = int.Parse(cmd[1]);
                        if (indexDrop > initialLoot.Count - 1 || indexDrop < 0) break;

                        string temp = initialLoot[indexDrop];
                        initialLoot.RemoveAt(indexDrop);
                        initialLoot.Add(temp);
                        break;

                    case "Steal":                       
                        int indexCount = int.Parse(cmd[1]);
                        int endIndex = initialLoot.Count - 1 - indexCount;
                        int k = 0;
                        List<string> stealItems = new List<string>();
                        if (endIndex >= 0)
                        {
                            for (int i = initialLoot.Count - 1 ; i > endIndex; i--)
                            {
                                stealItems.Insert(0,initialLoot[i]);
                                initialLoot.RemoveAt(i);
                                k++;
                            }    
                        }
                        else
                        {
                            for (int i = initialLoot.Count - 1; i >= 0; i--)
                            {

                                stealItems.Insert(0, initialLoot[i]);
                                initialLoot.RemoveAt(i);
                                k++;
                            }
                        }
                        Console.WriteLine(string.Join(", ", stealItems));
                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split();
            }//while

            double averageGain = 0;
            
            if (initialLoot.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                foreach (var item in initialLoot)
                {
                    averageGain += item.Length;
                }
                averageGain /= initialLoot.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
        }
    }
}
