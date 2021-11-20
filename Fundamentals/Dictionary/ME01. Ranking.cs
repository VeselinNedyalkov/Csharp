using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace AssociativeArraysMoreExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contentPass = new Dictionary<string, string>();

            string inputContest = Console.ReadLine();

            while (inputContest != "end of contests")
            {
                string[] data = inputContest.Split(":");
                string contest = data[0];
                string pass = data[1];                                
                contentPass.Add(contest, pass);

                inputContest = Console.ReadLine();
            }//adding contest and passwords 

            //make new dictionary
            SortedDictionary<string, Dictionary<string,int>> candidates = new SortedDictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] data = input.Split("=>");
                string contest = data[0];
                string password = data[1];
                string userName = data[2];
                int points = int.Parse(data[3]);
                //check if contest and password are true
                if (contentPass.ContainsKey(contest))
                {
                    if (contentPass[contest] == password)
                    {
                        //check if userName is not existing add it
                        if (!candidates.ContainsKey(userName))
                            candidates.Add(userName, new Dictionary<string, int>());
                        //if contest not existing add it with points if exist check for the points
                        if (!candidates[userName].ContainsKey(contest))
                            candidates[userName].Add(contest, points);
                        else if (candidates[userName][contest] < points)
                            candidates[userName][contest] = points;


                    }
                }

                input = Console.ReadLine();
            }//adding points

            string name = string.Empty;
            int totalPoints = 0;
            //faind the best points
            foreach (var topUser in candidates)
            {
                int tempPoints = topUser.Value.Values.Sum();
                if (totalPoints < tempPoints)
                {
                    totalPoints = tempPoints;
                    name = topUser.Key.ToString();
                }                   
            }
            //print the result
            Console.WriteLine($"Best candidate is {name} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in candidates)
{
                Console.WriteLine($"{user.Key}");

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
