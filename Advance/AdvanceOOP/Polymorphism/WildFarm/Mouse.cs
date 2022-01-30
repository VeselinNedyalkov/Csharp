using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        public override bool IsEating(string food)
        {
            if (food == "Vegetable" || food == "Fruit")
            {
                return true;
            }
            else
                return false;
        }
        public override double WeightIncrease { get => 0.1; }
    
        public override void TryToEat(string food, int foodQuantity)
        {
            Console.WriteLine("Squeak");

            base.TryToEat(food, foodQuantity);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
