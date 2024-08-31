namespace Homies.Models.Type;

/// <summary>
/// Type view model used in the Event form
/// Does not get validation as it does not concern user input
/// </summary>
public class TypeFormViewModel
{
    /// <summary>
    /// Type identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Type name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
