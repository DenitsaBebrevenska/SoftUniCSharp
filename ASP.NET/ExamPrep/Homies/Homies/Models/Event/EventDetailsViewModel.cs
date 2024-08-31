namespace Homies.Models.Event;

/// <summary>
/// View model for /Details form
/// The properties are not validated as they do not concert user input
/// </summary>
public class EventDetailsViewModel
{
    /// <summary>
    /// Even identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Event name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Event description
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Date and time of event creation 
    /// </summary>
    public string CreatedOn { get; set; } = null!;

    /// <summary>
    /// Date and time of event start 
    /// </summary>
    public string Start { get; set; } = null!;

    /// <summary>
    /// Date and time of event end 
    /// </summary>
    public string End { get; set; } = null!;

    /// <summary>
    /// Event`s type name
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Event organiser user identifier
    /// </summary>
    public string Organiser { get; set; } = null!;
}
