namespace GameZone.Common.Constants;

/// <summary>
/// Contains globally accessible constants.
/// These constants include default validation error messages and formatting strings.
/// </summary>
public static class GlobalConstants
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
	/// The format used is "yyyy-MM-dd".
	/// </summary>
	public const string DefaultDateTimeFormat = "yyyy-MM-dd";

}
