using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models;

public class ProductViewModel
{
	public int Id { get; set; }

	[Required]
	[StringLength(100, MinimumLength = 2, ErrorMessage = "Invalid product name length!")]
	public string Name { get; set; } = string.Empty;
}
