using System.ComponentModel.DataAnnotations;
using TravelAgency.Common;

namespace TravelAgency.Data.Models;
public class TourPackage
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.PackageNameMaxLength)]
    public string PackageName { get; set; } = null!;

    [MaxLength(TableConstraints.PackageDescriptionMaxLength)]
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

    public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new HashSet<TourPackageGuide>();
}
