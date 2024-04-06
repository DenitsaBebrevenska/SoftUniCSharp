namespace InfluencerManagerApp.Models.Influencers
{
    public class BloggerInfluencer : Influencer
    {
        private const double BloggerInfluencerRate = 2;
        private const double BloggerInfluencerFactor = 0.2;
        public BloggerInfluencer(string username, int followers)
            : base(username, followers, BloggerInfluencerRate)
        {
        }

        public override int CalculateCampaignPrice()
            => (int)(Followers * BloggerInfluencerRate * BloggerInfluencerFactor);
    }
}
