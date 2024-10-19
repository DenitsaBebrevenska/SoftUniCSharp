namespace DeskMarket.Models.Category;

/// <summary>
/// Represents the view model for a category.
/// Used to transfer category data between the view and the controller.
/// Not being validated as it doesn`t deal with user`s input.
/// </summary>
public class CategoryFormViewModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the category.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string Name { get; set; } = null!;
}
