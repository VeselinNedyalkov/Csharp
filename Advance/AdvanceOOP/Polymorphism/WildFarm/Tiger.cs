using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override double WeightIncrease { get => 1; }

     
        public override void TryToEat(string food, int foodQuantity)
        {
            Console.WriteLine("ROAR!!!");

            base.TryToEat(food, foodQuantity);
        }
    }
}
