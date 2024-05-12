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
                .ForMember(d => d.BuyerName, opt =>
                    opt.MapFrom(s =>
                            $"{s.Buyer.FirstName} {s.Buyer.LastName}"));



            //Category
            CreateMap<ImportCategoryDto, Category>()
                .ForMember(d => d.Name, opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Category, ExportCategoryDto>()
                .ForMember(d => d.Count,
                    opt => opt.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice, opt =>
                    opt.MapFrom(s => s.CategoryProducts
                        .Select(cp => cp.Product.Price).Average()))
                .ForMember(d => d.TotalRevenue, opt =>
                    opt.MapFrom(d => d.CategoryProducts
                        .Sum(cp => cp.Product.Price)));

            //CategoryProduct
            CreateMap<ImportCategoryProductDto, CategoryProduct>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
