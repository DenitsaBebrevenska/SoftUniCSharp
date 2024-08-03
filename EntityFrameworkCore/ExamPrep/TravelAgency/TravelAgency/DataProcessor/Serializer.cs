using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TravelAgency.Common;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guidesAndPackages = context.Guides
                .AsNoTracking()
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new ExportGuideDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Select(tpg => new ExportTourPackageDto()
                        {
                            Name = tpg.TourPackage.PackageName,
                            Description = tpg.TourPackage.Description,
                            Price = tpg.TourPackage.Price,
                        })
                        .OrderByDescending(tp => tp.Price)
                        .ThenBy(tp => tp.Name)
                        .ToArray()
                })
                .OrderByDescending(g => g.TourPackages.Length)
                .ThenBy(g => g.FullName)
                .ToArray();

            string rootName = "Guides";
            return XmlHelper.Serialize(guidesAndPackages, rootName);
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            string package = "Horse Riding Tour";

            var customersAndPackages = context.Customers
                .Include(c => c.Bookings)
                .ThenInclude(b => b.TourPackage)
                .ToArray()
                .Where(c => c.Bookings
                    .Any(b => b.TourPackage.PackageName == package))
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == package)
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .OrderBy(b => b.Date)
                        .ToArray()
                })
                .OrderByDescending(c => c.Bookings.Length)
                .ThenBy(c => c.FullName);




            return JsonConvert.SerializeObject(customersAndPackages, Formatting.Indented);
        }
    }
}
