using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Room room;
        private Booking booking;
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            room = new Room(2, 150);
            booking = new Booking(101, room, 3);
            hotel = new Hotel("Zero", 5);
        }

        [Test]
        public void RoomConstructorTestWorkingProperrly()
        {
            Assert.AreEqual(room.BedCapacity, 2);
            Assert.AreEqual(room.PricePerNight, 150);
        }


        [Test]
        [TestCase(0 , 150)]
        [TestCase(-4 , 150)]
        public void RoombadCapacityExeptionIfValueIsZeroOrnegativ(int bedCapacity, double pricePerNight)
        {

            Assert.Throws<ArgumentException> (() => new Room(bedCapacity, pricePerNight));
        }

        [Test]
        [TestCase(2, 0)]
        [TestCase(4, -150)]
        public void RoombadPricePerNightExeptionIfValueIsZeroOrnegativ(int bedCapacity, double pricePerNight)
        {
            Assert.Throws<ArgumentException>(() => new Room(bedCapacity, pricePerNight));
        }

        [Test]
        public void BookingProperlyWorkingBookingNum()
        {
            Assert.AreEqual(booking.BookingNumber, 101);
        }

        [Test]
        public void BookingProperlyWorkingRoom()
        {
            Assert.AreEqual(booking.Room, room);
        }

        [Test]
        public void BookingProperlyWorkingResidenceDuration()
        {
            Assert.AreEqual(booking.ResidenceDuration, 3);
        }

        [Test]
        public void HotelContructorTestFullName()
        {
            Assert.AreEqual(hotel.FullName, "Zero");
        }

        [Test]
        public void HotelContructorTestCategory()
        {

            Assert.AreEqual(hotel.Category, 5);
        }

        [Test]
        [TestCase(null , 5)]
        [TestCase(" " , 5)]
        public void HotelFullNameExeptionIfNullOrSpace(string fullName, int category)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, category));
        }

        [Test]
        [TestCase("Zero", 0)]
        [TestCase("Zero", 6)]
        public void HotelCategoryExeptionIflessThanOneOrMoreThanFive(string fullName, int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel(fullName, category));
        }

        [Test]
        public void HotelTurnoverTest()
        {
            Assert.AreEqual(hotel.Turnover, 0);
        }

        [Test]
        public void HotelAddRoomColectionCountTest()
        {
            hotel.AddRoom(room);

            Assert.AreEqual(hotel.Rooms.Count, 1);
        }

        [Test]
        public void HotelBookingRoomExeptionForLessThanZeroAdults()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-1, 2, 2, 5000));
        }

        [Test]
        public void HotelBookingRoomExeptionForLessThanZeroChildren()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, -1, 2, 5000));
        }

        [Test]
        public void HotelBookingRoomExeptionForLessThanOneResidenceDuration()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 2, 0, 5000));
        }

        [Test]
        public void HotelBookRoomCount()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 2, 5000);
            hotel.BookRoom(1, 1, 2, 2000);

            Assert.AreEqual(hotel.Bookings.Count, 2);
        }

        [Test]
        public void HotelBookRoomTurnoverCount()
        {
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 2, 5000);
            hotel.BookRoom(1, 1, 2, 2000);

            Assert.AreEqual(hotel.Turnover, 600);
        }
    }
}
