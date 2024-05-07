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
            CreateMap<User, ExportUserSoldProductDto>()
                .ForMember(d => d.FirstName,
                    opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName,
                    opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.SoldProducts,
                    opt => opt.MapFrom(s => s.ProductsSold
                        .Select(p => new ExportSoldProductDto
                        {
                            Name = p.Name,
                            Price = p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })));


            //Product
            CreateMap<ImportProductDto, Product>();
            CreateMap<Product, ExportProductRangeDto>()
                .ForMember(d => d.ProductName,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(s => s.ProductPrice,
                    opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.SellerName,
                    opt => opt.MapFrom(d => $"{d.Seller.FirstName} {d.Seller.LastName}"));

            //Category
            CreateMap<ImportCategoryDto, Category>();

            //CategoryProduct
            CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
