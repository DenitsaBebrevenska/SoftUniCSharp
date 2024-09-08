using HouseRentingSystem.Core.Enums;
using HouseRentingSystem.Core.Models.Category;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts;
public interface IHouseService
{
    Task<IEnumerable<HouseIndexViewModel>> LastThreeHousesAsync();

    Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();

    Task<bool> CategoryExistsAsync(int categoryId);

    Task<int> CreateAsync(HouseFormViewModel model, int agentId);

    Task<HouseQueryServiceModel> AllAsync(string? category = null,
        string? searchTerm = null,
        HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1,
        int housesPerPage = 1);

    Task<IEnumerable<string>> AllCategoriesNamesAsync();
}
