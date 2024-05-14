using AutoMapper;
using Cadastre.Common;
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
            return default;
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
