using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Data.Constants.TableConstraints;

namespace HouseRentingSystem.Infrastructure.Data.Models;
public class Category
{
	[Key]
	[Comment("Category identifier")]
	public int Id { get; set; }

	[Required]
	[MaxLength(CategoryNameMaxLength)]
	[Comment("Category`s name")]
	public string Name { get; set; } = null!;

	public ICollection<House> Houses { get; set; } = new List<House>();
}
