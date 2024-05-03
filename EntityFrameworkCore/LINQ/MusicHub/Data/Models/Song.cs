using MusicHub.Common;
using MusicHub.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class Song
{
    public Song()
    {
        SongPerformers = new HashSet<SongPerformer>();
    }
    public int Id { get; set; }

    [MaxLength(DatabaseConstraints.SongNameLength)]
    public string Name { get; set; } = null!;

    public TimeSpan Duration { get; set; }

    public DateTime CreatedOn { get; set; }

    public Genre Genre { get; set; }

    public int? AlbumId { get; set; }
    public virtual Album? Album { get; set; } = null!;

    public int WriterId { get; set; }
    public virtual Writer Writer { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<SongPerformer> SongPerformers { get; set; } = null!;
}
