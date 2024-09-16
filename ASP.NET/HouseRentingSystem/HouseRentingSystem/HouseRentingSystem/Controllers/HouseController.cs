using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Extensions;
using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.ValidationErrorMessages;

namespace HouseRentingSystem.Controllers;

public class HouseController : BaseController
{
    private readonly IHouseService _houseService;
    private readonly IAgentService _agentService;
    public HouseController(IHouseService houseService,
        IAgentService agentService)
    {
        _houseService = houseService;
        _agentService = agentService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> All([FromQuery] AllHousesQueryModel query)
    {
        var model = await _houseService
            .AllAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllHousesQueryModel.HousesPerPage);

        query.TotalHousesCount = model.TotalHousesCount;
        query.Houses = model.Houses;

        query.Categories = await _houseService.AllCategoriesNamesAsync();

        return View(query);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        IEnumerable<HouseViewModel> myHouses;

        var userId = User.Id();

        if (await _agentService.ExistsByIdAsync(userId) && !User.IsAdmin())
        {
            var currentAgentId = await _agentService.GetAgentIdAsync(userId) ?? 0;
            myHouses = await _houseService.AllHousesByAgentIdAsync(currentAgentId);
        }
        else
        {
            myHouses = await _houseService.AllHousesByUserIdAsync(userId);
        }

        return View(myHouses);
    }

    [HttpGet]
    [HouseExists]
    public async Task<IActionResult> Details(int id, string information)
    {
        var model = await _houseService.HouseDetailsByIdAsync(id);

        if (model.GetInformation() != information)
        {
            return BadRequest();
        }

        return View(model);
    }

    [HttpGet]
    [MustBeAgent]
    public async Task<IActionResult> Add()
    {
        var model = new HouseFormViewModel()
        {
            Categories = await _houseService.AllCategoriesAsync()
        };

        return View(model);
    }

    [HttpPost]
    [MustBeAgent]
    public async Task<IActionResult> Add(HouseFormViewModel model)
    {
        if (!await _houseService.CategoryExistsAsync(model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), InvalidCategoryMessage);
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await _houseService.AllCategoriesAsync();
            return View(model);
        }

        int? agentId = await _agentService.GetAgentIdAsync(User.Id());

        int newHouseId = await _houseService
            .CreateAsync(model, agentId ?? 0);

        return RedirectToAction(nameof(Details), new { id = newHouseId, information = model.GetInformation() });
    }

    [HttpGet]
    [HouseExists]
    [UserIsTheHouseAgentOrAdmin]
    public async Task<IActionResult> Edit(int id)
    {
        var model = await _houseService
            .GetHouseFormModelByIdAsync(id);

        return View(model);
    }

    [HttpPost]
    [HouseExists]
    [UserIsTheHouseAgentOrAdmin]
    public async Task<IActionResult> Edit(int id, HouseFormViewModel model)
    {
        if (!await _houseService.CategoryExistsAsync(model.CategoryId))
        {
            ModelState.AddModelError(nameof(model.CategoryId), InvalidCategoryMessage);
        }

        if (!ModelState.IsValid)
        {
            model.Categories = await _houseService.AllCategoriesAsync();
            return View(model);
        }

        await _houseService
            .EditAsync(id, model);

        return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
    }

    [HttpGet]
    [HouseExists]
    [UserIsTheHouseAgentOrAdmin]
    public async Task<IActionResult> Delete(int id)
    {
        var house = await _houseService.HouseDetailsByIdAsync(id);

        var model = new HouseDeleteViewModel()
        {
            Id = house.Id,
            Title = house.Title,
            Address = house.Address,
            ImageUrl = house.ImageUrl
        };

        return View(model);
    }

    [HttpPost]
    [HouseExists]
    [UserIsTheHouseAgentOrAdmin]
    public async Task<IActionResult> Delete(HouseDetailsViewModel model)
    {
        await _houseService.DeleteAsync(model.Id);
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    [HouseExists]
    public async Task<IActionResult> Rent(int id)
    {
        if (await _agentService.ExistsByIdAsync(User.Id()) &&
            !User.IsAdmin())
        {
            return Unauthorized();
        }

        if (!await _houseService.IsRentedAsync(id))
        {
            await _houseService.RentAsync(id, User.Id());
        }

        return RedirectToAction(nameof(Mine));
    }

    [HttpPost]
    [HouseExists]
    public async Task<IActionResult> Leave(int id)
    {
        if (!await _houseService.IsRentedAsync(id))
        {
            return BadRequest();
        }

        if (!await _houseService.IsRentedByUserWithIdAsync(id, User.Id()))
        {
            return Unauthorized();
        }

        await _houseService.LeaveAsync(id);

        return RedirectToAction(nameof(Mine));
    }
}
