using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.Configuration.DataConstraints;

namespace Homies.Data.Models;

/// <summary>
/// Represents an event with its details
/// </summary>
public class Event
{
    /// <summary>
    /// The event identifier
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// The event name
    /// </summary>
    [Required]
    [MaxLength(EventNameMaxLength)]
    [Comment("Event name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// The event description
    /// </summary>
    [Required]
    [MaxLength(EventDescriptionMaxLength)]
    [Comment("Event description")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// The identifier of the user that organized the event
    /// </summary>
    [Comment("Event organiser user identifier")]
    public string OrganiserId { get; set; } = null!;

    public IdentityUser Organiser { get; set; } = null!;

    /// <summary>
    /// Date and time of event creation
    /// </summary>
    [Comment("Event date and time of creation")]
    public DateTime CreatedOn { get; set; }

    /// <summary>
    /// Date and time of event start
    /// </summary>
    [Comment("Event start date and time")]
    public DateTime Start { get; set; }

    /// <summary>
    /// Date and time of event end
    /// </summary>
    [Comment("Event end date and time")]
    public DateTime End { get; set; }

    /// <summary>
    /// The type identifier of the event
    /// </summary>
    [Comment("The event type identifier")]
    public int TypeId { get; set; }

    public Type Type { get; set; } = null!;

    /// <summary>
    /// A collection of participants associated with the event.
    /// Represents a many-to-many relationship with the EventParticipant entity.
    /// </summary>
    public ICollection<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
}
