using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Areas.Admin.Controllers;
public class HomeController : AdminBaseController
{
	public IActionResult Dashboard()
	{
		return View();
	}
}
