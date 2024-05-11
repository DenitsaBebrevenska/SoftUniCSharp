using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User

            CreateMap<ImportUserDto, User>();
            CreateMap<User, ExportUserDto>()
                .ForMember(d => d.SoldProducts,
                    opt => opt.MapFrom(s => s.ProductsSold));

            //Product
            CreateMap<ImportProductDto, Product>();
            CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.Buyer, opt =>
                    opt.MapFrom(s =>
                        s.Buyer == null || s.Buyer.FirstName == null
                            ? null
                            : $"{s.Buyer.FirstName} {s.Buyer.LastName}"));
            CreateMap<Product, ExportSoldProductDto>();


            //Category
            CreateMap<ImportCategoryDto, Category>()
                .ForMember(d => d.Name, opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));

            //CategoryProduct
            CreateMap<ImportCategoryProductDto, CategoryProduct>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
