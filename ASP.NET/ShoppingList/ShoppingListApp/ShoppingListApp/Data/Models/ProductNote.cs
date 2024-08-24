using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Data.Models;

public class ProductNote
{
	public int Id { get; set; }

	[Required]
	[StringLength(250)]
	public string Content { get; set; } = string.Empty;

	[ForeignKey(nameof(Product))]
	public int ProductId { get; set; }

	public Product Product { get; set; } = null!;
}
