using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HouseRentingSystem.Controllers;

public class AgentController : BaseController
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    [HttpPost]
    public async Task<IActionResult> Become(BecomeAgentFormModel model)
    {
        if (await _agentService.ExistsByIdAsync(User.Id()))
        {
            return BadRequest();
        }


        return RedirectToAction(nameof(HouseController.All), "House");
    }
}
