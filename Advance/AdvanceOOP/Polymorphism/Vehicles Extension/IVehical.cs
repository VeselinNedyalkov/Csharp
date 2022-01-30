using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehical
    {
        public double FuelQuntity { get; set; }
        public double FuelConsuption { get; set; }
        public double TankCapacity { get; set; }

        public bool IsEmpty { get; set; }

        bool EnoughtFuel(double distance);
        void Drive(double distance);

        void Refiling(double quantity);
    }
}
