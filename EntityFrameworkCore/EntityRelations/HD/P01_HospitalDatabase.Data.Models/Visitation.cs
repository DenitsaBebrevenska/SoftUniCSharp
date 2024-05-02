using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models;
public class Visitation
{
    public int VisitationId { get; set; }

    public DateTime Date { get; set; }

    [MaxLength(ValidationConstraints.VisitationCommentsLength)]
    public string Comments { get; set; }

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; }

    //[ForeignKey(nameof(Doctor))] second task
    //public int DoctorId { get; set; }
    //public virtual Doctor Doctor { get; set; }
}
