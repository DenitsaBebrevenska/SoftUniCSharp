using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services;
public class AgentService : IAgentService
{
    private readonly IRepository _repository;

    public AgentService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExistsByIdAsync(string userId)
        => await _repository
            .GetAllReadOnly<Agent>()
            .AnyAsync(a => a.UserId == userId);

    public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        => await _repository
            .GetAllReadOnly<Agent>()
            .AnyAsync(a => a.PhoneNumber == phoneNumber);

    public async Task<bool> UserHasRentsAsync(string userId)
        => await _repository
            .GetAllReadOnly<House>()
            .AnyAsync(h => h.RenterId == userId);

    public async Task CreateAsync(string userId, string phoneNumber)
    {
        var agent = new Agent()
        {
            PhoneNumber = phoneNumber,
            UserId = userId
        };

        await _repository.AddAsync(agent);
        await _repository.SaveChangesAsync();
    }
}
