namespace GameZone.Models.Game;

/// <summary>
/// View model representing an event for display purposes.
/// This model is used for displaying list of games in /All and /MyZone.
/// It does not include validation as it does not deal with user input.
/// </summary>
public class GameViewModel
{
	/// <summary>
	/// The game`s unique identifier
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// The game`s image Url which can be null
	/// </summary>
	public string? ImageUrl { get; set; }

	/// <summary>
	/// The game`s title
	/// </summary>
	public string Title { get; set; } = null!;

	/// <summary>
	/// The game`s genre name
	/// </summary>
	public string Genre { get; set; } = null!;

	/// <summary>
	/// The date of game`s release
	/// </summary>
	public string ReleasedOn { get; set; } = null!;

	/// <summary>
	/// The username of the game`s publisher
	/// </summary>
	public string Publisher { get; set; } = null!;
}
