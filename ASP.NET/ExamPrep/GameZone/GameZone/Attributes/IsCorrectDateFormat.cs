using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GameZone.Attributes;

public class IsCorrectDateFormat : ValidationAttribute
{
    private readonly string _dateFormat;

    public IsCorrectDateFormat(string dateFormat)
    {
        _dateFormat = dateFormat;
    }

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

    public override string FormatErrorMessage(string name)
    {
        return string.Format(ErrorMessageString
                             ?? $"The {name} field must be a valid date in {_dateFormat} format.", name, _dateFormat);
    }
}
