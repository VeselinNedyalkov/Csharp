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
            //List that contains the names of the runers
            List<string> ImputNames = Console.ReadLine().Split(", ").ToList();
            string paternName = @"(?<name>[A-Za-z]+)";
            string paternNum = @"(?<num>[0-9]+)";
            //dictionary to sort the winers
            Dictionary<string,int> runers = new Dictionary<string,int>();

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                //take coleection of letters from the input
                MatchCollection matchName = Regex.Matches(input, paternName);
                //take coleection of numbers from the input
                MatchCollection matchNum = Regex.Matches(input,paternNum);

                //join the collections
                string name = string.Join("", matchName);
                string totalRunKm = string.Join("", matchNum);
                int sumKm = 0;
                //sum all the km from the collection totalRunKm
                for (int i = 0; i < totalRunKm.Length; i++)
                {
                    sumKm += (int)char.GetNumericValue(totalRunKm[i]);
                }
                //check if the name exist in the 1st list with participant
                if (ImputNames.Contains(name))
                {
                    //check if the name exist in the dictionary 
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
            
            //take the 1st 3 winers
            int count = 0;
            string[] winers = new string[3];
            foreach (var runer in runers.OrderByDescending(x => x.Value))
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
