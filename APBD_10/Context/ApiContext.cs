using APBD_10.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Context;

public partial class ApiContext : DbContext
{
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public ApiContext()
    {
    }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=APBD_10;User=sa;Password=fY0urP@sswor_Policy;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(d => d.IdDoctor);
            entity.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(d => d.LastName).IsRequired().HasMaxLength(100);
            entity.Property(d => d.Email).IsRequired().HasMaxLength(100);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(p => p.IdPatient);
            entity.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            entity.Property(p => p.BirthDate).IsRequired();
        });

        modelBuilder.Entity<Medicament>(entity =>
        {
            entity.HasKey(m => m.IdMedicament);
            entity.Property(m => m.Name).IsRequired().HasMaxLength(100);
            entity.Property(m => m.Description).HasMaxLength(100);
            entity.Property(m => m.Type).HasMaxLength(100);
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(p => p.IdPrescription);
            entity.Property(p => p.Date).IsRequired();
            entity.Property(p => p.DueDate).IsRequired();

            entity.HasOne(p => p.Patient)
                .WithMany(pat => pat.Prescriptions)
                .HasForeignKey(p => p.IdPatient);

            entity.HasOne(p => p.Doctor)
                .WithMany()
                .HasForeignKey(p => p.IdDoctor);
        });

        modelBuilder.Entity<PrescriptionMedicament>(entity =>
        {
            entity.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

            entity.Property(pm => pm.Dose).IsRequired();
            entity.Property(pm => pm.Details).HasMaxLength(100);

            entity.HasOne(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdMedicament);

            entity.HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdPrescription);
        });
    }
}