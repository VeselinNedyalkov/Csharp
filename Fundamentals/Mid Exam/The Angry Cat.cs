using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Angry_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRating = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int indexEntryPoint = int.Parse(Console.ReadLine());
            string typeOfItemsTobreak = Console.ReadLine();
            int leftSum = 0;
            int rightSum = 0;

            switch (typeOfItemsTobreak)
            {
                case "cheap":
                    int valueCheepItems = priceRating[indexEntryPoint];

                    for (int i = 0; i < indexEntryPoint; i++)
                    {
                        if (priceRating[i] < valueCheepItems)
                            leftSum += priceRating[i];
                    }

                    for (int i = indexEntryPoint + 1; i < priceRating.Count; i++)
                    {
                        if (priceRating[i] < valueCheepItems)
                            rightSum += priceRating[i];
                    }
                    break;

                case "expensive":
                    int valueExpensive = priceRating[indexEntryPoint];
                    for (int i = 0; i < indexEntryPoint; i++)
                    {
                        if (priceRating[i] >= valueExpensive)
                            leftSum += priceRating[i];
                    }

                    for (int i = indexEntryPoint + 1; i < priceRating.Count; i++)
                    {
                        if (priceRating[i] >= valueExpensive)
                            rightSum += priceRating[i];
                    }
                    break;
                default:
                    break;
            }//switch
            if (leftSum >= rightSum)            
                Console.WriteLine($"Left - {leftSum}");            
            else
                Console.WriteLine($"Right - {rightSum}");
        }
    }
}
