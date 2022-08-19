using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            enduranceLevel = 1;
        }

        public double Cost { get => cost; private set => cost = value; }

        public int EnduranceLevel { get => enduranceLevel;
            private set
            {
                enduranceLevel = value;
            } 
        }

        public void IncreaseEndurance()
        {
            int endurValue = EnduranceLevel;
            endurValue++;

            if (endurValue > 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }

            EnduranceLevel = endurValue;
        }
    }
}
