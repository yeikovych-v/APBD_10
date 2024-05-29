using APBD_10.Dto;

namespace APBD_10.Models;

public partial class Medicament
{
    public Medicament(MedicamentDto dto)
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
