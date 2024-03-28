using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultCount;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childrenCount = value;
            }
        }
        public int BookingNumber { get; private set; }
        public string BookingSummary()
        {
            StringBuilder summary = new StringBuilder();
            summary.AppendLine($"Booking number: {BookingNumber}");
            summary.AppendLine($"Room type: {Room.GetType().Name}");
            summary.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            summary.AppendLine($"Total amount paid: {Math.Round(ResidenceDuration * Room.PricePerNight, 2):F2} $");

            return summary.ToString().TrimEnd();
        }
    }
}
