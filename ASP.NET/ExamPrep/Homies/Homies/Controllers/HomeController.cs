using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    /// <summary>
    /// Home controller, available to not logged-in users
    /// </summary>
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        /// <summary>
        /// Display home page for not logged-in users and
        /// redirects to Event/All when user is logged-in
        /// </summary>
        /// <returns></returns>
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