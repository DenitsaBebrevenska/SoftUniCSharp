using Cadastre.Common;
using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            int minimumYearAcquisition = 2000;

            var properties = dbContext.Properties
                .ToArray()
                .Where(p => p.DateOfAcquisition.Year >= minimumYearAcquisition)
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    p.PropertyIdentifier,
                    p.Area,
                    p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Owners = p.PropertiesCitizens
                        .Select(c => new
                        {
                            c.Citizen.LastName,
                            MaritalStatus = c.Citizen.MaritalStatus.ToString()
                        })
                        .OrderBy(c => c.LastName)
                        .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(properties, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            int minimumArea = 100;
            string rootName = "Properties";
            var properties = dbContext.Properties
                .Where(p => p.Area >= minimumArea)
                .AsNoTracking()
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyDto()
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                })
                .ToArray();

            return XmlHelper.Serialize(properties, rootName);
        }
    }
}
