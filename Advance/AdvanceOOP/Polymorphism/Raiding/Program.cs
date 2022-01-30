using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBaseHero> heroes = new List<IBaseHero>();
            int numHeroes = int.Parse(Console.ReadLine());
            int counter = 0;

            while (numHeroes != counter)            
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

               

                switch (heroType)
                {
                    case "Druid":
                        Druid druid = new Druid(name);
                        heroes.Add(druid);
                        counter++;
                        break;

                    case "Paladin":
                        Paladin paladin = new Paladin(name);
                        heroes.Add(paladin);
                        counter++;
                        break;

                    case "Rogue":
                        Rogue rogue = new Rogue(name);
                        heroes.Add(rogue);
                        counter++;
                        break;

                    case "Warrior":
                        Warrior warrior = new Warrior(name);
                        heroes.Add(warrior);
                        counter++;
                        break;

                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            long bossPower = long.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                bossPower -= hero.Power;
                Console.WriteLine(hero.CastAbility()); 
            }

            if (bossPower <= 0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
