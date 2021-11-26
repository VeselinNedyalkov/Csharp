using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plants> plantsList = new List<Plants>();

            int num = int.Parse(Console.ReadLine());
            //fil the list with the rarity and plant
            for (int i = 0; i < num; i++)
            {
                string[] inputData = Console.ReadLine().Split("<->");
                string plant = inputData[0];
                int rarity = int.Parse(inputData[1]);
                if (!IsListContain(plant, plantsList))
                    plantsList.Add(new Plants(plant, rarity, 0));
                else
                    plantsList.Single(x => x.Name == plant).Rarity = rarity;
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "Exhibition")
            {
                string[] data = cmd.Split(": ");

                switch (data[0])
                {
                    case "Rate":
                        string[] rate = data[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        string plant = rate[0];
                        double rating = double.Parse(rate[1]);
                        //use function to check is plant present in the list
                        if (IsListContain(plant , plantsList))
                        {
                            //if rating is 0 just add the rating
                            if(plantsList.Single(x => x.Name == plant).Rating == 0)
                            {
                                plantsList.Single(x => x.Name == plant).Rating = rating;
                            }
                            else //calculate the avrg rating
                            {
                                double tempRating = plantsList.Single(x => x.Name == plant).Rating;
                                plantsList.Single(x => x.Name == plant).Rating = (tempRating + rating) / 2;
                            }
                           
                        }
                        else
                            Console.WriteLine("error");
                        break;

                    case "Update":
                        rate = data[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        plant = rate[0];
                        int newrarity = int.Parse(rate[1]);

                        if (IsListContain(plant, plantsList))
                        {
                            plantsList.Single(x => x.Name == plant).Rarity = newrarity;
                        }
                        else
                            Console.WriteLine("error");
                        break;

                    case "Reset":
                        rate = data[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                        plant = rate[0];

                        if (IsListContain(plant, plantsList))
                        {
                            plantsList.Single(x => x.Name == plant).Rating = 0;
                        }
                        else
                            Console.WriteLine("error");
                        break;

                    default:
                        break;
                }

            }//while

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plantsList.OrderByDescending(x => x.Rarity).ThenByDescending(x => x.Rating))
            {
                Console.WriteLine($"- {plant.Name}; Rarity: {plant.Rarity}; Rating: {plant.Rating:f2}");
            }


            //function to check is plant present in the List
            static bool IsListContain(string plant, List<Plants> plantsList)
            {
                bool isContain = false;
                foreach (var item in plantsList)
                {
                    if(item.Name == plant)
                        isContain = true;
                }
                return isContain;
            }
        }
    }//class Program

    class Plants
    {
        // name , rarity , average_rating

        public string Name { get; set; }

        public int Rarity { get; set; }

        public double Rating { get; set; }

        public Plants(string name, int rarity,double rating)
        {
            Name = name;
            Rarity = rarity;    
            Rating = rating;
        }
    }
}
