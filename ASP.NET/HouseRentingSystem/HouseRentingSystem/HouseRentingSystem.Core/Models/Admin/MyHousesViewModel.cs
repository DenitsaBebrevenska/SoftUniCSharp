using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Models.Admin;
public class MyHousesViewModel
{
	public IEnumerable<HouseViewModel> AddedHouses { get; set; } = new List<HouseViewModel>();

	public IEnumerable<HouseViewModel> RentedHouses { get; set; } = new List<HouseViewModel>();
}
