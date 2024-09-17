using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers;
public class UsersController : AdminBaseController
{
	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		_userService = userService;
	}

	public async Task<IActionResult> Index()
	{
		var model = await _userService.AllAsync();

		return View(model);
	}
}
