using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shootin;
       

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shootin)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.shootin = shootin;
        }

        public Player()
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
        public double Stats
        {
            get
            {
                double stats = 0;
                stats = endurance + sprint + dribble + passing + shootin;
                return stats / 5;
            } 
        }
        public double Endurance
        {
            get => endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
                endurance = value;
            }
        }

        public double Sprint
        {
            get => sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }
                sprint = value;
            }
        }
        public double Dribble
        {
            get => dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
                dribble = value;
            }
        }
        public double Passing
        {
            get => passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
                passing = value;
            }
        }
        public double Shootin
        {
            get => shootin;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Shootin should be between 0 and 100.");
                }
                shootin = value;
            }
        }
    }
}

