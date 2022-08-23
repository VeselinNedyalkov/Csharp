using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> booking;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms = new RoomRepository();
            booking = new BookingRepository();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }

                fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }

                category = value;
            }
        }

        public double Turnover => Bookings.All().Sum(x => (x.ResidenceDuration * x.Room.PricePerNight)); 

        public IRepository<IRoom> Rooms { get => rooms;  set => rooms = value; }
        public IRepository<IBooking> Bookings { get => booking;  set => booking = value; }
    }
}
