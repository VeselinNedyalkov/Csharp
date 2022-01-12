using System;
using System.Collections.Generic;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            int numberCloats = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberCloats; i++)
            {
                string[] dresses = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = dresses[0];
                string[] cloats = dresses[1].Split(",");

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                if (clothes.ContainsKey(color))
                {
                    for (int j = 0; j < cloats.Length; j++)
                    {
                        if (!clothes[color].ContainsKey(cloats[j]))
                        {
                            clothes[color].Add(cloats[j], 1);
                        }
                        else
                        {
                            clothes[color][cloats[j]]++;
                        }
                    }
                }
                
                
            }

            string[] collorDress = Console.ReadLine().Split();
            string colorSearch = collorDress[0];
            string cothes = collorDress[1];

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes: ");

                foreach (var item in color.Value)
                {
                    if (item.Key == cothes && colorSearch == color.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                    
                }
            }

        }

       
    }
}
