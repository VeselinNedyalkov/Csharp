using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyUsers = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(" -> ");

            while (input[0] != "End")
            {
                string company = input[0];
                string employeeId = input[1];

                if (!companyUsers.ContainsKey(company))
                {
                    companyUsers.Add(company, new List<string>() { employeeId });
                }
                else
                {
                    if (!companyUsers[company].Contains(employeeId))
                    {
                        companyUsers[company].Add(employeeId);
                    }
                }
                input = Console.ReadLine().Split(" -> ");
            }//while

            

            foreach (var companyName in companyUsers.OrderBy(x => x.Key))
            {
                Console.WriteLine(companyName.Key);

                foreach (var id in companyName.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
