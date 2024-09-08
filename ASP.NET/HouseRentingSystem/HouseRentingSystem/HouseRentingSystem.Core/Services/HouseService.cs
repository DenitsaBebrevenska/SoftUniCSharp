using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Enums;
using HouseRentingSystem.Core.Models.Category;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;
public class HouseService : IHouseService
{
    private readonly IRepository _repository;

    public HouseService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<HouseIndexViewModel>> LastThreeHousesAsync()
        => await _repository
            .GetAllReadOnly<House>()
            .OrderByDescending(h => h.Id)
            .Take(3)
            .Select(h => new HouseIndexViewModel()
            {
                Id = h.Id,
                ImageUrl = h.ImageUrl,
                Title = h.Title
            })
            .ToListAsync();

    public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        => await _repository
            .GetAllReadOnly<Category>()
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();

    public async Task<bool> CategoryExistsAsync(int categoryId)
        => await _repository
            .GetAllReadOnly<Category>()
            .AnyAsync(c => c.Id == categoryId);

    public async Task<int> CreateAsync(HouseFormViewModel model, int agentId)
    {
        var house = new House()
        {
            Title = model.Title,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            Address = model.Address,
            AgentId = agentId,
            PricePerMonth = model.PricePerMonth,
            CategoryId = model.CategoryId
        };

        await _repository.AddAsync(house);
        await _repository.SaveChangesAsync();

        return house.Id;
    }

    public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1, int housesPerPage = 1)
    {
        var housesQuery = _repository.GetAll<House>().AsQueryable();

        if (string.IsNullOrWhiteSpace(category))
        {
            housesQuery = _repository
                .GetAll<House>()
                .Where(h => h.Category.Name == category);
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            housesQuery = housesQuery
                .Where(h =>
                    h.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Address.ToLower().Contains(searchTerm.ToLower()) ||
                    h.Description.ToLower().Contains(searchTerm.ToLower()));
        }

        housesQuery = sorting switch
        {
            HouseSorting.Price => housesQuery
                .OrderBy(h => h.PricePerMonth),
            HouseSorting.NotRentedFirst => housesQuery
                .OrderBy(h => h.RenterId != null)
                .ThenByDescending(h => h.Id),
            _ => housesQuery.OrderByDescending(h => h.Id)
        };

        var houses = await housesQuery
            .Skip((currentPage - 1) * housesPerPage)
            .Take(housesPerPage)
            .Select(h => new HouseServiceModel()
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                IsRented = h.RenterId != null,
                PricePerMonth = h.PricePerMonth
            })
            .ToListAsync();

        var totalHouses = housesQuery.Count();

        return new HouseQueryServiceModel()
        {
            TotalHousesCount = totalHouses,
            Houses = houses
        };
    }

    public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
    {
        return await _repository
            .GetAllReadOnly<Category>()
            .Select(c => c.Name)
            .Distinct()
            .ToListAsync();
    }

}
