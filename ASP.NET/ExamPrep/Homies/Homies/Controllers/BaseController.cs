using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers;

/// <summary>
/// Base model, requires authorization
/// </summary>
[Authorize]
public class BaseController : Controller
{
}
