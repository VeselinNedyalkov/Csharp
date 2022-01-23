using System;
using System.Linq;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> playerList;

        public Team(string name)
        {
            Name = name;
            playerList = new List<Player>();
        }
        public Team()
        {

        }

        public string Name 
        { 
            get => name;
            set 
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            } 
        }
        public double Rating
        {
            get
            {
                double rating = 0;
                foreach (var player in playerList)
                {
                    rating += player.Stats;
                }
                if (playerList.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return rating / playerList.Count;

                }
            } 
        }

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }

        public void RemovePlayer(string player)
        {
            playerList.Remove(playerList.Single(x => x.Name == player));
        }

        public bool ContainPlayer(string playerName)
        {
            bool isContain = false;
            if (playerList.Any(x => x.Name == playerName))
            {
                isContain = true;
            }
            return isContain;
        }
    }
}
