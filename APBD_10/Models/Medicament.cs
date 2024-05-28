﻿namespace APBD_10.Models;

public partial class Medicament
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    
    public virtual List<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}
