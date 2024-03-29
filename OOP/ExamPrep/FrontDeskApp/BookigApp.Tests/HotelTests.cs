using FrontDeskApp;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;

namespace BookingApp.Tests
{
    public class HotelTests
    {
        private Hotel hotel;
        private Hotel hotel2;
        private string hotelName = "Palace";
        private int category = 4;
        private Room room;
        private Booking booking;


        [SetUp]
        public void Setup()
        {
            hotel = new Hotel(hotelName, category);
        }

        [Test]
        public void Constructor_ShouldInitializeHotel()
        {
            Assert.IsNotNull(hotel);
        }

        [Test]
        public void Constructor_ShouldSetNameCorrectly()
        {
            Assert.AreEqual(hotelName, hotel.FullName);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("\t")]
        public void Name_ShouldThrowException_WhenGiveNullOrWhitespaceValue(string invalidName)
        {
            Assert.Throws<ArgumentNullException>(() =>
                hotel2 = new Hotel(invalidName, category));
        }

        [Test]
        public void Constructor_ShouldSetCategoryCorrectly()
        {
            Assert.AreEqual(category, hotel.Category);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(6)]
        [TestCase(10)]
        public void Category_ShouldThrowException_WhenValueLessThanOneOrMoreThanFive(int invalidCategory)
        {
            Assert.Throws<ArgumentException>(() =>
                hotel2 = new Hotel(hotelName, invalidCategory));
        }

        [Test]
        public void Turnover_ShouldInitiallyBeSetToZero()
        {
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void Constructor_ShouldInitializeRoomList()
        {
            Assert.IsNotNull(hotel.Rooms);
        }

        [Test]
        public void Constructor_ShouldInitializeBookingList()
        {
            Assert.IsNotNull(hotel.Bookings);
        }

        [Test]
        public void AddRoom_ShouldAddRoomToRoomList()
        {
            room = new Room(2, 50);
            Assert.IsFalse(hotel.Rooms.Contains(room));
            hotel.AddRoom(room);
            Assert.IsTrue(hotel.Rooms.Contains(room));
        }

        [Test]
        public void BookRoom_ShouldAddBookingToBookingList()
        {
            room = new Room(2, 50);
            hotel.AddRoom(room);
            Assert.IsFalse(hotel.Bookings.Any(b => b.Room == room && b.ResidenceDuration == 1));
            Assert.AreEqual(0, hotel.Bookings.Count);
            hotel.BookRoom(1, 0, 1, 2000);
            Assert.IsTrue(hotel.Bookings.Any(b => b.Room == room && b.ResidenceDuration == 1));
            Assert.AreEqual(1, hotel.Bookings.Count);
        }

        [Test]
        public void BookRoom_ShouldGiveCountPlusOneBookingNumber()
        {
            room = new Room(2, 50);
            hotel.AddRoom(room);
            int expectedResult = hotel.Bookings.Count() + 1;
            hotel.BookRoom(1, 0, 1, 2000);
            Assert.AreEqual(expectedResult, hotel.Bookings.First().BookingNumber);
            hotel.BookRoom(1, 0, 1, 2000);
            Assert.AreEqual(++expectedResult, hotel.Bookings
                .OrderByDescending(b => b.BookingNumber).First().BookingNumber);
        }

        [Test]
        public void BookRoom_ShouldIncreaseTurnoverCorrectly()
        {
            room = new Room(2, 50);
            hotel.AddRoom(room);
            Assert.AreEqual(0, hotel.Turnover);
            double expectedResult = 50;
            hotel.BookRoom(1, 0, 1, 2000);
            Assert.AreEqual(expectedResult, hotel.Turnover);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(0)]
        public void BookRoom_ShouldThrowException_WhenGivenZeroOrLessValueForAdultCount(int adultCount)
        {
            room = new Room(2, 50);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() =>
                hotel.BookRoom(adultCount, 0, 1, 2000));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void BookRoom_ShouldThrowException_WhenGivenNegativeValueForChildrenCount(int childrenCount)
        {
            room = new Room(2, 50);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() =>
                hotel.BookRoom(1, childrenCount, 1, 2000));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(0)]
        public void BookRoom_ShouldThrowException_WhenGivenZeroOrLessValueForDuration(int residenceDuration)
        {
            room = new Room(2, 50);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() =>
                hotel.BookRoom(1, 0, residenceDuration, 2000));
        }

        [Test]
        public void BookRoom_ShouldTakeTheFirstRoomWithMoreOrEqualToTheGivenBedsCountRoom()
        {
            room = new Room(2, 50);
            Room room2 = new Room(3, 50);
            Room room3 = new Room(4, 50);
            hotel.AddRoom(room);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);
            hotel.BookRoom(3, 0, 1, 2000);
            Assert.AreSame(room2, hotel.Bookings.First().Room);
        }

        [Test]
        public void BookRoom_ShouldBookARoomIfBudgetSuffice()
        {
            room = new Room(2, 50);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 0, 1, 10);
            Assert.IsFalse(hotel.Bookings.Any());
        }
    }
}