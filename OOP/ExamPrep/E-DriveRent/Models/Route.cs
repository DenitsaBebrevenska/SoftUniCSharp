using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string _startPoint;
        private string _endPoint;
        private double _length;
        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Length = length;
            RouteId = routeId;
            IsLocked = false;
        }

        public string StartPoint
        {
            get => _startPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }
                _startPoint = value;
            }
        }

        public string EndPoint
        {
            get => _endPoint;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }
                _endPoint = value;
            }
        }

        public double Length
        {
            get => _length;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }
                _length = value;
            }
        }
        public int RouteId { get; private set; }
        public bool IsLocked { get; private set; }

        public void LockRoute()
            => IsLocked = true;

    }
}
