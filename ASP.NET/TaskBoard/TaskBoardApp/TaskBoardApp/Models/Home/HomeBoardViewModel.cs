namespace TaskBoardApp.Models.Home;

/// <summary>
/// A view model for the home summary display of boards
/// </summary>
public class HomeBoardViewModel
{
    public string BoardName { get; set; } = null!;

    public int TaskCount { get; set; }
}
