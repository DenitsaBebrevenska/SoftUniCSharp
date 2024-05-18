using Medicines.Common;
using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models;
public class Patient
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.PatientNameMaxLength)]
    public string FullName { get; set; } = null!;

    public AgeGroup AgeGroup { get; set; }

    public Gender Gender { get; set; }

    public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
}
