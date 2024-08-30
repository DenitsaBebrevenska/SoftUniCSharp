namespace TaskBoardApp.Models.Home;

/// <summary>
/// A view model for the home summary display of boards
/// </summary>
public class HomeBoardViewModel
{
    /// <summary>
    /// The board name
    /// </summary>
    public string BoardName { get; set; } = null!;

    /// <summary>
    /// The count of tasks on that particular board
    /// </summary>
    public int TaskCount { get; set; }
}
