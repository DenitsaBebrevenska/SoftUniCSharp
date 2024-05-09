using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<ImportSupplierDto, Supplier>();
            CreateMap<ImportCustomerDto, Customer>();
            CreateMap<Customer, ExportCustomerDto>()
                .ForMember(s => s.BirthDate, opt =>
                    opt.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));
            CreateMap<ImportSaleDto, Sale>();
        }
    }
}
