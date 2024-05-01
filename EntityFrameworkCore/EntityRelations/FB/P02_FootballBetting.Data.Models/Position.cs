using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class Position
{
    public int PositionId { get; set; }

    public const int PositionNameLength = 20;
    [MaxLength(ValidationConstraints.PositionNameLength)]
    public string Name { get; set; }
}
