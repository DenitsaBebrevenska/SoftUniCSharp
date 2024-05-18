using Medicines.Common;
using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models;
public class Pharmacy
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(TableConstraints.PharmacyPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;

    public bool IsNonStop { get; set; }

    public virtual ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
}
