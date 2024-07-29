using System.Text;
using Trucks.Common;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;

namespace Trucks.DataProcessor
{
    using Data;
    using System.ComponentModel.DataAnnotations;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            string rootName = "Despatchers";
            var despatcherDtos = XmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, rootName);
            var validDespatchers = new HashSet<Despatcher>();
            StringBuilder sb = new StringBuilder();

            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto) ||
                    string.IsNullOrEmpty(despatcherDto.Position)) //or whitespace?
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher despatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position
                };

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    int categoryTypeMinValue = Enum.GetValues(typeof(CategoryType)).Cast<int>().Min();
                    int categoryTypeMaxValue = Enum.GetValues(typeof(CategoryType)).Cast<int>().Max();
                    int makeTypeMinValue = Enum.GetValues(typeof(MakeType)).Cast<int>().Min();
                    int makeTypeMaxValue = Enum.GetValues(typeof(MakeType)).Cast<int>().Max();

                    if (!IsValid(truckDto) ||
                        (truckDto.CategoryType < categoryTypeMinValue ||
                         truckDto.CategoryType > categoryTypeMaxValue) ||
                        (truckDto.MakeType < makeTypeMinValue ||
                         truckDto.MakeType > makeTypeMaxValue))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType,
                        Despatcher = despatcher
                    };

                    despatcher.Trucks.Add(truck);
                }

                validDespatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}