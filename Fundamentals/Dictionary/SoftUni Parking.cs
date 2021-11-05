using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registratedParkingLot = new Dictionary<string, string>();

            int users = int.Parse(Console.ReadLine());

            for (int i = 0; i < users; i++)
            {
                string[] comand = Console.ReadLine().Split();
                

                switch (comand[0])
                {
                    case "register":
                        string username = comand[1];
                        string lidenseNum = comand[2];
                        if (!registratedParkingLot.ContainsKey(username))
                        {
                            registratedParkingLot.Add(username, lidenseNum);
                            Console.WriteLine($"{username} registered {lidenseNum} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {lidenseNum}");
                        }
                        break;

                    case "unregister":
                         username = comand[1];
                        if (!registratedParkingLot.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        else
                        {
                            registratedParkingLot.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        break;

                    default:
                        break;
                }

               
            }
            foreach (var user in registratedParkingLot)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
