namespace APBD_10.Models;

public partial class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    
    public virtual List<Prescription> Prescriptions { get; set; }
}