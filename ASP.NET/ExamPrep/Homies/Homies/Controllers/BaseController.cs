using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers;

/// <summary>
/// Serves as the base controller for the application, enforcing authorization requirements
/// for all derived controllers.
/// </summary>
[Authorize]
public class BaseController : Controller
{
}
