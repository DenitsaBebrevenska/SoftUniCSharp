using System.ComponentModel.DataAnnotations;
using TravelAgency.Common;

namespace TravelAgency.Data.Models;
public class Customer
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.CustomerNameMaxLength)]
    public string FullName { get; set; } = null!;

    [MaxLength(TableConstraints.CustomerEmailMaxLength)]
    public string Email { get; set; } = null!;

    [MaxLength(TableConstraints.CustomerPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}
