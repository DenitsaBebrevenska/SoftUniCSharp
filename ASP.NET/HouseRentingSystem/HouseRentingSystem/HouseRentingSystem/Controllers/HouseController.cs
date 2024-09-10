using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
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

        if (await _agentService.ExistsByIdAsync(userId))
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
    public async Task<IActionResult> Details(int id)
    {
        if (!await _houseService.HouseExistsAsync(id))
        {
            return BadRequest();
        }

        var model = await _houseService.HouseDetailsByIdAsync(id);
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

        return RedirectToAction(nameof(Details), new { id = newHouseId });
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        return View(new HouseFormViewModel());
    }


    [HttpGet]
    public IActionResult Delete(int id)
    {
        return View(new HouseDetailsViewModel());
    }

    [HttpPost]
    public IActionResult Delete(int id, HouseDetailsViewModel model)
    {
        return RedirectToAction(nameof(All));
    }

    [HttpPost]
    public IActionResult Rent(int id)
    {
        return RedirectToAction(nameof(Mine));
    }

    [HttpPost]
    public IActionResult Leave(int id)
    {
        return RedirectToAction(nameof(Mine));
    }
}
