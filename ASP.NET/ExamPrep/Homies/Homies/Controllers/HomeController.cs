using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    /// <summary>
    /// Controller responsible for handling requests related to the home page.
    /// Accessible to both authenticated and unauthenticated users.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        /// <summary>
        /// Displays the home page for unauthenticated users.
        /// If the user is authenticated, redirects them to the event listing page.
        /// </summary>
        /// <returns>Home view for unauthenticated users, or a redirection to the event listing page for authenticated users.</returns>
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