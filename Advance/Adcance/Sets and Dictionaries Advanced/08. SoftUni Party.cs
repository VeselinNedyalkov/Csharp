using System;
using System.Collections.Generic;
using System.Drawing;

namespace SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "PARTY")
            {
                if (IsVip(cmd))
                    vip.Add(cmd);
                else
                    regular.Add(cmd);
            }

            while ((cmd = Console.ReadLine()) != "END")
            {
                if (IsVip(cmd))
                    vip.Remove(cmd);
                else
                    regular.Remove(cmd);
            }

            Console.WriteLine(vip.Count + regular.Count);
            foreach (var names in vip)
            {
                Console.WriteLine(names);
            }

            foreach (var names in regular)
            {
                Console.WriteLine(names);
            }
        }

        private static bool IsVip(string cmd)
        {
            int num = 0;

            return int.TryParse(cmd.Substring(0, 1), out num);
        }
    }
}







//There is a party in SoftUni.Many guests are invited and there are two types of them: VIP and Regular. 
//When a guest comes, check if he/she exists in any of the two reservation lists.
//All reservation numbers will be with the length of 8 chars.
//All VIP numbers start with a digit.
//First, you will be receiving the reservation numbers of the guests. You can also receive 2 possible commands:
//•	"PARTY" – After this command, you will begin receiving the reservation numbers of the people, who came to the party.
//•	"END" – The party is over and you have to stop the program and print the appropriate output.
//In the end, print the count of the guests who didn't come to the party, and afterward, print their reservation numbers. the VIP guests must be first.

