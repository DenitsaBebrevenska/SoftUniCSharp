using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Enums;
using HouseRentingSystem.Core.Models.Agent;
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

    public async Task<HouseQueryViewModel> AllAsync(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest,
        int currentPage = 1, int housesPerPage = 1)
    {
        var housesQuery = _repository.GetAll<House>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(category))
        {
            housesQuery = housesQuery
                .Where(h => h.Category.Name == category);
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            string normalizedSearchTerm = searchTerm.ToLower();
            housesQuery = housesQuery
                .Where(h =>
                    h.Title.ToLower().Contains(normalizedSearchTerm) ||
                    h.Address.ToLower().Contains(normalizedSearchTerm) ||
                    h.Description.ToLower().Contains(normalizedSearchTerm));
        }

        housesQuery = sorting switch
        {
            HouseSorting.Price => housesQuery
                .OrderBy(h => h.PricePerMonth),
            HouseSorting.NotRentedFirst => housesQuery
                .OrderBy(h => h.RenterId == null)
                .ThenByDescending(h => h.Id),
            _ => housesQuery.OrderByDescending(h => h.Id)
        };

        var houses = await housesQuery
            .Skip((currentPage - 1) * housesPerPage)
            .Take(housesPerPage)
            .ProjectToHouseModel()
            .ToListAsync();

        var totalHouses = await housesQuery.CountAsync();

        return new HouseQueryViewModel()
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

    public async Task<IEnumerable<HouseViewModel>> AllHousesByAgentIdAsync(int agentId)
    {
        return await _repository
            .GetAllReadOnly<House>()
            .Where(h => h.AgentId == agentId)
            .ProjectToHouseModel()
            .ToListAsync();
    }

    public async Task<IEnumerable<HouseViewModel>> AllHousesByUserIdAsync(string userId)
    {
        return await _repository
            .GetAllReadOnly<House>()
            .Where(h => h.RenterId == userId)
            .ProjectToHouseModel()
            .ToListAsync();
    }

    public async Task<bool> HouseExistsAsync(int id)
    {
        return await _repository
            .GetAllReadOnly<House>()
            .AnyAsync(h => h.Id == id);
    }

    public async Task<HouseDetailsViewModel> HouseDetailsByIdAsync(int id)
    {
        return await _repository
            .GetAll<House>()
            .Select(h => new HouseDetailsViewModel()
            {
                Id = h.Id,
                Title = h.Title,
                Address = h.Address,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                IsRented = h.RenterId != null,
                Category = h.Category.Name,
                Agent = new AgentViewModel()
                {
                    PhoneNumber = h.Agent.PhoneNumber,
                    Email = h.Agent.User.Email
                }
            })
            .FirstAsync(h => h.Id == id);
    }
}
