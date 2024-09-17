using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Admin.User;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;
public class UserService : IUserService
{
	private readonly IRepository _repository;

	public UserService(IRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<UserServiceModel>> AllAsync()
	{
		var users = await _repository.GetAllReadOnly<ApplicationUser>()
			.Include(u => u.Agent)
			.Select(u => new UserServiceModel()
			{
				Email = u.Email,
				FullName = $"{u.FirstName} {u.LastName}",
				PhoneNumber = u.Agent != null ? u.Agent.PhoneNumber : null,
				IsAgent = u.Agent != null
			})
			.ToListAsync();
		return users;
	}
}
