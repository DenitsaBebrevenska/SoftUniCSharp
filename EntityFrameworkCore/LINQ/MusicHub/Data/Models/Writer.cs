using MusicHub.Common;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;
public class Writer
{
    public Writer()
    {
        Songs = new HashSet<Song>();
    }
    public int Id { get; set; }

    [MaxLength(DatabaseConstraints.WriterNameLength)]
    public string Name { get; set; }

    public string? Pseudonym { get; set; }

    public virtual ICollection<Song> Songs { get; set; }

}
