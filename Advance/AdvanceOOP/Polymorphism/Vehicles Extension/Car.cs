using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehical
    {
        public Car(double fuelQuntity, double fuelConsuption, double tankCapacity) 
            : base(fuelQuntity, fuelConsuption, tankCapacity)
        {
        }

        public override double FuelConsuption 
        { 
            get => base.FuelConsuption; 
            set => base.FuelConsuption = value + 0.9; 
        }
    }
}
