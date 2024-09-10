namespace HouseRentingSystem.Core.Models.House;
public class HouseQueryViewModel
{
    public int TotalHousesCount { get; set; }

    public IEnumerable<HouseViewModel> Houses { get; set; } = new List<HouseViewModel>();
}
