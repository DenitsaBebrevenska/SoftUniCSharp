using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem.Controllers;
public class HomeController : BaseController
{
    private readonly IHouseService _houseService;

    public HomeController(IHouseService houseService)
    {
        _houseService = houseService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
        => View(await _houseService
            .LastThreeHousesAsync());

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
