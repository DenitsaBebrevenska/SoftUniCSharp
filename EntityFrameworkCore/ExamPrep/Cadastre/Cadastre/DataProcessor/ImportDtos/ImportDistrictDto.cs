﻿using Cadastre.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class ImportDistrictDto
{
    [XmlAttribute("Region")]
    [Required]
    public string Region { get; set; } = null!;

    [XmlElement("Name")]
    [StringLength(TableConstraints.DistrictNameMaxLength, MinimumLength = TableConstraints.DistrictNameMinLength)]
    [Required]
    public string Name { get; set; } = null!;

    [XmlElement("PostalCode")]
    [StringLength(TableConstraints.DistrictPostalCodeLength, MinimumLength = TableConstraints.DistrictPostalCodeLength)]
    [RegularExpression(TableConstraints.DistrictPostalCodeRegex)]
    [Required]
    public string PostalCode { get; set; } = null!;

    [XmlArray("Properties")]
    public ImportPropertyDto[] Properties { get; set; } = null!;
}
