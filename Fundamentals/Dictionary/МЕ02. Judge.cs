using System;
using System.Collections.Generic;
using System.Linq;

namespace Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] data = input.Split(" -> ");
                string username = data[0];
                string contest = data[1];
                int points = int.Parse(data[2]);

                if (!contests.ContainsKey(contest))
                    contests.Add(contest, new Dictionary<string, int>());

                if (!contests[contest].ContainsKey(username))
                    contests[contest].Add(username, points);
                else if (contests[contest][username] < points)
                    contests[contest][username] = points;

                input = Console.ReadLine();
            }


            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int cout = 1;
                foreach (var user in contest.Value.OrderByDescending(x => x.Value).ThenBy(user => user.Key))
                {
                    Console.WriteLine($"{cout++}. {user.Key} <::> {user.Value}");
                }
            }

            Console.WriteLine("Individual standings:");

            Dictionary<string, int> individualStandings = new Dictionary<string, int>();

            foreach (var user in contests)
            {
                foreach (var item in user.Value)
                {
                    if (!individualStandings.ContainsKey(item.Key))
                        individualStandings.Add(item.Key, item.Value);
                    else
                        individualStandings[item.Key] += item.Value;
                }
            }

            int count = 1;
            foreach (var user in individualStandings.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{count++}. {user.Key} -> {user.Value}");
            }
        }
    }
}
