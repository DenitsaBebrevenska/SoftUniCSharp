namespace Railway
{
    public class RailwayStation
    {
        private string _name;
        private Queue<string> _arrivalTrains;
        private Queue<string> _departureTrains;

        public RailwayStation(string name)
        {
            Name = name;
            _arrivalTrains = new Queue<string>();
            _departureTrains = new Queue<string>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                _name = value;
            }
        }

        public Queue<string> ArrivalTrains => _arrivalTrains;

        public Queue<string> DepartureTrains => _departureTrains;

        public void NewArrivalOnBoard(string trainInfo)
        {
            _arrivalTrains.Enqueue(trainInfo);
        }

        public string TrainHasArrived(string trainInfo)
        {
            if (_arrivalTrains.Peek() != trainInfo)
            {
                return $"There are other trains to arrive before {trainInfo}.";
            }
            _departureTrains.Enqueue(_arrivalTrains.Dequeue());

            return $"{trainInfo} is on the platform and will leave in 5 minutes.";
        }

        public bool TrainHasLeft(string trainInfo)
        {
            if (_departureTrains.Peek() == trainInfo)
            {
                _departureTrains.Dequeue();
                return true;
            }
            return false;
        }
    }
}
