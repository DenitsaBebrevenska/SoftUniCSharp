using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data.Models;

/// <summary>
/// EventsParticipants table: a many-to-many relationship establishing table.
/// Many participants can take part in many events
/// </summary>
public class EventParticipant
{
    /// <summary>
    /// The identifier of the user that participates the event
    /// </summary>
    [Comment("User identifier")]
    public string HelperId { get; set; } = null!;

    public IdentityUser Helper { get; set; } = null!;

    /// <summary>
    /// The identifier of the event
    /// </summary>
    [Comment("Event identifier")]
    public int EventId { get; set; }

    public Event Event { get; set; } = null!;
}
