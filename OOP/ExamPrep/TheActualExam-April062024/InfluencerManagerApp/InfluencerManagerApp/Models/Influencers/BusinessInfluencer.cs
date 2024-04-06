namespace InfluencerManagerApp.Models.Influencers
{
    public class BusinessInfluencer : Influencer
    {
        private const double BusinessInfluencerRate = 3;
        private const double BusinessInfluencerFactor = 0.15;
        public BusinessInfluencer(string username, int followers)
            : base(username, followers, BusinessInfluencerRate)
        {
        }

        //round down instead since won`t be different from math.floor
        public override int CalculateCampaignPrice()
            => (int)(Followers * BusinessInfluencerRate * BusinessInfluencerFactor);
    }
}
