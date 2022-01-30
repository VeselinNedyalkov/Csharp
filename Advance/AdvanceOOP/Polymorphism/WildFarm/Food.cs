using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food : IFood
    {
        public Food(int qunatity)
        {
            Qunatity = qunatity;
        }

        public int Qunatity { get ; set ; }
    }
}
