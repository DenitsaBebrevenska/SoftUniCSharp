using System.ComponentModel;

namespace HouseRentingSystem.Core.Models.Agent;
public class AgentViewModel
{
    public string Email { get; set; } = null!;

    [DisplayName("Phone Number")]
    public string PhoneNumber { get; set; } = null!;
}
