using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight;

        public Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }

        public int BedCapacity { get => bedCapacity; private set => bedCapacity = value; }

        public double PricePerNight { get => pricePerNight;
            private set 
            {
                if (value < 0)
                {
                    pricePerNight = 0;
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }

                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
