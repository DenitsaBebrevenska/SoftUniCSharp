using BookingApp.Core.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;

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
            throw new NotImplementedException();
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            throw new NotImplementedException();
        }

        public string HotelReport(string hotelName)
        {
            throw new NotImplementedException();
        }
    }
}
