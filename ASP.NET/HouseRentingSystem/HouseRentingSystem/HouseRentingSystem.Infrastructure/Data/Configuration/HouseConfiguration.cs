﻿using HouseRentingSystem.Infrastructure.Data.Models;
using HouseRentingSystem.Infrastructure.Data.SeedDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Data.Configuration;
public class HouseConfiguration : IEntityTypeConfiguration<House>
{
	public void Configure(EntityTypeBuilder<House> builder)
	{
		builder
			.HasOne(h => h.Category)
			.WithMany(c => c.Houses)
			.HasForeignKey(h => h.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

		builder
			.HasOne(h => h.Agent)
			.WithMany(a => a.Houses)
			.HasForeignKey(h => h.AgentId)
			.OnDelete(DeleteBehavior.Restrict);

		var data = new SeedData();

		builder.HasData(data.FirstHouse, data.SecondHouse, data.ThirdHouse);

	}
}
