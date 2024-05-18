using Medicines.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos;
public class ImportPatientDto
{
    //"FullName": "Ivan Petrov",
    // "AgeGroup": "1",
    // "Gender": "0",
    // "Medicines": [
    //   15,
    //   23
    // ]


    [JsonProperty("FullName")]
    [StringLength(TableConstraints.PatientNameMaxLength, MinimumLength = TableConstraints.PatientNameMinLength)]
    [Required]
    public string FullName { get; set; } = null!;

    [JsonProperty("AgeGroup")]
    [Range((int)Data.Models.Enums.AgeGroup.Child, (int)Data.Models.Enums.AgeGroup.Senior)]
    [Required]
    public int AgeGroup { get; set; }

    [JsonProperty("Gender")]
    [Range((int)Data.Models.Enums.Gender.Male, (int)Data.Models.Enums.Gender.Female)]
    [Required]
    public int Gender { get; set; }

    [JsonProperty("Medicines")]
    [Required]
    public int[] Medicines { get; set; } = null!;

}
