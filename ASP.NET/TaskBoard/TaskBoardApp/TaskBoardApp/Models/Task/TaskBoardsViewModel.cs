namespace TaskBoardApp.Models.Task;

/// <summary>
/// A view model for a new task`s possible boards in a form 
/// </summary>
public class TaskBoardsViewModel
{
    /// <summary>
    /// Board identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Board name
    /// </summary>
    public string Name { get; set; }
}
