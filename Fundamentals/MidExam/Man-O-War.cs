using System;
using System.Collections.Generic;
using System.Linq;

namespace ManOWar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShipStatus = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            List<int> warshipStatus = Console.ReadLine().Split(">", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int maxHealth = int.Parse(Console.ReadLine());

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "Retire")
            {
                switch (cmd[0])
                {
                    case "Fire":
                        int fireIndex = int.Parse(cmd[1]);
                        int damageToWarship = int.Parse(cmd[2]);
                        if (fireIndex > warshipStatus.Count - 1 || fireIndex < 0) break;

                        if(warshipStatus[fireIndex] - damageToWarship <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                        else
                        {
                            warshipStatus[fireIndex] -= damageToWarship;
                        }   
                        break;

                    case "Defend":
                        int startIndex = int.Parse(cmd[1]);
                        int endIndex = int.Parse(cmd[2]);
                        int damageToPirateShip = int.Parse(cmd[3]);
                        if (startIndex < 0 || endIndex > pirateShipStatus.Count - 1) break;
                        

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            if (pirateShipStatus[i] - damageToPirateShip <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }                              
                            else
                                pirateShipStatus[i] -= damageToPirateShip;
                        }
                        break;

                    case "Repair":
                        int indexRepear = int.Parse(cmd[1]);
                        int healing = int.Parse(cmd[2]);
                        if (indexRepear > pirateShipStatus.Count - 1 || indexRepear < 0) break;

                        if (pirateShipStatus[indexRepear] + healing > maxHealth)
                            pirateShipStatus[indexRepear] = maxHealth;
                        else
                            pirateShipStatus[indexRepear] += healing;
                        
                        break;

                    case "Status":
                        int sectionNeedRepair = pirateShipStatus.Count(x => x < maxHealth * 0.2);
                        Console.WriteLine($"{sectionNeedRepair} sections need repair.");
                        break;

                    default:
                        break;
                }

                cmd = Console.ReadLine().Split();
            }//while

            Console.WriteLine($"Pirate ship status: {pirateShipStatus.Sum()}");
            Console.WriteLine($"Warship status: {warshipStatus.Sum()}");
        }
    }
}
