using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private double BaseCaloriesPerGram = 2;
        private double productCalories;
        private double grams;
        string product;
       

        public Topping(string productCalories, double grams)
        {
            ProductCalories = productCalories;
            Grams = grams;
        }

        public string ProductCalories
        {
            get => productCalories.ToString();
            set
            {
                product = value;

                if (value.ToLower() == "meat")
                {
                    productCalories = 1.2;
                }
                else if (value.ToLower() == "veggies")
                {
                    productCalories = 0.8;
                }
                else if (value.ToLower() == "cheese")
                {
                    productCalories = 1.1;
                }
                else if (value.ToLower() == "sauce")
                {
                    productCalories = 0.9;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {product} on top of your pizza.");
                }
            }
        }
        public double Grams 
        { 
            get => grams;
            set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{product} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }


        public double CalculateGramsTopping()
        {
            return BaseCaloriesPerGram * grams * productCalories;
        }
    }
}
