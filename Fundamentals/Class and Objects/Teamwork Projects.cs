using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teamList = new List<Team>();
            int registerTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < registerTeams; i++)
            {
                string[] inputTeam = Console.ReadLine().Split("-");
                string founder = inputTeam[0];
                string nameOfTeam = inputTeam[1];
                
                if (teamList.Any(name => name.NameOfTeam == nameOfTeam))
                {
                    Console.WriteLine($"Team {nameOfTeam} was already created!");
                }
                else if (teamList.Any(creator => creator.Founder == founder))
                {
                    Console.WriteLine($"{founder} cannot create another team!");
                }
                else
                {
                    Team teamClass = new Team(founder, nameOfTeam, new List<string>());
                    teamList.Add(teamClass);
                    Console.WriteLine($"Team {nameOfTeam} has been created by {founder}!");
                }
            }//for

            string[] assignment = Console.ReadLine().Split("->");

            while (assignment[0] != "end of assignment")
            {
                string member = assignment[0];
                string team = assignment[1];

                if (!teamList.Any(teamName => teamName.NameOfTeam == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teamList.Any(name => name.TeamMates.Contains(member)) || teamList.Any(name => name.Founder == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }
                else
                {
                    var currentTeam = teamList.First(x => x.NameOfTeam == team);
                    currentTeam.TeamMates.Add(member);

                }
                
                assignment = Console.ReadLine().Split("->");
            }
            var disband = teamList.Where(members => members.TeamMates.Count() == 0);
            var finalTeam = teamList.Where(members => members.TeamMates.Count() > 0);

            foreach (Team item in teamList.OrderByDescending(item => item.NameOfTeam).ThenBy(item => item.Founder))
            {
                Console.WriteLine($"{item.NameOfTeam}");
                Console.WriteLine($"-{item.Founder}");
                foreach (string members in item.TeamMates.OrderBy(members => members))
                {
                    Console.WriteLine($"--{members}");
                }
            }
            Console.WriteLine("Teams to disband:");

            if (disband.Count() != 0)
            {
                foreach (Team dis in disband)
                {
                    Console.WriteLine(dis);
                }
            }
          
        }
    }//class program

    class Team
    {
        public Team(string founder, string nameOfTeam, List<string> teamMates)
        {
            Founder = founder;
            NameOfTeam = nameOfTeam;
            TeamMates = teamMates;
        }

        //public Team(List<string> teamMates)
        //{
        //    TeamMates = teamMates;
        //}

        public string Founder { get; set; }
        public string NameOfTeam { get; set; }
        public List<string> TeamMates { get; set; }

        public override string ToString()
        {
            return $"Team {NameOfTeam} has been created by {Founder}!";
        }
    }
}
