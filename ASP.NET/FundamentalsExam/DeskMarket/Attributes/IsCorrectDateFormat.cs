using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DeskMarket.Attributes;

/// <summary>
/// Custom validation attribute that checks if a given string value is in the correct date format.
/// </summary>
/// <param name="dateFormat">The expected date format</param>
public class IsCorrectDateFormat(string dateFormat) : ValidationAttribute
{
    /// <summary>
    /// Validates whether the provided value matches the specified date format.
    /// </summary>
    /// <param name="value">The value to validate, expected to be a string.</param>
    /// <param name="validationContext">Provides context information about the validation operation.</param>
    /// <returns>
    /// <see cref="ValidationResult.Success"/> if the value matches the specified date format; otherwise, a validation error message.
    /// </returns>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string dateString &&
        DateTime.TryParseExact(
                dateString,
                dateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
        {
            return ValidationResult.Success;
        }

        var errorMessage = $"The {validationContext.DisplayName} field must be in the valid date format - {dateFormat}.";
        return new ValidationResult(errorMessage);
    }
}
