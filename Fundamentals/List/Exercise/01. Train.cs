using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Ecercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] comands = Console.ReadLine().Split();

            while (comands[0] != "end")
            {
                
                if (comands[0] == "Add")
                {
                    int wagonsAddAndPeople = int.Parse(comands[1]);
                    wagons.Add(wagonsAddAndPeople);
                }
                else
                {
                    int peopleToAdd = int.Parse(comands[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int capacityOfWagon = maxCapacity - wagons[i];
                        if (capacityOfWagon >= peopleToAdd)
                        {
                            wagons[i] += peopleToAdd;
                            peopleToAdd = 0;
                        }
                        if (peopleToAdd == 0)
                        {
                            break;
                        }
                      
                    }//for
                     
                }
                
                comands = Console.ReadLine().Split();
            }//while
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
