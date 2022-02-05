
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //all swords and coast for them
            Dictionary<int, string> swords = new Dictionary<int, string>
            {
                {70 , "Gladius" },
                {80, "Shamshir" },
                {90, "Katana" },
                {110, "Sabre" },
                {150, "Broadsword" }
            };

            Dictionary<string, int> swordsMade = new Dictionary<string, int>();       
            
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split()
                .Select(int.Parse).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split()
                .Select(int.Parse).ToArray());

            int countNumberSwords = 0;
            
            while(steel.Count != 0)
            {
                if (carbon.Count == 0)
                {
                    break;
                }
                //remove the steal and carbon and combine them
                int steelQantity = steel.Dequeue();
                int carboQuantity = carbon.Pop();
                int combineSteelCarbon = steelQantity + carboQuantity;
                //if you can buy  a sword add it to dictionary
                if (swords.ContainsKey(combineSteelCarbon))
                {
                    countNumberSwords++;
                    string swordName = swords[combineSteelCarbon];
                    if (!swordsMade.ContainsKey(swordName))
                    {
                        swordsMade.Add(swordName, 1);
                    }
                    else
                    swordsMade[swordName]++;

                }
                else
                {
                    //if we don`t have enought resorces +5 to carbon and add it back toStack
                    carbon.Push(carboQuantity + 5);
                }
               
            }
           
            

            if (countNumberSwords == 0)
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {countNumberSwords} swords.");
            }

            if (steel.Any(x => x != 0))
            {
         
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Any(x => x != 0))
            {
                carbon.Reverse();
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            foreach (var sword in swordsMade.OrderBy(x => x.Key))
            {
                if (sword.Value != 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}

