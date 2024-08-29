namespace TaskBoardApp.Models;

/// <summary>
/// Error messages for the view model validations
/// </summary>
public static class ModelValidationErrorMessages
{
    /// <summary>
    /// Error message for required fields
    /// </summary>
    public const string RequiredField = "The field is required.";

    /// <summary>
    /// Error message for the length of the string in a field
    /// </summary>
    public const string StringLength = "The field {0} must be between {2} and {1} characters long.";
}
