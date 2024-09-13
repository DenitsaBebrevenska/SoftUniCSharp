﻿using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.Models.Home;

public class HouseIndexViewModel : IHouseModel
{
	public int Id { get; set; }

	public string Title { get; set; } = null!;

	public string Address { get; set; } = null!;

	public string ImageUrl { get; set; } = null!;
}
