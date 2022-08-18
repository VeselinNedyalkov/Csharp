using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private int openPositions;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }

        public ICollection<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get => openPositions; set => openPositions = value; }
        public char Group { get; set; }

        public int Count { get => Players.Count; }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Position) || String.IsNullOrEmpty(player.Name))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating <= 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player toRemove = Players.FirstOrDefault(x => x.Name == name);

            if (toRemove != null)
            {
                OpenPositions++;
            }
            return Players.Remove(toRemove);
        }

        public int RemovePlayerByPosition(string position)
        {
            List<Player> playersToremove = new List<Player>(Players.Where(x => x.Position == position));

            foreach (var playerRem in playersToremove)
            {
                Players.Remove(playerRem);
                OpenPositions++;
            }

            return playersToremove.Count;
        }

        public Player RetirePlayer(string name)
        {
            var player = Players.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                player.Retired = true;
            }

            return player;
        }

        public List<Player> AwardPlayers(int games)
        {
            return Players.Where(x => x.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in Players.Where(x => x.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
