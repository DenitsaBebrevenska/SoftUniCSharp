using AutoMapper;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<ImportUserDto, User>();
            CreateMap<ImportProductDto, Product>();
            CreateMap<ImportCategoryDto, Category>()
                .ForMember(d => d.Name, opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
