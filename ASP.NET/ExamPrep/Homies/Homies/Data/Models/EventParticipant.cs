using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data.Models;

/// <summary>
/// Represents the many-to-many relationship between participants and events.
/// Each participant can join multiple events, and each event can have multiple participants.
/// </summary>
public class EventParticipant
{
    /// <summary>
    /// The identifier of the participant (user) associated with the event.
    /// </summary>
    [Comment("User identifier")]
    public string HelperId { get; set; } = null!;

    /// <summary>
    /// Navigation property for the participant (user) associated with this event.
    /// </summary>
    public IdentityUser Helper { get; set; } = null!;

    /// <summary>
    /// The identifier of the event associated with the participant.
    /// </summary>
    [Comment("Event identifier")]
    public int EventId { get; set; }

    /// <summary>
    /// Navigation property for the event associated with this participant.
    /// </summary>
    public Event Event { get; set; } = null!;
}
