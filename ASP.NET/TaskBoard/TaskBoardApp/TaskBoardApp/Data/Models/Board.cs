using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstraints;
namespace TaskBoardApp.Data.Models;

/// <summary>
/// Board data model
/// </summary>
public class Board
{
    /// <summary>
    /// Board identifier
    /// </summary>
    [Key]
    [Comment("Board identifier")]
    public int Id { get; set; }

    /// <summary>
    /// The name of the board
    /// </summary>
    [Required]
    [MaxLength(BoardNameMaxLength)]
    [Comment("Board name")]
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Task> Tasks { get; set; } = new HashSet<Task>();
}
