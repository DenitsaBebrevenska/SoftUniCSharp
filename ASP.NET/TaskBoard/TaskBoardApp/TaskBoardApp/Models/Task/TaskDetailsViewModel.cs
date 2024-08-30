namespace TaskBoardApp.Models.Task;

/// <summary>
/// A view model for the task as displayed on Details method
/// </summary>
public class TaskDetailsViewModel : TaskViewModel
{
    /// <summary>
    /// The name of the board the task belongs to
    /// </summary>
    public string Board { get; set; } = null!;


    /// <summary>
    /// The date and time of task creation
    /// </summary>
    public string CreatedOn { get; set; } = null!;
}
