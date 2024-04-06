namespace InfluencerManagerApp.Models.Influencers
{
    public class FashionInfluencer : Influencer
    {
        private const double FashionInfluencerRate = 4;
        private const double FashionInfluencerFactor = 0.1;
        public FashionInfluencer(string username, int followers)
            : base(username, followers, FashionInfluencerRate)
        {
        }

        public override int CalculateCampaignPrice()
            => (int)(Followers * FashionInfluencerRate * FashionInfluencerFactor);
    }
}
