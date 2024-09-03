using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			if (User.Identity != null && User.Identity.IsAuthenticated)
			{
				return RedirectToAction("All", "Game");
			}

			return View();
		}

	}
}
