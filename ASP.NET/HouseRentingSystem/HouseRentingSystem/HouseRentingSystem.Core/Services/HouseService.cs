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
                Address = h.Address,
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
                    FullName = $"{h.Agent.User.FirstName} {h.Agent.User.LastName}",
                    PhoneNumber = h.Agent.PhoneNumber,
                    Email = h.Agent.User.Email
                }
            })
            .FirstAsync(h => h.Id == id);
    }

    public async Task EditAsync(int houseId, HouseFormViewModel model)
    {
        var house = await _repository
            .GetByIdAsync<House>(houseId);

        if (house != null)
        {
            house.Address = model.Address;
            house.Description = model.Description;
            house.CategoryId = model.CategoryId;
            house.ImageUrl = model.ImageUrl;
            house.PricePerMonth = model.PricePerMonth;
            house.Title = model.Title;

            await _repository.SaveChangesAsync();
        }
    }

    public async Task<bool> HasAgentWithIdAsync(int houseId, string userId)
    {
        return await _repository
            .GetAllReadOnly<House>()
            .AnyAsync(h => h.Id == houseId &&
                           h.Agent.UserId == userId);

    }

    public async Task<HouseFormViewModel?> GetHouseFormModelByIdAsync(int houseId)
    {
        var house = await _repository
            .GetAllReadOnly<House>()
            .Where(h => h.Id == houseId)
            .Select(h => new HouseFormViewModel()
            {
                Id = h.Id,
                Address = h.Address,
                Description = h.Description,
                CategoryId = h.CategoryId,
                ImageUrl = h.ImageUrl,
                PricePerMonth = h.PricePerMonth,
                Title = h.Title
            })
            .FirstOrDefaultAsync();


        if (house != null)
        {
            house.Categories = await AllCategoriesAsync();
        }

        return house;
    }

    public async Task DeleteAsync(int houseId)
    {
        var house = await _repository
            .GetByIdAsync<House>(houseId);
        _repository
            .Remove(house!);
        await _repository.SaveChangesAsync();

    }

    public async Task<bool> IsRentedAsync(int id)
    {
        var house = await _repository
            .GetByIdAsync<House>(id);

        return house!.RenterId != null;
    }

    public async Task<bool> IsRentedByUserWithIdAsync(int houseId, string userId)
    {
        var house = await _repository
            .GetByIdAsync<House>(houseId);

        return house!.RenterId == userId;
    }

    public async Task RentAsync(int houseId, string userId)
    {
        var house = await _repository
            .GetByIdAsync<House>(houseId);
        house!.RenterId = userId;
        await _repository.SaveChangesAsync();
    }

    public async Task LeaveAsync(int houseId)
    {
        var house = await _repository
            .GetByIdAsync<House>(houseId);
        house!.RenterId = null;
        await _repository.SaveChangesAsync();
    }
}
