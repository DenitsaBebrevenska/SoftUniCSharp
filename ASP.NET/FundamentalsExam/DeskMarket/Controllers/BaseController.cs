using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeskMarket.Controllers;

/// <summary>
/// Base controller class that requires authorization for all derived controllers.
/// </summary>
[Authorize]
public class BaseController : Controller
{
}
