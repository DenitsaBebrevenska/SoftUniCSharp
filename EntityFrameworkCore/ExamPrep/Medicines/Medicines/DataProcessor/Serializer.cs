using Medicines.Common;
using Medicines.DataProcessor.ExportDtos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace Medicines.DataProcessor
{
    using Data;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            //todo results are not ordered and the query fails to translate 


            DateTime latestDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var patients = context.Patients
                .Where(p => p.PatientsMedicines
                    .Any(pm => pm.Medicine.ProductionDate > latestDate))
                .ToArray()
                .Select(p => new ExportPatientDto()
                {
                    Gender = p.Gender.ToString(),
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines
                        .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                        .ThenBy(pm => pm.Medicine.Price)
                        .Select(pm => new ExportMedicineDto()
                        {
                            Category = pm.Medicine.Category.ToString(),
                            Name = pm.Medicine.Name,
                            Price = pm.Medicine.Price.ToString("F2"),
                            Producer = pm.Medicine.Producer,
                            BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        })
                        .ToArray()
                })
                .OrderByDescending(p => p.Medicines)
                .ThenBy(p => p.Name)
                .ToArray();


            string rootName = "Patients";
            return XmlHelper.Serialize(patients, rootName);
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
