using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using System.Globalization;

namespace Cadastre
{
    using AutoMapper;

    // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE OR RENAME THIS CLASS
    public class CadastreProfile : Profile
    {
        public CadastreProfile()
        {
            CreateMap<ImportDistrictDto, District>();
            CreateMap<ImportPropertyDto, Property>()
                .ForMember(d => d.DateOfAcquisition, opt =>
                    opt.MapFrom(s => DateTime.ParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture));
        }
    }
}
