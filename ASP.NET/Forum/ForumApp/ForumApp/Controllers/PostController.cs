using ForumApp.Core.Contracts;
using ForumApp.Infrastructure.Data.Models;
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
			.Select(p => new PostModel()
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
		return View(new PostModel());
	}

	[HttpPost]
	public async Task<IActionResult> Add(PostModel model)
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
		return View(new PostModel()
		{
			Id = model.Id,
			Title = model.Tittle,
			Content = model.Content
		});
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, PostModel model)
	{
		if (!ModelState.IsValid || model.Id != id)
		{
			return View(model);
		}

		await _service.UpdateAsync(new Post()
		{
			Id = model.Id,
			Tittle = model.Title,
			Content = model.Content
		});

		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
		await _service.DeleteAsync(id);
		return RedirectToAction(nameof(Index));
	}
}
