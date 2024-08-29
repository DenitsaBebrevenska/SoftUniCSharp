namespace TaskBoardApp.Models.Task;
/// <summary>
/// Task view model for displaying tasks from the context
/// </summary>
public class TaskViewModel
{
    /// <summary>
    /// Task identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Task title
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Task description
    /// </summary>
    public string Description { get; set; } = null!;


    /// <summary>
    /// Task`s owner name/username
    /// </summary>
    public string Owner { get; set; } = null!;
}
