using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.ModelConstants;

namespace GameZone.Data.Models;

/// <summary>
/// Represents a game genre
/// </summary>
public class Genre
{
	/// <summary>
	/// The genre`s unique identifier
	/// </summary>
	[Comment("The genre`s unique identifier")]
	public int Id { get; set; }

	/// <summary>
	/// The genre`s name
	/// </summary>
	[Required]
	[MaxLength(GenreNameMaxLength)]
	[Comment("The genre`s name")]
	public string Name { get; set; } = null!;

	/// <summary>
	/// A collection of games associated with this genre.
	/// Represents the one-to-many relationship between games and genre.
	/// </summary>
	public ICollection<Game> Games { get; set; } = new List<Game>();
}
