using ForumApp.Core.Contracts;
using ForumApp.Core.Models;
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
		return View(posts);
	}

	[HttpGet]
	public IActionResult Add()
	{
		return View(new PostModel());
	}

	[HttpPost]
	public async Task<IActionResult> Add(PostModel model)
	{
		if (!ModelState.IsValid)
		{
			return View(model);
		}

		await _service.AddAsync(model);

		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		var model = await _service.GetByIdAsync(id);
		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, PostModel model)
	{
		if (!ModelState.IsValid || model.Id != id)
		{
			return View(model);
		}

		await _service.UpdateAsync(model);

		return RedirectToAction(nameof(Index));
	}

	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
		await _service.DeleteAsync(id);
		return RedirectToAction(nameof(Index));
	}
}
