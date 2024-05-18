using Cadastre.Common;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace Cadastre.DataProcessor
{
    using Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

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
                    PostalCode = districtDto.PostalCode,
                    Region = Enum.Parse<Region>(districtDto.Region)
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

            dbContext.Districts.AddRange(districts);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var citizenDtos = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);
            var validCitizens = new HashSet<Citizen>();
            var existingPropertyIds = dbContext.Properties
                .Select(p => p.Id)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var citizenDto in citizenDtos)
            {
                if (!IsValid(citizenDto)
                    || !Enum.TryParse(typeof(MaritalStatus), citizenDto.MaritalStatus, true, out object result))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Citizen citizen = new Citizen()
                {
                    FirstName = citizenDto.FirstName,
                    LastName = citizenDto.LastName,
                    BirthDate = DateTime.ParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    MaritalStatus = (MaritalStatus)result
                };

                foreach (int propertyId in citizenDto.Properties.Distinct())
                {
                    if (existingPropertyIds.All(p => p != propertyId))
                    {
                        continue;
                    }

                    PropertyCitizen pc = new PropertyCitizen()
                    {
                        Citizen = citizen,
                        PropertyId = propertyId
                    };


                    citizen.PropertiesCitizens.Add(pc);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName,
                    citizen.PropertiesCitizens.Count));
                validCitizens.Add(citizen);
            }

            dbContext.Citizens.AddRange(validCitizens);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
