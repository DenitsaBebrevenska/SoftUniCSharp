using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers;
public class GameController : Controller
{
    public IActionResult All()
    {
        return View();
    }
}
