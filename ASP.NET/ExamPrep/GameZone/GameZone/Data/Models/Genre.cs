using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Data.Constants.ModelConstants;

namespace GameZone.Data.Models;

public class Genre
{
    [Comment("The genre`s unique identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(GenreNameMaxLength)]
    [Comment("The genre`s name")]
    public string Name { get; set; } = null!;

    public ICollection<Game> Games { get; set; } = new List<Game>();
}
