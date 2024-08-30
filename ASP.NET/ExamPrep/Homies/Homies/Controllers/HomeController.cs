using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var userIsAuthenticated = User.Identity.IsAuthenticated;

            if (userIsAuthenticated)
            {
                return RedirectToAction("All", "Event");
            }

            return View();
        }

    }
}