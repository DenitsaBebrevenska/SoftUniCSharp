namespace TaskBoardApp.Models.Home;

/// <summary>
/// A view model for Home Index
/// </summary>
public class HomeViewModel
{
    public int AllTasksCount { get; set; }

    public List<HomeBoardViewModel> BoardsWithTasksCount { get; set; } = null!;

    public int UserTaskCount { get; set; }
}
