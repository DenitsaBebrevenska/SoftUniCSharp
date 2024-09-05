using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Data.Constants.TableConstraints;

namespace HouseRentingSystem.Infrastructure.Data.Models;
public class House
{
	[Key]
	[Comment("House identifier")]
	public int Id { get; set; }

	[Required]
	[MaxLength(HouseTitleMaxLength)]
	[Comment("House title")]
	public string Title { get; set; } = null!;

	[Required]
	[MaxLength(HouseAddressMaxLength)]
	[Comment("House address")]
	public string Address { get; set; } = null!;

	[Required]
	[MaxLength(HouseDescriptionMaxLength)]
	[Comment("House brief description")]
	public string Description { get; set; } = null!;

	[Required]
	[MaxLength(ImageUrlMaxLength)]
	[Comment("House brief description")]
	public string ImageUrl { get; set; } = null!;

	[Column(TypeName = "decimal(6,2)")]
	[Comment("Price per month for the house rental")]
	public decimal PricePerMonth { get; set; }

	[Comment("Category identifier")]
	public int CategoryId { get; set; }

	public Category Category { get; set; } = null!;

	[Comment("Agent identifier")]
	public int AgentId { get; set; }

	public Agent Agent { get; set; } = null!;

	[Comment("The user`s identifier who rents the house")]
	public string? RenterId { get; set; }
}
