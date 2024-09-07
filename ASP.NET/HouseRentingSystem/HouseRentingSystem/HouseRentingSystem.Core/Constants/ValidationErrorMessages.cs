namespace HouseRentingSystem.Core.Constants;
public static class ValidationErrorMessages
{
    public const string RequiredFieldMessage = "The {0} field is required.";

    public const string StringLengthMessage = "The field {0} must be between {2} and {1} characters long.";

    public const string PhoneNumberExistsMessage = "Phone number already exists. Please enter a new one.";

    public const string UserHasRentsMessage = "Cannot become agent if you have rents.";
}
