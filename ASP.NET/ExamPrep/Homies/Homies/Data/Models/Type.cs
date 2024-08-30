using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Homies.Data.Configuration.DataConstraints;

namespace Homies.Data.Models;

/// <summary>
/// Type table
/// </summary>
public class Type
{
    /// <summary>
    /// Event type identifier
    /// </summary>
    [Key]
    [Comment("Event type identifier")]
    public int Id { get; set; }

    /// <summary>
    /// Event type name
    /// </summary>
    [Required]
    [MaxLength(EventTypeNameMaxLength)]
    [Comment("Event type name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Relationship to Event table => one type to many events
    /// </summary>
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
