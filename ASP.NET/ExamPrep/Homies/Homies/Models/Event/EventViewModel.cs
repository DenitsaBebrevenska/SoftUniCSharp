namespace Homies.Models.Event;

/// <summary>
/// View model representing an event for display purposes.
/// This model is used for displaying event information in the /All and /Joined views.
/// It does not include validation as it is intended solely for displaying data and does not deal with user input
/// </summary>
public class EventViewModel
{
    /// <summary>
    /// The event identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The event name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// The Event start date and time
    /// </summary>
    public string Start { get; set; } = null!;

    /// <summary>
    /// The event`s type name
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// The event`s organiser user identifier
    /// </summary>
    public string Organiser { get; set; } = null!;
}
