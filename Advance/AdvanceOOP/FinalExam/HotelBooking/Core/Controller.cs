using BookingApp.Core.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Rooms;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotelRepository;

        public Controller()
        {
            hotelRepository = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotelRepository.Select(hotelName);

            if (hotel != null)
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotelToAdd = new Hotel(hotelName, category);
            hotelRepository.AddNew(hotelToAdd);

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category , hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (!hotelRepository.All().All(x => x.Category == category))
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            foreach (var hotel in hotelRepository.All().Where(x => x.Category == category).OrderBy(x => x.FullName))
            {
                IRoom[] rooms = hotel.Rooms.All().Where(x => x.PricePerNight > 0).ToArray();

                foreach (var room in rooms.OrderBy(x => x.BedCapacity))
                {
                    if (room.BedCapacity >= adults + children)
                    {
                        int bookingNum = hotel.Bookings.All().Count() + 1;
                        IBooking booking = new Booking(room , duration , adults , children, bookingNum);

                        hotel.Bookings.AddNew(booking);

                        return String.Format(OutputMessages.BookingSuccessful, bookingNum , hotel.FullName);
                    }
                }
            }
            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover :f2} $");
            sb.AppendLine($"--Bookings:");

            if (!hotel.Bookings.All().Any())
            {
                sb.AppendLine();
                sb.AppendLine("none");
            }
            else
            {
                foreach (var bookings in hotel.Bookings.All())
                {
                    sb.AppendLine();
                    sb.AppendLine(bookings.BookingSummary());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" &&
                roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (room == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            } 

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName ,hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }

            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" &&
                roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = null;

            switch (roomTypeName)
            {
                case "Apartment":
                    room = new Apartment();
                    break;

                case "DoubleBed":
                    room = new DoubleBed();
                    break;

                case "Studio":
                    room = new Studio();
                    break;

                default:
                    break;
            }

            hotel.Rooms.AddNew(room);

            return String.Format(OutputMessages.RoomTypeAdded,roomTypeName ,hotelName);
        }
    }
}
