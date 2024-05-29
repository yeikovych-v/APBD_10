using APBD_10.Dto;

namespace APBD_10.Models;

public partial class Doctor
{
    public Doctor(PrescriptionEntryDoctorDto doc)
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