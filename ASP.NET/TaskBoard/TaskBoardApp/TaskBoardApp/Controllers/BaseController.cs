using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoardApp.Controllers;

/// <summary>
/// The base controller that all controllers will inherit except home. It requires authorization by default.
/// </summary>

[Authorize]
public class BaseController : Controller
{
}
