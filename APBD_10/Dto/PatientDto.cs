using APBD_10.Models;

namespace APBD_10.Dto;

public class PatientDto
{
    public PatientDto(Patient patient)
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