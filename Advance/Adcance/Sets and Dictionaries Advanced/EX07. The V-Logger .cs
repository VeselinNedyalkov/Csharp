using System;
using System.Linq;
using System.Collections.Generic;

namespace The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary <string,HashSet<string>>> followers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            

            string comand;
            while ((comand = Console.ReadLine()) != "Statistics")
            {
                string[] data = comand.Split(" ");

                if (data[1] == "joined")
                {
                    string vloggername = data[0];

                    if (!followers.ContainsKey(vloggername))
                    {
                        followers.Add(vloggername, new Dictionary<string, HashSet<string>>());
                        followers[vloggername].Add("followers", new HashSet<string>());
                        followers[vloggername].Add("following", new HashSet<string>());
                           
                    }
                }
                else if (data[1] == "followed")
                {
                    string followerName = data[0];
                    string vloggerName = data[2];

                    if (followers.ContainsKey(followerName) && followers.ContainsKey(vloggerName))
                    {
                        if (followerName != vloggerName)
                        {

                            followers[followerName]["following"].Add(vloggerName);
                            followers[vloggerName]["followers"].Add(followerName);
                        }
                    }
                }
            }//while

            Console.WriteLine($"The V-Logger has a total of {followers.Count()} vloggers in its logs.");
            int count = 1;
            foreach (var item in followers.OrderByDescending(x => x.Value["followers"].Count()).ThenBy(x => x.Value["following"].Count()))
            {
                Console.WriteLine($"{count++}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                if (count == 2)
                {
                    foreach (var name in item.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
            }

            

        }
    }
}
