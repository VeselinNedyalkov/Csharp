using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


namespace P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<Cities> cities = new List<Cities>();
            string citiesInput;

            while ((citiesInput = Console.ReadLine()) != "Sail")
            {
                //add all variables
                string[] citiesToAttack = citiesInput.Split("||",StringSplitOptions.RemoveEmptyEntries);
                string cityName = citiesToAttack[0];
                int population = int.Parse(citiesToAttack[1]);
                int gold = int.Parse(citiesToAttack[2]);
                //check is the city present in the List
                if (!IsCityContain(cityName, cities))
                    cities.Add(new Cities(cityName, population, gold));
                else
                {
                    cities.Single(x => x.Name == cityName).Population += population;
                    cities.Single(x => x.Name == cityName).Gold += gold;
                }
            }


            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] attacks = cmd.Split("=>");

                switch (attacks[0])
                {
                    case "Plunder":
                        //add the values
                        string town = attacks[1];
                        int people = int.Parse(attacks[2]);
                        int gold = int.Parse(attacks[3]);
                        var attackedCity = cities.Single(x => x.Name == town);
                        //if city population - population killd or gold < 0 we remove the city
                        if(attackedCity.Population - people <= 0 || attackedCity.Gold - gold <= 0)
                        {
                            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                            Console.WriteLine($"{town} has been wiped off the map!");
                            cities.Remove(attackedCity);                            
                        }
                        else
                        {
                            attackedCity.Population -= people;
                            attackedCity.Gold -= gold;
                            Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        }
                        break;

                    case "Prosper":
                        //add the values
                        town = attacks[1];
                        gold = int.Parse(attacks[2]);
                        attackedCity = cities.Single(x => x.Name == town);
                        //if gold is positiv number
                        if (gold >= 0)
                        {
                            attackedCity.Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {attackedCity.Gold} gold.");
                        }
                        else  //if gold is negativ number
                            Console.WriteLine("Gold added cannot be a negative number!");
                        break;
                  

                    default:
                        break;
                }
            }//while


            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            if (cities.Count > 0)  //if cities are 0 don`t print      
                foreach (var city in cities.OrderByDescending(x => x.Gold).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }

            //method to che is the current city presen in the list
            static bool IsCityContain(string name, List<Cities> cities)
            {
                bool isContain = false;
                foreach (var city in cities)
                {
                    if(city.Name == name)
                        isContain = true;
                }
                return isContain;
            }
        }

        class Cities
        {
            public string Name { get; set; }
            public int Population { get; set; }
            public int Gold { get; set; }

            public Cities(string cityName , int population , int gold)
            {
                Name = cityName;
                Population = population;
                Gold = gold;
            }
        }
    }
}
