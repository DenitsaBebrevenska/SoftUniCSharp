using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.Configuration.DataConstraints;

namespace Homies.Data.Models;

/// <summary>
///  Represents a category or classification for events.
/// </summary>
public class Type
{
    /// <summary>
    /// The event type identifier
    /// </summary>
    [Key]
    [Comment("Event type identifier")]
    public int Id { get; set; }

    /// <summary>
    /// The event type name
    /// </summary>
    [Required]
    [MaxLength(EventTypeNameMaxLength)]
    [Comment("Event type name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the collection of events associated with this type.
    /// Represents a one-to-many relationship between types and events.
    /// </summary>
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
