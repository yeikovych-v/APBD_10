using APBD_10.Models;

namespace APBD_10.Dto;

public class PrescriptionDto
{
    public PrescriptionDto(Prescription prescription)
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