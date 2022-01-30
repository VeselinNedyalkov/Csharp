using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set ; }
        public  double Weight { get ; set ; }
        public int FoodEaten { get ; set ; }
        public virtual double WeightIncrease { get;}

        public virtual bool IsEating(string food)
        {
            return MeetEaters(food);
        }

        private static bool MeetEaters(string food)
        {
            if (food == "Meat")
            {
                return true;
            }
            else
                return false;
        }

        public virtual void TryToEat(string food,int foodQuantity)
        {
            if (IsEating(food))
            {
                Weight += WeightIncrease * foodQuantity;
                FoodEaten = foodQuantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food}!");
            }
        }

    }
}
