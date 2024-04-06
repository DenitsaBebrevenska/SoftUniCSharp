namespace SocialMediaManager.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using NUnit.Framework;
    public class InfluencerTests
    {
        private Influencer influencer;
        private string username = "Twincle";
        private int followers = 20;

        [SetUp]
        public void Setup()
        {
            influencer = new Influencer(username, followers);
        }

        [Test]
        public void Constructor_ShouldInitializeInfluencer()
        {
            Assert.IsNotNull(influencer);
        }

        [Test]
        public void Constructor_ShouldSetUsernameCorrectly()
        {
            Assert.AreEqual(username, influencer.Username);
        }

        [Test]
        public void Constructor_ShouldSetFollowersCorrectly()
        {
            Assert.AreEqual(followers, influencer.Followers);
        }
    }
}