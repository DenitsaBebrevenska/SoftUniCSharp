using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
	public IActionResult Error(int statusCode)
	{
		if (statusCode == 400)
		{
			return View("Error400");
		}

		if (statusCode == 401)
		{
			return View("Error401");
		}

		return View();
	}
}
