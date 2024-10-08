﻿using HouseRentingSystem.Core.Enums;
using System.ComponentModel;

namespace HouseRentingSystem.Core.Models.House;
public class AllHousesQueryModel
{
    public const int HousesPerPage = 3;

    public string Category { get; init; } = null!;

    [DisplayName("Search by text")]
    public string SearchTerm { get; init; } = null!;

    public HouseSorting Sorting { get; init; }

    public int CurrentPage { get; init; } = 1;

    public int TotalHousesCount { get; set; }

    public IEnumerable<string> Categories { get; set; } = null!;

    public IEnumerable<HouseViewModel> Houses { get; set; } = new List<HouseViewModel>();
}
