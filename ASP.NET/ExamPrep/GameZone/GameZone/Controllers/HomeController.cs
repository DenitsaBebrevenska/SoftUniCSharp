using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
	/// <summary>
	/// Controller responsible for handling requests related to the home page.
	/// Accessible to both authenticated and unauthenticated users.
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// Displays the home page for unauthenticated users.
		/// If the user is authenticated, redirects them to the event listing page.
		/// </summary>
		/// <returns>Home view for unauthenticated users, or a redirection to the event listing page for authenticated users.</returns>
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
