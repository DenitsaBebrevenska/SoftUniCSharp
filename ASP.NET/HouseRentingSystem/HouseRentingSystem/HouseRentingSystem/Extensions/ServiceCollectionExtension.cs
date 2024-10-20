﻿using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtension
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<IHouseService, HouseService>();
		services.AddScoped<IAgentService, AgentService>();
		services.AddScoped<IStatisticsService, StatisticsService>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IRentService, RentService>();

		return services;
	}

	public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
	{
		var connectionString = config.GetConnectionString("DefaultConnection") ??
							   throw new ArgumentException("DefaultConnection string not set.");
		services.AddDbContext<HomeRentingDbContext>(options => options.UseSqlServer(connectionString));

		services.AddScoped<IRepository, Repository>();

		services.AddDatabaseDeveloperPageExceptionFilter();

		return services;
	}

	public static IServiceCollection AddApplicationIdentity(this IServiceCollection services)
	{
		services.AddDefaultIdentity<ApplicationUser>(options =>
			{
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
			})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<HomeRentingDbContext>();

		return services;
	}
}
