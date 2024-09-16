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

	public const string HousePricePerMonthMinimum = "0";

	public const string HousePricePerMonthMaximum = "2000";

	public const int AgentPhoneNumberMinLength = 7;

	public const int AgentPhoneNumberMaxLength = 15;

	public const int ImageUrlMaxLength = 2_048;

	public const int UserFirstNameMinLength = 1;

	public const int UserFirstNameMaxLength = 12;

	public const int UserLastNameMinLength = 3;

	public const int UserLastNameMaxLength = 15;

}
