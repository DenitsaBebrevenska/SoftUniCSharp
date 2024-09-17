using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Admin.Rent;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;
public class RentService : IRentService
{
	private readonly IRepository _repository;

	public RentService(IRepository repository)
	{
		_repository = repository;
	}
	public async Task<IEnumerable<RentServiceModel>> AllAsync()
	{
		return await _repository
			.GetAllReadOnly<House>()
			.Include(h => h.Agent)
			.Include(h => h.Renter)
			.Where(h => h.RenterId != null)
			.Select(h => new RentServiceModel()
			{
				HouseTitle = h.Title,
				HouseImageUrl = h.ImageUrl,
				AgentEmail = h.Agent.User.Email,
				AgentFullName = $"{h.Agent.User.FirstName} {h.Agent.User.LastName}",
				RenterEmail = h.Renter!.Email,
				RenterFullName = $"{h.Renter.FirstName} {h.Renter.LastName}"
			})
			.ToListAsync();
	}
}
