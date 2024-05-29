using APBD_10.Models;

namespace APBD_10.Dto;

public class OneFileDto
{
    public class PatientDto
    {
        public PatientDto(OneFileModels.Patient patient)
        {
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            IdPatient = patient.IdPatient;
            BirthDate = patient.BirthDate;
        }

        public PatientDto()
        {
        }

        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
    }
    
    public class PrescriptionDto
    {
        public PrescriptionDto(OneFileModels.Prescription prescription)
        {
            IdPrescription = prescription.IdPrescription;
            Date = prescription.Date;
            DueDate = prescription.DueDate;
        }

        public PrescriptionDto()
        {
        }

        public int IdPrescription { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
        public List<MedicamentDto> Medicaments { get; set; }
        public PatientDisplayDoctorDto Doctor { get; set; }
    }
    
    public class MedicamentDto
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
    
    public class PrescriptionEntryDto
    {
        public PatientDto PatientDto { get; set; }
        public List<MedicamentDto> MedicamentDtos { get; set; }
        public PrescriptionEntryDoctorDto PrescriptionEntryDoctorDto { get; set; }
        public DateOnly Date { get; set; }
        public DateOnly DueDate { get; set; }
    
    }
    
    public class PrescriptionEntryDoctorDto
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    
    public class PatientDisplayDto
    {
        public PatientDto PatientDto { get; set; }
        public List<PrescriptionDto> Prescriptions { get; set; }
    }
    
    public class PatientDisplayDoctorDto
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
    }
}
