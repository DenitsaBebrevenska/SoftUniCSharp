namespace GameZone.Models.Game;

/// <summary>
/// Represents a view model for a game.
/// This model is used for game deletion.
/// Does not include validations as it does not deal with user input.
/// </summary>
public class GameDeleteViewModel
{
	/// <summary>
	/// The game`s unique identifier
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// The game`s title
	/// </summary>
	public string Title { get; set; } = null!;

	/// <summary>
	/// The game`s description
	/// </summary>
	public string Description { get; set; } = null!;

	/// <summary>
	/// The game`s publisher`s username
	/// </summary>
	public string Publisher { get; set; } = null!;
}
