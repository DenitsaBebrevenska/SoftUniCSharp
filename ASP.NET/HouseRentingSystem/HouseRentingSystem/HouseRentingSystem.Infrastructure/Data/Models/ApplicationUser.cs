using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Data.Constants.TableConstraints;

namespace HouseRentingSystem.Infrastructure.Data.Models;
public class ApplicationUser : IdentityUser
{
	[Required]
	[Comment("User`s First Name")]
	[MaxLength(UserFirstNameMaxLength)]
	public string FirstName { get; set; } = string.Empty;

	[Required]
	[Comment("User`s Last Name")]
	[MaxLength(UserLastNameMaxLength)]
	public string LastName { get; set; } = string.Empty;

	public Agent? Agent { get; set; }
}
