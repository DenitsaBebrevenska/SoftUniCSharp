namespace Homies.Models.Event;

/// <summary>
/// Event view model for /All and /Joined
/// Does not get validation as it does not concern user input
/// </summary>
public class EventViewModel
{
    /// <summary>
    /// Event identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Event name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Event start date and time
    /// </summary>
    public string Start { get; set; } = null!;

    /// <summary>
    /// Event`s type name
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Event`s organiser user identifier
    /// </summary>
    public string Organiser { get; set; } = null!;
}
