using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {        
            string paternDamage = @"[-]?[0-9]*[.]?[0-9]+";
            string paternName = @"[^0-9+\-,\/*.]";
            string paternSum = @"[\*\/]";
            int demonhealth = 0;
            double damage = 0;

            string[] demonsInput = Console.ReadLine().Split(new char[] { ',', ' ' },StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x).ToArray();

            for (int i = 0; i < demonsInput.Length; i++)
            {
                string demon = demonsInput[i];
                demonhealth = 0;
                //take all the letters
                MatchCollection demonName = Regex.Matches(demon, paternName);
                //calculate the health
                foreach (Match health in demonName)
                {
                    demonhealth += char.Parse(health.Value);
                }


                //take all the numbers and calculate the damage
                MatchCollection demonDamge = Regex.Matches(demon, paternDamage);                              
                damage = 0;
                foreach (Match damageDamon in demonDamge)
                {
                    damage += double.Parse(damageDamon.Value);
                }

                //take the simvols * /
                MatchCollection multyOrDiv = Regex.Matches(demon, paternSum);              

                foreach (Match operation in multyOrDiv)
                {
                    if (operation.Value == "*")
                        damage *= 2;
                    if (operation.Value == "/")
                        damage /= 2;
                }

                Console.WriteLine($"{demon} - {demonhealth} health, {damage:f2} damage");

              
            }//for

         
        }
    }
}
