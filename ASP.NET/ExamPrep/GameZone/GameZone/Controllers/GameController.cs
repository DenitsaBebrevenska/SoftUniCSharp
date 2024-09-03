using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models.Game;
using GameZone.Models.Genre;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
				Publisher = g.Publisher.UserName,
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
			PublisherId = GetCurrentUserId(),
			GenreId = model.GenreId
		};

		await _context.Games.AddAsync(game);
		await _context.SaveChangesAsync();

		return RedirectToAction(nameof(All));

	}

	[HttpGet]
	public async Task<IActionResult> MyZone()
	{
		var currentUserId = GetCurrentUserId();

		var userZone = await _context
			.Games
			.Where(g => g.GamersGames
				.Any(gg => gg.GamerId == currentUserId))
			.AsNoTracking()
			.Select(g => new GameViewModel()
			{
				Id = g.Id,
				ImageUrl = g.ImageUrl,
				Title = g.Title,
				Genre = g.Genre.Name,
				ReleasedOn = g.ReleasedOn.ToString(DefaultDateTimeFormat),
				Publisher = g.PublisherId
			})
			.ToListAsync();

		return View(userZone);
	}

	[HttpGet]
	public async Task<IActionResult> AddToMyZone(int id)
	{
		var game = await _context
			.Games
			.Include(g => g.GamersGames)
			.FirstOrDefaultAsync(g => g.Id == id);

		if (game == null)
		{
			return BadRequest();
		}

		var currentUserId = GetCurrentUserId();

		if (game.GamersGames
			.All(gg => gg.GamerId != currentUserId))
		{
			await _context.GamersGames
				.AddAsync(new GamerGame()
				{
					GameId = game.Id,
					GamerId = currentUserId
				});

			await _context.SaveChangesAsync();
		}

		return RedirectToAction(nameof(MyZone));
	}

	[HttpGet]
	public async Task<IActionResult> StrikeOut(int id)
	{
		var game = await _context
			.Games
			.Include(g => g.GamersGames)
			.FirstOrDefaultAsync(g => g.Id == id);

		if (game == null)
		{
			return BadRequest();
		}

		var currentUserId = GetCurrentUserId();
		var gamerGame = await _context
			.GamersGames
			.FirstAsync(gg => gg.GamerId == currentUserId && gg.GameId == game.Id);

		_context
			.GamersGames
			.Remove(gamerGame);

		await _context.SaveChangesAsync();

		return RedirectToAction(nameof(MyZone));
	}

	[HttpGet]
	public async Task<IActionResult> Edit(int id)
	{
		var game = await _context
			.Games
			.FindAsync(id);

		if (game == null)
		{
			return BadRequest();
		}

		if (game.PublisherId != GetCurrentUserId())
		{
			return Unauthorized();
		}

		var model = new GameFormViewModel()
		{
			Id = game.Id,
			Title = game.Title,
			Description = game.Description,
			ImageUrl = game.ImageUrl,
			ReleasedOn = game.ReleasedOn.ToString(DefaultDateTimeFormat),
			GenreId = game.GenreId,
			Genres = await GetAvailableGenreModels()
		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, GameFormViewModel model)
	{
		var game = await _context
			.Games
			.FindAsync(id);

		if (game == null)
		{
			return BadRequest();
		}

		if (game.PublisherId != GetCurrentUserId())
		{
			return Unauthorized();
		}

		if (!ModelState.IsValid)
		{
			return View(model);
		}

		game.Title = model.Title;
		game.ImageUrl = model.ImageUrl;
		game.Description = model.Description;
		game.ReleasedOn = DateTime.ParseExact(model.ReleasedOn, DefaultDateTimeFormat, CultureInfo.InvariantCulture);
		game.GenreId = model.GenreId;

		await _context.SaveChangesAsync();

		return RedirectToAction(nameof(All));
	}

	[HttpGet]
	public async Task<IActionResult> Details(int id)
	{
		var game = await _context
			.Games
			.Include(g => g.Publisher)
			.Include(g => g.Genre)
			.FirstOrDefaultAsync(g => g.Id == id);

		if (game == null)
		{
			return BadRequest();
		}

		var model = new GameDetailsViewModel()
		{
			Id = id,
			Title = game.Title,
			ImageUrl = game.ImageUrl,
			Description = game.Description,
			ReleasedOn = game.ReleasedOn.ToString(DefaultDateTimeFormat),
			Genre = game.Genre.Name,
			Publisher = game.Publisher.UserName
		};

		return View(model);
	}

	[HttpGet]
	public async Task<IActionResult> Delete(int id)
	{
		var game = await _context
			.Games
			.Include(g => g.Publisher)
			.FirstOrDefaultAsync(g => g.Id == id);

		if (game == null)
		{
			return BadRequest();
		}

		if (game.PublisherId != GetCurrentUserId())
		{
			return Unauthorized();
		}

		var model = new GameDeleteViewModel()
		{
			Id = game.Id,
			Title = game.Title,
			Description = game.Description,
			Publisher = game.Publisher.UserName
		};

		return View(model);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var game = await _context
			.Games
			.FirstOrDefaultAsync(g => g.Id == id);

		if (game == null)
		{
			return BadRequest();
		}

		if (game.PublisherId != GetCurrentUserId())
		{
			return Unauthorized();
		}

		var gamersGames = await _context
			.GamersGames
			.Where(gg => gg.GameId == id)
			.ToListAsync();

		_context.GamersGames
			.RemoveRange(gamersGames);

		_context
			.Games
			.Remove(game);

		await _context.SaveChangesAsync();

		return RedirectToAction(nameof(All));
	}
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

	private string GetCurrentUserId()
		=> User.FindFirstValue(ClaimTypes.NameIdentifier);
}
