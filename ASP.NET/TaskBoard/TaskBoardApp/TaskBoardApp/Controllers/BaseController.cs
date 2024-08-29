using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoardApp.Controllers;

/// <summary>
/// The base controller that all controllers will inherit except home will require authorization
/// </summary>

[Authorize]
public class BaseController : Controller
{
}
