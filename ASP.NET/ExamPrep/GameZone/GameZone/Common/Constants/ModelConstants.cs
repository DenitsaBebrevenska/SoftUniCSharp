namespace GameZone.Common.Constants;

/// <summary>
/// Constants for both data and view model validations
/// </summary>
public static class ModelConstants
{
	/// <summary>
	/// The minimum string length of a game title
	/// </summary>
	public const int GameTitleMinLength = 2;

	/// <summary>
	/// The maximum string length of a game title
	/// </summary>
	public const int GameTitleMaxLength = 50;

	/// <summary>
	/// The minimum string length of a game description
	/// </summary>
	public const int GameDescriptionMinLength = 10;

	/// <summary>
	/// The maximum string length of a game description
	/// </summary>
	public const int GameDescriptionMaxLength = 500;

	/// <summary>
	/// The minimum string length of a genre name
	/// </summary>
	public const int GenreNameMinLength = 3;

	/// <summary>
	/// The maximum string length of a genre name
	/// </summary>
	public const int GenreNameMaxLength = 25;
}
