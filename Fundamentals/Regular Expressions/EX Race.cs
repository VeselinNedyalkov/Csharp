using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ImputNames = Console.ReadLine().Split(", ").ToList();
            string paternName = @"(?<name>[A-Za-z]+)";
            string paternNum = @"(?<num>[0-9]+)";
            Dictionary<string,int> runers = new Dictionary<string,int>();

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection matchName = Regex.Matches(input, paternName);
                MatchCollection matchNum = Regex.Matches(input,paternNum);

                string name = string.Join("", matchName);
                string totalRunKm = string.Join("", matchNum);
                int sumKm = 0;
                for (int i = 0; i < totalRunKm.Length; i++)
                {
                    sumKm += (int)char.GetNumericValue(totalRunKm[i]);
                }

                if (ImputNames.Contains(name))
                {
                    if (!runers.ContainsKey(name))
                    {
                        runers.Add(name, sumKm);
                    }
                    else
                    {
                        runers[name] += sumKm;
                    }
                }

                input = Console.ReadLine();
            }

            runers = runers.OrderByDescending(x => x.Value).ToDictionary(x => x.Key,y => y.Value);
            int count = 0;
            string[] winers = new string[3];
            foreach (var runer in runers)
            {
                winers[count] = runer.Key;
                count++;
                if (count == 3)
                    break;
            }

            Console.WriteLine($"1st place: {winers[0]}\n2nd place: {winers[1]}\n3rd place: {winers[2]}");
            
        }
    }
}
