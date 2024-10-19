using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeskMarket.Controllers
{
    /// <summary>
    /// Controller for handling the home page of the application.
    /// Inherits from <see cref="BaseController"/> and allows anonymous access to the Index action.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// Handles GET requests for the home page.
        /// If the user is authenticated, they are redirected to the Product/Index.
        /// Otherwise, the home page view is returned.
        /// </summary>
        /// <returns>
        /// A <see cref="IActionResult"/> that either renders the home page view or redirects the user to the Product page if authenticated.
        /// </returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Product");
            }

            return View();
        }
    }
}
