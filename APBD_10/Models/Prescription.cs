namespace APBD_10.Models;

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