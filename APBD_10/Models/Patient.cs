using APBD_10.Dto;

namespace APBD_10.Models;

public partial class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    
    public virtual List<Prescription> Prescriptions { get; set; }

    public Patient(PatientDto dto)
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