using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GameZone.Attributes;

/// <summary>
/// The attribute checks if a string property 
/// is in the correct date format specified by the provided format string.
/// </summary>
public class IsCorrectDateFormat : ValidationAttribute
{
	/// <summary>
	/// The expected date format that the string must match.
	/// </summary>
	private readonly string _dateFormat;

	/// <summary>
	/// Initializes a new instance of the <see cref="IsCorrectDateFormat"/> class 
	/// with the specified date format.
	/// </summary>
	/// <param name="dateFormat">The date format string that the input must match, e.g., "yyyy-MM-dd".</param>
	public IsCorrectDateFormat(string dateFormat)
	{
		_dateFormat = dateFormat;
	}

	/// <summary>
	/// Validates whether the given value matches the specified date format.
	/// </summary>
	/// <param name="value">The object to validate, expected to be a string.</param>
	/// <param name="validationContext">Provides contextual information about the validation operation.</param>
	/// <returns>
	/// A <see cref="ValidationResult"/> indicating success if the date format is correct.
	/// Otherwise, returns an error message with the format requirements.
	/// </returns>
	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		if (value is string dateString &&
			DateTime.TryParseExact(
				dateString,
				_dateFormat,
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out DateTime dateResult))
		{
			return ValidationResult.Success!;
		}

		var errorMessage = FormatErrorMessage(validationContext.DisplayName);
		return new ValidationResult(errorMessage);
	}

	/// <summary>
	/// Formats the error message to be displayed when validation fails.
	/// </summary>
	/// <param name="name">The name of the property being validated.</param>
	/// <returns>A formatted error message string.</returns>
	public override string FormatErrorMessage(string name)
	{
		return string.Format(ErrorMessageString
							 ?? $"The {name} field must be a valid date in {_dateFormat} format.", name, _dateFormat);
	}
}
