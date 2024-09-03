using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Data.Models;

/// <summary>
/// Represents the many-to-many relationship between games and gamers.
/// Each gamer can have many games in his collection and each game can have many gamers who play it.
/// </summary>
public class GamerGame
{
	/// <summary>
	/// The identifier of the game
	/// </summary>
	[Comment("The game`s unique identifier")]
	public int GameId { get; set; }

	/// <summary>
	/// Navigational property for the game associated with this user/gamer
	/// </summary>
	public Game Game { get; set; } = null!;

	/// <summary>
	/// The identifier of the gamer/user
	/// </summary>
	[Required]
	[Comment("The user`s unique identifier")]
	public string GamerId { get; set; } = null!;

	/// <summary>
	/// Navigational property for the gamer/user associated with this game
	/// </summary>
	public IdentityUser Gamer { get; set; } = null!;
}
