namespace Homies.Models.Event;

/// <summary>
/// View model for displaying detailed information about an event.
/// This model is used for read-only operations and does not include validation as it does not deal with user input.
/// </summary>
public class EventDetailsViewModel
{
    /// <summary>
    /// The event identifier
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// The event name
    /// </summary>
    public string Name { get; init; } = null!;

    /// <summary>
    /// Event description
    /// </summary>
    public string Description { get; init; } = null!;

    /// <summary>
    /// The date and time of event creation 
    /// </summary>
    public string CreatedOn { get; init; } = null!;

    /// <summary>
    /// The date and time of event start 
    /// </summary>
    public string Start { get; init; } = null!;

    /// <summary>
    /// The date and time of event end 
    /// </summary>
    public string End { get; init; } = null!;

    /// <summary>
    /// The event`s type name
    /// </summary>
    public string Type { get; init; } = null!;

    /// <summary>
    /// The event organiser user identifier
    /// </summary>
    public string Organiser { get; init; } = null!;
}
