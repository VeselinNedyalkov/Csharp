using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceSide = new Dictionary<string, List<string>>();

            string inpiut = Console.ReadLine();

            while (inpiut != "Lumpawaroo")
            {
                if (inpiut.Contains("|"))
                {
                    string[] theForce = inpiut.Split(" | ");
                    string side = theForce[0];
                    string name = theForce[1];

                    if (!forceSide.ContainsKey(side))
                        forceSide.Add(side, new List<string>());

                    if (!forceSide[side].Contains(name) && !forceSide.Values.Any(x => x.Contains(name)))
                        forceSide[side].Add(name);
                }
                else if(inpiut.Contains("->"))
                {
                    string[] theForce = inpiut.Split(" -> ");
                    string side = theForce[1];
                    string name = theForce[0];

                    if (!forceSide.ContainsKey(side))
                        forceSide.Add(side, new List<string>());

                    if (!forceSide.Values.Any(x => x.Contains(name)))
                    {                   
                        forceSide[side].Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                    }
                    else
                    {
                        foreach (var item in forceSide.Where(x => x.Value.Contains(name)))
                        {
                            item.Value.Remove(name);
                        }
                        forceSide[side].Add(name);
                        Console.WriteLine($"{name} joins the {side} side!");
                    }
                                      
                }
                inpiut = Console.ReadLine();
            }//while

            foreach (var sides in forceSide.OrderByDescending(x => x.Value.Count()).ThenBy(y => y.Key))
            {
                if (sides.Value.Count != 0)
                {
                    Console.WriteLine($"Side: {sides.Key}, Members: {sides.Value.Count}");
                    foreach (var jeday in sides.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {jeday}");
                    }
                }
                
            }
        }
    }
}
