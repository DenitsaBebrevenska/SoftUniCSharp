using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data;
public class HospitalContext : DbContext
{
    public HospitalContext()
    {

    }

    public HospitalContext(DbContextOptions options)
    : base(options)
    {

    }

    public DbSet<Diagnose> Diagnoses { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Visitation> Visitations { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

    //public DbSet<Doctor> Doctor {get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User));
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //defining complex key for PatientMedicament
        modelBuilder.Entity<PatientMedicament>(entity =>
        {
            entity.HasKey(pk => new { pk.PatientId, pk.MedicamentId });
        });

    }
}
