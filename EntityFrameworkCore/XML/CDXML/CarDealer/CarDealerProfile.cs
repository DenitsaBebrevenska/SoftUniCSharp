using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            CreateMap<ImportSupplierDto, Supplier>();
            CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(d => d.PartsCount, opt
                    => opt.MapFrom(s => s.Parts.Count));

            //Part
            CreateMap<ImportPartDto, Part>();


            //Car
            CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.PartIds, opt => opt.DoNotValidate());
            CreateMap<Car, ExportCarDto>();
            CreateMap<Car, ExportBmwCarDto>();
            CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts, opt =>
                    opt.MapFrom(s => s.PartsCars
                        .Select(pc => new ExportPartDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(p => p.Price)));

            //Customer
            CreateMap<ImportCustomerDto, Customer>();


            //Sale
            CreateMap<ImportSaleDto, Sale>();

        }
    }
}
