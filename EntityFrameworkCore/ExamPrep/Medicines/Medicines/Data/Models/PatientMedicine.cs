﻿namespace Medicines.Data.Models;
public class PatientMedicine
{
    public int PatientId { get; set; }

    public virtual Patient Patient { get; set; }

    public int MedicineId { get; set; }

    public virtual Medicine Medicine { get; set; }
}
