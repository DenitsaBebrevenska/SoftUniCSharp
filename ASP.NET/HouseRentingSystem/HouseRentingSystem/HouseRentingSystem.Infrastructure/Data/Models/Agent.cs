using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Data.Constants.TableConstraints;

namespace HouseRentingSystem.Infrastructure.Data.Models;
public class Agent
{
	[Key]
	[Comment("Agent identifier")]
	public int Id { get; set; }

	[Required]
	[MaxLength(AgentPhoneNumberMaxLength)]
	[Comment("Agent`s phone number")]
	public string PhoneNumber { get; set; } = null!;

	[Required]
	[Comment("The user identifier")]
	public string UserId { get; set; } = null!;

	public IdentityUser User { get; set; } = null!;

	public ICollection<House> Houses { get; set; } = new List<House>();
}
