namespace HouseRentingSystem.Infrastructure.Data.Constants;
public static class TableConstraints
{
	public const int CategoryNameMaxLength = 50;

	public const int HouseTitleMinLength = 10;

	public const int HouseTitleMaxLength = 50;

	public const int HouseAddressMinLength = 30;

	public const int HouseAddressMaxLength = 150;

	public const int HouseDescriptionMinLength = 50;

	public const int HouseDescriptionMaxLength = 500;

	public const decimal HousePricePerMonthMinimum = 0m;

	public const decimal HousePricePerMonthMaximum = 2_000m;

	public const int AgentPhoneNumberMinLength = 7;

	public const int AgentPhoneNumberMaxLength = 15;

	public const int ImageUrlMaxLength = 2_048;

	public const int UserIdentifierLength = 36;
}
