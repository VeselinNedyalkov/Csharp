﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mammal : Animal , IMammal
    {
        public Mammal(string name, double weight,string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get ; set ; }
    }
}
