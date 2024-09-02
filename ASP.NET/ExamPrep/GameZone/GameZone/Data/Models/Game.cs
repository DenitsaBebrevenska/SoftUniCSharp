using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.Constants.ModelConstants;

namespace GameZone.Data.Models;

public class Game
{
    [Comment("The game`s unique identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(GameTitleMaxLength)]
    [Comment("The title of the game")]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(GameDescriptionMaxLength)]
    [Comment("Description of the game")]
    public string Description { get; set; } = null!;

    [Comment("Game image")]
    public string? ImageUrl { get; set; }

    [Required]
    [Comment("The unique identifies of the game`s publisher")]
    public string PublisherId { get; set; } = null!;

    public IdentityUser Publisher { get; set; } = null!;

    [Comment("The day and time of game`s release")]
    public DateTime ReleasedOn { get; set; }

    [Comment("The game`s genre unique identifier")]
    public int GenreId { get; set; }

    public Genre Genre { get; set; } = null!;

    public ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
}
