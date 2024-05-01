using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace P02_FootballBetting.Data.Models;
public class Color
{
    public int ColorId { get; set; }

    [MaxLength(ValidationConstraints.ColorNameLength)]
    public string Name { get; set; }
}
