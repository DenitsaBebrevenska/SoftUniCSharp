using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotels.AddNew(new Hotel(hotelName, category));
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotels.All().All(h => h.FullName != hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);

            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            if (roomTypeName != "Apartment" && roomTypeName != "Studio" && roomTypeName != "DoubleBed")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = null;

            switch (roomTypeName)
            {
                case "Apartment":
                    room = new Apartment();
                    break;
                case "Studio":
                    room = new Studio();
                    break;
                case "DoubleBed":
                    room = new DoubleBed();
                    break;
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.All().All(h => h.FullName != hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != "Apartment" && roomTypeName != "Studio" && roomTypeName != "DoubleBed")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IHotel hotel = hotels.Select(hotelName);

            if (hotel.Rooms.All().All(r => r.GetType().Name != roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            if (hotels.All().All(h => h.Category != category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            List<IRoom> roomsAvailable = new List<IRoom>();

            foreach (var hotel in hotels.All().OrderBy(h => h.FullName))
            {
                foreach (var room in hotel.Rooms.All().Where(r => r.PricePerNight > 0))
                {
                    roomsAvailable.Add(room);
                }
            }

            IRoom appropriateRoom = roomsAvailable.OrderBy(r => r.BedCapacity)
                .FirstOrDefault(r => r.BedCapacity >= adults + children);

            if (appropriateRoom is null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            IHotel targetHotel = hotels.All().FirstOrDefault(h => h.Rooms.All()
                .Any(r => r.PricePerNight == appropriateRoom.PricePerNight &&
                          r.BedCapacity == appropriateRoom.BedCapacity));

            int bookingNumber = targetHotel.Bookings.All().Count + 1;
            targetHotel.Bookings
                .AddNew(new Booking(appropriateRoom, duration, adults, children, bookingNumber));

            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, targetHotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            if (hotels.All().All(h => h.FullName != hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            IHotel hotel = hotels.Select(hotelName);

            StringBuilder report = new StringBuilder();
            report.AppendLine($"Hotel name: {hotelName}");
            report.AppendLine($"--{hotel.Category} star hotel");
            report.AppendLine($"--Turnover: {hotel.Turnover} $");
            report.AppendLine($"--Bookings:");

            if (hotel.Bookings.All().Count == 0)
            {
                report.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    report.AppendLine(booking.BookingSummary());
                }
            }

            return report.ToString().TrimEnd();
        }
    }
}
