using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planetToAddUnit = planets.Models.FirstOrDefault(x => x.Name == planetName);

            if (planetToAddUnit == null)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces"
                && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
           
            if (planetToAddUnit.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unitToAdd = null;
            switch (unitTypeName)
            {
                case "AnonymousImpactUnit":
                    unitToAdd = new AnonymousImpactUnit();
                    break;

                case "SpaceForces":
                    unitToAdd = new SpaceForces();
                    break;

                case "StormTroopers":
                    unitToAdd = new StormTroopers();
                    break;
                default:
                    break;
            }

            planetToAddUnit.Spend(unitToAdd.Cost);
            planetToAddUnit.AddUnit(unitToAdd);

            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planetToAddWeapon = planets.Models.FirstOrDefault(x => x.Name == planetName);

            if (planetToAddWeapon == null)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planetToAddWeapon.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "NuclearWeapon"
                && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }


            IWeapon weaponToAdd = null;

            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weaponToAdd = new BioChemicalWeapon(destructionLevel);
                    break;

                case "NuclearWeapon":
                    weaponToAdd = new NuclearWeapon(destructionLevel);
                    break;

                case "SpaceMissiles":
                    weaponToAdd = new SpaceMissiles(destructionLevel);
                    break;
                default:
                    break;
            }

            planetToAddWeapon.Spend(weaponToAdd.Price);
            planetToAddWeapon.AddWeapon(weaponToAdd);

            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.Models.Any(x => x.Name == name))
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            Planet planet = new Planet(name, budget);

            planets.AddItem(planet);

            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in planets.Models.OrderByDescending(x => x.MilitaryPower)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            bool winerFirst = false;
            bool winerSecond = false;

            IPlanet firstPlanet = planets.Models.Single(x => x.Name == planetOne);
            IPlanet secondPlanet = planets.Models.Single(x => x.Name == planetTwo);

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                if (firstPlanet.Weapons.Any(x => nameof(x) == "NuclearWeapon") &&
                    !secondPlanet.Weapons.Any(x => nameof(x) == "NuclearWeapon"))
                {
                    winerFirst = true;
                }
                else if (!firstPlanet.Weapons.Any(x => nameof(x) == "NuclearWeapon") &&
                    secondPlanet.Weapons.Any(x => nameof(x) == "NuclearWeapon"))
                {
                    winerSecond = true;
                }
                else
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winerFirst = true;
            }
            else
            {
                winerSecond = true;
            }

            IPlanet WinerPlanet = null;
            string winer = string.Empty;
            IPlanet LosesPlanet = null;
            string loser = string.Empty;

            if (winerFirst)
            {
                WinerPlanet = firstPlanet;
                winer = planetOne;
                LosesPlanet = secondPlanet;
                loser = planetTwo;
            }
            else if(winerSecond)
            {
                WinerPlanet = secondPlanet;
                winer = planetTwo;
                LosesPlanet = firstPlanet;
                loser = planetOne;
            }


            WinerPlanet.Spend(WinerPlanet.Budget / 2);
            WinerPlanet.Profit(LosesPlanet.Budget / 2);
            double forceCost = LosesPlanet.Army.Sum(x => x.Cost);
            double weaponCost = LosesPlanet.Weapons.Sum(x => x.Price);
            WinerPlanet.Profit(forceCost + weaponCost);
            planets.RemoveItem(LosesPlanet.Name);

            return String.Format(OutputMessages.WinnigTheWar, winer , loser);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.Models.FirstOrDefault(x => x.Name == planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(
                    ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            foreach (var arm in planet.Army)
            {
                arm.IncreaseEndurance();
            }

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
