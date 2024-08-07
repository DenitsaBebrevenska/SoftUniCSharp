﻿using Footballers.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto;

[XmlType("Footballer")]
public class ImportFootballerDto
{
    [Required]
    [XmlElement("Name")]
    [StringLength(TableConstraints.FootballerNameMaxLength, MinimumLength = TableConstraints.FootballerNameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("ContractStartDate")]
    public string ContractStartDate { get; set; } = null!;

    [Required]
    [XmlElement("ContractEndDate")]
    public string ContractEndDate { get; set; } = null!;

    [Required]
    [XmlElement("BestSkillType")]
    public int BestSkillType { get; set; }

    [Required]
    [XmlElement("PositionType")]
    public int PositionType { get; set; }


}
