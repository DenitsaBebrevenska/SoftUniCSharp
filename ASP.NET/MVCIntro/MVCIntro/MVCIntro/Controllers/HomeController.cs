using Microsoft.AspNetCore.Mvc;
using MVCIntro.Models;
using System.Diagnostics;

namespace MVCIntro.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Loaded home index page");
        ViewBag.Message = "Hello World!";
        return View();
    }

    public IActionResult About()
    {
        ViewBag.Title = "AboutPage";
        ViewBag.Message = "This is an ASP.NET Core MVC app.";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Numbers()
    {
        ViewBag.Tittle = "Nums 1 ... 50";
        return View();
    }

    [HttpGet]
    public IActionResult NumbersToN(int n = 3)
    {
        ViewBag.Number = n;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
