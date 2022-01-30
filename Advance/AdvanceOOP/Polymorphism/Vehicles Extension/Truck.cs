using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehical
    {
        public Truck(double fuelQuntity, double fuelConsuption, double tankCapacity) 
            : base(fuelQuntity, fuelConsuption, tankCapacity)
        {
        }

        public override double FuelConsuption 
        { 
            get => base.FuelConsuption; 
            set => base.FuelConsuption = value + 1.6; 
        }

        public override void Refiling(double quantity)
        {
            ValidateQuantity(quantity);
            quantity *= 0.95;
            base.Refiling(quantity);
        }
    }
}
