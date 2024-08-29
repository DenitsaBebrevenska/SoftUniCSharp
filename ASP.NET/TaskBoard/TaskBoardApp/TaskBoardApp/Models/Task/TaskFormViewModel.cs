using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.DataConstraints;
using static TaskBoardApp.Models.ModelValidationErrorMessages;

namespace TaskBoardApp.Models.Task;

/// <summary>
/// A view model for the task that will be in the form for adding a new task
/// </summary>
public class TaskFormViewModel
{
    /// <summary>
    /// Task title
    /// </summary>
    [Required(ErrorMessage = RequiredField)]
    [StringLength(TaskTitleMaxLength,
        MinimumLength = TaskTitleMinLength,
        ErrorMessage = StringLength)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// Task description
    /// </summary>
    [Required(ErrorMessage = RequiredField)]
    [StringLength(TaskDescriptionMaxLength,
        MinimumLength = TaskDescriptionMinLength,
        ErrorMessage = StringLength)]
    public string Description { get; set; } = null!;

    /// <summary>
    /// The identifier of the board to which the task belong
    /// </summary>
    [Display(Name = "Board")]
    public int BoardId { get; set; }

    /// <summary>
    /// The possible board options to choose from in the form
    /// </summary>
    public IEnumerable<TaskBoardsViewModel> Boards { get; set; } = null!;
}
