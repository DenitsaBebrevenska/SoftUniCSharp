﻿using HouseRentingSystem.Attributes;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
    public IActionResult All()
    {
        return View(new AllHousesQueryModel());
    }

    [HttpGet]
    public IActionResult Mine()
    {
        return View(new AllHousesQueryModel());
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        return View(new HouseDetailsViewModel());
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
            ModelState.AddModelError(nameof(model.CategoryId), "");
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

    [HttpPost]
    public IActionResult Add(int id, HouseFormViewModel model)
    {
        return RedirectToAction(nameof(Details), new { id = "1" });
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
