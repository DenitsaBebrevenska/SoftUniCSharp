using HouseRentingSystem.Core.Contracts;
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
}
