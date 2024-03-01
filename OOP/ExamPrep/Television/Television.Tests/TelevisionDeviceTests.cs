using System;
namespace Television.Tests
{
    public class TelevisionDeviceTests
    {
        private TelevisionDevice _device;
        private const string Brand = "Samsung";
        private const double Price = 1299.99;
        private const int Width = 42;
        private const int Height = 42;

        [SetUp]
        public void SetUp()
        {
            _device = new TelevisionDevice(Brand, Price, Width, Height);
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Assert.IsNotNull(_device);
        }

        [Test]
        public void BrandProperty_ShouldWorkCorrectly()
        {
            Assert.AreEqual(Brand, _device.Brand);
        }

        [Test]
        public void PriceProperty_ShouldWorkCorrectly()
        {
            Assert.AreEqual(Price, _device.Price);
        }

        [Test]
        public void WidthProperty_ShouldWorkCorrectly()
        {
            Assert.AreEqual(Width, _device.ScreenWidth);
        }

        [Test]
        public void HeightProperty_ShouldWorkCorrectly()
        {
            Assert.AreEqual(Height, _device.ScreenHeigth);
        }

        [Test]
        public void CurrentChannel_ShouldReturnDefaultChannel_WhenDeviceIsInitialized()
        {
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, _device.CurrentChannel);
        }

        [Test]
        public void CurrentVolume_ShouldReturnDefaultChannel_WhenDeviceIsInitialized()
        {
            int expectedResult = 13;
            Assert.AreEqual(expectedResult, _device.Volume);
        }

        [Test]
        public void IsMuted_ShouldReturnFalse_WhenDeviceIsInitialized()
        {
            Assert.IsFalse(_device.IsMuted);
        }

        [Test]
        public void MuteDevice_ShouldChangeCurrentMuteStateCorrectly()
        {
            Assert.IsFalse(_device.IsMuted);
            _device.MuteDevice();
            Assert.IsTrue(_device.IsMuted);
        }

        [Test]
        public void SwitchOn_CorrectlyReturnStateOfDevice()
        {
            string expectedResult = $"Cahnnel 0 - Volume 13 - Sound On";
            Assert.AreEqual(expectedResult, _device.SwitchOn());

            _device.MuteDevice();
            _device.ChangeChannel(2);
            _device.VolumeChange("UP", 1);

            expectedResult = $"Cahnnel 2 - Volume 14 - Sound Off";
        }

        [Test]
        public void ChangeChannel_ShouldThrowAnException_WhenGiveNegativeChannelNumber()
        {
            int invalidChannel = -1;

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => _device.ChangeChannel(invalidChannel));

            Assert.AreEqual("Invalid key!", exception.Message);
        }

        [Test]
        public void ChangeChannel_ShouldChangeCurrentChannel()
        {
            int expectedResult = 2;
            int currentChannel = _device.CurrentChannel;
            _device.ChangeChannel(expectedResult);

            Assert.AreNotEqual(expectedResult, currentChannel);
        }

        [Test]
        public void ChangeChannel_ShouldCorrectlyReturnCurrentChannel()
        {
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, _device.ChangeChannel(expectedResult));
        }

        [TestCase(2)]
        [TestCase(15)]
        [TestCase(20)]
        public void ChangeVolume_ShouldIncreaseVolume_WhenCommandIsUp(int units)
        {
            string direction = "UP";
            int previousVolume = _device.Volume;
            _device.VolumeChange(direction, units);
            Assert.That(previousVolume, Is.LessThan(_device.Volume));
        }

        [TestCase(90)]
        [TestCase(200)]
        public void ChangeVolume_ShouldNotIncreaseVolumePast100(int units)
        {
            string direction = "UP";
            int exceededVolume = _device.Volume + units;
            Assert.That(exceededVolume, Is.GreaterThan(100));
            _device.VolumeChange(direction, units);

            Assert.AreEqual(100, _device.Volume);
        }

        [TestCase(-2)]
        [TestCase(-15)]
        [TestCase(-20)]
        public void ChangeVolume_ShouldIncreaseVolume_RegardlessOfUnitsBeingNegativeNumbers(int units)
        {
            string direction = "UP";
            int previousVolume = _device.Volume;
            _device.VolumeChange(direction, units);
            Assert.That(previousVolume, Is.LessThan(_device.Volume));
        }

        [TestCase(2)]
        [TestCase(7)]
        [TestCase(13)]
        public void ChangeVolume_ShouldDecreaseVolume_WhenCommandIsDown(int units)
        {
            string direction = "DOWN";
            int previousVolume = _device.Volume;
            _device.VolumeChange(direction, units);
            Assert.That(previousVolume, Is.GreaterThan(_device.Volume));
        }

        [TestCase(20)]
        [TestCase(70)]
        public void ChangeVolume_ShouldNotReduceVolumePast0(int units)
        {
            string direction = "DOWN";
            int exceededVolume = _device.Volume - units;
            Assert.That(exceededVolume, Is.LessThan(0));
            _device.VolumeChange(direction, units);

            Assert.AreEqual(0, _device.Volume);
        }

        [TestCase(-2)]
        [TestCase(-15)]
        [TestCase(-20)]
        public void ChangeVolume_ShouldDecreaseVolume_RegardlessOfUnitsBeingNegativeNumbers(int units)
        {
            string direction = "DOWN";
            int previousVolume = _device.Volume;
            _device.VolumeChange(direction, units);
            Assert.That(previousVolume, Is.GreaterThan(_device.Volume));
        }

        [TestCase(5)]
        [TestCase(-5)]

        public void ChangeVolume_ShouldCorrectlyReturnCurrentVolume_WhenIncreased(int units)
        {
            string direction = "UP";
            int expectedVolume = _device.Volume + Math.Abs(units);
            string expectedResult = $"Volume: {expectedVolume}";
            Assert.AreEqual(expectedResult, _device.VolumeChange(direction, units));
        }


        [TestCase(5)]
        [TestCase(-5)]

        public void ChangeVolume_ShouldCorrectlyReturnCurrentVolume_WhenDecreased(int units)
        {
            string direction = "DOWN";
            int expectedVolume = _device.Volume - Math.Abs(units);
            string expectedResult = $"Volume: {expectedVolume}";
            Assert.AreEqual(expectedResult, _device.VolumeChange(direction, units));
        }

        [Test]
        public void ToString_ShouldCorrectlyReturnString()
        {
            string expectedString = $"TV Device: {Brand}, Screen Resolution: {Width}x{Height}, Price {Price}$";
            Assert.AreEqual(expectedString, _device.ToString());
        }
    }
}