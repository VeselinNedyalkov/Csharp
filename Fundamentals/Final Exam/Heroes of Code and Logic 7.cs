using System;
using System.Linq;
using System.Collections.Generic;

namespace Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            const int MAX_HP = 100;
            const int MAX_MP = 200;

            int numberHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberHeroes; i++)
            {
                string[] heroData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = heroData[0];
                int hp = int.Parse(heroData[1]);
                int mp = int.Parse(heroData[2]);

                heroes.Add(new Hero(name, hp, mp));
            }

            string cmd;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] action = cmd.Split(" - ");

                switch (action[0])
                {
                    case "CastSpell":
                        string heroName = action[1];
                        int manaNeeded = int.Parse(action[2]);
                        string spelName = action[3];

                        if (heroes.Single(x => x.Name == heroName).MP >= manaNeeded)
                        {
                            heroes.Single(x => x.Name == heroName).MP -= manaNeeded;
                            int manaLeft = heroes.Single(x => x.Name == heroName).MP;
                            Console.WriteLine($"{heroName} has successfully cast {spelName} and now has {manaLeft} MP!");
                        }
                        else
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spelName}!");
                        break;

                    case "TakeDamage":
                        heroName = action[1];
                        int damage = int.Parse(action[2]);
                        string attacker = action[3];

                        if (heroes.Single(x => x.Name == heroName).HP > damage)
                        {
                            heroes.Single(x => x.Name == heroName).HP -= damage;
                            int currentHP = heroes.Single(x => x.Name == heroName).HP;
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currentHP} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroes.Remove(heroes.Single(x => x.Name == heroName));
                        }
                        break;

                    case "Recharge":
                        heroName = action[1];
                        int amount = int.Parse(action[2]);
                        int amountRecovered = 0;
                        if ((heroes.Single(x => x.Name == heroName).MP + amount) > MAX_MP)
                        {
                            amountRecovered = MAX_MP - heroes.Single(x => x.Name == heroName).MP;
                            heroes.Single(x => x.Name == heroName).MP = MAX_MP;
                        }
                        else
                        {
                            heroes.Single(x => x.Name == heroName).MP += amount;
                            amountRecovered = amount;
                        }
                        Console.WriteLine($"{heroName} recharged for {amountRecovered} MP!");
                        break;

                    case "Heal":
                        heroName = action[1];
                        amount = int.Parse(action[2]);
                        amountRecovered = 0;
                        if ((heroes.Single(x => x.Name == heroName).HP + amount) > MAX_HP)
                        {
                            amountRecovered = MAX_HP - heroes.Single(x => x.Name == heroName).HP;
                            heroes.Single(x => x.Name == heroName).HP = MAX_HP;                            
                        }
                        else
                        {
                            heroes.Single(x => x.Name == heroName).HP += amount;
                            amountRecovered = amount;
                        }
                        Console.WriteLine($"{heroName} healed for {amountRecovered} HP!");
                        break;

                    default:
                        break;
                }
            }//while

            foreach (var hero in heroes.OrderByDescending(x => x.HP).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{hero.Name}\n  HP: {hero.HP}\n  MP: {hero.MP}");
            }
        }
    }

    class Hero
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

        public Hero(string name, int hitPoints, int manaPoints)
        {
            Name = name;
            HP = hitPoints;
            MP = manaPoints;
        }
    }
}
