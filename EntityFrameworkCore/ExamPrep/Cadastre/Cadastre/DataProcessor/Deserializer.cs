using AutoMapper;
using Cadastre.Common;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using System.Globalization;
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
            string rootName = "Districts";
            var districtsDtos = XmlHelper.Deserialize<ImportDistrictDto[]>(xmlDocument, rootName);

            var existingDistrictNames = dbContext.Districts
                .Select(d => d.Name)
                .ToArray();

            var existingPropertyIdentifiers = dbContext.Properties
                .Select(p => p.PropertyIdentifier)
                .ToArray();

            var existingPropertyAddresses = dbContext.Properties
                .Select(p => p.Address)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var districts = new HashSet<District>();

            foreach (var districtDto in districtsDtos)
            {
                if (!IsValid(districtDto)
                    || existingDistrictNames.Any(d => d == districtDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                District district = new District()
                {
                    Name = districtDto.Name,
                    PostalCode = districtDto.PostalCode
                };

                foreach (var propertyDto in districtDto.Properties)
                {
                    if (!IsValid(propertyDto)
                        || existingPropertyIdentifiers.Any(pi => pi == propertyDto.PropertyIdentifier)
                        || district.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier)
                        || existingPropertyAddresses.Any(pi => pi == propertyDto.Address)
                        || district.Properties.Any(p => p.Address == propertyDto.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Property property = new Property()
                    {
                        PropertyIdentifier = propertyDto.PropertyIdentifier,
                        Area = propertyDto.Area,
                        Details = propertyDto.Details,
                        Address = propertyDto.Address,
                        DateOfAcquisition = DateTime.ParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy",
                            CultureInfo.InvariantCulture)
                    };

                    district.Properties.Add(property);
                }

                districts.Add(district);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }

            dbContext.Districts.AddRange();
            dbContext.SaveChanges();

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
