namespace APBD_10.Dto;

public class PatientDisplayDto
{
    public PatientDto PatientDto { get; set; }
    public List<PrescriptionDto> Prescriptions { get; set; }
}