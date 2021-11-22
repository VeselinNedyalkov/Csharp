using System;
using System.Collections.Generic;




namespace Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //make a dictionary to store the infor
            Dictionary<string, SortedDictionary<string, double[]>> dragons = new Dictionary<string, SortedDictionary<string, double[]>>();

            int numberOfDragons = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] dragonData = Console.ReadLine().Split();
                string type = dragonData[0];
                string name = dragonData[1];
                double damage = 0;
                double health = 0;
                double armor = 0;
                //if some damage armor of health is null add it default  value
                if (dragonData[2] == "null")               
                    damage = 45;               
                else
                    damage = double.Parse(dragonData[2]);

                if (dragonData[3] == "null")
                    health = 250;
                else
                    health = double.Parse(dragonData[3]);

                if (dragonData[4] == "null")
                    armor = 10;
                else
                    armor = double.Parse(dragonData[4]);
                //add the data to the dictionary
                if (!dragons.ContainsKey(type))
                    dragons.Add(type, new SortedDictionary<string, double[]>());
                if (dragons.ContainsKey(type) && !dragons[type].ContainsKey(name))
                    dragons[type].Add(name,new double[3]);
                if (dragons.ContainsKey(type) && dragons[type].ContainsKey(name))
                {
                    dragons[type][name][0] = damage;
                    dragons[type][name][1] = health;
                    dragons[type][name][2] = armor;
                }
                   
                       
            }//for

            double damageAvr = 0;
            double healthAvr = 0;
            double armorAvr = 0;
            

            foreach (var dragon in dragons)
            {
                //calculate avarage damage healt and armor
                foreach (var type in dragon.Value)
                {
                    int count = 0;
                    double tempNUm = 0;
                    foreach (var item in dragon.Value)
                    {
                        count++;
                        tempNUm += item.Value[0];
                    }
                    damageAvr = tempNUm / count;

                    count = 0;
                    tempNUm = 0;
                    foreach (var item in dragon.Value)
                    {
                        count++;
                        tempNUm += item.Value[1];
                    }
                    healthAvr = tempNUm / count;

                    count = 0;
                    tempNUm = 0;
                    foreach (var item in dragon.Value)
                    {
                        count++;
                        tempNUm += item.Value[2];
                    }
                    armorAvr = tempNUm / count;
                    //print and break;
                    Console.WriteLine($"{dragon.Key}::({damageAvr:f2}/{healthAvr:f2}/{armorAvr:f2})");
                    break;
                }
                foreach (var name in dragon.Value)
{
                    Console.WriteLine($"-{name.Key} -> damage: {name.Value[0]}, health: {name.Value[1]}, armor: {name.Value[2]}");
                }
            }

          
        }
    }
}
