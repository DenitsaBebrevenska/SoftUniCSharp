namespace TaskBoardApp.Models.Home;

/// <summary>
/// A view model for Home Index
/// </summary>
public class HomeViewModel
{
    /// <summary>
    /// The total count tasks
    /// </summary>
    public int AllTasksCount { get; set; }

    /// <summary>
    /// The different boards present
    /// </summary>
    public List<HomeBoardViewModel> BoardsWithTasksCount { get; set; } = null!;

    /// <summary>
    /// The count of the user specific tasks
    /// </summary>
    public int UserTaskCount { get; set; }
}
