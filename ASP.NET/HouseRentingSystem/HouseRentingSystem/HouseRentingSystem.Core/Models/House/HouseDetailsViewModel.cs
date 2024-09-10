using HouseRentingSystem.Core.Models.Agent;

namespace HouseRentingSystem.Core.Models.House;

public class HouseDetailsViewModel : HouseViewModel
{
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;

    public AgentViewModel Agent { get; set; } = null!;
}
