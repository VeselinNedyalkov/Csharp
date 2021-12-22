using System;
using System.Linq;
using System.Collections.Generic;

namespace Truck_Tour
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < number; i++)
            {
                int[] pump = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                pumps.Enqueue(pump);
            }

            int pumpCounter = 0;
           
            
            while (true)
            {
                int totalFuel = 0;
                foreach (var item in pumps)
                {
                    int fuel = item[0];
                    int distance = item[1];
                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        pumpCounter++;
                            break;
                    }                   
                }
                if (totalFuel > 0)
                    break;
              
            }
            Console.WriteLine(pumpCounter);
        }

    }
}
