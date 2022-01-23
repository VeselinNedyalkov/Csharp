using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] inputData = cmd.Split(";");

                switch (inputData[0])
                {
                    case "Team":
                        Team team = new Team();
                        try
                        {
                            team = new Team(inputData[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                        teams.Add(team);
                        break;

                    case "Add":
                        string teamName = inputData[1];
                        string playerName = inputData[2];
                        int endurance = int.Parse(inputData[3]);
                        int sprint = int.Parse(inputData[4]);
                        int dribble = int.Parse(inputData[5]);
                        int passing = int.Parse(inputData[6]);
                        int shooting = int.Parse(inputData[7]);

                        if (teams.Any(x => x.Name == teamName))
                        {
                            Player player = new Player();
                            try
                            {
                                player = new Player(playerName,endurance,sprint,dribble,passing,shooting);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }
                            teams.Single(x => x.Name == teamName).AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;

                    case "Remove":
                        teamName = inputData[1];
                        playerName = inputData[2];
                        if (teams.Single(x => x.Name == teamName).ContainPlayer(playerName))
                        {
                            teams.Single(x => x.Name == teamName).RemovePlayer(playerName);
                        }
                        else
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        }
                        break;

                    case "Rating":
                        teamName = inputData[1];
                        if (teams.Any(x=> x.Name == teamName))
                        {
                            double rating = teams.Single(x => x.Name == teamName).Rating;
                            Console.WriteLine($"{teamName} - {Math.Round(rating)}"); 
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;

                    default:
                        break;
                }

            }
        }

        
    }
}
