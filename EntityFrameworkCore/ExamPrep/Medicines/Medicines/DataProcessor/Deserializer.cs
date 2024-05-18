using Medicines.Common;
using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using Medicines.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace Medicines.DataProcessor
{
    using Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);
            var validPatients = new HashSet<Patient>();
            var availableMedicineIds = context.Medicines.Select(m => m.Id).ToArray();
            StringBuilder sb = new StringBuilder();

            foreach (var patientDto in patientDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender
                };


                foreach (var medicineId in patientDto.Medicines)
                {
                    if (!availableMedicineIds.Contains(medicineId)
                        || patient.PatientsMedicines.Any(pm => pm.MedicineId == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine pm = new PatientMedicine()
                    {
                        MedicineId = medicineId
                    };

                    patient.PatientsMedicines.Add(pm);
                }

                validPatients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName,
                    patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(validPatients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            string rootName = "Pharmacies";
            var pharmacyDtos = XmlHelper.Deserialize<ImportPharmacyDto[]>(xmlString, rootName);
            StringBuilder sb = new StringBuilder();
            var validPharmacies = new HashSet<Pharmacy>();

            foreach (var pharmacyDto in pharmacyDtos)
            {
                if (!IsValid(pharmacyDto) ||
                    !bool.TryParse(pharmacyDto.IsNonStop, out bool result))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    IsNonStop = result,
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber
                };

                foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (DateTime.ParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                        <= DateTime.ParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                        || pharmacy.Medicines.Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        Category = (Category)medicineDto.Category,
                        Name = medicineDto.Name,
                        Price = (decimal)medicineDto.Price,
                        ProductionDate = DateTime.ParseExact(medicineDto.ProductionDate, "yyyy-MM-dd",
                            CultureInfo.InvariantCulture),
                        ExpiryDate = DateTime.ParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd",
                            CultureInfo.InvariantCulture),
                        Producer = medicineDto.Producer
                    };

                    pharmacy.Medicines.Add(medicine);
                }

                validPharmacies.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(validPharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
