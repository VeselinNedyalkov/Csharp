using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehical : IVehical
    {
        private double fuelQuntity;

        protected Vehical(double fuelQuntity, double fuelConsuption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuntity = fuelQuntity;
            FuelConsuption = fuelConsuption;
            IsEmpty = true;
        }

        public double FuelQuntity 
        { 
            get => fuelQuntity; 
            set
            {
                if (value > TankCapacity)
                {
                    fuelQuntity = 0;
                  
                }
                else
                    fuelQuntity = value;

            } 
        }

        public virtual double FuelConsuption { get; set; }
        public double TankCapacity { get; set; }
        public bool IsEmpty { get; set; }

        public bool EnoughtFuel(double distance)
            => distance * FuelConsuption < FuelQuntity;


        public void Drive(double distance)
        {
            FuelQuntity -= distance * FuelConsuption;
        }

        public virtual void Refiling(double quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (quantity + FuelQuntity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }
            FuelQuntity += quantity;
        }
    }
}
