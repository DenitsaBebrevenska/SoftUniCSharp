namespace Homies.Models.Type;

/// <summary>
/// View model representing an event type.
/// This model is used to populate dropdowns or selection lists in event-related forms.
/// It does not include validation attributes as it does not deal with user input.
///  </summary>
public class TypeFormViewModel
{
    /// <summary>
    /// The type identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The type name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
