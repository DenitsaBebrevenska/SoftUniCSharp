using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers;
public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private TextViewModel _model = new TextViewModel();
	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public IActionResult Index()
	{
		if (TempData["SplitModel"] is string serializedModel)
		{
			return View(JsonSerializer.Deserialize<TextViewModel>(serializedModel));
		}
		return View(new TextViewModel());
	}

	[HttpPost]
	public IActionResult Split(TextViewModel model)
	{
		_model = model;
		var words = _model.Text
			.Split(' ', StringSplitOptions.RemoveEmptyEntries)
			.ToArray();

		_model.WordsOfText = string.Join(Environment.NewLine, words);
		TempData["SplitModel"] = JsonSerializer.Serialize(model);
		return RedirectToAction(nameof(Index));
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
