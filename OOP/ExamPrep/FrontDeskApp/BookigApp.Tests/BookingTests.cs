using FrontDeskApp;
using NUnit.Framework;

namespace BookingApp.Tests
{
    public class BookingTests
    {
        private Room room;
        private int capacity = 2;
        private double pricePerNight = 50;
        private Booking booking;
        private int bookingNumber = 1;
        private int duration = 2;

        [SetUp]
        public void Setup()
        {
            room = new Room(capacity, pricePerNight);
            booking = new Booking(bookingNumber, room, duration);
        }

        [Test]
        public void Constructor_ShouldInitializeBooking()
        {
            Assert.IsNotNull(booking);
        }

        [Test]
        public void Constructor_ShouldSetBookingCorrectly()
        {
            Assert.AreEqual(bookingNumber, bookingNumber);
        }


        [Test]
        public void Constructor_ShouldSetRoomCorrectly()
        {
            Assert.AreSame(room, booking.Room);
        }


        [Test]
        public void Constructor_ShouldSetResidenceDurationCorrectly()
        {
            Assert.AreEqual(duration, booking.ResidenceDuration);
        }

    }
}