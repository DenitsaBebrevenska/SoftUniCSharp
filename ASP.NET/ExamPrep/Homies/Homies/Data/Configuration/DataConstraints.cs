namespace Homies.Data.Configuration;

/// <summary>
/// Constraints for data model validations
/// </summary>
public static class DataConstraints
{
    /// <summary>
    /// Event name minimum length
    /// </summary>
    public const int EventNameMinLength = 5;

    /// <summary>
    /// Event name maximum length
    /// </summary>
    public const int EventNameMaxLength = 20;

    /// <summary>
    /// Event description minimum length
    /// </summary>
    public const int EventDescriptionMinLength = 15;

    /// <summary>
    /// Event description maximum length
    /// </summary>
    public const int EventDescriptionMaxLength = 150;

    /// <summary>
    /// Event type name minimum length
    /// </summary>
    public const int EventTypeNameMinLength = 5;

    /// <summary>
    /// Event type name maximum length
    /// </summary>
    public const int EventTypeNameMaxLength = 15;
}
