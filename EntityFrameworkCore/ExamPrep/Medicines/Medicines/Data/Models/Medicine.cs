using Medicines.Common;
using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models;
public class Medicine
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public Category Category { get; set; }

    public DateTime ProductionDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    [MaxLength(TableConstraints.MedicineProducerMaxLength)]
    public string Producer { get; set; } = null!;

    public int PharmacyId { get; set; }

    public virtual Pharmacy Pharmacy { get; set; } = null!;

    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
}
