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

/// <summary>
/// Event controller, available only for logged-in users
/// </summary>
public class EventController : BaseController
{
    /// <summary>
    /// Db Context field
    /// </summary>
    private readonly HomiesDbContext _context;

    /// <summary>
    /// DI for DB context
    /// </summary>
    /// <param name="context"></param>
    public EventController(HomiesDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Displays all events
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Prepares an event view model and passes it to the view
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new EventFormViewModel()
        {
            AvailableTypes = await GetAvailableTypes()
        };

        return View(model);
    }


    /// <summary>
    /// Checks model validity and adds new event
    /// If model is invalid, returns the same model to the view
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Displays all events to which the current user is a participant of
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Joined()
    {
        var userId = GetUserId();
        var joinedEvents = await _context
            .Events
            .Include(e => e.Type)
            .Include(e => e.EventsParticipants)
            .AsNoTracking()
            .Where(e => e.OrganiserId != userId && e.EventsParticipants.Any(ep => ep.HelperId == userId))
            .Select(e => new EventViewModel()
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


    /// <summary>
    /// Prepares event view model and passes it to the view
    /// Validates the id, and if invalid, returns Bad request
    /// Edit is only available to event`s creator
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var targetEvent = await _context
            .Events
            .FindAsync(id);

        if (targetEvent == null)
        {
            return BadRequest();
        }

        var model = new EventFormViewModel()
        {
            Name = targetEvent.Name,
            Description = targetEvent.Description,
            Start = targetEvent.Start.ToString(DateAndTimeFormat),
            End = targetEvent.End.ToString(DateAndTimeFormat),
            TypeId = targetEvent.TypeId,
            AvailableTypes = await GetAvailableTypes()
        };

        return View(model);
    }

    /// <summary>
    /// Edits an event and redirects to /All
    /// Validates model and id and throws bad request if any of these is invalid
    /// Edit is only available to event`s creator
    /// </summary>
    /// <param name="model"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Edit(EventFormViewModel model, int id)
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

        var targetEvent = await _context
            .Events
            .FindAsync(id);

        targetEvent.Name = model.Name;
        targetEvent.Description = model.Description;
        targetEvent.Start = startResult;
        targetEvent.End = endResult;
        targetEvent.TypeId = model.TypeId;

        await _context.SaveChangesAsync();
        return RedirectToAction("All");
    }

    /// <summary>
    /// Adds a participant to an event and redirects to /Joined
    /// Validates id, if invalid returns BadRequest
    /// The event will be added only if the user is not the event`s creator
    /// or the event is not part of the collection of his events
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        var targetEvent = await _context
            .Events
            .Include(e => e.EventsParticipants)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (targetEvent == null)
        {
            return BadRequest();
        }

        var userId = GetUserId();

        bool userIsAParticipant = targetEvent
            .EventsParticipants
            .Any(p => p.HelperId == userId);
        bool userIsOwner = targetEvent
            .OrganiserId == userId;

        if (!userIsAParticipant && !userIsOwner)
        {
            targetEvent.EventsParticipants
                .Add(new EventParticipant()
                {
                    EventId = targetEvent.Id,
                    HelperId = userId
                });

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Joined");
    }

    /// <summary>
    /// Removes a participant from an event and redirects to /Joined
    /// Validates id, if invalid returns BadRequest
    /// The participant will be removed only if he is already
    /// taking part of the said event
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Leave(int id)
    {
        var targetEvent = await _context
            .Events
            .Include(e => e.EventsParticipants)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (targetEvent == null)
        {
            return BadRequest();
        }

        var userId = GetUserId();

        bool userIsAParticipant = targetEvent
            .EventsParticipants
            .Any(p => p.HelperId == userId);
        bool userIsOwner = targetEvent
            .OrganiserId == userId;

        if (userIsAParticipant && !userIsOwner)
        {
            var eventParticipant = await _context
                .EventsParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == userId
                                      && ep.EventId == targetEvent.Id);

            _context.EventsParticipants
                .Remove(eventParticipant);

            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Joined");
    }


    /// <summary>
    /// Displays the details of an event
    /// Validates id, if invalid returns BadRequest
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var targetEvent = await _context
            .Events
            .Include(e => e.Type)
            .Include(e => e.Organiser)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (targetEvent == null)
        {
            return BadRequest();
        }

        var model = new EventDetailsViewModel()
        {
            Id = targetEvent.Id,
            Name = targetEvent.Name,
            Description = targetEvent.Description,
            CreatedOn = targetEvent.CreatedOn.ToString(DateAndTimeFormat),
            Start = targetEvent.Start.ToString(DateAndTimeFormat),
            End = targetEvent.End.ToString(DateAndTimeFormat),
            Organiser = targetEvent.Organiser.UserName,
            Type = targetEvent.Type.Name
        };

        return View(model);
    }

    /// <summary>
    /// Returns the identifier of the current logged-in user
    /// </summary>
    /// <returns></returns>
    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);

    /// <summary>
    /// Returns a collection of all type names from table Types
    /// </summary>
    /// <returns></returns>
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
