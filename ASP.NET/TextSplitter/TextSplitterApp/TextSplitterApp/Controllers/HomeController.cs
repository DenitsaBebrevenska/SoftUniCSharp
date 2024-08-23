using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers;
public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public IActionResult Index(TextViewModel textModel)
	{
		return View(textModel);
	}

	[HttpPost]
	public IActionResult Split(TextViewModel textModel)
	{
		var words = textModel.Text
			.Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.ToArray();

		textModel.WordsOfText = string.Join(Environment.NewLine, words);

		return RedirectToAction("Index", textModel);
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
