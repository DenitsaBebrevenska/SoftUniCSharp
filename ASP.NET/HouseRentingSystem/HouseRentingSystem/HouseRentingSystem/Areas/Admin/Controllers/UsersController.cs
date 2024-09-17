using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Admin.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static HouseRentingSystem.Core.Constants.AdministratorConstants;

namespace HouseRentingSystem.Areas.Admin.Controllers;
public class UsersController : AdminBaseController
{
	private readonly IUserService _userService;
	private readonly IMemoryCache _memoryCache;
	public UsersController(IUserService userService,
		IMemoryCache memoryCache)
	{
		_userService = userService;
		_memoryCache = memoryCache;
	}

	public async Task<IActionResult> Index()
	{
		var model = _memoryCache.Get<IEnumerable<UserServiceModel>>(UserCacheKey);

		if (model == null || !model.Any())
		{
			model = await _userService.AllAsync();
			var cacheOption = new MemoryCacheEntryOptions()
				.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
			_memoryCache.Set(UserCacheKey, model, cacheOption);
		}

		return View(model);
	}
}
