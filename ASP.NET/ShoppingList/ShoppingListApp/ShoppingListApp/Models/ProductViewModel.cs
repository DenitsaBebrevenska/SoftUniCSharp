using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models;

public class ProductViewModel
{
	public int Id { get; set; }

	[Required(ErrorMessage = "Field {0} is required.")]
	[Display(Name = "product name")]
	[StringLength(100, MinimumLength = 2, ErrorMessage = "Field {0} must be {2} and {1} symbols.")]
	public string Name { get; set; } = string.Empty;
}
