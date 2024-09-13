using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistic;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;
public class StatisticsService : IStatisticsService
{
	private readonly IRepository _repository;

	public StatisticsService(IRepository repository)
	{
		_repository = repository;
	}
	public async Task<StatisticServiceModel> TotalAsync()
	{
		var houseCount = await _repository
			.GetAllReadOnly<House>()
			.CountAsync();

		var rentedHousesCount = await _repository
			.GetAllReadOnly<House>()
			.Where(h => h.RenterId != null)
			.CountAsync();

		return new StatisticServiceModel()
		{
			TotalHouses = houseCount,
			TotalRents = rentedHousesCount
		};
	}
}
