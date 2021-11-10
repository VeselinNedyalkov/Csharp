using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] data = input.Split(" -> ");
                    string player = data[0];
                    string position = data[1];
                    int skill = int.Parse(data[2]);

                    if (!players.ContainsKey(player))
                        players.Add(player, new Dictionary<string, int>());

                    if (!players[player].ContainsKey(position))
                        players[player].Add(position, skill);

                    if (players[player][position] < skill)
                        players[player][position] = skill;
                }
                else
                {
                    string[] data = input.Split(" vs ");
                    string firstPlayer = data[0];
                    string secondPLayer = data[1];

                    if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPLayer))
                    {
                        if (!players.ContainsKey(firstPlayer) || !players.ContainsKey(secondPLayer))
                            break;

                        foreach (var playerOne in players[firstPlayer])
                        {
                            foreach (var playerTwo in players[secondPLayer])
                            {
                                if (playerOne.Key == playerTwo.Key)
                                {
                                    if(playerOne.Value > playerTwo.Value)
                                    {
                                        players.Remove(secondPLayer);
                                        break;
                                    }
                                    else if (playerOne.Value < playerTwo.Value)
                                    {
                                        players.Remove(firstPlayer);
                                        break;
                                    }
                                }
                            }
                            if (!players.ContainsKey(firstPlayer) || !players.ContainsKey(secondPLayer))
                                break;
                        }
                    }
                }

                input = Console.ReadLine();
            }//while

            foreach (var player in players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
