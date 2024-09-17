using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers;
public class RentsController : AdminBaseController
{
	private readonly IRentService _rentService;

	public RentsController(IRentService rentService)
	{
		_rentService = rentService;
	}
	public async Task<IActionResult> Index()
	{
		var model = await _rentService.AllAsync();
		return View(model);
	}
}
