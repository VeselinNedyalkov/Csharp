using System;

namespace Guinea_Pig
{
    class Program
    {
        static void Main(string[] args)
        {
            double quantityFoodKg = double.Parse(Console.ReadLine());
            double quantityHayKg = double.Parse(Console.ReadLine());
            double quantityCoverKg = double.Parse(Console.ReadLine());
            double pigWeightKg = double.Parse(Console.ReadLine());
            const int indexKgToGram = 1000;
            const int FOOD_EATEN_FOR_A_DAY = 300;

            double foodGrams = quantityFoodKg * indexKgToGram;
            double hayGrams = quantityHayKg * indexKgToGram;
            double coverGrams = quantityCoverKg * indexKgToGram;
            double weight = pigWeightKg * indexKgToGram;

            for (int days = 1; days <= 30; days++)
            {
                foodGrams -= FOOD_EATEN_FOR_A_DAY;

                if (days % 2 == 0)
                    hayGrams -= foodGrams * 0.05;

                if (days % 3 == 0)
                    coverGrams -= weight / 3;

                if (foodGrams <= 0 || hayGrams <= 0 || coverGrams <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    break;
                }                               
            }//for

            if (foodGrams > 0 && hayGrams > 0 && coverGrams > 0)
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodGrams / indexKgToGram:f2}, Hay: {hayGrams / indexKgToGram:f2}, Cover: {coverGrams / indexKgToGram:f2}.");
        }
    }
}
