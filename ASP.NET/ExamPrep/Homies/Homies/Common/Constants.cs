namespace Homies.Common;

/// <summary>
/// Constants, includes date time format through-out the whole app and some error messages
/// for data annotations
/// </summary>
public static class Constants
{
    /// <summary>
    /// Default date time format
    /// </summary>
    public const string DateAndTimeFormat = "yyyy-MM-dd H:mm";

    /// <summary>
    /// Error message for [StringLength] data annotation
    /// </summary>
    public const string StringLengthErrorMessage = "The {0} must be between {2} and {1} characters long.";

    /// <summary>
    /// Error message for [Required] data annotation
    /// </summary>
    public const string RequiredFieldErrorMessage = "The field {0} is required.";
}
