using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Data.Models;

public class GamerGame
{
    public int GameId { get; set; }

    public Game Game { get; set; } = null!;

    [Required]
    public string GamerId { get; set; } = null!;

    public IdentityUser Gamer { get; set; } = null!;
}
