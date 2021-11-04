using System;
using System.Collections.Generic;
using System.Linq;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;
            const int MAXMAT = 250;

            
            while (true)
            {
                string[] inputOre = Console.ReadLine().Split();
                for (int i = 0; i < inputOre.Length; i += 2)
                {
                    int oreIncome = int.Parse(inputOre[i]);
                    string oreName = inputOre[i + 1].ToLower();

                    if (oreName == "shards" || oreName == "fragments" || oreName == "motes")                    //if is a key mat add it to the proper dictionary
                        keyMaterials[oreName] += oreIncome;

                    if (oreName != "shards" && oreName != "fragments" && oreName != "motes")                    //if is not a key map add it to junk dictionary
                    {
                        if (!junkMaterials.ContainsKey(oreName))
                        {
                            junkMaterials.Add(oreName, 0);
                        }
                        junkMaterials[oreName] += oreIncome;
                    }

                    if (keyMaterials["shards"] >= MAXMAT || keyMaterials["fragments"] >= MAXMAT || keyMaterials["motes"] >= MAXMAT) //if reach enough key mat break;
                        break;
                }
                if (keyMaterials["shards"] >= MAXMAT || keyMaterials["fragments"] >= MAXMAT || keyMaterials["motes"] >= MAXMAT)
                    break;
            }//while

            string material = "";                                                        //which of the materials is reach 250
            foreach (var item in keyMaterials)
            {
                if (item.Value >= MAXMAT)
                {
                    material = item.Key;
                }
            }

            switch (material)                                         //if material is ... then the item is .. and we call funtion LegendaryItem()                                        
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    LegendaryItem(keyMaterials,junkMaterials, material);
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    LegendaryItem(keyMaterials, junkMaterials, material);
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    LegendaryItem(keyMaterials, junkMaterials, material);
                    break;
                default:
                    break;
            }
        }//main

        static void LegendaryItem(Dictionary<string, int> keyMaterials, SortedDictionary<string, int> junkMaterials,string material)
        {
            keyMaterials[material] -= 250;                                                      //remove the price

            keyMaterials = keyMaterials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key,x => x.Value); //sort the Dictionary  keyMaterials
            foreach (var item in keyMaterials)                                                                                     //print the Dictionary  keyMaterials
            {   
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            
            foreach (var item in junkMaterials)                                                                                      //print the Dictionary junkMaterials
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
