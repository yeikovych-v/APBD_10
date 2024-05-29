using APBD_10.Models;

namespace APBD_10.Dto;

public class PrescriptionEntryDto
{
    public PatientDto PatientDto { get; set; }
    public List<MedicamentDto> MedicamentDtos { get; set; }
    public PrescriptionEntryDoctorDto PrescriptionEntryDoctorDto { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DueDate { get; set; }
    
}