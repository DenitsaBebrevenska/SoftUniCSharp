using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Models.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using static Homies.Common.Constants;

namespace Homies.Controllers;
public class EventController : Controller
{
    private readonly HomiesDbContext _context;

    public EventController(HomiesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var events = await _context.Events
            .Include(e => e.Type)
            .AsNoTracking()
            .Select(t => new EventViewModel()
            {
                Id = t.Id,
                Name = t.Name,
                Start = t.Start.ToString(DateAndTimeFormat),
                Type = t.Type.Name,
                Organiser = t.Organiser.UserName
            })
            .ToListAsync();

        return View(events);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new EventFormViewModel()
        {
            AvailableTypes = await GetAvailableTypes()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventFormViewModel model)
    {
        if (!ModelState.IsValid ||
            !DateTime.TryParseExact(
                model.Start,
                DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var startResult) ||
            !DateTime.TryParseExact(
                model.End,
                DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var endResult))
        {
            model.AvailableTypes = await GetAvailableTypes();
            return View(model);
        }

        var newEvent = new Event()
        {
            Name = model.Name,
            Description = model.Description,
            OrganiserId = GetUserId(),
            CreatedOn = DateTime.Now,
            Start = startResult,
            End = endResult,
            TypeId = model.TypeId
        };

        _context.Events.Add(newEvent);
        await _context.SaveChangesAsync();

        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Joined()
    {
        var userId = GetUserId();
        var joinedEvents = await _context
            .Events
            .Include(e => e.Type)
            .AsNoTracking()
            .Where(e => e.OrganiserId == userId)
            .Select(e => new JoinedEventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Organiser = e.OrganiserId,
                Start = e.Start.ToString(DateAndTimeFormat),
                Type = e.Type.Name
            })
            .ToListAsync();

        return View(joinedEvents);
    }
    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);

    private async Task<ICollection<TypeFormViewModel>> GetAvailableTypes()
    {
        return await _context
            .Types
            .AsNoTracking()
            .Select(t => new TypeFormViewModel()
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToListAsync();
    }
}
