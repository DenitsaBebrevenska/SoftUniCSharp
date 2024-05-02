using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;
public class Doctor
{
    public int DoctorId { get; set; }

    [MaxLength(ValidationConstraints.DoctorNameLength)]
    public string Name { get; set; }

    [MaxLength(ValidationConstraints.DoctorSpecialtyLength)]
    public string Specialty { get; set; }

    public virtual ICollection<Visitation> Visitations { get; set; }
}
