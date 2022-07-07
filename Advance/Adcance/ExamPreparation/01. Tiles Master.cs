using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam25June2022
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> areaWhite = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> areaGrey = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> locations = new Dictionary<string, int>()
            {
                { "Sink" , 0 },
                { "Oven" , 0 },
                { "Countertop" , 0 },
                { "Wall" , 0 },
                { "Floor" , 0 }
            };

            while (areaWhite.Count() != 0 && areaGrey.Count() != 0)
            {
                int white = areaWhite.Pop();
                int grey = areaGrey.Dequeue();

                int area = white + grey;

                if (white == grey)
                {
                    switch (area)
                    {
                        case 40:
                            locations["Sink"]++;
                            break;

                        case 50:
                            locations["Oven"]++;
                            break;

                        case 60:
                            locations["Countertop"]++;
                            break;

                        case 70:
                            locations["Wall"]++;
                            break;

                        default:
                            locations["Floor"]++;
                            break;
                    }
                }
                else
                {
                    white /= 2;
                    areaWhite.Push(white);
                    areaGrey.Enqueue(grey);
                }
                
            }

            if (areaWhite.Count() == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.Write("White tiles left: ");
                Console.Write(String.Join(", ", areaWhite));
                Console.WriteLine();
            }

            if (areaGrey.Count() == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.Write("Grey tiles left: ");
                Console.Write(String.Join(", ", areaGrey));
                Console.WriteLine();
            }

            foreach (var loc in locations.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                if (loc.Value != 0)
                {
                    Console.WriteLine($"{loc.Key}: {loc.Value}");
                }
            }
        }
    }
}
