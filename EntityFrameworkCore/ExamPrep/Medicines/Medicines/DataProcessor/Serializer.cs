using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Medicines.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            throw new NotImplementedException();
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m => (int)m.Category == medicineCategory && m.Pharmacy.IsNonStop)
                .AsNoTracking()
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        m.Pharmacy.Name,
                        m.Pharmacy.PhoneNumber
                    }
                })
                .ToArray();

            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }
    }
}
