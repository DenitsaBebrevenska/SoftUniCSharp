using HouseRentingSystem.Core.Models.Admin.Rent;

namespace HouseRentingSystem.Core.Contracts
{
	public interface IRentService
	{
		Task<IEnumerable<RentServiceModel>> AllAsync();
	}
}
