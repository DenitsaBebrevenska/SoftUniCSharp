using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookingApp.Tests
{
    public class RoomTests
    {
        private Room room;
        private Room room2;
        private int capacity = 2;
        private double pricePerNight = 50;

        [SetUp]
        public void Setup()
        {
            room = new Room(capacity, pricePerNight);
        }

        [Test]
        public void Constructor_ShouldInitializeRoom()
        {
            Assert.IsNotNull(room);
        }

        [Test]
        public void Constructor_ShouldSetCapacityCorrectly()
        {
            Assert.AreEqual(capacity, room.BedCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void Capacity_ShouldThrowException_WhenValueIsNegativeOrZero(int invalidCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
                room2 = new Room(invalidCapacity, pricePerNight));
        }

        [Test]
        public void Constructor_ShouldSetPricePerNightCorrectly()
        {
            Assert.AreEqual(pricePerNight, room.PricePerNight);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void PricePerNight_ShouldThrowException_WhenValueIsNegativeOrZero(int invalidPricePerNight)
        {
            Assert.Throws<ArgumentException>(() =>
                room2 = new Room(capacity, invalidPricePerNight));
        }
    }
}