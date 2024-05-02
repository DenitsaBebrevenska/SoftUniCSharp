using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;
public class Patient
{
    public Patient()
    {
        Visitations = new HashSet<Visitation>();
        Diagnoses = new HashSet<Diagnose>();
        Prescriptions = new HashSet<PatientMedicament>();
    }
    public int PatientId { get; set; }

    [MaxLength(ValidationConstraints.PatientFirstNameLength)]
    public string FirstName { get; set; }

    [MaxLength(ValidationConstraints.PatientLastNameLength)]
    public string LastName { get; set; }

    [MaxLength(ValidationConstraints.PatientAddressLength)]
    public string Address { get; set; }

    [Unicode(false)]
    [MaxLength(ValidationConstraints.PatientEmailLength)]
    public string Email { get; set; }

    public bool HasInsurance { get; set; }

    public virtual ICollection<Visitation> Visitations { get; set; }

    public virtual ICollection<Diagnose> Diagnoses { get; set; }

    public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
}
