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
}
