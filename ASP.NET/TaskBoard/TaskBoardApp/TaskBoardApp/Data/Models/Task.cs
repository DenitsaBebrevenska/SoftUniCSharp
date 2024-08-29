using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstraints;
namespace TaskBoardApp.Data.Models;

/// <summary>
/// Task data model
/// </summary>
public class Task
{
    /// <summary>
    /// Task identifier
    /// </summary>
    [Key]
    [Comment("Task identifier")]
    public int Id { get; set; }

    /// <summary>
    /// Task title
    /// </summary>
    [Required]
    [MaxLength(TaskTitleMaxLength)]
    [Comment("Task title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Task description
    /// </summary>
    [Required]
    [MaxLength(TaskDescriptionMaxLength)]
    [Comment("Task description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Task creation date and time
    /// </summary>
    [Comment("Task date and time creation")]
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// The board identifier to which the task is assigned
    /// </summary>
    [Comment("Board identifier of to which the task belongs")]
    public int? BoardId { get; set; }

    public Board? Board { get; set; }

    /// <summary>
    /// The identifier of task owner
    /// </summary>
    [Required]
    [Comment("Owner/creator identifier of the task")]
    public string OwnerId { get; set; } = null!;

    public IdentityUser Owner { get; set; } = null!;
}
