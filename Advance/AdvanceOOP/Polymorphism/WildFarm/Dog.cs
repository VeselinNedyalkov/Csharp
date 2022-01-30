using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncrease { get => 0.4; }

        
        public override void TryToEat(string food, int foodQuantity)
        {
            Console.WriteLine("Woof!");
            base.TryToEat(food, foodQuantity);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
