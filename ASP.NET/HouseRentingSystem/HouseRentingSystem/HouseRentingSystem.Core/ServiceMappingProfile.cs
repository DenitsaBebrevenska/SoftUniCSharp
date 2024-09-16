using AutoMapper;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Core.Models.Category;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Models;

namespace HouseRentingSystem.Core;
public class ServiceMappingProfile : Profile
{
    public ServiceMappingProfile()
    {
        CreateMap<House, HouseIndexViewModel>();
        CreateMap<House, HouseFormViewModel>();
        CreateMap<House, HouseDetailsViewModel>()
            .ForMember(h => h.IsRented, config =>
                config.MapFrom(h => h.RenterId != null))
            .ForMember(h => h.Category, config =>
                config.MapFrom(h => h.Category.Name))
            .ForMember(h => h.Agent, config =>
                config.MapFrom(h => h.Agent));
        CreateMap<Agent, AgentViewModel>()
            .ForMember(a => a.FullName, config =>
                config.MapFrom(a => $"{a.User.FirstName} {a.User.LastName}"))
            .ForMember(a => a.Email, config =>
                config.MapFrom(a => a.User.Email));
        CreateMap<Category, CategoryViewModel>();
    }
}

