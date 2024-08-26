using ForumApp.Core.Contracts;
using ForumApp.Infrastructure.Models;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers;
public class PostController : Controller
{
	private readonly IPostService _service;

	public PostController(IPostService service)
	{
		_service = service;
	}

	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var posts = await _service
			.GetAllAsync();
		var models = posts
			.Select(p => new PostViewModel()
			{
				Id = p.Id,
				Title = p.Tittle,
				Content = p.Content
			});
		return View(models);
	}

	[HttpGet]
	public IActionResult Add()
	{
		return View(new PostViewModel());
	}

	[HttpPost]
	public async Task<IActionResult> Add(PostViewModel model)
	{
		if (ModelState.IsValid)
		{
			await _service.AddAsync(new Post()
			{
				Tittle = model.Title,
				Content = model.Content
			});
		}

		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		var model = await _service.GetByIdAsync(id);
		return View(model);
	}

	[HttpPost]
	public Task<IActionResult> Edit()
	{

	}
}
