using APBD_10.Dto;

namespace APBD_10.Models;

public class OneFileModels
{
    public partial class Patient
    {
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
    
        public virtual List<Prescription> Prescriptions { get; set; }

        public Patient(OneFileDto.PatientDto dto)
        {
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            IdPatient = dto.IdPatient;
            BirthDate = dto.BirthDate;
        }
    
        public Patient()
        {
        }
    }
    
    public partial class Prescription
    {
        public int IdPrescription { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual List<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
    
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }
    
        public virtual Medicament Medicament { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
    
    public partial class Medicament
    {
        public Medicament(OneFileDto.MedicamentDto dto)
        {
            IdMedicament = dto.IdMedicament;
            Name = dto.Name;
            Description = dto.Description;
            Type = dto.Type;
        }

        public Medicament()
        {
        }

        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    
        public virtual List<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    }
    
    public partial class Doctor
    {
        public Doctor(OneFileDto.PrescriptionEntryDoctorDto doc)
        {
            IdDoctor = doc.IdDoctor;
            FirstName = doc.FirstName;
            LastName = doc.LastName;
            Email = doc.Email;
        }

        public Doctor()
        {
        }

        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    
        public virtual List<Prescription> Prescriptions { get; set; }
    }
}