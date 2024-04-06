using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models.Campaigns;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Models.Influencers;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System.Text;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;
        private const double CampaignBudgetThreshold = 10_000;
        private const double InfluencerBonusIncome = 2_000;
        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }
        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            IInfluencer influencer;

            switch (typeName)
            {
                case "BusinessInfluencer":
                    influencer = new BusinessInfluencer(username, followers);
                    break;
                case "FashionInfluencer":
                    influencer = new FashionInfluencer(username, followers);
                    break;
                case "BloggerInfluencer":
                    influencer = new BloggerInfluencer(username, followers);
                    break;
                default:
                    return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.FindByName(username) != null)
            {
                return string.Format(OutputMessages.UsernameIsRegistered, username, nameof(InfluencerRepository));
            }

            influencers.AddModel(influencer);
            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            ICampaign campaign;

            switch (typeName)
            {
                case "ProductCampaign":
                    campaign = new ProductCampaign(brand);
                    break;
                case "ServiceCampaign":
                    campaign = new ServiceCampaign(brand);
                    break;
                default:
                    return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }

            if (campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            campaigns.AddModel(campaign);
            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotFound, nameof(InfluencerRepository), username);
            }

            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (campaign.Contributors.Any(c => c == username))
            {
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if ((campaign.GetType().Name == "ProductCampaign" && influencer.GetType().Name == "BloggerInfluencer")
                || (campaign.GetType().Name == "ServiceCampaign" && influencer.GetType().Name == "FashionInfluencer"))
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            influencer.EarnFee(influencer.CalculateCampaignPrice());
            influencer.EnrollCampaign(brand);
            campaign.Engage(influencer);

            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return OutputMessages.InvalidCampaignToFund;
            }

            if (amount <= 0)
            {
                return OutputMessages.NotPositiveFundingAmount;
            }

            campaign.Gain(amount);
            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            ICampaign campaign = campaigns.FindByName(brand);

            if (campaign == null)
            {
                return OutputMessages.InvalidCampaignToClose;
            }

            if (campaign.Budget <= CampaignBudgetThreshold)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var contributor in campaign.Contributors)
            {
                IInfluencer influencer = influencers.FindByName(contributor);
                influencer.EarnFee(InfluencerBonusIncome);
                influencer.EndParticipation(brand);
            }

            campaigns.RemoveModel(campaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);

            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }

            if (influencer.Participations.Any())
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(influencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            StringBuilder report = new StringBuilder();

            foreach (var influencer in influencers.Models
                         .OrderByDescending(i => i.Income)
                         .ThenByDescending(i => i.Followers))
            {
                report.AppendLine(influencer.ToString());

                if (influencer.Participations.Any())
                {
                    report.AppendLine("Active Campaigns:");

                    foreach (var brand in influencer.Participations
                                 .OrderBy(c => c))
                    {
                        ICampaign campaign = campaigns.FindByName(brand);
                        report.AppendLine($"--{campaign.ToString()}");
                    }
                }
            }

            return report.ToString().TrimEnd();
        }
    }
}
