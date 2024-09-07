using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers;

public class HouseController : BaseController
{
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
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(HouseFormViewModel model)
    {
        return RedirectToAction(nameof(Details), new { id = "1" });
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
