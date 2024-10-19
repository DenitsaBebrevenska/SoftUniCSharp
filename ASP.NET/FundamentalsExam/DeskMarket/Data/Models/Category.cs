using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Common.Constants.ModelConstants;

namespace DeskMarket.Data.Models;

/// <summary>
/// Represents a product category.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets or sets the unique identifier for the category.
    /// </summary>
    [Key]
    [Comment("Category identifier")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// The name is required and has a maximum length defined by <see cref="CategoryNameMaxLength"/>.
    /// </summary>
    [Required]
    [MaxLength(CategoryNameMaxLength)]
    [Comment("The name of the category")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the collection of products associated with this category.
    /// A navigational property.
    /// </summary>
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
