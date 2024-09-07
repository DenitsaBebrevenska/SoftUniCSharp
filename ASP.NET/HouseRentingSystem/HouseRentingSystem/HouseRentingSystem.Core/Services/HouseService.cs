using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;
public class HouseService : IHouseService
{
	private readonly IRepository _repository;

	public HouseService(IRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<HouseIndexViewModel>> LastThreeHousesAsync()
		=> await _repository
			.GetAllReadOnly<House>()
			.OrderByDescending(h => h.Id)
			.Take(3)
			.Select(h => new HouseIndexViewModel()
			{
				Id = h.Id,
				ImageUrl = h.ImageUrl,
				Title = h.Title
			})
			.ToListAsync();
}
