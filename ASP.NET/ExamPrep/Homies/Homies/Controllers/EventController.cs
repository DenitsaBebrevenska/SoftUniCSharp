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
/// Manages event-related actions accessible only to authenticated users.
/// </summary>
public class EventController : BaseController
{
    /// <summary>
    /// Database context for accessing event data.
    /// </summary>
    private readonly HomiesDbContext _context;

    /// <summary>
    /// Initializes the controller with the database context.
    /// </summary>
    /// <param name="context">The database context.</param>
    public EventController(HomiesDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves and displays a list of all events.
    /// </summary>
    /// <returns>The view showing all events</returns>
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var events = await _context
            .Events
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
    /// Prepares the event creation form with necessary data.
    /// </summary>
    /// <returns>The view for creating a new event.</returns>
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
    /// Validates and adds a new event to the database.
    /// Returns the same view if validation fails.
    /// </summary>
    /// <param name="model">The event form model.</param>
    /// <returns>Redirects to the list of all events on success; redisplays the form on failure.</returns>
    [HttpPost]
    public async Task<IActionResult> Add(EventFormViewModel model)
    {
        if (!DateTime.TryParseExact(
                model.Start,
                DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var startResult))
        {
            ModelState.AddModelError(nameof(model.Start), $"Start date format must be: {DateAndTimeFormat}");
        }

        if (!DateTime.TryParseExact(
                model.End,
                DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var endResult))
        {
            ModelState.AddModelError(nameof(model.End), $"End date format must be: {DateAndTimeFormat}");
        }
        if (!ModelState.IsValid)
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

        await _context.Events.AddAsync(newEvent);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }

    /// <summary>
    /// Displays all events the current user is participating in.
    /// </summary>
    /// <returns>The view showing the user's joined events.</returns>
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
    /// Prepares the event edit form with existing event data.
    /// Returns a bad request if the event is not found or the user is not the organizer.
    /// </summary>
    /// <param name="id">The event ID.</param>
    /// <returns>The view for editing an event.</returns>
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
    /// Validates and updates an existing event.
    /// Returns a bad request if the event is not found or the model is invalid.
    /// </summary>
    /// <param name="model">The event form model.</param>
    /// <param name="id">The event ID.</param>
    /// <returns>Redirects to the list of all events on success; redisplays the form on failure.</returns>
    [HttpPost]
    public async Task<IActionResult> Edit(EventFormViewModel model, int id)
    {
        var targetEvent = await _context
            .Events
            .FindAsync(id);

        if (targetEvent == null)
        {
            return BadRequest();
        }

        if (!DateTime.TryParseExact(
                model.Start,
                DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var startResult))
        {
            ModelState.AddModelError(nameof(model.Start), $"Start date format must be: {DateAndTimeFormat}");
        }

        if (!DateTime.TryParseExact(
                model.End,
                DateAndTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var endResult))
        {
            ModelState.AddModelError(nameof(model.End), $"End date format must be: {DateAndTimeFormat}");
        }

        if (!ModelState.IsValid)
        {
            model.AvailableTypes = await GetAvailableTypes();
            return View(model);
        }

        targetEvent.Name = model.Name;
        targetEvent.Description = model.Description;
        targetEvent.Start = startResult;
        targetEvent.End = endResult;
        targetEvent.TypeId = model.TypeId;

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(All));
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

        return RedirectToAction(nameof(Joined));
    }

    /// <summary>
    /// Adds the current user as a participant to an event.
    /// Returns a bad request if the event is not found or the user is already a participant or the organizer.
    /// </summary>
    /// <param name="id">The event ID.</param>
    /// <returns>Redirects to the list of joined events.</returns>
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

        return RedirectToAction(nameof(All));
    }


    /// <summary>
    /// Displays detailed information about a specific event.
    /// Validates the event ID, returning a BadRequest result if the event is not found.
    /// </summary>
    /// <param name="id">The event ID.</param>
    /// <returns>The view displaying event details, or BadRequest if the event is not found.</returns>
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
    /// Retrieves the identifier of the currently logged-in user.
    /// </summary>
    /// <returns>The user ID as a string.</returns>
    private string GetUserId()
        => User.FindFirstValue(ClaimTypes.NameIdentifier);

    /// <summary>
    /// Retrieves a list of available event types from the database.
    /// </summary>
    /// <returns>A collection of type view models.</returns>
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
