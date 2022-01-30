using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {      
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override double WeightIncrease { get => 0.3; }
        public override bool IsEating(string food)
        {
            if (food == "Vegetable" || food == "Meat")
            {
                return true;
            }
            else
                return false;
        }
   
        public override void TryToEat(string food, int foodQuantity)
        {
            Console.WriteLine("Meow");
            base.TryToEat(food, foodQuantity);
        }
    }
}
