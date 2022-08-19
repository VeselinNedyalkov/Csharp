using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double unitEndurances = army.Sum(x => x.EnduranceLevel);
                double weponDestruction = weapons.Sum(x => x.DestructionLevel);
                double total = unitEndurances + weponDestruction;

                if (army.Any(x => x.GetType().Name == "AnonymousImpactUnit"))
                {
                    total *= 1.3;
                }

                if (weapons.Any(x => x.GetType().Name == "NuclearWeapon"))
                {
                    total *= 1.45;
                }

                return Math.Round(total, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => army;

        public IReadOnlyCollection<IWeapon> Weapons => weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            string result = army.Any() ? string.Join(", ",army.Select(x => x.GetType().Name)) : "No units";
            sb.AppendLine($"--Forces: {result}");
            string resultWeapons = weapons.Any() ? string.Join(", ", weapons.Select(x => x.GetType().Name)) : "No weapons";
            sb.AppendLine($"--Combat equipment: {resultWeapons}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            //check Budget += amount;
            double value = Budget;
            Budget = amount + value;
        }

        public void Spend(double amount)
        {
            double value = Budget - amount;

            if (value < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget = value;
        }

        public void TrainArmy()
        {
            foreach (var a in army)
            {
                a.IncreaseEndurance();
            }
        }
    }
}
