using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.ModelConstants;

namespace GameZone.Data.Models;
/// <summary>
/// Represents a game with its details
/// </summary>
public class Game
{
	/// <summary>
	/// Gets or sets the game`s unique identifier
	/// </summary>
	[Comment("The game`s unique identifier")]
	public int Id { get; set; }

	/// <summary>
	/// Get or sets the game`s title
	/// </summary>
	[Required]
	[MaxLength(GameTitleMaxLength)]
	[Comment("The title of the game")]
	public string Title { get; set; } = null!;

	/// <summary>
	/// Gets or sets the game`s description
	/// </summary>
	[Required]
	[MaxLength(GameDescriptionMaxLength)]
	[Comment("Description of the game")]
	public string Description { get; set; } = null!;

	/// <summary>
	/// Get or sets the game`s image URL. Can be null.
	/// </summary>
	[Comment("Game image")]
	public string? ImageUrl { get; set; }

	/// <summary>
	/// Gets or sets the game`s publisher`s identifier
	/// </summary>
	[Required]
	[Comment("The unique identifies of the game`s publisher")]
	public string PublisherId { get; set; } = null!;

	/// <summary>
	/// A navigational property for the game`s publisher who is an identity user
	/// </summary>
	public IdentityUser Publisher { get; set; } = null!;

	/// <summary>
	/// Gets or sets the date and time of the game`s release
	/// </summary>
	[Comment("The day and time of game`s release")]
	public DateTime ReleasedOn { get; set; }

	/// <summary>
	/// Gets or sets the game`s genre identifier
	/// </summary>
	[Comment("The game`s genre unique identifier")]
	public int GenreId { get; set; }

	/// <summary>
	/// A navigational property for the game`s genre
	/// </summary>
	public Genre Genre { get; set; } = null!;

	/// <summary>
	/// A collection of GamerGame associated with this game.
	/// Represents a many-to-many relationship between the GamerGame entity.
	/// </summary>
	public ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
}
