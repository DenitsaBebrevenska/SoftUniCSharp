namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    public class RailwayStationTests
    {
        private RailwayStation _station;
        private string _name = "Hogwarts";
        private string _train1 = "London-Dublin";
        private string _train2 = "London-Hogwarts";
        private string _train3 = "London-Hogsmead";

        [SetUp]
        public void SetUp()
        {
            _station = new RailwayStation(_name);
        }

        [Test]
        public void Constructor_ShouldInitializeStation()
        {
            Assert.IsNotNull(_station);
        }

        [Test]
        public void Constructor_ShouldSetNameCorrectly()
        {
            Assert.AreEqual(_name, _station.Name);
        }

        [Test]
        public void Constructor_ShouldInitializeArrivalTrains()
        {
            Assert.IsNotNull(_station.ArrivalTrains);
        }

        [Test]
        public void Constructor_ShouldInitializeDepartureTrains()
        {
            Assert.IsNotNull(_station.DepartureTrains);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]

        public void SettingTheNameToNullOrWhitespace_ShouldThrowException(string invalidName)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => _station = new RailwayStation(invalidName));

            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
        }

        [Test]
        public void NewArrivalOnBoard_ShouldCorrectlyEnqueueTrainOnArrivalTrains()
        {
            Assert.AreEqual(0, _station.ArrivalTrains.Count);
            _station.NewArrivalOnBoard(_train1);
            Assert.AreEqual(1, _station.ArrivalTrains.Count);
            Assert.AreEqual(_train1, _station.ArrivalTrains.Peek());
        }


        [Test]
        public void TrainHasArrived_ShouldRemoveTrainFromArrivalTrainList()
        {
            _station.NewArrivalOnBoard(_train1);
            _station.TrainHasArrived(_train1);

            Assert.That(!_station.ArrivalTrains.Contains(_train1));
            Assert.AreEqual(0, _station.ArrivalTrains.Count);
        }

        [Test]
        public void TrainHasArrived_ShouldAddTrainToDepartureTrainList()
        {
            _station.NewArrivalOnBoard(_train1);
            Assert.AreEqual(0, _station.DepartureTrains.Count);
            _station.TrainHasArrived(_train1);

            Assert.AreEqual(_train1, _station.DepartureTrains.Peek());
            Assert.AreEqual(1, _station.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasArrived_ShouldReturnCorrectInfoAboutDeparturingTrain()
        {
            _station.NewArrivalOnBoard(_train1);

            string expectedResult = $"{_train1} is on the platform and will leave in 5 minutes.";
            Assert.AreEqual(expectedResult, _station.TrainHasArrived(_train1));
        }

        [Test]
        public void TrainHasArrived_ShouldReturnCorrectInfoIfThereAreMoreArrivingTrains()
        {
            _station.NewArrivalOnBoard(_train1);
            _station.NewArrivalOnBoard(_train2);
            _station.NewArrivalOnBoard(_train3);

            string expectedResult = $"There are other trains to arrive before {_train3}.";
            Assert.AreEqual(expectedResult, _station.TrainHasArrived(_train3));
        }

        [Test]
        public void TrainHasArrived_ShouldRemoveFirstFromArrivalTrainsAndQueueToDepartureTrains()
        {
            _station.NewArrivalOnBoard(_train1);
            _station.NewArrivalOnBoard(_train2);
            _station.TrainHasArrived(_train1);

            Assert.AreEqual(false, _station.ArrivalTrains.Contains(_train1));
            Assert.AreEqual(_train2, _station.ArrivalTrains.Peek());
            Assert.AreEqual(true, _station.DepartureTrains.Contains(_train1));
            Assert.AreEqual(_train1, _station.DepartureTrains.Peek());
        }

        [Test]
        public void TrainHasLeft_ShouldReturnTrue_WhenTrainIsTheOneToLeave()
        {
            _station.NewArrivalOnBoard(_train1);
            _station.NewArrivalOnBoard(_train2);
            _station.TrainHasArrived(_train1);
            _station.TrainHasArrived(_train2);

            Assert.AreEqual(true, _station.TrainHasLeft(_train1));
        }

        [Test]
        public void TrainHasLeft_ShouldRemoveTrainFromDepartureTrainList()
        {
            _station.NewArrivalOnBoard(_train1);
            _station.NewArrivalOnBoard(_train2);
            _station.TrainHasArrived(_train1);
            _station.TrainHasArrived(_train2);
            _station.TrainHasLeft(_train1);

            Assert.IsFalse(_station.DepartureTrains.Contains(_train1));
        }

        [Test]
        public void TrainHasLeft_ShouldReturnFalse_WhenTrainIsNotTheOneToLeave()
        {
            _station.NewArrivalOnBoard(_train1);
            _station.NewArrivalOnBoard(_train2);
            _station.TrainHasArrived(_train1);
            _station.TrainHasArrived(_train2);

            Assert.AreEqual(false, _station.TrainHasLeft(_train2));
        }
    }
}