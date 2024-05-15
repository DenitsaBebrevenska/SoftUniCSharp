using AutoMapper;
using Cadastre.Common;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using System.Text;

namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        private static IMapper InitializeMapper()
            => new Mapper(new MapperConfiguration(cfg =>
                cfg.AddProfile(new CadastreProfile())));


        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var mapper = InitializeMapper();
            string rootName = "Districts";
            var districtDtos = XmlHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, rootName);
            StringBuilder sb = new StringBuilder();

            var districts = new HashSet<District>();

            foreach (var districtDto in districtDtos)
            {
                if (!IsValid(districtDto)
                    || dbContext.Districts.Any(d => d.Name == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District district = mapper.Map<District>(districtDto);

                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValid(propertyDto)
                        || district.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || district.Properties.Any(p => p.Address == propertyDto.Address)
                        || dbContext.Properties.Any(p => p.Address == propertyDto.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        Property propertyToRemove = district.Properties.FirstOrDefault(p =>
                            p.PropertyIdentifier == propertyDto.PropertyIdentifier);
                        district.Properties.Remove(propertyToRemove);
                        continue;
                    }

                    district.Properties.Add(mapper.Map<Property>(propertyDto));
                }

                districts.Add(district);

                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }

            //dbContext.Districts.AddRange(districts);
            //dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
