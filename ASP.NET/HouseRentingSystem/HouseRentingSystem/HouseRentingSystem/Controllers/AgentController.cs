using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Agent;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.ValidationErrorMessages;

namespace HouseRentingSystem.Controllers;

public class AgentController : BaseController
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    [HttpGet]
    [NotAnAgent]
    public IActionResult Become()
        => View(new BecomeAgentFormModel());

    [HttpPost]
    [NotAnAgent]
    public async Task<IActionResult> Become(BecomeAgentFormModel model)
    {
        if (await _agentService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
        {
            ModelState.AddModelError(nameof(model.PhoneNumber), PhoneNumberExistsMessage);
        }

        if (await _agentService.UserHasRentsAsync(User.Id()))
        {
            ModelState.AddModelError("Error", UserHasRentsMessage);
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _agentService.CreateAsync(User.Id(), model.PhoneNumber);

        return RedirectToAction(nameof(HouseController.All), "House");
    }
}
