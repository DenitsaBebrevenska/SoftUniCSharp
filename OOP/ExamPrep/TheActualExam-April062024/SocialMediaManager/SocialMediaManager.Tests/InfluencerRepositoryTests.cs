namespace SocialMediaManager.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using NUnit.Framework;
    public class InfluencerRepositoryTests
    {
        private InfluencerRepository repository;
        private Influencer influencer1;
        private Influencer influencer2;
        private string username1 = "Twincle";
        private string username2 = "TomCat";
        private int followers1 = 20;
        private int followers2 = 2000;

        [SetUp]
        public void Setup()
        {
            repository = new InfluencerRepository();
            influencer1 = new Influencer(username1, followers1);
            influencer2 = new Influencer(username2, followers2);
        }

        [Test]
        public void Constructor_ShouldInitializeRepository()
        {
            Assert.IsNotNull(repository);
        }

        [Test]
        public void Constructor_ShouldInitializeInfluencerList()
        {
            Assert.IsNotNull(repository.Influencers);
        }

        [Test]
        public void RegisterInfluencer_ShouldAddInfluencerToInfluencerList()
        {
            Assert.IsFalse(repository.Influencers.Contains(influencer1));
            repository.RegisterInfluencer(influencer1);
            Assert.IsTrue(repository.Influencers.Contains(influencer1));
        }

        [Test]
        public void RegisterInfluencer_ShouldReturnCorrectString()
        {
            string expectedResult = $"Successfully added influencer {username1} with {followers1}";
            Assert.AreEqual(expectedResult, repository.RegisterInfluencer(influencer1));
        }

        [Test]
        public void RegisterInfluencer_ShouldThrowException_WhenInfluencerIsNull()
        {
            Influencer nullInfluencer = null;
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                repository.RegisterInfluencer(nullInfluencer));
            Assert.AreEqual("Influencer is null (Parameter 'influencer')", exception.Message);
            Assert.AreEqual("influencer", exception.ParamName);
        }

        [Test]
        public void RegisterInfluencer_ShouldThrowException_WhenAddingInfluencerThatAlreadyExists()
        {
            repository.RegisterInfluencer(influencer1);
            Assert.IsTrue(repository.Influencers.Contains(influencer1));
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                repository.RegisterInfluencer(influencer1));
            Assert.AreEqual($"Influencer with username {username1} already exists", exception.Message);
        }

        [Test]
        public void RemoveInfluencer_ShoulRemoveInfluencerFromInfluencerList()
        {
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            repository.RemoveInfluencer(username2);
            Assert.IsFalse(repository.Influencers.Contains(influencer2));
        }

        [Test]
        public void RemoveInfluencer_ShouldReturnTrue_WhenSuccessfullyRemoving()
        {
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            Assert.IsTrue(repository.RemoveInfluencer(username2));
        }

        [Test]
        public void RemoveInfluencer_ShouldReturnFalse_WhenUnsuccessfullyRemoving()
        {
            repository.RegisterInfluencer(influencer1);
            Assert.IsFalse(repository.RemoveInfluencer(username2));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        public void RemoveInfluencer_ShouldThrowException_WhenInfluencerUsernameIsNullOrWhitespace(string invalidUsername)
        {
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
                repository.RemoveInfluencer(invalidUsername));
            Assert.AreEqual("Username cannot be null (Parameter 'username')", exception.Message);
            Assert.AreEqual("username", exception.ParamName);
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ShouldReturnCorrectInfluencer()
        {
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            Assert.AreSame(influencer2, repository.GetInfluencerWithMostFollowers());
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ShouldReturnTheFirstUserWithThatManyFollowers()
        {
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            Influencer influencer3 = new Influencer("Any", followers2);
            repository.RegisterInfluencer(influencer3);
            Assert.AreSame(influencer2, repository.GetInfluencerWithMostFollowers());
        }


        [Test]
        public void GetInfluencer_ShouldReturnCorrectInfluencer()
        {
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            Assert.AreSame(influencer2, repository.GetInfluencer(username2));
        }

        [TestCase("Any")]
        [TestCase("NonExistent")]
        public void GetInfluencer_ShouldReturnNullForNonExistentInfluencer(string usernameNonExistent)
        {
            repository.RegisterInfluencer(influencer1);
            repository.RegisterInfluencer(influencer2);
            Assert.IsNull(repository.GetInfluencer(usernameNonExistent));
        }
    }
}