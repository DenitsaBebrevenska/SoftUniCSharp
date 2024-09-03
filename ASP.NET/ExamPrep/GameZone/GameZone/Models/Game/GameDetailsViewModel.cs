namespace GameZone.Models.Game;

/// <summary>
/// A view model for a game.
/// The model is used for displaying details about the game.
/// It does not get validation for it does not deal with user input.
/// </summary>
public class GameDetailsViewModel
{
	/// <summary>
	/// The game`s unique identifier
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// The game`s image URL which can be null
	/// </summary>
	public string? ImageUrl { get; set; }

	/// <summary>
	/// The game`s title
	/// </summary>
	public string Title { get; set; } = null!;

	/// <summary>
	/// The game`s description
	/// </summary>
	public string Description { get; set; } = null!;

	/// <summary>
	/// The game`s genre name
	/// </summary>
	public string Genre { get; set; } = null!;

	/// <summary>
	/// The date of game`s release
	/// </summary>
	public string ReleasedOn { get; set; } = null!;

	/// <summary>
	/// The game`s publisher`s username
	/// </summary>
	public string Publisher { get; set; } = null!;

}
