using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models.Game;
using GameZone.Models.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using static GameZone.Common.Constants.GlobalConstants;

namespace GameZone.Controllers;

[Authorize]
public class GameController : Controller
{
	private readonly GameZoneDbContext _context;

	public GameController(GameZoneDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> All()
	{
		var games = await _context
			.Games
			.AsNoTracking()
			.Select(g => new GameViewModel()
			{
				Id = g.Id,
				ImageUrl = g.ImageUrl,
				Title = g.Title,
				Publisher = g.PublisherId,
				ReleasedOn = g.ReleasedOn.ToString(DefaultDateTimeFormat),
				Genre = g.Genre.Name
			})
			.ToListAsync();

		return View(games);
	}

	[HttpGet]
	public async Task<IActionResult> Add()
	{
		var model = new GameFormViewModel();
		model.Genres = await GetAvailableGenreModels();

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Add(GameFormViewModel model)
	{
		if (!ModelState.IsValid)
		{
			model.Genres = await GetAvailableGenreModels();

			return View(model);
		}

		var game = new Game()
		{
			Title = model.Title,
			Description = model.Description,
			ImageUrl = model.ImageUrl,
			ReleasedOn = DateTime.ParseExact(model.ReleasedOn, DefaultDateTimeFormat, CultureInfo.InvariantCulture),
			PublisherId = GetCurrentUserUsername(),
			GenreId = model.GenreId
		};

		await _context.Games.AddAsync(game);
		await _context.SaveChangesAsync();

		return RedirectToAction(nameof(All));

	}

	[HttpGet]

	private async Task<ICollection<GenreFormViewModel>> GetAvailableGenreModels()
		=> await _context
			.Genres
			.AsNoTracking()
			.Select(g => new GenreFormViewModel()
			{
				Id = g.Id,
				Name = g.Name
			})
			.ToListAsync();

	private string GetCurrentUserUsername()
		=> User.FindFirstValue(ClaimTypes.NameIdentifier);
}
