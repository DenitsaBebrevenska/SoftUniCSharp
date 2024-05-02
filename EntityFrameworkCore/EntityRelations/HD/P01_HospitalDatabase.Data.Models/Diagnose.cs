using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models;

public class Diagnose
{
    public int DiagnoseId { get; set; }

    [MaxLength(ValidationConstraints.DiagnoseNameLength)]
    public string Name { get; set; }

    [MaxLength(ValidationConstraints.DiagnoseCommentsLength)]
    public string Comments { get; set; }

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; }
}
