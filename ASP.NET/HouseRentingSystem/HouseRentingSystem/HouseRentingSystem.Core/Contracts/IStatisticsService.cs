using HouseRentingSystem.Core.Models.Statistic;

namespace HouseRentingSystem.Core.Contracts;
public interface IStatisticsService
{
	Task<StatisticServiceModel> TotalAsync();
}
