
using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public Dough Dough
        { 
            set
            {
                dough = value;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Topping Toppings
        {
            set
            {
                if (toppings.Count > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                toppings.Add(value);
            }
        }

        public double TotalCalories()
        {
            double totalCalories = dough.CalculateCalories();

            foreach (var item in toppings)
            {
                totalCalories += item.CalculateGramsTopping();
            }
            return totalCalories;
        }
    }
}
