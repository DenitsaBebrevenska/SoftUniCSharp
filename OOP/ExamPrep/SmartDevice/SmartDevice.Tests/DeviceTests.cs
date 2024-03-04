using System.Text;

namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;

    public class DeviceTests
    {
        private Device _device;
        private int _memoryCapacity = 100;
        private string _appName = "GooglePlay";
        private int _appropriateFileSize = 20;

        [SetUp]
        public void Setup()
        {
            _device = new Device(_memoryCapacity);

        }

        [Test]
        public void Constructor_ShouldInitializeDevice()
        {
            Assert.IsNotNull(_device);
        }

        [Test]
        public void Constructor_ShouldSetMemoryCapacityCorrectly()
        {
            Assert.AreEqual(_memoryCapacity, _device.MemoryCapacity);
        }

        [Test]
        public void Constructor_ShouldSetInitialAvailableMemoryToMemoryCapacity()
        {
            Assert.AreEqual(_memoryCapacity, _device.AvailableMemory);
        }

        [Test]
        public void Constructor_ShouldSetInitialPhotosToZero()
        {
            Assert.AreEqual(0, _device.Photos);
        }

        [Test]
        public void Constructor_ShouldInitializeApplicationList()
        {
            Assert.IsNotNull(_device.Applications);
            Assert.AreEqual(0, _device.Applications.Count);
        }

        [TestCase(101)]
        [TestCase(200)]
        public void TakePhoto_ShouldReturnFalse_IfPhotoSizeIsBiggerThanAvailableMemory(int photosize)
        {
            Assert.That(photosize > _device.AvailableMemory);
            Assert.IsFalse(_device.TakePhoto(photosize));
        }

        [TestCase(50)]
        [TestCase(100)]
        public void TakePhoto_ShouldReturnTrue_IfPhotoSizeIsLessOrEqualToAvailableMemory(int photosize)
        {
            Assert.That(photosize <= _device.AvailableMemory);
            Assert.IsTrue(_device.TakePhoto(photosize));
        }

        [TestCase(50)]
        [TestCase(100)]
        public void TakePhoto_ShouldReduceAvailableMemory_WhenSuccessfullyTakingAPhoto(int photosize)
        {
            int expectedResult = _device.AvailableMemory - photosize;
            _device.TakePhoto(photosize);
            Assert.AreEqual(expectedResult, _device.AvailableMemory);
        }

        [Test]
        public void TakePhoto_ShouldIncreasePhotoCount_WhenSuccessfullyTakingAPhoto()
        {
            int expectedResult = 1;
            Assert.AreEqual(0, _device.Photos);
            _device.TakePhoto(_appropriateFileSize);
            Assert.AreEqual(expectedResult, _device.Photos);
        }

        [TestCase(101)]
        [TestCase(200)]
        public void InstallApp_ThrowException_WhenAppSizeIsBiggerThanAvailableMemory(int appSize)
        {
            Assert.That(appSize > _device.AvailableMemory);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
               () => _device.InstallApp(_appName, appSize));
            Assert.AreEqual("Not enough available memory to install the app.", exception.Message);
        }

        [TestCase(100)]
        [TestCase(50)]
        public void InstallApp_ShouldReturnCorrectString_WhenAppSizeIsLessOrEqualToAvailableMemory(int appSize)
        {
            Assert.That(appSize <= _device.AvailableMemory);
            Assert.AreEqual($"{_appName} is installed successfully. Run application?", _device.InstallApp(_appName, appSize));
        }

        [TestCase(100)]
        [TestCase(50)]
        public void InstallApp_ShouldReduceAvailableMemory_WhenSuccessfullyInstallingAnApp(int appSize)
        {
            Assert.That(appSize <= _device.AvailableMemory);
            int expectedResult = _device.AvailableMemory - appSize;
            _device.InstallApp(_appName, appSize);
            Assert.AreEqual(expectedResult, _device.AvailableMemory);
        }

        [Test]
        public void InstallApp_ShouldAddAppNameToAppList_WhenSuccessfullyInstallingAnApp()
        {
            Assert.IsFalse(_device.Applications.Contains(_appName));
            _device.InstallApp(_appName, _appropriateFileSize);
            Assert.IsTrue(_device.Applications.Contains(_appName));
        }

        [Test]
        public void FormatDevice_ShouldSetPhotosToZero()
        {
            _device.TakePhoto(_appropriateFileSize);
            Assert.IsTrue(_device.Photos > 0);
            _device.FormatDevice();
            Assert.IsTrue(_device.Photos == 0);
        }

        [Test]
        public void FormatDevice_ShouldClearAppList()
        {
            _device.InstallApp(_appName, _appropriateFileSize);
            Assert.IsTrue(_device.Applications.Count > 0);
            _device.FormatDevice();
            Assert.IsTrue(_device.Applications.Count == 0);
        }

        [Test]
        public void FormatDevice_ShouldResetAvailableMemoryToInitialMemoryCapacity()
        {
            _device.InstallApp(_appName, _appropriateFileSize);
            Assert.IsTrue(_device.AvailableMemory < _memoryCapacity);
            _device.FormatDevice();
            Assert.IsTrue(_device.AvailableMemory == _memoryCapacity);
        }

        [Test]
        public void GetDeviceStatus_ShouldReturnCorrectly()
        {
            _device.TakePhoto(_appropriateFileSize);
            int expectedMemory = _memoryCapacity - _appropriateFileSize * 3;
            _device.InstallApp(_appName, _appropriateFileSize);
            _device.InstallApp(_appName, _appropriateFileSize);
            StringBuilder expectedResult = new StringBuilder();
            expectedResult.AppendLine($"Memory Capacity: {_memoryCapacity} MB, Available Memory: {expectedMemory} MB");
            expectedResult.AppendLine($"Photos Count: 1");
            expectedResult.AppendLine($"Applications Installed: {_appName}, {_appName}");

            Assert.AreEqual(expectedResult.ToString().TrimEnd(), _device.GetDeviceStatus());
        }
    }
}