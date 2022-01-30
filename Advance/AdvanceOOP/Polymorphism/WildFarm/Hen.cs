using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightIncrease { get => 0.35; }

        public override bool IsEating(string food)
        {
            return true;
        }
        public override void TryToEat(string food, int foodQuantity )
        {
            Console.WriteLine("Cluck");
            base.TryToEat(food, foodQuantity);
        }
    }
}
