using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HouseRentingSystem.Areas.Admin.Controllers;
public class HouseController : AdminBaseController
{
	private readonly IHouseService _houseService;
	private readonly IAgentService _agentService;

	public HouseController(IHouseService houseService,
		IAgentService agentService)
	{
		_houseService = houseService;
		_agentService = agentService;
	}

	public async Task<IActionResult> Mine()
	{
		var currentUserId = User.Id();
		var agentId = await _agentService.GetAgentIdAsync(currentUserId) ?? 0;

		var myHouses = new MyHousesViewModel()
		{
			AddedHouses = await _houseService.AllHousesByAgentIdAsync(agentId),
			RentedHouses = await _houseService.AllHousesByUserIdAsync(currentUserId)
		};

		return View(myHouses);
	}
}
