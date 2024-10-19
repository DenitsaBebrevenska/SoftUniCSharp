namespace DeskMarket.Common.Constants;
/// <summary>
/// Contains globally accessible constants.
/// These constants include default validation error messages and formatting strings.
/// </summary>
public class GlobalConstants
{
    /// <summary>
    /// Default error message for string length validation.
    /// </summary>
    public const string StringLengthValidationErrorMessage =
        "The field {0} must be between {2} and {1} characters long.";

    /// <summary>
    /// Default error message for required field validation.
    /// </summary>
    public const string RequiredValidationErrorMessage =
        "The field {0} is required.";


    /// <summary>
    /// Default format string for displaying and parsing date and time values.
    /// The format used is "dd-MM-yyyy".
    /// </summary>
    public const string DefaultDateTimeFormat = "dd-MM-yyyy";
}
