using ForumApp.Core.Contracts;
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
	public async Task<IActionResult> Index()
	{
		var posts = await _service
			.GetAll();
		var models = posts
			.Select(p => new PostViewModel()
			{
				Id = p.Id,
				Title = p.Tittle,
				Content = p.Content
			});
		return View(models);
	}

	public IActionResult Add()
	{
		return View();
	}
}
