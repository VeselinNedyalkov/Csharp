using System;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine().Split("|");             //input rooms
            int health = 100;
            int bitcoins = 0;
            const int MAX_HEALT = 100;

            for (int i = 0; i < rooms.Length; i++)                      //check all rooms
            {
                string[] eventInRoom = rooms[i].Split(" ",StringSplitOptions.RemoveEmptyEntries);//event is rooms

                switch (eventInRoom[0])
                {
                    case "potion":          
                        int healingPower = int.Parse(eventInRoom[1]);  

                        if (health == MAX_HEALT) break;                 //if max health break

                        if (healingPower + health > MAX_HEALT)          //if healingPower is more than max health
                        {
                            healingPower = MAX_HEALT - health;
                            health = MAX_HEALT;
                        }
                        else
                        {
                            health += healingPower;
                        }
                        Console.WriteLine($"You healed for {healingPower} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;

                    case "chest":
                        int botcoinsFoundInRoom = int.Parse(eventInRoom[1]);
                        bitcoins += botcoinsFoundInRoom;                        //add bitcoins in totalSum
                        Console.WriteLine($"You found {botcoinsFoundInRoom} bitcoins.");
                        break;  
                        
                    default:                            //monster fight
                        int monsterDamage = int.Parse(eventInRoom[1]);
                        string monsterName = eventInRoom[0];

                        health -= monsterDamage;

                        if (health <= 0)
                        {
                            Console.WriteLine($"You died! Killed by {monsterName}.");
                            Console.WriteLine($"Best room: {i + 1}");
                            return;
                        }
                        else
                            Console.WriteLine($"You slayed {monsterName}.");
                        break;
                }//switch

            }//for
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
