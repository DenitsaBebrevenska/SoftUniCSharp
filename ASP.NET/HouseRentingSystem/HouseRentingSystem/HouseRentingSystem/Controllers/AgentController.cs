using HouseRentingSystem.Models.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

[Authorize]
public class AgentController : Controller
{
	[HttpPost]
	public IActionResult Become(BecomeAgentFormModel model)
	{
		return RedirectToAction(nameof(HouseController.All), "House");
	}
}
