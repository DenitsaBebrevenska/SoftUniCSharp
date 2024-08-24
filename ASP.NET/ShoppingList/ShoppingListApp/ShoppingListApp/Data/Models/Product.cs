using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data.Models;

public class Product
{
	public int Id { get; set; }

	[Required]
	[StringLength(100)]
	public string Name { get; set; } = string.Empty;

	public IEnumerable<ProductNote> Notes { get; set; } = new HashSet<ProductNote>();
}
