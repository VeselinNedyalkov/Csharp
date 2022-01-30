using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {

        public Owl(string name, double weight,  double wingSize)
            : base(name, weight,  wingSize)
        {
        }

        public override double WeightIncrease { get => 0.25; }

      
        public override void TryToEat(string food, int foodQuantity)
        {
            Console.WriteLine("Hoot Hoot");

            base.TryToEat(food, foodQuantity);
        }
    }
}
