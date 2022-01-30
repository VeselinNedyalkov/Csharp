using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehical
    {
        public Bus(double fuelQuntity, double fuelConsuption, double tankCapacity) 
            : base(fuelQuntity, fuelConsuption, tankCapacity)
        {
        }

       
        public override double FuelConsuption 
        {
            get 
            {
                if (IsEmpty)
                {
                    return base.FuelConsuption;
                }
                else
                {
                    return base.FuelConsuption + 1.4; 
                }
            }           
            set => base.FuelConsuption = value; 
        }
    }
}
