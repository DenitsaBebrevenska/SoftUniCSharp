﻿using Footballers.Common;
using Footballers.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models;
public class Footballer
{
    public int Id { get; set; }

    [MaxLength(TableConstraints.FootballerNameMaxLength)]
    public string Name { get; set; } = null!;

    public DateTime ContractStartDate { get; set; }

    public DateTime ContractEndDate { get; set; }

    public PositionType PositionType { get; set; }

    public BestSkillType BestSkillType { get; set; }

    public int CoachId { get; set; }

    public virtual Coach Coach { get; set; } = null!;

    public virtual ICollection<TeamFootballer> TeamsFootballers { get; set; } = new HashSet<TeamFootballer>();
}
