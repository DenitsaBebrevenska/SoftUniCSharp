using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Models.Board;

/// <summary>
/// Board view model for displaying the boards
/// </summary>
public class BoardViewModel
{
    /// <summary>
    /// Board identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Board name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// A collection of all tasks belonging to this board
    /// </summary>
    public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
}
