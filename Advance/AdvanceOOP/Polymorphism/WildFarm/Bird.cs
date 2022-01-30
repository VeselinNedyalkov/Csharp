using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal , IBird
    {
        public Bird(string name, double weight, double wingSize) 
            : base(name, weight )
        {
            WingSize = wingSize;
        }

        public double WingSize { get ; set ; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
