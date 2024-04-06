namespace InfluencerManagerApp.Models.Campaigns
{
    public class ProductCampaign : Campaign
    {
        private const double ProductCampaignBudget = 60_000;
        public ProductCampaign(string brand)
            : base(brand, ProductCampaignBudget)
        {
        }
    }
}
